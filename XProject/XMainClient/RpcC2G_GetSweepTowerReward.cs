using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200128A RID: 4746
	internal class RpcC2G_GetSweepTowerReward : Rpc
	{
		// Token: 0x0600DF02 RID: 57090 RVA: 0x00333F04 File Offset: 0x00332104
		public override uint GetRpcType()
		{
			return 23703U;
		}

		// Token: 0x0600DF03 RID: 57091 RVA: 0x00333F1B File Offset: 0x0033211B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetSweepTowerRewardArg>(stream, this.oArg);
		}

		// Token: 0x0600DF04 RID: 57092 RVA: 0x00333F2B File Offset: 0x0033212B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetSweepTowerRewardRes>(stream);
		}

		// Token: 0x0600DF05 RID: 57093 RVA: 0x00333F3A File Offset: 0x0033213A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetSweepTowerReward.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DF06 RID: 57094 RVA: 0x00333F56 File Offset: 0x00332156
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetSweepTowerReward.OnTimeout(this.oArg);
		}

		// Token: 0x04006312 RID: 25362
		public GetSweepTowerRewardArg oArg = new GetSweepTowerRewardArg();

		// Token: 0x04006313 RID: 25363
		public GetSweepTowerRewardRes oRes = new GetSweepTowerRewardRes();
	}
}
