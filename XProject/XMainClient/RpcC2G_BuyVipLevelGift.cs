using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001208 RID: 4616
	internal class RpcC2G_BuyVipLevelGift : Rpc
	{
		// Token: 0x0600DCE7 RID: 56551 RVA: 0x00330F6C File Offset: 0x0032F16C
		public override uint GetRpcType()
		{
			return 52536U;
		}

		// Token: 0x0600DCE8 RID: 56552 RVA: 0x00330F83 File Offset: 0x0032F183
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BuyVipLevelGiftArg>(stream, this.oArg);
		}

		// Token: 0x0600DCE9 RID: 56553 RVA: 0x00330F93 File Offset: 0x0032F193
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BuyVipLevelGiftRes>(stream);
		}

		// Token: 0x0600DCEA RID: 56554 RVA: 0x00330FA2 File Offset: 0x0032F1A2
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_BuyVipLevelGift.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DCEB RID: 56555 RVA: 0x00330FBE File Offset: 0x0032F1BE
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_BuyVipLevelGift.OnTimeout(this.oArg);
		}

		// Token: 0x040062A8 RID: 25256
		public BuyVipLevelGiftArg oArg = new BuyVipLevelGiftArg();

		// Token: 0x040062A9 RID: 25257
		public BuyVipLevelGiftRes oRes = new BuyVipLevelGiftRes();
	}
}
