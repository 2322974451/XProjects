using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_SyncTime
	{

		public static void OnReply(SyncTimeArg oArg, SyncTimeRes oRes)
		{
			XSingleton<XServerTimeMgr>.singleton.OnSyncTime(oArg.time, Process_RpcC2G_SyncTime.Ticks);
		}

		public static void OnTimeout(SyncTimeArg oArg)
		{
			XSingleton<XServerTimeMgr>.singleton.OnSyncTimeout();
		}

		public static long Ticks = 0L;
	}
}
