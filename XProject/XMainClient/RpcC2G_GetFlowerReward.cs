using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200112F RID: 4399
	internal class RpcC2G_GetFlowerReward : Rpc
	{
		// Token: 0x0600D97E RID: 55678 RVA: 0x0032B2BC File Offset: 0x003294BC
		public override uint GetRpcType()
		{
			return 65090U;
		}

		// Token: 0x0600D97F RID: 55679 RVA: 0x0032B2D3 File Offset: 0x003294D3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetFlowerRewardArg>(stream, this.oArg);
		}

		// Token: 0x0600D980 RID: 55680 RVA: 0x0032B2E3 File Offset: 0x003294E3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetFlowerRewardRes>(stream);
		}

		// Token: 0x0600D981 RID: 55681 RVA: 0x0032B2F2 File Offset: 0x003294F2
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetFlowerReward.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D982 RID: 55682 RVA: 0x0032B30E File Offset: 0x0032950E
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetFlowerReward.OnTimeout(this.oArg);
		}

		// Token: 0x04006206 RID: 25094
		public GetFlowerRewardArg oArg = new GetFlowerRewardArg();

		// Token: 0x04006207 RID: 25095
		public GetFlowerRewardRes oRes = new GetFlowerRewardRes();
	}
}
