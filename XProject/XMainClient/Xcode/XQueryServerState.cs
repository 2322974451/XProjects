using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XQueryServerState : XSingleton<XQueryServerState>
	{

		public XQueryServerState()
		{
			this.CallbackHandler = new XQueryServerState.ServerStateResponseHandler(this.PrintHandler);
			this.m_Socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
			this.m_CompleteAR = new Queue<IAsyncResult>();
			this.m_QueryServerID = new List<XQueryServerState.QueryInfo>();
		}

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

		private int bytes2int(byte[] a)
		{
			return (int)(a[0] + byte.MaxValue * (a[1] + byte.MaxValue * (a[2] + byte.MaxValue * a[3])));
		}

		public void Query(int serverID, string serverIP, int serverPort)
		{
			this.AddQueryRecord(serverID, serverIP, serverPort);
			this.SendQueryProtocol(serverID, serverIP, serverPort);
		}

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

		public void ProcessQueryMessage()
		{
			this.ProcessResponse();
			this.ProcessTimeoutRecord();
		}

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

		private void PrintHandler(int serverID, ServerStateEnum serverState, ServerFlagEnum serverFlag)
		{
			XSingleton<XDebug>.singleton.AddLog("server ", serverID.ToString(), " state: ", serverState.ToString(), " flag: ", serverFlag.ToString(), XDebugColor.XDebug_None);
		}

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

		private void OnRecv(IAsyncResult ar)
		{
			Queue<IAsyncResult> completeAR = this.m_CompleteAR;
			lock (completeAR)
			{
				this.m_CompleteAR.Enqueue(ar);
			}
		}

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

		private readonly int TIMEOUT_VALUE = 5000;

		public XQueryServerState.ServerStateResponseHandler CallbackHandler = null;

		private Queue<IAsyncResult> m_CompleteAR;

		private List<XQueryServerState.QueryInfo> m_QueryServerID;

		private Socket m_Socket;

		private class stateobj
		{

			public EndPoint remote = new IPEndPoint(0L, 0);

			public byte[] buffer = new byte[64];
		}

		private class QueryInfo
		{

			public int serverID;

			public int queryTime;

			public int tryCount;

			public string serverIP;

			public int serverPort;
		}

		public delegate void ServerStateResponseHandler(int serverID, ServerStateEnum serverState, ServerFlagEnum serverFlag);
	}
}
