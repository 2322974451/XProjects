using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000D8E RID: 3470
	internal class RpcC2G_GetGuildBonusReward : Rpc
	{
		// Token: 0x0600BD2D RID: 48429 RVA: 0x00270978 File Offset: 0x0026EB78
		public override uint GetRpcType()
		{
			return 55720U;
		}

		// Token: 0x0600BD2E RID: 48430 RVA: 0x0027098F File Offset: 0x0026EB8F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetGuildBonusRewardArg>(stream, this.oArg);
		}

		// Token: 0x0600BD2F RID: 48431 RVA: 0x0027099F File Offset: 0x0026EB9F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetGuildBonusRewardResult>(stream);
		}

		// Token: 0x0600BD30 RID: 48432 RVA: 0x002709AE File Offset: 0x0026EBAE
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetGuildBonusReward.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600BD31 RID: 48433 RVA: 0x002709CA File Offset: 0x0026EBCA
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetGuildBonusReward.OnTimeout(this.oArg);
		}

		// Token: 0x04004D08 RID: 19720
		public GetGuildBonusRewardArg oArg = new GetGuildBonusRewardArg();

		// Token: 0x04004D09 RID: 19721
		public GetGuildBonusRewardResult oRes = new GetGuildBonusRewardResult();
	}
}
