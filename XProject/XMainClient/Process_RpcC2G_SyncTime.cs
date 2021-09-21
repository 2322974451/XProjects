using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FFF RID: 4095
	internal class Process_RpcC2G_SyncTime
	{
		// Token: 0x0600D4A3 RID: 54435 RVA: 0x00321A64 File Offset: 0x0031FC64
		public static void OnReply(SyncTimeArg oArg, SyncTimeRes oRes)
		{
			XSingleton<XServerTimeMgr>.singleton.OnSyncTime(oArg.time, Process_RpcC2G_SyncTime.Ticks);
		}

		// Token: 0x0600D4A4 RID: 54436 RVA: 0x00321A7D File Offset: 0x0031FC7D
		public static void OnTimeout(SyncTimeArg oArg)
		{
			XSingleton<XServerTimeMgr>.singleton.OnSyncTimeout();
		}

		// Token: 0x040060F7 RID: 24823
		public static long Ticks = 0L;
	}
}
