using System;

namespace XMainClient
{
	// Token: 0x02000EB0 RID: 3760
	public enum NetErrCode
	{
		// Token: 0x04005888 RID: 22664
		Net_NoError,
		// Token: 0x04005889 RID: 22665
		Net_SysError,
		// Token: 0x0400588A RID: 22666
		Net_ConnectError,
		// Token: 0x0400588B RID: 22667
		Net_SrvNtfError,
		// Token: 0x0400588C RID: 22668
		Net_ReconnectFailed,
		// Token: 0x0400588D RID: 22669
		Net_Rpc_Delay,
		// Token: 0x0400588E RID: 22670
		Net_PauseRecv_Overflow,
		// Token: 0x0400588F RID: 22671
		Net_RecvBuff_Overflow,
		// Token: 0x04005890 RID: 22672
		Net_SendBuff_Overflow,
		// Token: 0x04005891 RID: 22673
		Net_Unknown_Exception
	}
}
