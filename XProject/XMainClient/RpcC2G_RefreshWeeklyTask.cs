using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015F9 RID: 5625
	internal class RpcC2G_RefreshWeeklyTask : Rpc
	{
		// Token: 0x0600ED12 RID: 60690 RVA: 0x00347E24 File Offset: 0x00346024
		public override uint GetRpcType()
		{
			return 3384U;
		}

		// Token: 0x0600ED13 RID: 60691 RVA: 0x00347E3B File Offset: 0x0034603B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<RefreshWeeklyTaskArg>(stream, this.oArg);
		}

		// Token: 0x0600ED14 RID: 60692 RVA: 0x00347E4B File Offset: 0x0034604B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<RefreshWeeklyTaskRes>(stream);
		}

		// Token: 0x0600ED15 RID: 60693 RVA: 0x00347E5A File Offset: 0x0034605A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_RefreshWeeklyTask.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600ED16 RID: 60694 RVA: 0x00347E76 File Offset: 0x00346076
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_RefreshWeeklyTask.OnTimeout(this.oArg);
		}

		// Token: 0x040065CA RID: 26058
		public RefreshWeeklyTaskArg oArg = new RefreshWeeklyTaskArg();

		// Token: 0x040065CB RID: 26059
		public RefreshWeeklyTaskRes oRes = null;
	}
}
