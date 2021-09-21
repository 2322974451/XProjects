using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200145C RID: 5212
	internal class PtcG2C_IBShopHasBuyNtf : Protocol
	{
		// Token: 0x0600E677 RID: 58999 RVA: 0x0033E96C File Offset: 0x0033CB6C
		public override uint GetProtoType()
		{
			return 12835U;
		}

		// Token: 0x0600E678 RID: 59000 RVA: 0x0033E983 File Offset: 0x0033CB83
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<IBShopHasBuy>(stream, this.Data);
		}

		// Token: 0x0600E679 RID: 59001 RVA: 0x0033E993 File Offset: 0x0033CB93
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<IBShopHasBuy>(stream);
		}

		// Token: 0x0600E67A RID: 59002 RVA: 0x0033E9A2 File Offset: 0x0033CBA2
		public override void Process()
		{
			Process_PtcG2C_IBShopHasBuyNtf.Process(this);
		}

		// Token: 0x04006480 RID: 25728
		public IBShopHasBuy Data = new IBShopHasBuy();
	}
}
