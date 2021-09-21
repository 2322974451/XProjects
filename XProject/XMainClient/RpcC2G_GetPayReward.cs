using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014A6 RID: 5286
	internal class RpcC2G_GetPayReward : Rpc
	{
		// Token: 0x0600E7A1 RID: 59297 RVA: 0x0034047C File Offset: 0x0033E67C
		public override uint GetRpcType()
		{
			return 63038U;
		}

		// Token: 0x0600E7A2 RID: 59298 RVA: 0x00340493 File Offset: 0x0033E693
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetPayRewardArg>(stream, this.oArg);
		}

		// Token: 0x0600E7A3 RID: 59299 RVA: 0x003404A3 File Offset: 0x0033E6A3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetPayRewardRes>(stream);
		}

		// Token: 0x0600E7A4 RID: 59300 RVA: 0x003404B2 File Offset: 0x0033E6B2
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetPayReward.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E7A5 RID: 59301 RVA: 0x003404CE File Offset: 0x0033E6CE
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetPayReward.OnTimeout(this.oArg);
		}

		// Token: 0x040064B7 RID: 25783
		public GetPayRewardArg oArg = new GetPayRewardArg();

		// Token: 0x040064B8 RID: 25784
		public GetPayRewardRes oRes = null;
	}
}
