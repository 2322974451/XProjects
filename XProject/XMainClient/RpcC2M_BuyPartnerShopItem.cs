using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001408 RID: 5128
	internal class RpcC2M_BuyPartnerShopItem : Rpc
	{
		// Token: 0x0600E526 RID: 58662 RVA: 0x0033C950 File Offset: 0x0033AB50
		public override uint GetRpcType()
		{
			return 14493U;
		}

		// Token: 0x0600E527 RID: 58663 RVA: 0x0033C967 File Offset: 0x0033AB67
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BuyPartnerShopItemArg>(stream, this.oArg);
		}

		// Token: 0x0600E528 RID: 58664 RVA: 0x0033C977 File Offset: 0x0033AB77
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BuyPartnerShopItemRes>(stream);
		}

		// Token: 0x0600E529 RID: 58665 RVA: 0x0033C986 File Offset: 0x0033AB86
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_BuyPartnerShopItem.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E52A RID: 58666 RVA: 0x0033C9A2 File Offset: 0x0033ABA2
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_BuyPartnerShopItem.OnTimeout(this.oArg);
		}

		// Token: 0x04006443 RID: 25667
		public BuyPartnerShopItemArg oArg = new BuyPartnerShopItemArg();

		// Token: 0x04006444 RID: 25668
		public BuyPartnerShopItemRes oRes = null;
	}
}
