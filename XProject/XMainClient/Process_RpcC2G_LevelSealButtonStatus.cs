using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001105 RID: 4357
	internal class Process_RpcC2G_LevelSealButtonStatus
	{
		// Token: 0x0600D8D3 RID: 55507 RVA: 0x0032A16C File Offset: 0x0032836C
		public static void OnReply(LevelSealOverExpArg oArg, LevelSealOverExpRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.errorcode > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
				}
				else
				{
					XLevelSealDocument specificDocument = XDocuments.GetSpecificDocument<XLevelSealDocument>(XLevelSealDocument.uuID);
					specificDocument.LevelSealButtonClick(oArg, oRes);
				}
			}
		}

		// Token: 0x0600D8D4 RID: 55508 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(LevelSealOverExpArg oArg)
		{
		}
	}
}
