using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000B47 RID: 2887
	internal class RpcC2M_GetGuildWageReward : Rpc
	{
		// Token: 0x0600A88E RID: 43150 RVA: 0x001E0C4C File Offset: 0x001DEE4C
		public override uint GetRpcType()
		{
			return 50133U;
		}

		// Token: 0x0600A88F RID: 43151 RVA: 0x001E0C63 File Offset: 0x001DEE63
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetGuildWageRewardArg>(stream, this.oArg);
		}

		// Token: 0x0600A890 RID: 43152 RVA: 0x001E0C73 File Offset: 0x001DEE73
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetGuildWageReward>(stream);
		}

		// Token: 0x0600A891 RID: 43153 RVA: 0x001E0C82 File Offset: 0x001DEE82
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetGuildWageReward.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600A892 RID: 43154 RVA: 0x001E0C9E File Offset: 0x001DEE9E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetGuildWageReward.OnTimeout(this.oArg);
		}

		// Token: 0x04003E77 RID: 15991
		public GetGuildWageRewardArg oArg = new GetGuildWageRewardArg();

		// Token: 0x04003E78 RID: 15992
		public GetGuildWageReward oRes = null;
	}
}
