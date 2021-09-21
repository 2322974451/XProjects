using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200159B RID: 5531
	internal class Process_RpcC2M_GetMarriageRelation
	{
		// Token: 0x0600EB93 RID: 60307 RVA: 0x00345FB0 File Offset: 0x003441B0
		public static void OnReply(GetMarriageRelationArg oArg, GetMarriageRelationRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.error == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					XWeddingDocument doc = XWeddingDocument.Doc;
					doc.OnGetMarriageRelationInfo(oRes);
					doc.OnGetPartDetailInfoBack(oRes);
				}
			}
		}

		// Token: 0x0600EB94 RID: 60308 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetMarriageRelationArg oArg)
		{
		}
	}
}
