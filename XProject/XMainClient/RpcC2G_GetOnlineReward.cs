using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001098 RID: 4248
	internal class RpcC2G_GetOnlineReward : Rpc
	{
		// Token: 0x0600D71E RID: 55070 RVA: 0x003272B4 File Offset: 0x003254B4
		public override uint GetRpcType()
		{
			return 21137U;
		}

		// Token: 0x0600D71F RID: 55071 RVA: 0x003272CB File Offset: 0x003254CB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetOnlineRewardArg>(stream, this.oArg);
		}

		// Token: 0x0600D720 RID: 55072 RVA: 0x003272DB File Offset: 0x003254DB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetOnlineRewardRes>(stream);
		}

		// Token: 0x0600D721 RID: 55073 RVA: 0x003272EA File Offset: 0x003254EA
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetOnlineReward.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D722 RID: 55074 RVA: 0x00327306 File Offset: 0x00325506
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetOnlineReward.OnTimeout(this.oArg);
		}

		// Token: 0x04006199 RID: 24985
		public GetOnlineRewardArg oArg = new GetOnlineRewardArg();

		// Token: 0x0400619A RID: 24986
		public GetOnlineRewardRes oRes = new GetOnlineRewardRes();
	}
}
