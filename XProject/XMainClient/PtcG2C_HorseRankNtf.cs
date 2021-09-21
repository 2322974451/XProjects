using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013C8 RID: 5064
	internal class PtcG2C_HorseRankNtf : Protocol
	{
		// Token: 0x0600E41B RID: 58395 RVA: 0x0033B3A8 File Offset: 0x003395A8
		public override uint GetProtoType()
		{
			return 22250U;
		}

		// Token: 0x0600E41C RID: 58396 RVA: 0x0033B3BF File Offset: 0x003395BF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HorseRank>(stream, this.Data);
		}

		// Token: 0x0600E41D RID: 58397 RVA: 0x0033B3CF File Offset: 0x003395CF
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HorseRank>(stream);
		}

		// Token: 0x0600E41E RID: 58398 RVA: 0x0033B3DE File Offset: 0x003395DE
		public override void Process()
		{
			Process_PtcG2C_HorseRankNtf.Process(this);
		}

		// Token: 0x0400640E RID: 25614
		public HorseRank Data = new HorseRank();
	}
}
