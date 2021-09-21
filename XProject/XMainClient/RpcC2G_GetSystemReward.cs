using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200104B RID: 4171
	internal class RpcC2G_GetSystemReward : Rpc
	{
		// Token: 0x0600D5E0 RID: 54752 RVA: 0x003250F8 File Offset: 0x003232F8
		public override uint GetRpcType()
		{
			return 11595U;
		}

		// Token: 0x0600D5E1 RID: 54753 RVA: 0x0032510F File Offset: 0x0032330F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetSystemRewardArg>(stream, this.oArg);
		}

		// Token: 0x0600D5E2 RID: 54754 RVA: 0x0032511F File Offset: 0x0032331F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetSystemRewardRes>(stream);
		}

		// Token: 0x0600D5E3 RID: 54755 RVA: 0x0032512E File Offset: 0x0032332E
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetSystemReward.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D5E4 RID: 54756 RVA: 0x0032514A File Offset: 0x0032334A
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetSystemReward.OnTimeout(this.oArg);
		}

		// Token: 0x04006156 RID: 24918
		public GetSystemRewardArg oArg = new GetSystemRewardArg();

		// Token: 0x04006157 RID: 24919
		public GetSystemRewardRes oRes = new GetSystemRewardRes();
	}
}
