using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_DragonGroupRoleList
	{

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

		public static void OnTimeout(DragonGroupRoleListC2S oArg)
		{
		}
	}
}
