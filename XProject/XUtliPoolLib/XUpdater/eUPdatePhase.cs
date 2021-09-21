using System;

namespace XUpdater
{
	// Token: 0x02000017 RID: 23
	internal enum eUPdatePhase
	{
		// Token: 0x0400005F RID: 95
		xUP_None,
		// Token: 0x04000060 RID: 96
		xUP_Prepare,
		// Token: 0x04000061 RID: 97
		xUP_FetchVersion,
		// Token: 0x04000062 RID: 98
		xUP_LoadVersion,
		// Token: 0x04000063 RID: 99
		xUP_CompareVersion,
		// Token: 0x04000064 RID: 100
		xUP_DownLoadConfirm,
		// Token: 0x04000065 RID: 101
		xUP_DownLoadBundle,
		// Token: 0x04000066 RID: 102
		xUP_ShowVersion,
		// Token: 0x04000067 RID: 103
		xUP_LaunchGame,
		// Token: 0x04000068 RID: 104
		xUP_Ending,
		// Token: 0x04000069 RID: 105
		xUP_Finish,
		// Token: 0x0400006A RID: 106
		xUP_Error
	}
}
