using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001050 RID: 4176
	internal class Process_RpcC2G_Revive
	{
		// Token: 0x0600D5F7 RID: 54775 RVA: 0x003253EC File Offset: 0x003235EC
		public static void OnReply(ReviveArg oArg, ReviveRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XSingleton<XDebug>.singleton.AddLog("Revieve Type: " + oArg.type, null, null, null, null, null, XDebugColor.XDebug_None);
				XReviveDocument specificDocument = XDocuments.GetSpecificDocument<XReviveDocument>(XReviveDocument.uuID);
				specificDocument.ResetAutoReviveData();
				ErrorCode result = oRes.result;
				if (result != ErrorCode.ERR_SUCCESS)
				{
					if (result != ErrorCode.ERR_REVIVE_MAXNUM)
					{
						ReviveType type = oArg.type;
						if (type != ReviveType.ReviveItem)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
						}
						else
						{
							bool flag2 = specificDocument.SpecialCostID > 0U;
							if (flag2)
							{
								specificDocument.ShowSpecialRevive();
							}
							else
							{
								XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
							}
						}
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
					}
				}
				else
				{
					switch (oArg.type)
					{
					case ReviveType.ReviveItem:
					case ReviveType.ReviveMoney:
						specificDocument.SetReviveData(specificDocument.ReviveUsedTime + 1, specificDocument.ReviveCostTime + 1, ReviveType.ReviveNone);
						break;
					case ReviveType.ReviveSprite:
					{
						bool flag3 = oArg.clientinfo != null && oArg.clientinfo.islimit;
						if (flag3)
						{
							specificDocument.SetReviveData(specificDocument.ReviveUsedTime + 1, specificDocument.ReviveCostTime, ReviveType.ReviveNone);
						}
						break;
					}
					case ReviveType.ReviveVIP:
					{
						bool flag4 = specificDocument.VipReviveCount > 0U;
						if (flag4)
						{
							XReviveDocument xreviveDocument = specificDocument;
							uint vipReviveCount = xreviveDocument.VipReviveCount - 1U;
							xreviveDocument.VipReviveCount = vipReviveCount;
						}
						specificDocument.SetReviveData(specificDocument.ReviveUsedTime + 1, specificDocument.ReviveCostTime, ReviveType.ReviveNone);
						break;
					}
					}
				}
			}
		}

		// Token: 0x0600D5F8 RID: 54776 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ReviveArg oArg)
		{
		}
	}
}
