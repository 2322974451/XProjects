using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001566 RID: 5478
	internal class PtcG2C_MobaHintNtf : Protocol
	{
		// Token: 0x0600EAB0 RID: 60080 RVA: 0x00344B14 File Offset: 0x00342D14
		public override uint GetProtoType()
		{
			return 17027U;
		}

		// Token: 0x0600EAB1 RID: 60081 RVA: 0x00344B2B File Offset: 0x00342D2B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MobaHintNtf>(stream, this.Data);
		}

		// Token: 0x0600EAB2 RID: 60082 RVA: 0x00344B3B File Offset: 0x00342D3B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<MobaHintNtf>(stream);
		}

		// Token: 0x0600EAB3 RID: 60083 RVA: 0x00344B4A File Offset: 0x00342D4A
		public override void Process()
		{
			Process_PtcG2C_MobaHintNtf.Process(this);
		}

		// Token: 0x04006554 RID: 25940
		public MobaHintNtf Data = new MobaHintNtf();
	}
}
