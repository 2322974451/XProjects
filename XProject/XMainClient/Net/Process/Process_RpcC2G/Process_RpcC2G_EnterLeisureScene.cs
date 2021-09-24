using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_EnterLeisureScene
	{

		public static void OnReply(EnterLeisureSceneArg oArg, EnterLeisureSceneRes oRes)
		{
			XYorozuyaDocument.Doc.OnReqBack(oRes);
		}

		public static void OnTimeout(EnterLeisureSceneArg oArg)
		{
		}
	}
}
