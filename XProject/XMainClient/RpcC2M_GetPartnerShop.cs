using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001406 RID: 5126
	internal class RpcC2M_GetPartnerShop : Rpc
	{
		// Token: 0x0600E51D RID: 58653 RVA: 0x0033C8AC File Offset: 0x0033AAAC
		public override uint GetRpcType()
		{
			return 46131U;
		}

		// Token: 0x0600E51E RID: 58654 RVA: 0x0033C8C3 File Offset: 0x0033AAC3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetPartnerShopArg>(stream, this.oArg);
		}

		// Token: 0x0600E51F RID: 58655 RVA: 0x0033C8D3 File Offset: 0x0033AAD3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetPartnerShopRes>(stream);
		}

		// Token: 0x0600E520 RID: 58656 RVA: 0x0033C8E2 File Offset: 0x0033AAE2
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetPartnerShop.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E521 RID: 58657 RVA: 0x0033C8FE File Offset: 0x0033AAFE
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetPartnerShop.OnTimeout(this.oArg);
		}

		// Token: 0x04006441 RID: 25665
		public GetPartnerShopArg oArg = new GetPartnerShopArg();

		// Token: 0x04006442 RID: 25666
		public GetPartnerShopRes oRes = null;
	}
}
