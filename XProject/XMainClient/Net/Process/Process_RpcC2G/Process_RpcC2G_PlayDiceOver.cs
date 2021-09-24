using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_PlayDiceOver
	{

		public static void OnReply(PlayDiceOverArg oArg, PlayDiceOverRes oRes)
		{
			XSuperRiskDocument.Doc.OnMoveOver(oRes);
		}

		public static void OnTimeout(PlayDiceOverArg oArg)
		{
		}
	}
}
