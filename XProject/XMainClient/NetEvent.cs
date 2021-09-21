using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000EB5 RID: 3765
	public class NetEvent : INetEventData, ILuaNetEventData
	{
		// Token: 0x0600C858 RID: 51288 RVA: 0x002CE317 File Offset: 0x002CC517
		public NetEvent()
		{
			this.Reset();
		}

		// Token: 0x0600C859 RID: 51289 RVA: 0x002CE338 File Offset: 0x002CC538
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

		// Token: 0x0600C85A RID: 51290 RVA: 0x002CE3A7 File Offset: 0x002CC5A7
		public void ManualReturnProtocol()
		{
			this.protocol = null;
		}

		// Token: 0x170034F6 RID: 13558
		// (get) Token: 0x0600C85B RID: 51291 RVA: 0x002CE3B2 File Offset: 0x002CC5B2
		// (set) Token: 0x0600C85C RID: 51292 RVA: 0x002CE3BA File Offset: 0x002CC5BA
		public Protocol protocol { get; set; }

		// Token: 0x170034F7 RID: 13559
		// (get) Token: 0x0600C85D RID: 51293 RVA: 0x002CE3C3 File Offset: 0x002CC5C3
		// (set) Token: 0x0600C85E RID: 51294 RVA: 0x002CE3CB File Offset: 0x002CC5CB
		public Rpc rpc { get; set; }

		// Token: 0x170034F8 RID: 13560
		// (get) Token: 0x0600C85F RID: 51295 RVA: 0x002CE3D4 File Offset: 0x002CC5D4
		// (set) Token: 0x0600C860 RID: 51296 RVA: 0x002CE3DC File Offset: 0x002CC5DC
		public LuaNetNode node { get; set; }

		// Token: 0x0400589A RID: 22682
		public NetEvtType m_nEvtType;

		// Token: 0x0400589B RID: 22683
		public SmallBuffer<byte> m_oBuffer;

		// Token: 0x0400589C RID: 22684
		public bool m_bSuccess;

		// Token: 0x0400589D RID: 22685
		public NetErrCode m_nErrCode;

		// Token: 0x0400589E RID: 22686
		public int m_nBufferLength;

		// Token: 0x0400589F RID: 22687
		public int m_SocketID;

		// Token: 0x040058A0 RID: 22688
		public long m_oTime;

		// Token: 0x040058A1 RID: 22689
		public bool IsPtc = false;

		// Token: 0x040058A2 RID: 22690
		public bool IsOnlyLua = false;
	}
}
