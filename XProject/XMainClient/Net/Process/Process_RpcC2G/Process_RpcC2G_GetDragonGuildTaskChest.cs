using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_GetDragonGuildTaskChest
	{

		public static void OnReply(GetDragonGuildTaskChestArg oArg, GetDragonGuildTaskChestRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
			else
			{
				XDragonGuildTaskDocument specificDocument = XDocuments.GetSpecificDocument<XDragonGuildTaskDocument>(XDragonGuildTaskDocument.uuID);
				bool flag2 = oArg.type == DragonGuildTaskType.TASK_ACHIVEMENT;
				if (flag2)
				{
					specificDocument.OnFetchAchieve(oArg.taskid);
				}
				else
				{
					bool flag3 = oArg.type == DragonGuildTaskType.TASK_NORMAL;
					if (flag3)
					{
						specificDocument.OnFetchTask(oArg.taskid);
					}
				}
			}
		}

		public static void OnTimeout(GetDragonGuildTaskChestArg oArg)
		{
		}
	}
}
