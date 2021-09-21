using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020010EE RID: 4334
	internal class Process_RpcC2G_SetDesignationReq
	{
		// Token: 0x0600D873 RID: 55411 RVA: 0x003298F4 File Offset: 0x00327AF4
		public static void OnReply(SetDesignationReq oArg, SetDesignationRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.result > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
				}
				else
				{
					XDesignationDocument specificDocument = XDocuments.GetSpecificDocument<XDesignationDocument>(XDesignationDocument.uuID);
					bool flag3 = oArg.type == 2U;
					if (flag3)
					{
						specificDocument.DealWithAppearRedPoint(oArg.designationID, oRes.dataList);
					}
					specificDocument.SetDesignationInfo(oArg.type, oArg.designationID, oRes.name);
				}
			}
		}

		// Token: 0x0600D874 RID: 55412 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(SetDesignationReq oArg)
		{
		}
	}
}
