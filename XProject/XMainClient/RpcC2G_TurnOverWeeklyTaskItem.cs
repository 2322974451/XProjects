using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001607 RID: 5639
	internal class RpcC2G_TurnOverWeeklyTaskItem : Rpc
	{
		// Token: 0x0600ED4D RID: 60749 RVA: 0x00348230 File Offset: 0x00346430
		public override uint GetRpcType()
		{
			return 19937U;
		}

		// Token: 0x0600ED4E RID: 60750 RVA: 0x00348247 File Offset: 0x00346447
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TurnOverWeeklyTaskItemArg>(stream, this.oArg);
		}

		// Token: 0x0600ED4F RID: 60751 RVA: 0x00348257 File Offset: 0x00346457
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<TurnOverWeeklyTaskItemRes>(stream);
		}

		// Token: 0x0600ED50 RID: 60752 RVA: 0x00348266 File Offset: 0x00346466
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_TurnOverWeeklyTaskItem.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600ED51 RID: 60753 RVA: 0x00348282 File Offset: 0x00346482
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_TurnOverWeeklyTaskItem.OnTimeout(this.oArg);
		}

		// Token: 0x040065D6 RID: 26070
		public TurnOverWeeklyTaskItemArg oArg = new TurnOverWeeklyTaskItemArg();

		// Token: 0x040065D7 RID: 26071
		public TurnOverWeeklyTaskItemRes oRes = null;
	}
}
