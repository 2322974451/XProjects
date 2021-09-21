using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001475 RID: 5237
	internal class Process_RpcC2G_AtlasUpStar
	{
		// Token: 0x0600E6D8 RID: 59096 RVA: 0x0033F15C File Offset: 0x0033D35C
		public static void OnReply(AtlasUpStarArg oArg, AtlasUpStarRes oRes)
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
					XCardCollectDocument specificDocument = XDocuments.GetSpecificDocument<XCardCollectDocument>(XCardCollectDocument.uuID);
					specificDocument.ChangeStar((int)oRes.star, (int)oArg.groupid);
				}
			}
		}

		// Token: 0x0600E6D9 RID: 59097 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(AtlasUpStarArg oArg)
		{
		}
	}
}
