using System;
using System.Collections.Generic;
using System.Threading;
using XUtliPoolLib;

namespace XMainClient
{

	public class CNetwork : ILuaNetwork, IXInterface
	{

		private bool LuaSend(uint _type, bool isRpc, uint tagID, byte[] _reqBuff)
		{
			bool flag = this.GetSocketState() == SocketState.State_Connected;
			if (flag)
			{
				bool flag2 = this.luaSender == null;
				if (flag2)
				{
					this.luaSender = (this.m_oSender as ILuaNetSender);
				}
				bool flag3 = this.luaSender != null;
				if (flag3)
				{
					return this.luaSender.Send(_type, isRpc, tagID, _reqBuff);
				}
			}
			return false;
		}

		public bool Deprecated { get; set; }

		public void InitLua(int rpcCache)
		{
			CNetwork.sm_RpcWaitingReplyCache = new LuaNetNode[rpcCache];
		}

		public bool LuaRigsterPtc(uint type, bool copyBuffer)
		{
			bool flag = this.m_registedPtcList == null;
			if (flag)
			{
				this.m_registedPtcList = new Dictionary<uint, bool>();
			}
			bool flag2 = !this.m_registedPtcList.ContainsKey(type);
			bool result;
			if (flag2)
			{
				this.m_registedPtcList.Add(type, copyBuffer);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		public void LuaRegistDispacher(List<uint> types)
		{
			bool flag = this.m_onlydispacherInLua == null;
			if (flag)
			{
				this.m_onlydispacherInLua = new List<uint>();
			}
			this.m_onlydispacherInLua = types;
		}

		private void RegisterRPC(uint tag, uint _type, bool copyBuffer, DelLuaRespond _onRes, DelLuaError _onError)
		{
			bool flag = CNetwork.sm_RpcWaitingReplyCache != null;
			if (flag)
			{
				LuaNetNode node = this.GetNode(copyBuffer);
				node.Reset();
				node.isRpc = true;
				node.tagID = CNetwork.sm_luaTagID;
				node.copyBuffer = copyBuffer;
				node.resp = _onRes;
				node.err = _onError;
				Monitor.Enter(CNetwork.sm_RpcWaitingReplyCache);
				CNetwork.sm_RpcWaitingReplyCache[(int)tag] = node;
				Monitor.Exit(CNetwork.sm_RpcWaitingReplyCache);
			}
		}

		public void LuaRigsterRPC(uint _type, bool copyBuffer, DelLuaRespond _onRes, DelLuaError _onError)
		{
			uint rpctag = this.GetRPCTag();
			this.RegisterRPC(rpctag, _type, copyBuffer, _onRes, _onError);
		}

		public bool ConatainPtc(uint type)
		{
			bool flag = this.m_registedPtcList == null;
			return !flag && this.m_registedPtcList.ContainsKey(type);
		}

		public bool ContainPtc(uint type, out bool copyBuffer)
		{
			bool flag = this.m_registedPtcList == null;
			if (flag)
			{
				this.m_registedPtcList = new Dictionary<uint, bool>();
			}
			return this.m_registedPtcList.TryGetValue(type, out copyBuffer);
		}

		public bool IsOnlyDispacherInLua(uint type)
		{
			bool flag = this.m_onlydispacherInLua == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = this.m_onlydispacherInLua.Contains(type);
				result = flag2;
			}
			return result;
		}

		private uint GetRPCTag()
		{
			uint num = CNetwork.sm_luaTagID++ - Rpc.sMaxTagID;
			bool flag = (ulong)num >= (ulong)((long)CNetwork.sm_RpcWaitingReplyCache.Length);
			if (flag)
			{
				CNetwork.sm_luaTagID = Rpc.sMaxTagID;
				num = 0U;
			}
			return num;
		}

		public LuaNetNode GetRemoveRpc(uint tagID)
		{
			tagID -= Rpc.sMaxTagID;
			LuaNetNode result = null;
			bool flag = CNetwork.sm_RpcWaitingReplyCache != null;
			if (flag)
			{
				Monitor.Enter(CNetwork.sm_RpcWaitingReplyCache);
				bool flag2 = tagID >= 0U && (ulong)tagID < (ulong)((long)CNetwork.sm_RpcWaitingReplyCache.Length);
				if (flag2)
				{
					result = CNetwork.sm_RpcWaitingReplyCache[(int)tagID];
					CNetwork.sm_RpcWaitingReplyCache[(int)tagID] = null;
				}
				Monitor.Exit(CNetwork.sm_RpcWaitingReplyCache);
			}
			return result;
		}

		public bool LuaSendPtc(uint _type, byte[] _reqBuff)
		{
			return this.LuaSend(_type, false, 0U, _reqBuff);
		}

		public bool LuaSendRPC(uint _type, byte[] _reqBuff, DelLuaRespond _onRes, DelLuaError _onError)
		{
			bool flag = this.GetSocketState() == SocketState.State_Connected;
			if (flag)
			{
				uint tagID = CNetwork.sm_luaTagID;
				uint rpctag = this.GetRPCTag();
				bool flag2 = this.LuaSend(_type, true, tagID, _reqBuff);
				if (flag2)
				{
					this.RegisterRPC(rpctag, _type, true, _onRes, _onError);
					return true;
				}
			}
			return false;
		}

		private byte[] GetBuffer()
		{
			bool flag = this.m_oLuaBufferCache.Count > 0;
			byte[] result;
			if (flag)
			{
				result = this.m_oLuaBufferCache.Dequeue();
			}
			else
			{
				result = new byte[CNetProcessor.MaxBuffSize];
			}
			return result;
		}

		public LuaNetNode GetNode(bool allocBuffer)
		{
			Monitor.Enter(this.m_oLuaNodeCache);
			bool flag = this.m_oLuaNodeCache.Count > 0;
			LuaNetNode luaNetNode;
			if (flag)
			{
				luaNetNode = this.m_oLuaNodeCache.Dequeue();
			}
			else
			{
				luaNetNode = new LuaNetNode();
			}
			if (allocBuffer)
			{
				luaNetNode.buffer = this.GetBuffer();
			}
			Monitor.Exit(this.m_oLuaNodeCache);
			return luaNetNode;
		}

		public void ReturnNode(LuaNetNode node)
		{
			Monitor.Enter(this.m_oLuaNodeCache);
			this.m_oLuaNodeCache.Enqueue(node);
			bool flag = node.buffer != null;
			if (flag)
			{
				this.m_oLuaBufferCache.Enqueue(node.buffer);
				node.buffer = null;
			}
			Monitor.Exit(this.m_oLuaNodeCache);
		}

		public void LuaClear()
		{
			Monitor.Enter(this.m_oLuaNodeCache);
			this.m_oLuaNodeCache.Clear();
			this.m_oLuaBufferCache.Clear();
			Monitor.Exit(this.m_oLuaNodeCache);
		}

		public static void PrintBytes(byte[] bytes)
		{
			CNetwork.PrintBytes("LUA", bytes);
		}

		public static void PrintBytes(string tag, byte[] bytes)
		{
		}

		public int SendBytes
		{
			get
			{
				return CClientSocket.TotalSendBytes;
			}
		}

		public int RecvBytes
		{
			get
			{
				return CClientSocket.TotalRecvBytes;
			}
		}

		public CNetwork()
		{
			this.m_oSocket = null;
			this.m_oProcess = null;
			this.m_dwSendBuffSize = 0U;
			this.m_dwRecvBuffSize = 0U;
		}

		public bool Init(INetProcess oProc, INetSender oSender, IPacketBreaker oBreaker, uint dwSendBuffSize, uint dwRecvBuffSize)
		{
			this.m_oSender = oSender;
			this.m_oProcess = oProc;
			this.m_oBreaker = oBreaker;
			this.m_dwSendBuffSize = dwSendBuffSize;
			this.m_dwRecvBuffSize = dwRecvBuffSize;
			this.m_oDataQueue = new Queue<NetEvent>();
			this.m_oPreProcessQueue = new Queue<NetEvent>();
			bool bUse3Thread = this.m_bUse3Thread;
			if (bUse3Thread)
			{
				this.m_oPreProcessThread = new Thread(new ThreadStart(this.PreProcess));
				this.m_oPreProcessThread.Start();
			}
			return true;
		}

		public void UnInit()
		{
		}

		public int GetSocketID()
		{
			bool flag = this.m_oSocket == null;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				result = this.m_oSocket.ID;
			}
			return result;
		}

