using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013C6 RID: 5062
	internal class PtcG2C_HorseAwardAllNtf : Protocol
	{
		// Token: 0x0600E414 RID: 58388 RVA: 0x0033B350 File Offset: 0x00339550
		public override uint GetProtoType()
		{
			return 5990U;
		}

		// Token: 0x0600E415 RID: 58389 RVA: 0x0033B367 File Offset: 0x00339567
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HorseAwardAll>(stream, this.Data);
		}

		// Token: 0x0600E416 RID: 58390 RVA: 0x0033B377 File Offset: 0x00339577
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HorseAwardAll>(stream);
		}

		// Token: 0x0600E417 RID: 58391 RVA: 0x0033B386 File Offset: 0x00339586
		public override void Process()
		{
			Process_PtcG2C_HorseAwardAllNtf.Process(this);
		}

		// Token: 0x0400640D RID: 25613
		public HorseAwardAll Data = new HorseAwardAll();
	}
}
