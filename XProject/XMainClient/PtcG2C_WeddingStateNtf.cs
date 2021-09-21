using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015AB RID: 5547
	internal class PtcG2C_WeddingStateNtf : Protocol
	{
		// Token: 0x0600EBD3 RID: 60371 RVA: 0x00346470 File Offset: 0x00344670
		public override uint GetProtoType()
		{
			return 30976U;
		}

		// Token: 0x0600EBD4 RID: 60372 RVA: 0x00346487 File Offset: 0x00344687
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WeddingStateNtf>(stream, this.Data);
		}

		// Token: 0x0600EBD5 RID: 60373 RVA: 0x00346497 File Offset: 0x00344697
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<WeddingStateNtf>(stream);
		}

		// Token: 0x0600EBD6 RID: 60374 RVA: 0x003464A6 File Offset: 0x003446A6
		public override void Process()
		{
			Process_PtcG2C_WeddingStateNtf.Process(this);
		}

		// Token: 0x0400658E RID: 25998
		public WeddingStateNtf Data = new WeddingStateNtf();
	}
}
