using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001416 RID: 5142
	internal class RpcC2M_GetPartnerShopRecord : Rpc
	{
		// Token: 0x0600E55F RID: 58719 RVA: 0x0033CE4C File Offset: 0x0033B04C
		public override uint GetRpcType()
		{
			return 56970U;
		}

		// Token: 0x0600E560 RID: 58720 RVA: 0x0033CE63 File Offset: 0x0033B063
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetPartnerShopRecordArg>(stream, this.oArg);
		}

		// Token: 0x0600E561 RID: 58721 RVA: 0x0033CE73 File Offset: 0x0033B073
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetPartnerShopRecordRes>(stream);
		}

		// Token: 0x0600E562 RID: 58722 RVA: 0x0033CE82 File Offset: 0x0033B082
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetPartnerShopRecord.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E563 RID: 58723 RVA: 0x0033CE9E File Offset: 0x0033B09E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetPartnerShopRecord.OnTimeout(this.oArg);
		}

		// Token: 0x0400644E RID: 25678
		public GetPartnerShopRecordArg oArg = new GetPartnerShopRecordArg();

		// Token: 0x0400644F RID: 25679
		public GetPartnerShopRecordRes oRes = null;
	}
}