		public bool IsDisconnect()
		{
			return this.GetSocketState() == SocketState.State_Closed;
		}

		public bool IsConnecting()
		{
			return this.GetSocketState() == SocketState.State_Connecting;
		}

		public bool IsConnected()
		{
			return this.GetSocketState() == SocketState.State_Connected;
		}

		public SocketState GetSocketState()
		{
			bool flag = this.m_oSocket == null;
			SocketState result;
			if (flag)
			{
				result = SocketState.State_Closed;
			}
			else
			{
				result = this.m_oSocket.GetState();
			}
			return result;
		}

		public bool Send(Protocol protocol)
		{
			bool flag = this.GetSocketState() == SocketState.State_Connected;
			if (flag)
			{
				bool flag2 = this.m_oSender.Send(protocol);
				if (flag2)
				{
					return true;
				}
			}
			return false;
		}

		public bool Send(Rpc rpc)
		{
			bool flag = this.GetSocketState() == SocketState.State_Connected;
			if (flag)
			{
				bool flag2 = this.m_oSender.Send(rpc);
				if (flag2)
				{
					return true;
				}
			}
			return false;
		}

		public bool Connect(string host, int port)
		{
			XSingleton<XDebug>.singleton.AddLog("connect to ", host, ":", port.ToString(), null, null, XDebugColor.XDebug_None);
			bool flag = this.m_oSocket == null;
			if (flag)
			{
				this.m_oSocket = new CClientSocket();
			}
			bool flag2 = !this.m_oSocket.Init(this.m_dwSendBuffSize, this.m_dwRecvBuffSize, this, this.m_oBreaker);
			bool result;
			if (flag2)
			{
				this.m_oSocket.Close();
				this.m_oProcess.OnConnect(false);
				result = false;
			}
			else
			{
				bool flag3 = this.m_oSocket.Connect(host, port);
				bool flag4 = !flag3;
				if (flag4)
				{
					this.m_oProcess.OnConnect(false);
				}
				result = flag3;
			}
			return result;
		}

