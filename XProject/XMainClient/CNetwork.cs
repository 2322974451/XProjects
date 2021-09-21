using System;
using System.Collections.Generic;
using System.Threading;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B3E RID: 2878
	public class CNetwork : ILuaNetwork, IXInterface
	{
		// Token: 0x0600A832 RID: 43058 RVA: 0x001DFB08 File Offset: 0x001DDD08
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

		// Token: 0x17003021 RID: 12321
		// (get) Token: 0x0600A833 RID: 43059 RVA: 0x001DFB68 File Offset: 0x001DDD68
		// (set) Token: 0x0600A834 RID: 43060 RVA: 0x001DFB70 File Offset: 0x001DDD70
		public bool Deprecated { get; set; }

		// Token: 0x0600A835 RID: 43061 RVA: 0x001DFB79 File Offset: 0x001DDD79
		public void InitLua(int rpcCache)
		{
			CNetwork.sm_RpcWaitingReplyCache = new LuaNetNode[rpcCache];
		}

		// Token: 0x0600A836 RID: 43062 RVA: 0x001DFB88 File Offset: 0x001DDD88
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

		// Token: 0x0600A837 RID: 43063 RVA: 0x001DFBDC File Offset: 0x001DDDDC
		public void LuaRegistDispacher(List<uint> types)
		{
			bool flag = this.m_onlydispacherInLua == null;
			if (flag)
			{
				this.m_onlydispacherInLua = new List<uint>();
			}
			this.m_onlydispacherInLua = types;
		}

		// Token: 0x0600A838 RID: 43064 RVA: 0x001DFC0C File Offset: 0x001DDE0C
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

		// Token: 0x0600A839 RID: 43065 RVA: 0x001DFC80 File Offset: 0x001DDE80
		public void LuaRigsterRPC(uint _type, bool copyBuffer, DelLuaRespond _onRes, DelLuaError _onError)
		{
			uint rpctag = this.GetRPCTag();
			this.RegisterRPC(rpctag, _type, copyBuffer, _onRes, _onError);
		}

		// Token: 0x0600A83A RID: 43066 RVA: 0x001DFCA4 File Offset: 0x001DDEA4
		public bool ConatainPtc(uint type)
		{
			bool flag = this.m_registedPtcList == null;
			return !flag && this.m_registedPtcList.ContainsKey(type);
		}

		// Token: 0x0600A83B RID: 43067 RVA: 0x001DFCD4 File Offset: 0x001DDED4
		public bool ContainPtc(uint type, out bool copyBuffer)
		{
			bool flag = this.m_registedPtcList == null;
			if (flag)
			{
				this.m_registedPtcList = new Dictionary<uint, bool>();
			}
			return this.m_registedPtcList.TryGetValue(type, out copyBuffer);
		}

		// Token: 0x0600A83C RID: 43068 RVA: 0x001DFD0C File Offset: 0x001DDF0C
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

		// Token: 0x0600A83D RID: 43069 RVA: 0x001DFD40 File Offset: 0x001DDF40
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

		// Token: 0x0600A83E RID: 43070 RVA: 0x001DFD88 File Offset: 0x001DDF88
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

		// Token: 0x0600A83F RID: 43071 RVA: 0x001DFDF4 File Offset: 0x001DDFF4
		public bool LuaSendPtc(uint _type, byte[] _reqBuff)
		{
			return this.LuaSend(_type, false, 0U, _reqBuff);
		}

		// Token: 0x0600A840 RID: 43072 RVA: 0x001DFE10 File Offset: 0x001DE010
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

		// Token: 0x0600A841 RID: 43073 RVA: 0x001DFE64 File Offset: 0x001DE064
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

		// Token: 0x0600A842 RID: 43074 RVA: 0x001DFEA4 File Offset: 0x001DE0A4
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

		// Token: 0x0600A843 RID: 43075 RVA: 0x001DFF0C File Offset: 0x001DE10C
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

		// Token: 0x0600A844 RID: 43076 RVA: 0x001DFF67 File Offset: 0x001DE167
		public void LuaClear()
		{
			Monitor.Enter(this.m_oLuaNodeCache);
			this.m_oLuaNodeCache.Clear();
			this.m_oLuaBufferCache.Clear();
			Monitor.Exit(this.m_oLuaNodeCache);
		}

		// Token: 0x0600A845 RID: 43077 RVA: 0x001DFF9A File Offset: 0x001DE19A
		public static void PrintBytes(byte[] bytes)
		{
			CNetwork.PrintBytes("LUA", bytes);
		}

		// Token: 0x0600A846 RID: 43078 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void PrintBytes(string tag, byte[] bytes)
		{
		}

		// Token: 0x17003022 RID: 12322
		// (get) Token: 0x0600A847 RID: 43079 RVA: 0x001DFFAC File Offset: 0x001DE1AC
		public int SendBytes
		{
			get
			{
				return CClientSocket.TotalSendBytes;
			}
		}

		// Token: 0x17003023 RID: 12323
		// (get) Token: 0x0600A848 RID: 43080 RVA: 0x001DFFC4 File Offset: 0x001DE1C4
		public int RecvBytes
		{
			get
			{
				return CClientSocket.TotalRecvBytes;
			}
		}

		// Token: 0x0600A849 RID: 43081 RVA: 0x001DFFDC File Offset: 0x001DE1DC
		public CNetwork()
		{
			this.m_oSocket = null;
			this.m_oProcess = null;
			this.m_dwSendBuffSize = 0U;
			this.m_dwRecvBuffSize = 0U;
		}

		// Token: 0x0600A84A RID: 43082 RVA: 0x001E0048 File Offset: 0x001DE248
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

		// Token: 0x0600A84B RID: 43083 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void UnInit()
		{
		}

		// Token: 0x0600A84C RID: 43084 RVA: 0x001E00C8 File Offset: 0x001DE2C8
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

		// Token: 0x0600A84D RID: 43085 RVA: 0x001E00F8 File Offset: 0x001DE2F8
		public bool IsDisconnect()
		{
			return this.GetSocketState() == SocketState.State_Closed;
		}

		// Token: 0x0600A84E RID: 43086 RVA: 0x001E0114 File Offset: 0x001DE314
		public bool IsConnecting()
		{
			return this.GetSocketState() == SocketState.State_Connecting;
		}

		// Token: 0x0600A84F RID: 43087 RVA: 0x001E0130 File Offset: 0x001DE330
		public bool IsConnected()
		{
			return this.GetSocketState() == SocketState.State_Connected;
		}

		// Token: 0x0600A850 RID: 43088 RVA: 0x001E014C File Offset: 0x001DE34C
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

		// Token: 0x0600A851 RID: 43089 RVA: 0x001E017C File Offset: 0x001DE37C
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

		// Token: 0x0600A852 RID: 43090 RVA: 0x001E01B4 File Offset: 0x001DE3B4
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

		// Token: 0x0600A853 RID: 43091 RVA: 0x001E01EC File Offset: 0x001DE3EC
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

		// Token: 0x0600A854 RID: 43092 RVA: 0x001E02A4 File Offset: 0x001DE4A4
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

		// Token: 0x0600A855 RID: 43093 RVA: 0x001E03D8 File Offset: 0x001DE5D8
		public bool Send(byte[] buffer)
		{
			bool flag = this.GetSocketState() == SocketState.State_Connected;
			return flag && this.m_oSocket.Send(buffer);
		}

		// Token: 0x0600A856 RID: 43094 RVA: 0x001E0408 File Offset: 0x001DE608
		public bool Send(byte[] buffer, int start, int length)
		{
			bool flag = this.GetSocketState() == SocketState.State_Connected;
			return flag && this.m_oSocket.Send(buffer, start, length);
		}

		// Token: 0x0600A857 RID: 43095 RVA: 0x001E043C File Offset: 0x001DE63C
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

		// Token: 0x0600A858 RID: 43096 RVA: 0x001E058C File Offset: 0x001DE78C
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

		// Token: 0x0600A859 RID: 43097 RVA: 0x001E0610 File Offset: 0x001DE810
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

		// Token: 0x0600A85A RID: 43098 RVA: 0x001E0660 File Offset: 0x001DE860
		public void PushConnectEvent(bool bSuccess)
		{
			NetEvent @event = XNetEventPool.GetEvent();
			@event.m_nEvtType = NetEvtType.Event_Connect;
			@event.m_bSuccess = bSuccess;
			this.EnQueue(@event, false);
		}

		// Token: 0x0600A85B RID: 43099 RVA: 0x001E068C File Offset: 0x001DE88C
		public void PushClosedEvent(NetErrCode nErrCode, int sockid)
		{
			NetEvent @event = XNetEventPool.GetEvent();
			@event.m_nEvtType = NetEvtType.Event_Closed;
			@event.m_nErrCode = nErrCode;
			@event.m_SocketID = sockid;
			this.EnQueue(@event, false);
		}

		// Token: 0x0600A85C RID: 43100 RVA: 0x001E06C0 File Offset: 0x001DE8C0
		public void PushReceiveEvent(ref SmallBuffer<byte> oData, int length)
		{
			NetEvent @event = XNetEventPool.GetEvent();
			@event.m_nEvtType = NetEvtType.Event_Receive;
			@event.m_oBuffer = oData;
			@event.m_nBufferLength = length;
			this.m_oProcess.OnPrePropress(@event);
			this.EnQueue(@event, this.m_bUse3Thread);
		}

		// Token: 0x0600A85D RID: 43101 RVA: 0x001E070C File Offset: 0x001DE90C
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

		// Token: 0x0600A85E RID: 43102 RVA: 0x001E07FC File Offset: 0x001DE9FC
		private void PreProcess()
		{
			for (;;)
			{
				this.InnerPreprocess();
				Thread.Sleep(1);
			}
		}

		// Token: 0x0600A85F RID: 43103 RVA: 0x001E0820 File Offset: 0x001DEA20
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

		// Token: 0x0600A860 RID: 43104 RVA: 0x001E08DB File Offset: 0x001DEADB
		public void Clear()
		{
			XNetEventPool.Clear();
			this.LuaClear();
		}

		// Token: 0x04003E59 RID: 15961
		private Queue<LuaNetNode> m_oLuaNodeCache = new Queue<LuaNetNode>();

		// Token: 0x04003E5A RID: 15962
		private Queue<byte[]> m_oLuaBufferCache = new Queue<byte[]>();

		// Token: 0x04003E5B RID: 15963
		private static LuaNetNode[] sm_RpcWaitingReplyCache = null;

		// Token: 0x04003E5C RID: 15964
		private static uint sm_luaTagID = Rpc.sMaxTagID;

		// Token: 0x04003E5D RID: 15965
		private List<uint> m_onlydispacherInLua = null;

		// Token: 0x04003E5E RID: 15966
		private Dictionary<uint, bool> m_registedPtcList = null;

		// Token: 0x04003E5F RID: 15967
		private ILuaNetSender luaSender = null;

		// Token: 0x04003E61 RID: 15969
		private CClientSocket m_oSocket;

		// Token: 0x04003E62 RID: 15970
		private Queue<NetEvent> m_oPreProcessQueue;

		// Token: 0x04003E63 RID: 15971
		private bool m_bUse3Thread = false;

		// Token: 0x04003E64 RID: 15972
		private int m_iMaxCountPerFrame = 50;

		// Token: 0x04003E65 RID: 15973
		private Thread m_oPreProcessThread;

		// Token: 0x04003E66 RID: 15974
		private Queue<NetEvent> m_oDataQueue;

		// Token: 0x04003E67 RID: 15975
		private INetSender m_oSender;

		// Token: 0x04003E68 RID: 15976
		private INetProcess m_oProcess;

		// Token: 0x04003E69 RID: 15977
		private IPacketBreaker m_oBreaker;

		// Token: 0x04003E6A RID: 15978
		private uint m_dwSendBuffSize;

		// Token: 0x04003E6B RID: 15979
		private uint m_dwRecvBuffSize;
	}
}
