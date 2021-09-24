using System;
using XUtliPoolLib;

namespace XMainClient
{

	public class NetEvent : INetEventData, ILuaNetEventData
	{

		public NetEvent()
		{
			this.Reset();
		}

		public void Reset()
		{
			this.m_nEvtType = NetEvtType.Event_Connect;
			this.m_oBuffer.SetInvalid();
			this.m_bSuccess = true;
			this.m_oTime = DateTime.Now.Ticks;
			this.m_nErrCode = NetErrCode.Net_NoError;
			this.m_nBufferLength = 0;
			this.m_SocketID = 0;
			this.IsOnlyLua = false;
			this.protocol = null;
			this.rpc = null;
			this.node = null;
		}

		public void ManualReturnProtocol()
		{
			this.protocol = null;
		}

		public Protocol protocol { get; set; }

		public Rpc rpc { get; set; }

		public LuaNetNode node { get; set; }

		public NetEvtType m_nEvtType;

		public SmallBuffer<byte> m_oBuffer;

		public bool m_bSuccess;

		public NetErrCode m_nErrCode;

		public int m_nBufferLength;

		public int m_SocketID;

		public long m_oTime;

		public bool IsPtc = false;

		public bool IsOnlyLua = false;
	}
}
