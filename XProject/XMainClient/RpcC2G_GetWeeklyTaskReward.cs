using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015F7 RID: 5623
	internal class RpcC2G_GetWeeklyTaskReward : Rpc
	{
		// Token: 0x0600ED09 RID: 60681 RVA: 0x00347D64 File Offset: 0x00345F64
		public override uint GetRpcType()
		{
			return 30588U;
		}

		// Token: 0x0600ED0A RID: 60682 RVA: 0x00347D7B File Offset: 0x00345F7B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetWeeklyTaskRewardArg>(stream, this.oArg);
		}

		// Token: 0x0600ED0B RID: 60683 RVA: 0x00347D8B File Offset: 0x00345F8B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetWeeklyTaskRewardRes>(stream);
		}

		// Token: 0x0600ED0C RID: 60684 RVA: 0x00347D9A File Offset: 0x00345F9A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetWeeklyTaskReward.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600ED0D RID: 60685 RVA: 0x00347DB6 File Offset: 0x00345FB6
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetWeeklyTaskReward.OnTimeout(this.oArg);
		}

		// Token: 0x040065C8 RID: 26056
		public GetWeeklyTaskRewardArg oArg = new GetWeeklyTaskRewardArg();

		// Token: 0x040065C9 RID: 26057
		public GetWeeklyTaskRewardRes oRes = null;
	}
}
