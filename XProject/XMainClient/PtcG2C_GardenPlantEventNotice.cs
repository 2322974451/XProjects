using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001335 RID: 4917
	internal class PtcG2C_GardenPlantEventNotice : Protocol
	{
		// Token: 0x0600E1C3 RID: 57795 RVA: 0x00338114 File Offset: 0x00336314
		public override uint GetProtoType()
		{
			return 60686U;
		}

		// Token: 0x0600E1C4 RID: 57796 RVA: 0x0033812B File Offset: 0x0033632B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GardenPlantEventNoticeArg>(stream, this.Data);
		}

		// Token: 0x0600E1C5 RID: 57797 RVA: 0x0033813B File Offset: 0x0033633B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GardenPlantEventNoticeArg>(stream);
		}

		// Token: 0x0600E1C6 RID: 57798 RVA: 0x0033814A File Offset: 0x0033634A
		public override void Process()
		{
			Process_PtcG2C_GardenPlantEventNotice.Process(this);
		}

		// Token: 0x0400639B RID: 25499
		public GardenPlantEventNoticeArg Data = new GardenPlantEventNoticeArg();
	}
}
