using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200138E RID: 5006
	internal class RpcC2G_GetDailyTaskReward : Rpc
	{
		// Token: 0x0600E32E RID: 58158 RVA: 0x0033A050 File Offset: 0x00338250
		public override uint GetRpcType()
		{
			return 59899U;
		}

		// Token: 0x0600E32F RID: 58159 RVA: 0x0033A067 File Offset: 0x00338267
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetDailyTaskRewardArg>(stream, this.oArg);
		}

		// Token: 0x0600E330 RID: 58160 RVA: 0x0033A077 File Offset: 0x00338277
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetDailyTaskRewardRes>(stream);
		}

		// Token: 0x0600E331 RID: 58161 RVA: 0x0033A086 File Offset: 0x00338286
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetDailyTaskReward.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E332 RID: 58162 RVA: 0x0033A0A2 File Offset: 0x003382A2
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetDailyTaskReward.OnTimeout(this.oArg);
		}

		// Token: 0x040063E1 RID: 25569
		public GetDailyTaskRewardArg oArg = new GetDailyTaskRewardArg();

		// Token: 0x040063E2 RID: 25570
		public GetDailyTaskRewardRes oRes = new GetDailyTaskRewardRes();
	}
}
