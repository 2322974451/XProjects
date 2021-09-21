using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001346 RID: 4934
	internal class PtcG2C_GardenBanquetNotice : Protocol
	{
		// Token: 0x0600E20E RID: 57870 RVA: 0x00338828 File Offset: 0x00336A28
		public override uint GetProtoType()
		{
			return 36929U;
		}

		// Token: 0x0600E20F RID: 57871 RVA: 0x0033883F File Offset: 0x00336A3F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GardenBanquetNtf>(stream, this.Data);
		}

		// Token: 0x0600E210 RID: 57872 RVA: 0x0033884F File Offset: 0x00336A4F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GardenBanquetNtf>(stream);
		}

		// Token: 0x0600E211 RID: 57873 RVA: 0x0033885E File Offset: 0x00336A5E
		public override void Process()
		{
			Process_PtcG2C_GardenBanquetNotice.Process(this);
		}

		// Token: 0x040063AB RID: 25515
		public GardenBanquetNtf Data = new GardenBanquetNtf();
	}
}
