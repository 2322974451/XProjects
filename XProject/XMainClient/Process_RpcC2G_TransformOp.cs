using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020015DC RID: 5596
	internal class Process_RpcC2G_TransformOp
	{
		// Token: 0x0600EC99 RID: 60569 RVA: 0x0034746C File Offset: 0x0034566C
		public static void OnReply(TransformOpArg oArg, TransformOpRes oRes)
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
					XTransformDocument specificDocument = XDocuments.GetSpecificDocument<XTransformDocument>(XTransformDocument.uuID);
					specificDocument.OnGetTransformOp(oArg, oRes);
				}
			}
		}

		// Token: 0x0600EC9A RID: 60570 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(TransformOpArg oArg)
		{
		}
	}
}
