using System;
using System.IO;
using System.Threading;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	public abstract class Rpc
	{

		public static bool OnRpcDelay
		{
			get
			{
				return Rpc._is_rpc_delay;
			}
		}

		public static bool OnRpcTimeOutClosed
		{
			get
			{
				return Rpc._is_rpc_close_time_out;
			}
		}

		public static float RpcDelayedTime
		{
			get
			{
				return Rpc._rpc_delayed_time;
			}
		}

		public static float DelayThreshold
		{
			get
			{
				return Rpc._delayThreshold;
			}
		}

		public EProtocolErrCode ThreadErrCode
		{
			get
			{
				return this.m_threadErrCode;
			}
			set
			{
				this.m_threadErrCode = value;
			}
		}

		public Rpc()
		{
			this._timeCb = new XTimerMgr.ElapsedEventHandler(this.TimerCallback);
			uint rpcType = this.GetRpcType();
			if (rpcType <= 10091U)
			{
				if (rpcType != 9179U)
				{
					if (rpcType == 10091U)
					{
						this.timeout = 5f;
					}
				}
				else
				{
					this.timeout = 5f;
				}
			}
			else if (rpcType != 25069U)
			{
				if (rpcType != 28358U)
				{
					if (rpcType == 30514U)
					{
						this.timeout = (float)XServerTimeMgr.SyncTimeOut / 1000f;
					}
				}
				else
				{
					this.timeout = 5f;
				}
			}
			else
			{
				this.timeout = 5f;
			}
		}

		public virtual uint GetRpcType()
		{
			return 0U;
		}

		public void SerializeWithHead(MemoryStream stream)
		{
			long position = stream.Position;
			ProtocolHead sharedHead = ProtocolHead.SharedHead;
			sharedHead.type = this.GetRpcType();
			sharedHead.flag = 3U;
			sharedHead.tagID = this.tagID;
			sharedHead.Serialize(stream);
			this.Serialize(stream);
			long position2 = stream.Position;
			uint value = (uint)(position2 - position - 4L);
			stream.Position = position;
			stream.Write(BitConverter.GetBytes(value), 0, 4);
			stream.Position = position2;
		}

		public abstract void Serialize(MemoryStream stream);

		public abstract void DeSerialize(MemoryStream stream);

		public virtual bool CheckPValid()
		{
			bool flag = this.m_threadErrCode == EProtocolErrCode.EDeSerializeErr;
			bool result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Roc EDeSerializeErr Type:", this.GetRpcType().ToString(), null, null, null, null);
				result = false;
			}
			else
			{
				result = true;
			}
			return result;
		}

		public float Timeout
		{
			get
			{
				return this.timeout;
			}
			set
			{
				this.timeout = value;
			}
		}

		public uint TimerToken
		{
			get
			{
				return this.timerToken;
			}
		}

		public void BeforeSend()
		{
			Rpc.sTagID += 1U;
			bool flag = Rpc.sTagID >= Rpc.sMaxTagID;
			if (flag)
			{
				Rpc.sTagID = 0U;
			}
			this.tagID = Rpc.sTagID;
		}

		public void AfterSend()
		{
			this.sendTime = Time.realtimeSinceStartup;
			Monitor.Enter(Rpc.sm_RpcWaitingReplyCache);
			bool flag = (ulong)this.tagID < (ulong)((long)Rpc.sm_RpcWaitingReplyCache.Length);
			if (flag)
			{
				bool flag2 = Rpc.sm_RpcWaitingReplyCache[(int)this.tagID] != null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("rpc not processed yet", null, null, null, null, null);
				}
				Rpc.sm_RpcWaitingReplyCache[(int)this.tagID] = this;
			}
			Monitor.Exit(Rpc.sm_RpcWaitingReplyCache);
		}

		public void SetTimeOut()
		{
			bool flag = this._timeCb == null;
			if (flag)
			{
				this._timeCb = new XTimerMgr.ElapsedEventHandler(this.TimerCallback);
			}
			this.timerToken = XSingleton<XTimerMgr>.singleton.SetGlobalTimer(this.timeout, this._timeCb, null);
		}

		public void CallTimeOut()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.timerToken);
			this.OnTimeout(null);
		}

		private void TimerCallback(object args)
		{
			Rpc.RemoveRpcByTag(this.tagID);
			this.OnTimeout(args);
			bool flag = this.GetRpcType() != 30514U && this.GetRpcType() != 39595U && XSingleton<XClientNetwork>.singleton.IsConnected();
			if (flag)
			{
				Rpc._is_rpc_close_time_out = true;
				Rpc.delayRpcName = this.ToString();
			}
			XSingleton<XDebug>.singleton.AddWarningLog("RPC TimeOut: ", this.ToString(), null, null, null, null);
		}

		public virtual void Process()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.timerToken);
		}

		public void RemoveTimer()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.timerToken);
		}

		public abstract void OnTimeout(object args);

		public static void RemoveRpcByTag(uint dwTag)
		{
			Monitor.Enter(Rpc.sm_RpcWaitingReplyCache);
			bool flag = (ulong)dwTag < (ulong)((long)Rpc.sm_RpcWaitingReplyCache.Length);
			if (flag)
			{
				Rpc.sm_RpcWaitingReplyCache[(int)dwTag] = null;
			}
			Monitor.Exit(Rpc.sm_RpcWaitingReplyCache);
		}

		public static Rpc GetRemoveRpcByTag(uint dwTag)
		{
			Rpc result = null;
			Monitor.Enter(Rpc.sm_RpcWaitingReplyCache);
			bool flag = (ulong)dwTag < (ulong)((long)Rpc.sm_RpcWaitingReplyCache.Length);
			if (flag)
			{
				result = Rpc.sm_RpcWaitingReplyCache[(int)dwTag];
				Rpc.sm_RpcWaitingReplyCache[(int)dwTag] = null;
			}
			Monitor.Exit(Rpc.sm_RpcWaitingReplyCache);
			return result;
		}

		public static void CheckDelay()
		{
			Rpc._is_rpc_delay = false;
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			Rpc._rpc_delayed_time = 0f;
			Monitor.Enter(Rpc.sm_RpcWaitingReplyCache);
			int i = 0;
			while (i < Rpc.sm_RpcWaitingReplyCache.Length)
			{
				Rpc rpc = Rpc.sm_RpcWaitingReplyCache[i];
				bool flag = rpc != null;
				if (flag)
				{
					bool flag2 = rpc.GetRpcType() == 30514U || rpc.GetRpcType() == 28358U || rpc.GetRpcType() == 45201U || rpc.GetRpcType() == 39595U;
					if (!flag2)
					{
						float num = realtimeSinceStartup - rpc.sendTime;
						bool flag3 = Rpc._rpc_delayed_time < num;
						if (flag3)
						{
							Rpc._rpc_delayed_time = num;
						}
						bool flag4 = num > Rpc._delayThreshold;
						if (flag4)
						{
							Rpc._is_rpc_delay = true;
							Rpc.delayRpcName = rpc.ToString();
							break;
						}
					}
				}
				IL_C3:
				i++;
				continue;
				goto IL_C3;
			}
			Monitor.Exit(Rpc.sm_RpcWaitingReplyCache);
		}

		public static void Close()
		{
			Monitor.Enter(Rpc.sm_RpcWaitingReplyCache);
			for (int i = 0; i < Rpc.sm_RpcWaitingReplyCache.Length; i++)
			{
				Rpc rpc = Rpc.sm_RpcWaitingReplyCache[i];
				bool flag = rpc != null;
				if (flag)
				{
					XSingleton<XTimerMgr>.singleton.KillTimer(rpc.TimerToken);
					rpc.OnTimeout(null);
				}
				Rpc.sm_RpcWaitingReplyCache[i] = null;
			}
			Monitor.Exit(Rpc.sm_RpcWaitingReplyCache);
			Rpc._is_rpc_delay = false;
			Rpc._is_rpc_close_time_out = false;
		}

		private static readonly float _delayThreshold = 1f;

		private static readonly float _timeout_close_Threshold = 15f;

		private static bool _is_rpc_delay = false;

		private static bool _is_rpc_close_time_out = false;

		private static float _rpc_delayed_time = 0f;

		public static uint sMaxTagID = 1024U;

		private static Rpc[] sm_RpcWaitingReplyCache = new Rpc[Rpc.sMaxTagID];

		private static uint sTagID = 0U;

		public static string delayRpcName = "";

		public int SocketID;

		private float sendTime;

		public long replyTick;

		private XTimerMgr.ElapsedEventHandler _timeCb = null;

		protected EProtocolErrCode m_threadErrCode = EProtocolErrCode.ENoErr;

		private uint tagID = 0U;

		private uint timerToken = 0U;

		private float timeout = Rpc._timeout_close_Threshold - 1f;
	}
}
