using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200108C RID: 4236
	internal class Process_RpcC2G_OpenSceneChest
	{
		// Token: 0x0600D6F3 RID: 55027 RVA: 0x00326F64 File Offset: 0x00325164
		public static void OnReply(OpenSceneChestArg oArg, OpenSceneChestRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.result == ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XLevelDocument xlevelDocument = XSingleton<XGame>.singleton.Doc.GetXComponent(XLevelDocument.uuID) as XLevelDocument;
					xlevelDocument.OnFetchSceneChestSucc(oArg.sceneID);
				}
			}
		}

		// Token: 0x0600D6F4 RID: 55028 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(OpenSceneChestArg oArg)
		{
		}
	}
}
