using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_ArtifactCompose
	{

		public static void OnReply(ArtifactComposeArg oArg, ArtifactComposeRes oRes)
		{
			ArtifactComposeDocument.Doc.OnReqCoposeArtifactBack(oArg.type, oRes);
		}

		public static void OnTimeout(ArtifactComposeArg oArg)
		{
		}
	}
}
