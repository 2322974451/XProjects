using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001053 RID: 4179
	internal class RpcC2G_BuyShopItem : Rpc
	{
		// Token: 0x0600D604 RID: 54788 RVA: 0x003256A0 File Offset: 0x003238A0
		public override uint GetRpcType()
		{
			return 33881U;
		}

		// Token: 0x0600D605 RID: 54789 RVA: 0x003256B7 File Offset: 0x003238B7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BuyShopItemArg>(stream, this.oArg);
		}

		// Token: 0x0600D606 RID: 54790 RVA: 0x003256C7 File Offset: 0x003238C7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BuyShopItemRes>(stream);
		}

		// Token: 0x0600D607 RID: 54791 RVA: 0x003256D6 File Offset: 0x003238D6
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_BuyShopItem.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D608 RID: 54792 RVA: 0x003256F2 File Offset: 0x003238F2
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_BuyShopItem.OnTimeout(this.oArg);
		}

		// Token: 0x0400615E RID: 24926
		public BuyShopItemArg oArg = new BuyShopItemArg();

		// Token: 0x0400615F RID: 24927
		public BuyShopItemRes oRes = new BuyShopItemRes();
	}
}
