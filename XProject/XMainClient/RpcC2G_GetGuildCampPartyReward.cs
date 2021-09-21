using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014FC RID: 5372
	internal class RpcC2G_GetGuildCampPartyReward : Rpc
	{
		// Token: 0x0600E904 RID: 59652 RVA: 0x00342164 File Offset: 0x00340364
		public override uint GetRpcType()
		{
			return 58935U;
		}

		// Token: 0x0600E905 RID: 59653 RVA: 0x0034217B File Offset: 0x0034037B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetGuildCampPartyRewardArg>(stream, this.oArg);
		}

		// Token: 0x0600E906 RID: 59654 RVA: 0x0034218B File Offset: 0x0034038B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetGuildCampPartyRewardRes>(stream);
		}

		// Token: 0x0600E907 RID: 59655 RVA: 0x0034219A File Offset: 0x0034039A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetGuildCampPartyReward.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E908 RID: 59656 RVA: 0x003421B6 File Offset: 0x003403B6
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetGuildCampPartyReward.OnTimeout(this.oArg);
		}

		// Token: 0x040064FC RID: 25852
		public GetGuildCampPartyRewardArg oArg = new GetGuildCampPartyRewardArg();

		// Token: 0x040064FD RID: 25853
		public GetGuildCampPartyRewardRes oRes = null;
	}
}
