using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200156A RID: 5482
	internal class RpcC2M_GetMobaBattleWeekReward : Rpc
	{
		// Token: 0x0600EAC0 RID: 60096 RVA: 0x00344C58 File Offset: 0x00342E58
		public override uint GetRpcType()
		{
			return 55678U;
		}

		// Token: 0x0600EAC1 RID: 60097 RVA: 0x00344C6F File Offset: 0x00342E6F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetMobaBattleWeekRewardArg>(stream, this.oArg);
		}

		// Token: 0x0600EAC2 RID: 60098 RVA: 0x00344C7F File Offset: 0x00342E7F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetMobaBattleWeekRewardRes>(stream);
		}

		// Token: 0x0600EAC3 RID: 60099 RVA: 0x00344C8E File Offset: 0x00342E8E
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetMobaBattleWeekReward.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EAC4 RID: 60100 RVA: 0x00344CAA File Offset: 0x00342EAA
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetMobaBattleWeekReward.OnTimeout(this.oArg);
		}

		// Token: 0x04006557 RID: 25943
		public GetMobaBattleWeekRewardArg oArg = new GetMobaBattleWeekRewardArg();

		// Token: 0x04006558 RID: 25944
		public GetMobaBattleWeekRewardRes oRes = null;
	}
}
