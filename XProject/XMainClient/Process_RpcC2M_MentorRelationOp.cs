using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020013DB RID: 5083
	internal class Process_RpcC2M_MentorRelationOp
	{
		// Token: 0x0600E46B RID: 58475 RVA: 0x0033BB9C File Offset: 0x00339D9C
		public static void OnReply(MentorRelationOpArg oArg, MentorRelationOpRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
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
					XMentorshipDocument.Doc.OnGetMentorshipOpReply(oArg, oRes);
				}
			}
		}

		// Token: 0x0600E46C RID: 58476 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(MentorRelationOpArg oArg)
		{
		}
	}
}
