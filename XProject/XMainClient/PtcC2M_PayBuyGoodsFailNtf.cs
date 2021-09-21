using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014CF RID: 5327
	internal class PtcC2M_PayBuyGoodsFailNtf : Protocol
	{
		// Token: 0x0600E846 RID: 59462 RVA: 0x00341228 File Offset: 0x0033F428
		public override uint GetProtoType()
		{
			return 23670U;
		}

		// Token: 0x0600E847 RID: 59463 RVA: 0x0034123F File Offset: 0x0033F43F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PayBuyGoodsFail>(stream, this.Data);
		}

		// Token: 0x0600E848 RID: 59464 RVA: 0x0034124F File Offset: 0x0033F44F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PayBuyGoodsFail>(stream);
		}

		// Token: 0x0600E849 RID: 59465 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x040064D6 RID: 25814
		public PayBuyGoodsFail Data = new PayBuyGoodsFail();
	}
}
