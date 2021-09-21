using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001676 RID: 5750
	internal class PtcG2C_PayGiftNtf : Protocol
	{
		// Token: 0x0600EF26 RID: 61222 RVA: 0x0034AD44 File Offset: 0x00348F44
		public override uint GetProtoType()
		{
			return 51433U;
		}

		// Token: 0x0600EF27 RID: 61223 RVA: 0x0034AD5B File Offset: 0x00348F5B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PayGiftNtfData>(stream, this.Data);
		}

		// Token: 0x0600EF28 RID: 61224 RVA: 0x0034AD6B File Offset: 0x00348F6B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PayGiftNtfData>(stream);
		}

		// Token: 0x0600EF29 RID: 61225 RVA: 0x0034AD7A File Offset: 0x00348F7A
		public override void Process()
		{
			Process_PtcG2C_PayGiftNtf.Process(this);
		}

		// Token: 0x0400663E RID: 26174
		public PayGiftNtfData Data = new PayGiftNtfData();
	}
}
