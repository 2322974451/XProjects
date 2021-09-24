using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_OpenSceneChest
	{

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

		public static void OnTimeout(OpenSceneChestArg oArg)
		{
		}
	}
}