		public void Close(NetErrCode err)
		{
			bool flag = this.m_oSocket != null;
			if (flag)
			{
				int id = this.m_oSocket.ID;
				this.m_oSocket.Close();
				this.m_oSocket = null;
				bool flag2 = this.m_oDataQueue.Count > 0;
				if (flag2)
				{
					NetEvent netEvent = this.m_oDataQueue.Dequeue();
					while (netEvent != null)
					{
						CClientSocket.ReturnBuffer(ref netEvent.m_oBuffer);
						XNetEventPool.RecycleNoLock(netEvent);
						bool flag3 = this.m_oDataQueue.Count > 0;
						if (flag3)
						{
							netEvent = this.m_oDataQueue.Dequeue();
						}
						else
						{
							netEvent = null;
						}
					}
					this.m_oDataQueue.Clear();
				}
				bool flag4 = this.m_oPreProcessQueue.Count > 0;
				if (flag4)
				{
					NetEvent netEvent2 = this.m_oPreProcessQueue.Dequeue();
					while (netEvent2 != null)
					{
						CClientSocket.ReturnBuffer(ref netEvent2.m_oBuffer);
						XNetEventPool.RecycleNoLock(netEvent2);
						bool flag5 = this.m_oPreProcessQueue.Count > 0;
						if (flag5)
						{
							netEvent2 = this.m_oPreProcessQueue.Dequeue();
						}
						else
						{
							netEvent2 = null;
						}
					}
					this.m_oPreProcessQueue.Clear();
				}
				this.PushClosedEvent(err, id);
			}
		}

