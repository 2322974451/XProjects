using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001502 RID: 5378
	internal class RpcC2G_ArtifactCompose : Rpc
	{
		// Token: 0x0600E91D RID: 59677 RVA: 0x00342378 File Offset: 0x00340578
		public override uint GetRpcType()
		{
			return 599U;
		}

		// Token: 0x0600E91E RID: 59678 RVA: 0x0034238F File Offset: 0x0034058F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ArtifactComposeArg>(stream, this.oArg);
		}

		// Token: 0x0600E91F RID: 59679 RVA: 0x0034239F File Offset: 0x0034059F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ArtifactComposeRes>(stream);
		}

		// Token: 0x0600E920 RID: 59680 RVA: 0x003423AE File Offset: 0x003405AE
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ArtifactCompose.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E921 RID: 59681 RVA: 0x003423CA File Offset: 0x003405CA
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ArtifactCompose.OnTimeout(this.oArg);
		}

		// Token: 0x04006501 RID: 25857
		public ArtifactComposeArg oArg = new ArtifactComposeArg();

		// Token: 0x04006502 RID: 25858
		public ArtifactComposeRes oRes = null;
	}
}
