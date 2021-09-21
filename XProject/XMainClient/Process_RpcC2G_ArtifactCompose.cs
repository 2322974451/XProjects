using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001503 RID: 5379
	internal class Process_RpcC2G_ArtifactCompose
	{
		// Token: 0x0600E922 RID: 59682 RVA: 0x003423D9 File Offset: 0x003405D9
		public static void OnReply(ArtifactComposeArg oArg, ArtifactComposeRes oRes)
		{
			ArtifactComposeDocument.Doc.OnReqCoposeArtifactBack(oArg.type, oRes);
		}

		// Token: 0x0600E923 RID: 59683 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ArtifactComposeArg oArg)
		{
		}
	}
}
