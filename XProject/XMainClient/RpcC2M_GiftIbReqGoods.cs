using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014FE RID: 5374
	internal class RpcC2M_GiftIbReqGoods : Rpc
	{
		// Token: 0x0600E90D RID: 59661 RVA: 0x00342278 File Offset: 0x00340478
		public override uint GetRpcType()
		{
			return 18140U;
		}

		// Token: 0x0600E90E RID: 59662 RVA: 0x0034228F File Offset: 0x0034048F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GiftIbReqGoodsArg>(stream, this.oArg);
		}

		// Token: 0x0600E90F RID: 59663 RVA: 0x0034229F File Offset: 0x0034049F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GiftIbReqGoodsRes>(stream);
		}

		// Token: 0x0600E910 RID: 59664 RVA: 0x003422AE File Offset: 0x003404AE
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GiftIbReqGoods.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E911 RID: 59665 RVA: 0x003422CA File Offset: 0x003404CA
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GiftIbReqGoods.OnTimeout(this.oArg);
		}

		// Token: 0x040064FE RID: 25854
		public GiftIbReqGoodsArg oArg = new GiftIbReqGoodsArg();

		// Token: 0x040064FF RID: 25855
		public GiftIbReqGoodsRes oRes = null;
	}
}
