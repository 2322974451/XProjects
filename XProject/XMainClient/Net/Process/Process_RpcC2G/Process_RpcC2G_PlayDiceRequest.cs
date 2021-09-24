using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_PlayDiceRequest
	{

		public static void OnReply(PlayDiceRequestArg oArg, PlayDiceRequestRes oRes)
		{
			XSuperRiskDocument.Doc.OnGetDicingResult(oRes);
		}

		public static void OnTimeout(PlayDiceRequestArg oArg)
		{
		}
	}
}