		public bool Send(byte[] buffer)
		{
			bool flag = this.GetSocketState() == SocketState.State_Connected;
			return flag && this.m_oSocket.Send(buffer);
		}

		public bool Send(byte[] buffer, int start, int length)
		{
			bool flag = this.GetSocketState() == SocketState.State_Connected;
			return flag && this.m_oSocket.Send(buffer, start, length);
		}

		public int ProcessMsg()
		{
			bool flag = this.m_oProcess == null;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				int num = 0;
				for (NetEvent netEvent = this.DeQueue(); netEvent != null; netEvent = this.DeQueue())
				{
					switch (netEvent.m_nEvtType)
					{
					case NetEvtType.Event_Connect:
						this.m_oProcess.OnConnect(netEvent.m_bSuccess);
						break;
					case NetEvtType.Event_Closed:
						this.m_oProcess.OnClosed(netEvent.m_nErrCode);
						XSingleton<XDebug>.singleton.AddGreenLog("close socket ", netEvent.m_SocketID.ToString(), " event is processed", null, null, null);
						break;
					case NetEvtType.Event_Receive:
					{
						bool bUse3Thread = this.m_bUse3Thread;
						if (bUse3Thread)
						{
							this.m_oProcess.OnProcess(netEvent);
							this.m_oProcess.OnPostProcess(netEvent);
						}
						else
						{
							this.m_oProcess.OnProcess(netEvent);
							this.m_oProcess.OnPostProcess(netEvent);
						}
						break;
					}
					default:
						XSingleton<XDebug>.singleton.AddErrorLog("null event", null, null, null, null, null);
						break;
					}
					CClientSocket.ReturnBuffer(ref netEvent.m_oBuffer);
					XNetEventPool.Recycle(netEvent);
					num++;
					bool flag2 = num >= this.m_iMaxCountPerFrame;
					if (flag2)
					{
						break;
					}
				}
				result = num;
			}
			return result;
		}

