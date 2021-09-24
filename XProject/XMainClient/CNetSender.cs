using System;
using System.IO;
using XUtliPoolLib;

namespace XMainClient
{

	public class CNetSender : INetSender, ILuaNetSender
	{

		public CNetSender(CNetwork network)
		{
			this.m_oNetwork = network;
			this.m_oSendStream = new MemoryStream();
		}

		public bool Send(Protocol protocol)
		{
			this.m_oSendStream.SetLength(0L);
			this.m_oSendStream.Position = 0L;
			protocol.SerializeWithHead(this.m_oSendStream);
			bool flag = XSingleton<XDebug>.singleton.EnableRecord();
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddPoint(protocol.GetProtoType(), protocol.GetType().Name, (float)this.m_oSendStream.Length, 1, XDebug.RecordChannel.ENetwork);
			}
			bool flag2 = this.m_oSendStream.Length > 1024L;
			if (flag2)
			{
				XSingleton<XDebug>.singleton.AddWarningLog2("Send Ptc:{0} to long:{1}b", new object[]
				{
					protocol.GetProtoType(),
					this.m_oSendStream.Length
				});
			}
			return this.m_oNetwork.Send(this.m_oSendStream.GetBuffer(), 0, (int)this.m_oSendStream.Length);
		}

		public bool Send(uint _type, bool isRpc, uint tagID, byte[] _reqBuff)
		{
			this.m_oSendStream.SetLength(0L);
			this.m_oSendStream.Position = 0L;
			long num = 0L;
			ProtocolHead sharedHead = ProtocolHead.SharedHead;
			sharedHead.Reset();
			sharedHead.tagID = tagID;
			sharedHead.type = _type;
			sharedHead.flag = (isRpc ? 3U : 0U);
			sharedHead.Serialize(this.m_oSendStream);
			this.m_oSendStream.Write(_reqBuff, 0, _reqBuff.Length);
			long position = this.m_oSendStream.Position;
			uint value = (uint)(position - num - 4L);
			this.m_oSendStream.Position = num;
			this.m_oSendStream.Write(BitConverter.GetBytes(value), 0, 4);
			this.m_oSendStream.Position = position;
			byte[] buffer = this.m_oSendStream.GetBuffer();
			int num2 = (int)this.m_oSendStream.Length;
			return this.m_oNetwork.Send(this.m_oSendStream.GetBuffer(), 0, (int)this.m_oSendStream.Length);
		}

		public bool Send(Rpc rpc)
		{
			rpc.SocketID = this.m_oNetwork.GetSocketID();
			rpc.BeforeSend();
			this.m_oSendStream.SetLength(0L);
			this.m_oSendStream.Position = 0L;
			rpc.SerializeWithHead(this.m_oSendStream);
			bool flag = XSingleton<XDebug>.singleton.EnableRecord();
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddPoint(rpc.GetRpcType(), rpc.GetType().Name, (float)this.m_oSendStream.Length, 1, XDebug.RecordChannel.ENetwork);
			}
			bool flag2 = this.m_oSendStream.Length > 1024L;
			if (flag2)
			{
				XSingleton<XDebug>.singleton.AddWarningLog2("Send Rpc:{0} to long:{1}b", new object[]
				{
					rpc.GetRpcType(),
					this.m_oSendStream.Length
				});
			}
			bool flag3 = this.m_oNetwork.Send(this.m_oSendStream.GetBuffer(), 0, (int)this.m_oSendStream.Length);
			bool flag4 = flag3;
			if (flag4)
			{
				rpc.AfterSend();
			}
			return flag3;
		}

		private CNetwork m_oNetwork;

		private MemoryStream m_oSendStream;
	}
}
