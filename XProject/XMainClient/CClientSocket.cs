using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000EAE RID: 3758
	public class CClientSocket
	{
		// Token: 0x0600C83C RID: 51260 RVA: 0x002CD5C0 File Offset: 0x002CB7C0
		public CClientSocket()
		{
			this.m_oSocket = null;
			this.m_nState = SocketState.State_Closed;
			CClientSocket.m_oSendBuff = null;
			CClientSocket.m_oRecvBuff = null;
			this.m_nStartPos = 0;
			this.m_nEndPos = 0;
			this.m_nCurrRecvLen = 0;
			CClientSocket.m_oSendBuff = null;
			this.m_oBreaker = null;
			this.m_nUID = ++CClientSocket.SOCKET_UID;
			this.m_RecvCb = new AsyncCallback(this.RecvCallback);
			this.m_ConnectCb = new AsyncCallback(this.OnConnect);
			this.m_SendCb = new AsyncCallback(this.OnSendCallback);
			bool flag = CClientSocket.m_BufferPool == null;
			if (flag)
			{
				CClientSocket.m_BufferPool = new SmallBufferPool<byte>();
				CClientSocket.m_BufferPool.Init(CClientSocket.blockInit, 1);
			}
		}

		// Token: 0x170034F2 RID: 13554
		// (get) Token: 0x0600C83D RID: 51261 RVA: 0x002CD6B8 File Offset: 0x002CB8B8
		public int ID
		{
			get
			{
				return this.m_nUID;
			}
		}

		// Token: 0x0600C83E RID: 51262 RVA: 0x002CD6D0 File Offset: 0x002CB8D0
		private void GetNetworkType()
		{
			try
			{
				string hostNameOrAddress = XSingleton<XUpdater.XUpdater>.singleton.XPlatform.GetLoginServer("QQ").Substring(0, XSingleton<XUpdater.XUpdater>.singleton.XPlatform.GetLoginServer("QQ").LastIndexOf(':'));
				IPAddress[] hostAddresses = Dns.GetHostAddresses(hostNameOrAddress);
				this.m_NetworkType = hostAddresses[0].AddressFamily;
			}
			catch (Exception ex)
			{
				XSingleton<XDebug>.singleton.AddWarningLog(ex.Message, null, null, null, null, null);
			}
		}

		// Token: 0x0600C83F RID: 51263 RVA: 0x002CD758 File Offset: 0x002CB958
		public bool Init(uint dwSendBuffSize, uint dwRecvBuffSize, CNetwork oNetwork, IPacketBreaker oBreaker)
		{
			this.GetNetworkType();
			try
			{
				this.m_nState = SocketState.State_Closed;
				this.m_oSocket = new Socket(this.m_NetworkType, SocketType.Stream, ProtocolType.Tcp);
				this.m_oSocket.NoDelay = true;
				bool flag = CClientSocket.m_oSendBuff == null;
				if (flag)
				{
					CClientSocket.m_oSendBuff = new byte[dwSendBuffSize];
				}
				bool flag2 = CClientSocket.m_oRecvBuff == null;
				if (flag2)
				{
					CClientSocket.m_oRecvBuff = new byte[dwRecvBuffSize];
				}
				this.m_oSocket.SendBufferSize = CClientSocket.SendBufferSize;
				this.m_oSendState = new CClientSocket.SendState();
				this.m_nStartPos = 0;
				this.m_nEndPos = 0;
				this.m_nCurrRecvLen = 0;
				this.m_oNetwork = oNetwork;
				this.m_oBreaker = oBreaker;
				this.m_oSendState.start = 0;
				this.m_oSendState.len = 0;
			}
			catch (Exception ex)
			{
				XSingleton<XDebug>.singleton.AddWarningLog(ex.Message, "new Socket Error!", null, null, null, null);
				return false;
			}
			return true;
		}

		// Token: 0x0600C840 RID: 51264 RVA: 0x002CD858 File Offset: 0x002CBA58
		public void UnInit()
		{
			this.Close();
		}

		// Token: 0x0600C841 RID: 51265 RVA: 0x002CD864 File Offset: 0x002CBA64
		private void OnConnect(IAsyncResult iar)
		{
			try
			{
				bool flag = this.m_nState == SocketState.State_Closed;
				if (!flag)
				{
					Socket socket = (Socket)iar.AsyncState;
					socket.EndConnect(iar);
					this.SetState(SocketState.State_Connected);
					this.GetNetwork().PushConnectEvent(true);
					socket.BeginReceive(CClientSocket.m_oRecvBuff, this.m_nCurrRecvLen, CClientSocket.m_oRecvBuff.Length - this.m_nCurrRecvLen, SocketFlags.None, this.m_RecvCb, socket);
					this.FindSomethingToSend();
				}
			}
			catch (Exception ex)
			{
				XSingleton<XDebug>.singleton.AddWarningLog(ex.Message, null, null, null, null, null);
				this.SetState(SocketState.State_Closed);
				this.GetNetwork().PushConnectEvent(false);
				this.Close();
			}
		}

		// Token: 0x0600C842 RID: 51266 RVA: 0x002CD928 File Offset: 0x002CBB28
		public bool Connect(string host, int port)
		{
			bool result;
			try
			{
				this.SetState(SocketState.State_Connecting);
				this.m_oSocket.BeginConnect(host, port, this.m_ConnectCb, this.m_oSocket);
				result = true;
			}
			catch (Exception ex)
			{
				XSingleton<XDebug>.singleton.AddWarningLog(ex.Message, null, null, null, null, null);
				result = false;
			}
			return result;
		}

		// Token: 0x0600C843 RID: 51267 RVA: 0x002CD98C File Offset: 0x002CBB8C
		public void Close()
		{
			XSingleton<XDebug>.singleton.AddLog("close socket ", this.m_nUID.ToString(), null, null, null, null, XDebugColor.XDebug_None);
			Rpc.Close();
			this.m_nState = SocketState.State_Closed;
			bool flag = this.m_oSocket == null;
			if (!flag)
			{
				try
				{
					this.m_oSocket.Close();
				}
				catch (Exception ex)
				{
					XSingleton<XDebug>.singleton.AddWarningLog(ex.Message, null, null, null, null, null);
				}
				this.m_oSocket = null;
			}
		}

		// Token: 0x0600C844 RID: 51268 RVA: 0x002CDA1C File Offset: 0x002CBC1C
		public bool Send(byte[] buffer)
		{
			return this.Send(buffer, 0, buffer.Length);
		}

		// Token: 0x0600C845 RID: 51269 RVA: 0x002CDA3C File Offset: 0x002CBC3C
		private void OnSendCallback(IAsyncResult iar)
		{
			try
			{
				bool flag = this.m_nState == SocketState.State_Closed;
				if (!flag)
				{
					CClientSocket.SendState sendState = (CClientSocket.SendState)iar.AsyncState;
					this.m_oSocket.EndSend(iar);
					this.m_nStartPos = (sendState.start + sendState.len) % CClientSocket.m_oSendBuff.Length;
					CClientSocket.TotalSendBytes += sendState.len;
					this.FindSomethingToSend();
				}
			}
			catch (Exception ex)
			{
				XSingleton<XDebug>.singleton.AddWarningLog("OnSendCallback Send Failed: ", ex.Message, null, null, null, null);
				this.GetNetwork().PushClosedEvent(NetErrCode.Net_SysError, this.ID);
				this.Close();
			}
		}

		// Token: 0x0600C846 RID: 51270 RVA: 0x002CDAF8 File Offset: 0x002CBCF8
		private void FindSomethingToSend()
		{
			try
			{
				while (this.m_nEndPos == this.m_nStartPos)
				{
					Thread.Sleep(1);
					bool flag = this.m_oSocket == null;
					if (flag)
					{
						return;
					}
				}
				bool flag2 = this.m_nEndPos > this.m_nStartPos;
				if (flag2)
				{
					this.m_oSendState.start = this.m_nStartPos;
					this.m_oSendState.len = this.m_nEndPos - this.m_nStartPos;
					bool flag3 = this.m_oSendState.len > CClientSocket.MaxSendSize;
					if (flag3)
					{
						this.m_oSendState.len = CClientSocket.MaxSendSize;
					}
					this.m_oSocket.BeginSend(CClientSocket.m_oSendBuff, this.m_oSendState.start, this.m_oSendState.len, SocketFlags.None, this.m_SendCb, this.m_oSendState);
				}
				else
				{
					bool flag4 = this.m_nEndPos < this.m_nStartPos;
					if (flag4)
					{
						this.m_oSendState.start = this.m_nStartPos;
						this.m_oSendState.len = CClientSocket.m_oSendBuff.Length - this.m_nStartPos;
						bool flag5 = this.m_oSendState.len > CClientSocket.MaxSendSize;
						if (flag5)
						{
							this.m_oSendState.len = CClientSocket.MaxSendSize;
						}
						this.m_oSocket.BeginSend(CClientSocket.m_oSendBuff, this.m_oSendState.start, this.m_oSendState.len, SocketFlags.None, this.m_SendCb, this.m_oSendState);
					}
					else
					{
						XSingleton<XDebug>.singleton.AddWarningLog("FindSomethingToSend Send Failed: No data to send error!", null, null, null, null, null);
					}
				}
			}
			catch (Exception ex)
			{
				this.Close();
				this.GetNetwork().PushClosedEvent(NetErrCode.Net_SysError, this.ID);
				XSingleton<XDebug>.singleton.AddWarningLog("FindSomethingToSend Exception Send Failed: ", ex.Message, null, null, null, null);
			}
		}

		// Token: 0x0600C847 RID: 51271 RVA: 0x002CDD04 File Offset: 0x002CBF04
		public bool Send(byte[] buffer, int start, int length)
		{
			bool flag = this.GetState() != SocketState.State_Connected;
			bool result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddLog("state is not connected, can't send!", null, null, null, null, null, XDebugColor.XDebug_None);
				result = false;
			}
			else
			{
				int num = CClientSocket.m_oSendBuff.Length;
				int num2 = this.m_nEndPos + num - this.m_nStartPos;
				int num3 = (num2 >= num) ? (num2 - num) : num2;
				bool flag2 = length + 1 + num3 > num;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddWarningLog("send bytes out of buffer range!", null, null, null, null, null);
					this.Close();
					this.GetNetwork().PushClosedEvent(NetErrCode.Net_SendBuff_Overflow, this.ID);
					result = false;
				}
				else
				{
					bool flag3 = this.m_nEndPos + length >= num;
					if (flag3)
					{
						int num4 = num - this.m_nEndPos;
						int num5 = length - num4;
						Array.Copy(buffer, start, CClientSocket.m_oSendBuff, this.m_nEndPos, num4);
						Array.Copy(buffer, start + num4, CClientSocket.m_oSendBuff, 0, num5);
						this.m_nEndPos = num5;
					}
					else
					{
						Array.Copy(buffer, start, CClientSocket.m_oSendBuff, this.m_nEndPos, length);
						this.m_nEndPos += length;
					}
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0600C848 RID: 51272 RVA: 0x002CDE40 File Offset: 0x002CC040
		public Socket GetSocket()
		{
			return this.m_oSocket;
		}

		// Token: 0x0600C849 RID: 51273 RVA: 0x002CDE58 File Offset: 0x002CC058
		public SocketState GetState()
		{
			return this.m_nState;
		}

		// Token: 0x0600C84A RID: 51274 RVA: 0x002CDE70 File Offset: 0x002CC070
		private void SetState(SocketState nState)
		{
			this.m_nState = nState;
		}

		// Token: 0x0600C84B RID: 51275 RVA: 0x002CDE7C File Offset: 0x002CC07C
		private CNetwork GetNetwork()
		{
			return this.m_oNetwork;
		}

		// Token: 0x0600C84C RID: 51276 RVA: 0x002CDE94 File Offset: 0x002CC094
		public void RecvCallback(IAsyncResult ar)
		{
			try
			{
				bool flag = this.m_nState == SocketState.State_Closed;
				if (!flag)
				{
					Socket socket = (Socket)ar.AsyncState;
					int num = socket.EndReceive(ar);
					bool flag2 = num > 0;
					if (flag2)
					{
						CClientSocket.TotalRecvBytes += num;
						this.m_nCurrRecvLen += num;
						this.DetectPacket();
						bool flag3 = this.m_nCurrRecvLen == CClientSocket.m_oRecvBuff.Length;
						if (flag3)
						{
							XSingleton<XDebug>.singleton.AddWarningLog("RecvCallback error ! m_nCurrRecvLen == m_oRecvBuff.Length", null, null, null, null, null);
						}
						socket.BeginReceive(CClientSocket.m_oRecvBuff, this.m_nCurrRecvLen, CClientSocket.m_oRecvBuff.Length - this.m_nCurrRecvLen, SocketFlags.None, this.m_RecvCb, socket);
					}
					else
					{
						bool flag4 = num == 0;
						if (flag4)
						{
							XSingleton<XDebug>.singleton.AddWarningLog("Close socket normally", null, null, null, null, null);
							this.Close();
							this.GetNetwork().PushClosedEvent(NetErrCode.Net_SysError, this.ID);
						}
						else
						{
							XSingleton<XDebug>.singleton.AddWarningLog("Close socket, recv error!", null, null, null, null, null);
							this.Close();
							this.GetNetwork().PushClosedEvent(NetErrCode.Net_SysError, this.ID);
						}
					}
				}
			}
			catch (ObjectDisposedException)
			{
			}
			catch (SocketException ex)
			{
				XSingleton<XDebug>.singleton.AddWarningLog(ex.Message, null, null, null, null, null);
				this.Close();
				this.GetNetwork().PushClosedEvent(NetErrCode.Net_SysError, this.ID);
			}
			catch (Exception ex2)
			{
				XSingleton<XDebug>.singleton.AddWarningLog(ex2.Message, null, null, null, null, null);
				this.Close();
				this.GetNetwork().PushClosedEvent(NetErrCode.Net_SysError, this.ID);
			}
		}

		// Token: 0x0600C84D RID: 51277 RVA: 0x002CE07C File Offset: 0x002CC27C
		public void DetectPacket()
		{
			int num = 0;
			while (this.m_nCurrRecvLen > 0)
			{
				int num2 = this.m_oBreaker.BreakPacket(CClientSocket.m_oRecvBuff, num, this.m_nCurrRecvLen);
				bool flag = num2 == 0;
				if (flag)
				{
					break;
				}
				bool bRecvMsg = this.m_bRecvMsg;
				if (bRecvMsg)
				{
					SmallBuffer<byte> smallBuffer = default(SmallBuffer<byte>);
					CClientSocket.GetBuffer(ref smallBuffer, num2);
					smallBuffer.Copy(CClientSocket.m_oRecvBuff, num, 0, num2);
					this.GetNetwork().PushReceiveEvent(ref smallBuffer, num2);
					bool bPause = this.m_bPause;
					if (bPause)
					{
						this.m_nPauseRecvLen += num2;
						bool flag2 = this.m_nPauseRecvLen > CClientSocket.PAUSE_RECV_MAX_LEN;
						if (flag2)
						{
							this.m_bRecvMsg = false;
						}
					}
				}
				num += num2;
				this.m_nCurrRecvLen -= num2;
			}
			bool flag3 = num > 0 && this.m_nCurrRecvLen > 0;
			if (flag3)
			{
				Array.Copy(CClientSocket.m_oRecvBuff, num, CClientSocket.m_oRecvBuff, 0, this.m_nCurrRecvLen);
			}
		}

		// Token: 0x0600C84E RID: 51278 RVA: 0x002CE184 File Offset: 0x002CC384
		public static void GetBuffer(ref SmallBuffer<byte> sb, int size)
		{
			SmallBufferPool<byte> bufferPool = CClientSocket.m_BufferPool;
			lock (bufferPool)
			{
				CClientSocket.m_BufferPool.GetBlock(ref sb, size, 0);
			}
		}

		// Token: 0x0600C84F RID: 51279 RVA: 0x002CE1CC File Offset: 0x002CC3CC
		public static void ReturnBuffer(ref SmallBuffer<byte> sb)
		{
			SmallBufferPool<byte> bufferPool = CClientSocket.m_BufferPool;
			lock (bufferPool)
			{
				CClientSocket.m_BufferPool.ReturnBlock(ref sb);
			}
		}

		// Token: 0x04005869 RID: 22633
		private Socket m_oSocket;

		// Token: 0x0400586A RID: 22634
		private SocketState m_nState;

		// Token: 0x0400586B RID: 22635
		private static byte[] m_oSendBuff;

		// Token: 0x0400586C RID: 22636
		private static byte[] m_oRecvBuff;

		// Token: 0x0400586D RID: 22637
		private volatile int m_nStartPos;

		// Token: 0x0400586E RID: 22638
		private volatile int m_nEndPos;

		// Token: 0x0400586F RID: 22639
		private int m_nCurrRecvLen;

		// Token: 0x04005870 RID: 22640
		private CClientSocket.SendState m_oSendState;

		// Token: 0x04005871 RID: 22641
		public static int TotalSendBytes;

		// Token: 0x04005872 RID: 22642
		public static int TotalRecvBytes;

		// Token: 0x04005873 RID: 22643
		private CNetwork m_oNetwork;

		// Token: 0x04005874 RID: 22644
		private IPacketBreaker m_oBreaker;

		// Token: 0x04005875 RID: 22645
		private int m_nUID;

		// Token: 0x04005876 RID: 22646
		private static int SOCKET_UID = 0;

		// Token: 0x04005877 RID: 22647
		private AsyncCallback m_RecvCb = null;

		// Token: 0x04005878 RID: 22648
		private AsyncCallback m_ConnectCb = null;

		// Token: 0x04005879 RID: 22649
		private AsyncCallback m_SendCb = null;

		// Token: 0x0400587A RID: 22650
		public bool m_bRecvMsg = true;

		// Token: 0x0400587B RID: 22651
		public bool m_bPause = false;

		// Token: 0x0400587C RID: 22652
		public int m_nPauseRecvLen = 0;

		// Token: 0x0400587D RID: 22653
		public static int PAUSE_RECV_MAX_LEN = XSingleton<XGlobalConfig>.singleton.GetInt("PauseRecvMaxLen");

		// Token: 0x0400587E RID: 22654
		public static int MaxSendSize = 1024;

		// Token: 0x0400587F RID: 22655
		public static int SendBufferSize = 32768;

		// Token: 0x04005880 RID: 22656
		private AddressFamily m_NetworkType = AddressFamily.InterNetwork;

		// Token: 0x04005881 RID: 22657
		private static SmallBufferPool<byte> m_BufferPool = null;

		// Token: 0x04005882 RID: 22658
		private static BlockInfo[] blockInit = new BlockInfo[]
		{
			new BlockInfo(32, 128),
			new BlockInfo(64, 128),
			new BlockInfo(128, 64),
			new BlockInfo(256, 32),
			new BlockInfo(512, 16),
			new BlockInfo(1024, 4),
			new BlockInfo(2048, 4),
			new BlockInfo(4096, 4),
			new BlockInfo(8192, 4),
			new BlockInfo(65536, 4)
		};

		// Token: 0x020019D7 RID: 6615
		private class SendState
		{
			// Token: 0x04008022 RID: 32802
			public int start;

			// Token: 0x04008023 RID: 32803
			public int len;
		}
	}
}
