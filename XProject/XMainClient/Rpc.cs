using System;
using System.IO;
using System.Threading;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000ECD RID: 3789
	public abstract class Rpc
	{
		// Token: 0x17003501 RID: 13569
		// (get) Token: 0x0600C8CC RID: 51404 RVA: 0x002CF42C File Offset: 0x002CD62C
		public static bool OnRpcDelay
		{
			get
			{
				return Rpc._is_rpc_delay;
			}
		}

		// Token: 0x17003502 RID: 13570
		// (get) Token: 0x0600C8CD RID: 51405 RVA: 0x002CF444 File Offset: 0x002CD644
		public static bool OnRpcTimeOutClosed
		{
			get
			{
				return Rpc._is_rpc_close_time_out;
			}
		}

		// Token: 0x17003503 RID: 13571
		// (get) Token: 0x0600C8CE RID: 51406 RVA: 0x002CF45C File Offset: 0x002CD65C
		public static float RpcDelayedTime
		{
			get
			{
				return Rpc._rpc_delayed_time;
			}
		}

		// Token: 0x17003504 RID: 13572
		// (get) Token: 0x0600C8CF RID: 51407 RVA: 0x002CF474 File Offset: 0x002CD674
		public static float DelayThreshold
		{
			get
			{
				return Rpc._delayThreshold;
			}
		}

		// Token: 0x17003505 RID: 13573
		// (get) Token: 0x0600C8D0 RID: 51408 RVA: 0x002CF48C File Offset: 0x002CD68C
		// (set) Token: 0x0600C8D1 RID: 51409 RVA: 0x002CF4A4 File Offset: 0x002CD6A4
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

		// Token: 0x0600C8D2 RID: 51410 RVA: 0x002CF4B0 File Offset: 0x002CD6B0
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

		// Token: 0x0600C8D3 RID: 51411 RVA: 0x002CF590 File Offset: 0x002CD790
		public virtual uint GetRpcType()
		{
			return 0U;
		}

		// Token: 0x0600C8D4 RID: 51412 RVA: 0x002CF5A4 File Offset: 0x002CD7A4
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

		// Token: 0x0600C8D5 RID: 51413
		public abstract void Serialize(MemoryStream stream);

		// Token: 0x0600C8D6 RID: 51414
		public abstract void DeSerialize(MemoryStream stream);

		// Token: 0x0600C8D7 RID: 51415 RVA: 0x002CF61C File Offset: 0x002CD81C
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

		// Token: 0x17003506 RID: 13574
		// (get) Token: 0x0600C8D8 RID: 51416 RVA: 0x002CF664 File Offset: 0x002CD864
		// (set) Token: 0x0600C8D9 RID: 51417 RVA: 0x002CF67C File Offset: 0x002CD87C
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

		// Token: 0x17003507 RID: 13575
		// (get) Token: 0x0600C8DA RID: 51418 RVA: 0x002CF688 File Offset: 0x002CD888
		public uint TimerToken
		{
			get
			{
				return this.timerToken;
			}
		}

		// Token: 0x0600C8DB RID: 51419 RVA: 0x002CF6A0 File Offset: 0x002CD8A0
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

		// Token: 0x0600C8DC RID: 51420 RVA: 0x002CF6E0 File Offset: 0x002CD8E0
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

		// Token: 0x0600C8DD RID: 51421 RVA: 0x002CF760 File Offset: 0x002CD960
		public void SetTimeOut()
		{
			bool flag = this._timeCb == null;
			if (flag)
			{
				this._timeCb = new XTimerMgr.ElapsedEventHandler(this.TimerCallback);
			}
			this.timerToken = XSingleton<XTimerMgr>.singleton.SetGlobalTimer(this.timeout, this._timeCb, null);
		}

		// Token: 0x0600C8DE RID: 51422 RVA: 0x002CF7AA File Offset: 0x002CD9AA
		public void CallTimeOut()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.timerToken);
			this.OnTimeout(null);
		}

		// Token: 0x0600C8DF RID: 51423 RVA: 0x002CF7C8 File Offset: 0x002CD9C8
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

		// Token: 0x0600C8E0 RID: 51424 RVA: 0x002CF842 File Offset: 0x002CDA42
		public virtual void Process()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.timerToken);
		}

		// Token: 0x0600C8E1 RID: 51425 RVA: 0x002CF842 File Offset: 0x002CDA42
		public void RemoveTimer()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.timerToken);
		}

		// Token: 0x0600C8E2 RID: 51426
		public abstract void OnTimeout(object args);

		// Token: 0x0600C8E3 RID: 51427 RVA: 0x002CF858 File Offset: 0x002CDA58
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

		// Token: 0x0600C8E4 RID: 51428 RVA: 0x002CF894 File Offset: 0x002CDA94
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

		// Token: 0x0600C8E5 RID: 51429 RVA: 0x002CF8E4 File Offset: 0x002CDAE4
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

		// Token: 0x0600C8E6 RID: 51430 RVA: 0x002CF9D8 File Offset: 0x002CDBD8
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

		// Token: 0x040058C5 RID: 22725
		private static readonly float _delayThreshold = 1f;

		// Token: 0x040058C6 RID: 22726
		private static readonly float _timeout_close_Threshold = 15f;

		// Token: 0x040058C7 RID: 22727
		private static bool _is_rpc_delay = false;

		// Token: 0x040058C8 RID: 22728
		private static bool _is_rpc_close_time_out = false;

		// Token: 0x040058C9 RID: 22729
		private static float _rpc_delayed_time = 0f;

		// Token: 0x040058CA RID: 22730
		public static uint sMaxTagID = 1024U;

		// Token: 0x040058CB RID: 22731
		private static Rpc[] sm_RpcWaitingReplyCache = new Rpc[Rpc.sMaxTagID];

		// Token: 0x040058CC RID: 22732
		private static uint sTagID = 0U;

		// Token: 0x040058CD RID: 22733
		public static string delayRpcName = "";

		// Token: 0x040058CE RID: 22734
		public int SocketID;

		// Token: 0x040058CF RID: 22735
		private float sendTime;

		// Token: 0x040058D0 RID: 22736
		public long replyTick;

		// Token: 0x040058D1 RID: 22737
		private XTimerMgr.ElapsedEventHandler _timeCb = null;

		// Token: 0x040058D2 RID: 22738
		protected EProtocolErrCode m_threadErrCode = EProtocolErrCode.ENoErr;

		// Token: 0x040058D3 RID: 22739
		private uint tagID = 0U;

		// Token: 0x040058D4 RID: 22740
		private uint timerToken = 0U;

		// Token: 0x040058D5 RID: 22741
		private float timeout = Rpc._timeout_close_Threshold - 1f;
	}
}
