using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013DE RID: 5086
	internal class PtcG2C_HorseFinalNtf : Protocol
	{
		// Token: 0x0600E476 RID: 58486 RVA: 0x0033BC78 File Offset: 0x00339E78
		public override uint GetProtoType()
		{
			return 57969U;
		}

		// Token: 0x0600E477 RID: 58487 RVA: 0x0033BC8F File Offset: 0x00339E8F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HorseFinal>(stream, this.Data);
		}

		// Token: 0x0600E478 RID: 58488 RVA: 0x0033BC9F File Offset: 0x00339E9F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HorseFinal>(stream);
		}

		// Token: 0x0600E479 RID: 58489 RVA: 0x0033BCAE File Offset: 0x00339EAE
		public override void Process()
		{
			Process_PtcG2C_HorseFinalNtf.Process(this);
		}

		// Token: 0x04006420 RID: 25632
		public HorseFinal Data = new HorseFinal();
	}
}
