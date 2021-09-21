using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D89 RID: 3465
	internal class XQueryServerState : XSingleton<XQueryServerState>
	{
		// Token: 0x0600BCFA RID: 48378 RVA: 0x0026FCA4 File Offset: 0x0026DEA4
		public XQueryServerState()
		{
			this.CallbackHandler = new XQueryServerState.ServerStateResponseHandler(this.PrintHandler);
			this.m_Socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
			this.m_CompleteAR = new Queue<IAsyncResult>();
			this.m_QueryServerID = new List<XQueryServerState.QueryInfo>();
		}

		// Token: 0x0600BCFB RID: 48379 RVA: 0x0026FD04 File Offset: 0x0026DF04
		private byte[] int2bytes(int serverID)
		{
			return new byte[]
			{
				(byte)(serverID & 255),
				(byte)(serverID >> 8 & 255),
				(byte)(serverID >> 16 & 255),
				(byte)(serverID >> 24 & 255)
			};
		}

		// Token: 0x0600BCFC RID: 48380 RVA: 0x0026FD54 File Offset: 0x0026DF54
		private int bytes2int(byte[] a)
		{
			return (int)(a[0] + byte.MaxValue * (a[1] + byte.MaxValue * (a[2] + byte.MaxValue * a[3])));
		}

		// Token: 0x0600BCFD RID: 48381 RVA: 0x0026FD87 File Offset: 0x0026DF87
		public void Query(int serverID, string serverIP, int serverPort)
		{
			this.AddQueryRecord(serverID, serverIP, serverPort);
			this.SendQueryProtocol(serverID, serverIP, serverPort);
		}

		// Token: 0x0600BCFE RID: 48382 RVA: 0x0026FDA0 File Offset: 0x0026DFA0
		private void SendQueryProtocol(int serverID, string serverIP, int serverPort)
		{
			try
			{
				this.m_Socket.SendTo(this.int2bytes(serverID), new IPEndPoint(IPAddress.Parse(serverIP), serverPort));
				XQueryServerState.stateobj stateobj = new XQueryServerState.stateobj();
				AsyncCallback callback = new AsyncCallback(this.OnRecv);
				this.m_Socket.BeginReceiveFrom(stateobj.buffer, 0, stateobj.buffer.Length, SocketFlags.None, ref stateobj.remote, callback, stateobj);
			}
			catch (Exception ex)
			{
				XSingleton<XDebug>.singleton.AddLog("query protocol failed! + ", ex.Message, null, null, null, null, XDebugColor.XDebug_None);
			}
		}

		// Token: 0x0600BCFF RID: 48383 RVA: 0x0026FE38 File Offset: 0x0026E038
		public void ProcessQueryMessage()
		{
			this.ProcessResponse();
			this.ProcessTimeoutRecord();
		}

		// Token: 0x0600BD00 RID: 48384 RVA: 0x0026FE4C File Offset: 0x0026E04C
		private void ProcessResponse()
		{
			while (this.m_CompleteAR.Count > 0)
			{
				IAsyncResult asyncResult = null;
				Queue<IAsyncResult> completeAR = this.m_CompleteAR;
				lock (completeAR)
				{
					asyncResult = this.m_CompleteAR.Dequeue();
				}
				try
				{
					XQueryServerState.stateobj stateobj = (XQueryServerState.stateobj)asyncResult.AsyncState;
					int num = this.m_Socket.EndReceiveFrom(asyncResult, ref stateobj.remote);
					bool flag = num > 0;
					if (flag)
					{
						this.ProcessData(stateobj.buffer, num);
					}
				}
				catch (Exception ex)
				{
					XSingleton<XDebug>.singleton.AddLog(ex.Message, null, null, null, null, null, XDebugColor.XDebug_None);
				}
			}
		}

		// Token: 0x0600BD01 RID: 48385 RVA: 0x0026FF18 File Offset: 0x0026E118
		private void ProcessData(byte[] buffer, int length)
		{
			bool flag = length != 6;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Decode Query Server State Info error!", null, null, null, null, null);
			}
			else
			{
				int serverID = this.bytes2int(buffer);
				this.RemoveQueryRecord(serverID);
				this.CallbackHandler(serverID, this.DecodeServerState(buffer[4]), this.DecodeServerFlag(buffer[5]));
			}
		}

		// Token: 0x0600BD02 RID: 48386 RVA: 0x0026FF78 File Offset: 0x0026E178
		private void PrintHandler(int serverID, ServerStateEnum serverState, ServerFlagEnum serverFlag)
		{
			XSingleton<XDebug>.singleton.AddLog("server ", serverID.ToString(), " state: ", serverState.ToString(), " flag: ", serverFlag.ToString(), XDebugColor.XDebug_None);
		}

		// Token: 0x0600BD03 RID: 48387 RVA: 0x0026FFB8 File Offset: 0x0026E1B8
		private ServerFlagEnum DecodeServerFlag(byte p)
		{
			ServerFlagEnum result;
			switch (p)
			{
			case 0:
				result = ServerFlagEnum.MAINTAIN;
				break;
			case 1:
				result = ServerFlagEnum.NEW;
				break;
			case 2:
				result = ServerFlagEnum.NORMAL;
				break;
			case 3:
				result = ServerFlagEnum.FULL;
				break;
			case 4:
				result = ServerFlagEnum.SUGGEST;
				break;
			default:
				result = ServerFlagEnum.MAINTAIN;
				break;
			}
			return result;
		}

		// Token: 0x0600BD04 RID: 48388 RVA: 0x00270000 File Offset: 0x0026E200
		private ServerStateEnum DecodeServerState(byte p)
		{
			ServerStateEnum result;
			switch (p)
			{
			case 0:
				result = ServerStateEnum.TIMEOUT;
				break;
			case 1:
				result = ServerStateEnum.EMPTY;
				break;
			case 2:
				result = ServerStateEnum.NORMAL;
				break;
			case 3:
				result = ServerStateEnum.FULL;
				break;
			default:
				result = ServerStateEnum.TIMEOUT;
				break;
			}
			return result;
		}

		// Token: 0x0600BD05 RID: 48389 RVA: 0x00270040 File Offset: 0x0026E240
		private void OnRecv(IAsyncResult ar)
		{
			Queue<IAsyncResult> completeAR = this.m_CompleteAR;
			lock (completeAR)
			{
				this.m_CompleteAR.Enqueue(ar);
			}
		}

		// Token: 0x0600BD06 RID: 48390 RVA: 0x00270088 File Offset: 0x0026E288
		private void AddQueryRecord(int serverID, string serverIP, int serverPort)
		{
			XQueryServerState.QueryInfo queryInfo = new XQueryServerState.QueryInfo();
			queryInfo.serverID = serverID;
			queryInfo.queryTime = Environment.TickCount;
			queryInfo.tryCount = 1;
			queryInfo.serverIP = serverIP;
			queryInfo.serverPort = serverPort;
			this.m_QueryServerID.Add(queryInfo);
		}

		// Token: 0x0600BD07 RID: 48391 RVA: 0x002700D0 File Offset: 0x0026E2D0
		private void RemoveQueryRecord(int serverID)
		{
			for (int i = 0; i < this.m_QueryServerID.Count; i++)
			{
				bool flag = this.m_QueryServerID[i].serverID == serverID;
				if (flag)
				{
					this.m_QueryServerID.RemoveAt(i);
					break;
				}
			}
		}

		// Token: 0x0600BD08 RID: 48392 RVA: 0x00270124 File Offset: 0x0026E324
		private void ProcessTimeoutRecord()
		{
			int tickCount = Environment.TickCount;
			for (int i = this.m_QueryServerID.Count - 1; i >= 0; i--)
			{
				XQueryServerState.QueryInfo queryInfo = this.m_QueryServerID[i];
				bool flag = tickCount > queryInfo.queryTime + this.TIMEOUT_VALUE;
				if (flag)
				{
					bool flag2 = queryInfo.tryCount <= 3;
					if (flag2)
					{
						queryInfo.tryCount++;
						queryInfo.queryTime = Environment.TickCount;
						this.SendQueryProtocol(queryInfo.serverID, queryInfo.serverIP, queryInfo.serverPort);
					}
					else
					{
						this.CallbackHandler(queryInfo.serverID, ServerStateEnum.TIMEOUT, ServerFlagEnum.MAINTAIN);
						this.m_QueryServerID.RemoveAt(i);
					}
				}
			}
		}

		// Token: 0x04004CF0 RID: 19696
		private readonly int TIMEOUT_VALUE = 5000;

		// Token: 0x04004CF1 RID: 19697
		public XQueryServerState.ServerStateResponseHandler CallbackHandler = null;

		// Token: 0x04004CF2 RID: 19698
		private Queue<IAsyncResult> m_CompleteAR;

		// Token: 0x04004CF3 RID: 19699
		private List<XQueryServerState.QueryInfo> m_QueryServerID;

		// Token: 0x04004CF4 RID: 19700
		private Socket m_Socket;

		// Token: 0x020019B9 RID: 6585
		private class stateobj
		{
			// Token: 0x04007FAD RID: 32685
			public EndPoint remote = new IPEndPoint(0L, 0);

			// Token: 0x04007FAE RID: 32686
			public byte[] buffer = new byte[64];
		}

		// Token: 0x020019BA RID: 6586
		private class QueryInfo
		{
			// Token: 0x04007FAF RID: 32687
			public int serverID;

			// Token: 0x04007FB0 RID: 32688
			public int queryTime;

			// Token: 0x04007FB1 RID: 32689
			public int tryCount;

			// Token: 0x04007FB2 RID: 32690
			public string serverIP;

			// Token: 0x04007FB3 RID: 32691
			public int serverPort;
		}

		// Token: 0x020019BB RID: 6587
		// (Invoke) Token: 0x06011061 RID: 69729
		public delegate void ServerStateResponseHandler(int serverID, ServerStateEnum serverState, ServerFlagEnum serverFlag);
	}
}
