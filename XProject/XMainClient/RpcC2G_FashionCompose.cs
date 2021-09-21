using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001043 RID: 4163
	internal class RpcC2G_FashionCompose : Rpc
	{
		// Token: 0x0600D5C0 RID: 54720 RVA: 0x00324EC8 File Offset: 0x003230C8
		public override uint GetRpcType()
		{
			return 46372U;
		}

		// Token: 0x0600D5C1 RID: 54721 RVA: 0x00324EDF File Offset: 0x003230DF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FashionComposeArg>(stream, this.oArg);
		}

		// Token: 0x0600D5C2 RID: 54722 RVA: 0x00324EEF File Offset: 0x003230EF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<FashionComposeRes>(stream);
		}

		// Token: 0x0600D5C3 RID: 54723 RVA: 0x00324EFE File Offset: 0x003230FE
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_FashionCompose.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D5C4 RID: 54724 RVA: 0x00324F1A File Offset: 0x0032311A
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_FashionCompose.OnTimeout(this.oArg);
		}

		// Token: 0x04006150 RID: 24912
		public FashionComposeArg oArg = new FashionComposeArg();

		// Token: 0x04006151 RID: 24913
		public FashionComposeRes oRes = new FashionComposeRes();
	}
}
