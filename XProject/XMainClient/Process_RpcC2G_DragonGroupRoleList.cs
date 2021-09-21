using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020015C0 RID: 5568
	internal class Process_RpcC2G_DragonGroupRoleList
	{
		// Token: 0x0600EC24 RID: 60452 RVA: 0x00346A58 File Offset: 0x00344C58
		public static void OnReply(DragonGroupRoleListC2S oArg, DragonGroupRoleListS2C oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				bool flag2 = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					XDragonPartnerDocument specificDocument = XDocuments.GetSpecificDocument<XDragonPartnerDocument>(XDragonPartnerDocument.uuID);
					bool flag3 = specificDocument != null;
					if (flag3)
					{
						specificDocument.OnReqDragonGropRoleInfo(oArg, oRes);
					}
				}
			}
		}

		// Token: 0x0600EC25 RID: 60453 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(DragonGroupRoleListC2S oArg)
		{
		}
	}
}
