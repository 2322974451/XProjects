using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200109A RID: 4250
	internal class RpcC2G_GetNextDayReward : Rpc
	{
		// Token: 0x0600D727 RID: 55079 RVA: 0x003273B4 File Offset: 0x003255B4
		public override uint GetRpcType()
		{
			return 40997U;
		}

		// Token: 0x0600D728 RID: 55080 RVA: 0x003273CB File Offset: 0x003255CB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetNextDayRewardArg>(stream, this.oArg);
		}

		// Token: 0x0600D729 RID: 55081 RVA: 0x003273DB File Offset: 0x003255DB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetNextDayRewardRes>(stream);
		}

		// Token: 0x0600D72A RID: 55082 RVA: 0x003273EA File Offset: 0x003255EA
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetNextDayReward.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D72B RID: 55083 RVA: 0x00327406 File Offset: 0x00325606
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetNextDayReward.OnTimeout(this.oArg);
		}

		// Token: 0x0400619B RID: 24987
		public GetNextDayRewardArg oArg = new GetNextDayRewardArg();

		// Token: 0x0400619C RID: 24988
		public GetNextDayRewardRes oRes = new GetNextDayRewardRes();
	}
}
