using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_JustDance
	{

		public static void OnReply(JustDanceArg oArg, JustDanceRes oRes)
		{
			XDanceDocument specificDocument = XDocuments.GetSpecificDocument<XDanceDocument>(XDanceDocument.uuID);
			specificDocument.OnJustDance(oArg, oRes);
		}

		public static void OnTimeout(JustDanceArg oArg)
		{
		}
	}
}
