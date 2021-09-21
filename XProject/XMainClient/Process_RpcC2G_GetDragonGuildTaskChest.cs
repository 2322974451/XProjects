using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200163D RID: 5693
	internal class Process_RpcC2G_GetDragonGuildTaskChest
	{
		// Token: 0x0600EE37 RID: 60983 RVA: 0x00349754 File Offset: 0x00347954
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

		// Token: 0x0600EE38 RID: 60984 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetDragonGuildTaskChestArg oArg)
		{
		}
	}
}
