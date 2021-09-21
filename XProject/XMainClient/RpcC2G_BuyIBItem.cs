using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001245 RID: 4677
	internal class RpcC2G_BuyIBItem : Rpc
	{
		// Token: 0x0600DDE6 RID: 56806 RVA: 0x003328A0 File Offset: 0x00330AA0
		public override uint GetRpcType()
		{
			return 11547U;
		}

		// Token: 0x0600DDE7 RID: 56807 RVA: 0x003328B7 File Offset: 0x00330AB7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<IBBuyItemReq>(stream, this.oArg);
		}

		// Token: 0x0600DDE8 RID: 56808 RVA: 0x003328C7 File Offset: 0x00330AC7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<IBBuyItemRes>(stream);
		}

		// Token: 0x0600DDE9 RID: 56809 RVA: 0x003328D6 File Offset: 0x00330AD6
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_BuyIBItem.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DDEA RID: 56810 RVA: 0x003328F2 File Offset: 0x00330AF2
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_BuyIBItem.OnTimeout(this.oArg);
		}

		// Token: 0x040062DB RID: 25307
		public IBBuyItemReq oArg = new IBBuyItemReq();

		// Token: 0x040062DC RID: 25308
		public IBBuyItemRes oRes = new IBBuyItemRes();
	}
}
