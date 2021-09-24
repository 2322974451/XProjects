using System;
using System.IO;
using Ionic.Zlib;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{

	public class CNetProcessor : ILuaNetProcess, INetProcess
	{

		public void OnLuaProcessBuffer(NetEvent evt)
		{
			bool flag = this.m_oNetwork.IsOnlyDispacherInLua(this.head.type);
			bool isPtc = this.head.IsPtc;
			if (isPtc)
			{
				bool flag2 = true;
				bool flag3 = this.m_oNetwork.ContainPtc(this.head.type, out flag2) || flag;
				if (flag3)
				{
					bool flag4 = this.RecvStream != null;
					if (flag4)
					{
						XSingleton<XDebug>.singleton.AddGreenLog("ptc new type: ", this.head.type.ToString(), " only: " + flag.ToString(), null, null, null);
						LuaNetNode node = this.m_oNetwork.GetNode(flag2 || flag);
						node.Reset();
						node.isRpc = false;
						node.isOnlyLua = flag;
						node.type = this.head.type;
						bool flag5 = flag2 || flag;
						if (flag5)
						{
							node.SetBuff(this.RecvStream.GetBuffer(), (int)this.RecvStream.Length);
						}
						evt.node = node;
						evt.IsOnlyLua = flag;
					}
				}
			}
			else
			{
				bool flag6 = flag;
				if (flag6)
				{
					LuaNetNode node2 = this.m_oNetwork.GetNode(true);
					node2.isOnlyLua = true;
					node2.isRpc = true;
					node2.type = this.head.type;
					byte[] buffer = this.RecvStream.GetBuffer();
					node2.SetBuff(buffer, (int)this.RecvStream.Length);
					evt.node = node2;
					evt.IsOnlyLua = true;
				}
				else
				{
					LuaNetNode removeRpc = this.m_oNetwork.GetRemoveRpc(this.head.tagID);
					bool flag7 = removeRpc == null;
					if (!flag7)
					{
						XSingleton<XDebug>.singleton.AddGreenLog("rpc new type: " + this.head.type, " only: " + flag.ToString(), null, null, null, null);
						removeRpc.type = this.head.type;
						removeRpc.isRpc = true;
						removeRpc.isOnlyLua = flag;
						bool copyBuffer = removeRpc.copyBuffer;
						if (copyBuffer)
						{
							removeRpc.SetBuff(this.RecvStream.GetBuffer(), (int)this.RecvStream.Length);
						}
						evt.node = removeRpc;
						evt.IsOnlyLua = false;
					}
				}
			}
		}

		public void OnLuaProcess(NetEvent evt)
		{
			LuaNetNode node = evt.node;
			bool flag = node != null;
			if (flag)
			{
				bool isOnlyLua = node.isOnlyLua;
				if (isOnlyLua)
				{
					XSingleton<XUpdater.XUpdater>.singleton.XLuaEngine.hotfixMgr.ProcessOveride(node.type, node.buffer, node.length);
				}
				else
				{
					bool isRpc = node.isRpc;
					if (isRpc)
					{
						bool flag2 = node.resp != null;
						if (flag2)
						{
							node.resp(node.buffer, node.length);
						}
					}
					else
					{
						XSingleton<XUpdater.XUpdater>.singleton.XLuaEngine.hotfixMgr.RegistedPtc(node.type, node.buffer, node.length);
					}
				}
				this.m_oNetwork.ReturnNode(node);
			}
		}

		public CNetProcessor(CNetwork network, INetObserver ob)
		{
			this.m_oNetwork = network;
			this.m_oObserver = ob;
			this.r = new Random(DateTime.Now.Millisecond);
			this.zDecompress = new ZlibStream(this.RecvStream, CompressionMode.Decompress, true);
		}

		public void OnConnect(bool bSuccess)
		{
			bool flag = this.m_oObserver != null;
			if (flag)
			{
				this.m_oObserver.OnConnect(bSuccess);
			}
		}

		public void OnClosed(NetErrCode nErrCode)
		{
			bool flag = this.m_oObserver != null;
			if (flag)
			{
				this.m_oObserver.OnClosed(nErrCode);
			}
		}

		private void ProcessStream(NetEvent evt)
		{
			bool flag = (long)evt.m_oBuffer.Count < 12L;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("head file size error", null, null, null, null, null);
			}
			else
			{
				this.head.Reset();
				this.head.Deserialize(ref evt.m_oBuffer);
				int size = this.head.Size;
				bool isInit = evt.m_oBuffer.IsInit;
				if (isInit)
				{
					bool isCompressed = this.head.IsCompressed;
					if (isCompressed)
					{
						this.zDecompress.Seek(0L, SeekOrigin.Begin);
						this.zDecompress.SetLength(0L);
						this.zDecompress.Write(evt.m_oBuffer.OriginalBuff, evt.m_oBuffer.StartOffset + size, evt.m_nBufferLength - size);
						this.zDecompress.Flush();
						this.RecvStream.Seek(0L, SeekOrigin.Begin);
					}
					else
					{
						this.RecvStream.Seek(0L, SeekOrigin.Begin);
						this.RecvStream.SetLength(0L);
						this.RecvStream.Write(evt.m_oBuffer.OriginalBuff, evt.m_oBuffer.StartOffset + size, evt.m_nBufferLength - size);
						this.RecvStream.Seek(0L, SeekOrigin.Begin);
					}
				}
			}
		}

		private void ProcessDeSerialize(NetEvent evt)
		{
			evt.IsPtc = this.head.IsPtc;
			bool isPtc = this.head.IsPtc;
			if (isPtc)
			{
				Protocol protocolThread = Protocol.GetProtocolThread(this.head.type);
				bool flag = protocolThread == null;
				if (flag)
				{
					bool flag2 = !this.m_oNetwork.ConatainPtc(this.head.type) && !this.m_oNetwork.IsOnlyDispacherInLua(this.head.type);
					if (flag2)
					{
						XSingleton<XDebug>.singleton.AddErrorLog("Ptc Not found: ", this.head.type.ToString(), null, null, null, null);
					}
				}
				else
				{
					try
					{
						bool flag3 = this.RecvStream.Length > 1024L;
						if (flag3)
						{
							XSingleton<XDebug>.singleton.AddWarningLog2("Recv Ptc:{0} to long:{1}b", new object[]
							{
								protocolThread.GetProtoType(),
								this.RecvStream.Length
							});
						}
						protocolThread.ThreadErrCode = EProtocolErrCode.ENoErr;
						protocolThread.DeSerialize(this.RecvStream);
					}
					catch (Exception ex)
					{
						XSingleton<XDebug>.singleton.AddErrorLog2("Ptc {0} deserialize fail: {1} ", new object[]
						{
							this.head.type,
							ex.Message
						});
						bool flag4 = protocolThread != null;
						if (flag4)
						{
							protocolThread.ThreadErrCode = EProtocolErrCode.EDeSerializeErr;
						}
					}
					evt.protocol = protocolThread;
				}
			}
			else
			{
				Rpc removeRpcByTag = Rpc.GetRemoveRpcByTag(this.head.tagID);
				bool flag5 = removeRpcByTag == null;
				if (!flag5)
				{
					try
					{
						bool flag6 = this.RecvStream.Length > 0L;
						if (flag6)
						{
							bool flag7 = this.RecvStream.Length > 1024L;
							if (flag7)
							{
								XSingleton<XDebug>.singleton.AddWarningLog2("Recv Rpc:{0} to long:{1}b", new object[]
								{
									removeRpcByTag.GetRpcType(),
									this.RecvStream.Length
								});
							}
							removeRpcByTag.ThreadErrCode = EProtocolErrCode.ENoErr;
							removeRpcByTag.DeSerialize(this.RecvStream);
						}
						else
						{
							bool isRpcNull = this.head.IsRpcNull;
							if (isRpcNull)
							{
								removeRpcByTag.ThreadErrCode = EProtocolErrCode.ENullProtocol;
							}
							else
							{
								removeRpcByTag.ThreadErrCode = EProtocolErrCode.ENoErr;
								removeRpcByTag.DeSerialize(this.RecvStream);
							}
						}
					}
					catch (Exception ex2)
					{
						XSingleton<XDebug>.singleton.AddErrorLog2("Rpc {0} deserialize fail: {1}", new object[]
						{
							this.head.type,
							ex2.Message
						});
						bool flag8 = removeRpcByTag != null;
						if (flag8)
						{
							removeRpcByTag.ThreadErrCode = EProtocolErrCode.EDeSerializeErr;
						}
					}
					evt.rpc = removeRpcByTag;
				}
			}
		}

		public void OnPrePropress(NetEvent evt)
		{
			this.ProcessStream(evt);
			this.ProcessDeSerialize(evt);
			this.OnLuaProcessBuffer(evt);
		}

		public void OnProcess(NetEvent evt)
		{
			CNetProcessor.m_sCurrentEvent = evt;
			bool flag = evt.protocol != null;
			if (flag)
			{
				bool flag2 = XSingleton<XDebug>.singleton.EnableRecord();
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddPoint(evt.protocol.GetProtoType(), evt.protocol.GetType().Name, (float)evt.m_nBufferLength, 0, XDebug.RecordChannel.ENetwork);
				}
				bool flag3 = !evt.IsOnlyLua;
				if (flag3)
				{
					evt.protocol.Process();
				}
				this.OnLuaProcess(evt);
			}
			else
			{
				bool flag4 = evt.rpc != null;
				if (!flag4)
				{
					this.OnLuaProcess(evt);
					return;
				}
				bool flag5 = XSingleton<XDebug>.singleton.EnableRecord();
				if (flag5)
				{
					XSingleton<XDebug>.singleton.AddPoint(evt.rpc.GetRpcType(), evt.rpc.GetType().Name, (float)evt.m_nBufferLength, 0, XDebug.RecordChannel.ENetwork);
				}
				evt.rpc.replyTick = evt.m_oTime;
				bool flag6 = !evt.IsOnlyLua;
				if (flag6)
				{
					evt.rpc.Process();
				}
				else
				{
					evt.rpc.RemoveTimer();
				}
				this.OnLuaProcess(evt);
			}
			bool flag7 = this.m_oObserver != null;
			if (flag7)
			{
				this.m_oObserver.OnReceive(this.head.type, 0);
			}
		}

		public void OnPostProcess(NetEvent evt)
		{
			bool flag = evt.protocol != null;
			if (flag)
			{
				Protocol.ReturnProtocolThread(evt.protocol);
			}
			CNetProcessor.m_sCurrentEvent = null;
		}

		public static void ManualReturnProtocol()
		{
			bool flag = CNetProcessor.m_sCurrentEvent != null;
			if (flag)
			{
				CNetProcessor.m_sCurrentEvent.ManualReturnProtocol();
			}
		}

		private CNetwork m_oNetwork;

		private INetObserver m_oObserver;

		private Random r;

		public static int MaxBuffSize = 65536;

		private MemoryStream RecvStream = new MemoryStream(65536);

		private ProtocolHead head = new ProtocolHead();

		private ZlibStream zDecompress = null;

		private static NetEvent m_sCurrentEvent = null;
	}
}