		public void EnQueue(NetEvent evt, bool propress)
		{
			bool flag = evt == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("null event EnQueue", null, null, null, null, null);
			}
			else if (propress)
			{
				Monitor.Enter(this.m_oPreProcessQueue);
				this.m_oPreProcessQueue.Enqueue(evt);
				Monitor.Exit(this.m_oPreProcessQueue);
			}
			else
			{
				Monitor.Enter(this.m_oDataQueue);
				this.m_oDataQueue.Enqueue(evt);
				Monitor.Exit(this.m_oDataQueue);
			}
		}

		private NetEvent DeQueue()
		{
			NetEvent result = null;
			Monitor.Enter(this.m_oDataQueue);
			bool flag = this.m_oDataQueue.Count > 0;
			if (flag)
			{
				result = this.m_oDataQueue.Dequeue();
			}
			Monitor.Exit(this.m_oDataQueue);
			return result;
		}

		public void PushConnectEvent(bool bSuccess)
		{
			NetEvent @event = XNetEventPool.GetEvent();
			@event.m_nEvtType = NetEvtType.Event_Connect;
			@event.m_bSuccess = bSuccess;
			this.EnQueue(@event, false);
		}

		public void PushClosedEvent(NetErrCode nErrCode, int sockid)
		{
			NetEvent @event = XNetEventPool.GetEvent();
			@event.m_nEvtType = NetEvtType.Event_Closed;
			@event.m_nErrCode = nErrCode;
			@event.m_SocketID = sockid;
			this.EnQueue(@event, false);
		}

		public void PushReceiveEvent(ref SmallBuffer<byte> oData, int length)
		{
			NetEvent @event = XNetEventPool.GetEvent();
			@event.m_nEvtType = NetEvtType.Event_Receive;
			@event.m_oBuffer = oData;
			@event.m_nBufferLength = length;
			this.m_oProcess.OnPrePropress(@event);
			this.EnQueue(@event, this.m_bUse3Thread);
		}

		private void InnerPreprocess()
		{
			int i = 0;
			while (i < this.m_iMaxCountPerFrame)
			{
				NetEvent netEvent = null;
				bool flag = false;
				Monitor.Enter(this.m_oPreProcessQueue);
				bool flag2 = this.m_oPreProcessQueue.Count > 0;
				if (flag2)
				{
					netEvent = this.m_oPreProcessQueue.Dequeue();
					flag = true;
				}
				Monitor.Exit(this.m_oPreProcessQueue);
				bool flag3 = !flag;
				if (flag3)
				{
					break;
				}
				i++;
				bool flag4 = netEvent == null;
				if (flag4)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("null event InnerPreprocess", null, null, null, null, null);
				}
				else
				{
					bool flag5 = netEvent.m_nEvtType == NetEvtType.Event_Receive;
					if (flag5)
					{
						this.m_oProcess.OnPrePropress(netEvent);
						this.EnQueue(netEvent, false);
					}
					else
					{
						XSingleton<XDebug>.singleton.AddErrorLog("unknown event", netEvent.m_nEvtType.ToString(), null, null, null, null);
					}
				}
			}
		}

		private void PreProcess()
		{
			for (;;)
			{
				this.InnerPreprocess();
				Thread.Sleep(1);
			}
		}

		public void OnGamePaused(bool pause)
		{
			bool flag = this.m_oSocket != null;
			if (flag)
			{
				if (pause)
				{
					this.m_oSocket.m_bPause = true;
					this.m_oSocket.m_nPauseRecvLen = 0;
				}
				else
				{
					this.m_oSocket.m_bPause = false;
					XSingleton<XDebug>.singleton.AddLog(string.Concat(new object[]
					{
						"PauseRecvLen: ",
						this.m_oSocket.m_nPauseRecvLen,
						",  Max:",
						CClientSocket.PAUSE_RECV_MAX_LEN
					}), null, null, null, null, null, XDebugColor.XDebug_None);
					bool flag2 = this.m_oSocket.m_nPauseRecvLen > CClientSocket.PAUSE_RECV_MAX_LEN;
					if (flag2)
					{
						this.Close(NetErrCode.Net_PauseRecv_Overflow);
					}
				}
			}
		}

		public void Clear()
		{
			XNetEventPool.Clear();
			this.LuaClear();
		}

		private Queue<LuaNetNode> m_oLuaNodeCache = new Queue<LuaNetNode>();

		private Queue<byte[]> m_oLuaBufferCache = new Queue<byte[]>();

		private static LuaNetNode[] sm_RpcWaitingReplyCache = null;

		private static uint sm_luaTagID = Rpc.sMaxTagID;

		private List<uint> m_onlydispacherInLua = null;

		private Dictionary<uint, bool> m_registedPtcList = null;

		private ILuaNetSender luaSender = null;

		private CClientSocket m_oSocket;

		private Queue<NetEvent> m_oPreProcessQueue;

		private bool m_bUse3Thread = false;

		private int m_iMaxCountPerFrame = 50;

		private Thread m_oPreProcessThread;

		private Queue<NetEvent> m_oDataQueue;

		private INetSender m_oSender;

		private INetProcess m_oProcess;

		private IPacketBreaker m_oBreaker;

		private uint m_dwSendBuffSize;

		private uint m_dwRecvBuffSize;
	}
}
