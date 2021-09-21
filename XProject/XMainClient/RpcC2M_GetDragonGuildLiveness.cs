using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001620 RID: 5664
	internal class RpcC2M_GetDragonGuildLiveness : Rpc
	{
		// Token: 0x0600EDBA RID: 60858 RVA: 0x00348C08 File Offset: 0x00346E08
		public override uint GetRpcType()
		{
			return 16507U;
		}

		// Token: 0x0600EDBB RID: 60859 RVA: 0x00348C1F File Offset: 0x00346E1F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetPartnerLivenessArg>(stream, this.oArg);
		}

		// Token: 0x0600EDBC RID: 60860 RVA: 0x00348C2F File Offset: 0x00346E2F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetPartnerLivenessRes>(stream);
		}

		// Token: 0x0600EDBD RID: 60861 RVA: 0x00348C3E File Offset: 0x00346E3E
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetDragonGuildLiveness.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EDBE RID: 60862 RVA: 0x00348C5A File Offset: 0x00346E5A
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetDragonGuildLiveness.OnTimeout(this.oArg);
		}

		// Token: 0x040065ED RID: 26093
		public GetPartnerLivenessArg oArg = new GetPartnerLivenessArg();

		// Token: 0x040065EE RID: 26094
		public GetPartnerLivenessRes oRes = null;
	}
}
