using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200117C RID: 4476
	internal class RpcC2G_GetGoddessTrialRewards : Rpc
	{
		// Token: 0x0600DAC1 RID: 56001 RVA: 0x0032E130 File Offset: 0x0032C330
		public override uint GetRpcType()
		{
			return 41420U;
		}

		// Token: 0x0600DAC2 RID: 56002 RVA: 0x0032E147 File Offset: 0x0032C347
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetGoddessTrialRewardsArg>(stream, this.oArg);
		}

		// Token: 0x0600DAC3 RID: 56003 RVA: 0x0032E157 File Offset: 0x0032C357
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetGoddessTrialRewardsRes>(stream);
		}

		// Token: 0x0600DAC4 RID: 56004 RVA: 0x0032E166 File Offset: 0x0032C366
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetGoddessTrialRewards.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DAC5 RID: 56005 RVA: 0x0032E182 File Offset: 0x0032C382
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetGoddessTrialRewards.OnTimeout(this.oArg);
		}

		// Token: 0x04006247 RID: 25159
		public GetGoddessTrialRewardsArg oArg = new GetGoddessTrialRewardsArg();

		// Token: 0x04006248 RID: 25160
		public GetGoddessTrialRewardsRes oRes = new GetGoddessTrialRewardsRes();
	}
}
