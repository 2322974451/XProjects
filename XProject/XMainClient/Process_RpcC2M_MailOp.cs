using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B6B RID: 2923
	internal class Process_RpcC2M_MailOp
	{
		// Token: 0x0600A921 RID: 43297 RVA: 0x001E1AA4 File Offset: 0x001DFCA4
		public static void OnReply(MailOpArg oArg, MailOpRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
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
					bool flag3 = oRes.errorcode == ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XMailDocument specificDocument = XDocuments.GetSpecificDocument<XMailDocument>(XMailDocument.uuID);
						specificDocument.ResMailOP(oArg, oRes);
					}
					else
					{
						bool flag4 = oArg.optype == 3U;
						if (flag4)
						{
							XMailDocument specificDocument2 = XDocuments.GetSpecificDocument<XMailDocument>(XMailDocument.uuID);
							specificDocument2.ReqMailInfo();
						}
						XSingleton<UiUtility>.singleton.ShowErrorCode(oRes.errorcode);
					}
				}
			}
		}

		// Token: 0x0600A922 RID: 43298 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(MailOpArg oArg)
		{
		}
	}
}
