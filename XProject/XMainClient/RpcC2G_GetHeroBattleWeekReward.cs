using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001459 RID: 5209
	internal class RpcC2G_GetHeroBattleWeekReward : Rpc
	{
		// Token: 0x0600E66C RID: 58988 RVA: 0x0033E768 File Offset: 0x0033C968
		public override uint GetRpcType()
		{
			return 63058U;
		}

		// Token: 0x0600E66D RID: 58989 RVA: 0x0033E77F File Offset: 0x0033C97F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetHeroBattleWeekRewardArg>(stream, this.oArg);
		}

		// Token: 0x0600E66E RID: 58990 RVA: 0x0033E78F File Offset: 0x0033C98F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetHeroBattleWeekRewardRes>(stream);
		}

		// Token: 0x0600E66F RID: 58991 RVA: 0x0033E79E File Offset: 0x0033C99E
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetHeroBattleWeekReward.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E670 RID: 58992 RVA: 0x0033E7BA File Offset: 0x0033C9BA
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetHeroBattleWeekReward.OnTimeout(this.oArg);
		}

		// Token: 0x0400647E RID: 25726
		public GetHeroBattleWeekRewardArg oArg = new GetHeroBattleWeekRewardArg();

		// Token: 0x0400647F RID: 25727
		public GetHeroBattleWeekRewardRes oRes = null;
	}
}
