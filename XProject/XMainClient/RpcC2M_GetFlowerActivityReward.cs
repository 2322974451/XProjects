using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200152D RID: 5421
	internal class RpcC2M_GetFlowerActivityReward : Rpc
	{
		// Token: 0x0600E9CF RID: 59855 RVA: 0x0034342C File Offset: 0x0034162C
		public override uint GetRpcType()
		{
			return 36979U;
		}

		// Token: 0x0600E9D0 RID: 59856 RVA: 0x00343443 File Offset: 0x00341643
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetFlowerActivityRewardArg>(stream, this.oArg);
		}

		// Token: 0x0600E9D1 RID: 59857 RVA: 0x00343453 File Offset: 0x00341653
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetFlowerActivityRewardRes>(stream);
		}

		// Token: 0x0600E9D2 RID: 59858 RVA: 0x00343462 File Offset: 0x00341662
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetFlowerActivityReward.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E9D3 RID: 59859 RVA: 0x0034347E File Offset: 0x0034167E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetFlowerActivityReward.OnTimeout(this.oArg);
		}

		// Token: 0x04006524 RID: 25892
		public GetFlowerActivityRewardArg oArg = new GetFlowerActivityRewardArg();

		// Token: 0x04006525 RID: 25893
		public GetFlowerActivityRewardRes oRes = null;
	}
}
