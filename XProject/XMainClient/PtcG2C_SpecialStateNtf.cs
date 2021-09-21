using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001448 RID: 5192
	internal class PtcG2C_SpecialStateNtf : Protocol
	{
		// Token: 0x0600E62B RID: 58923 RVA: 0x0033E0A4 File Offset: 0x0033C2A4
		public override uint GetProtoType()
		{
			return 11703U;
		}

		// Token: 0x0600E62C RID: 58924 RVA: 0x0033E0BB File Offset: 0x0033C2BB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SpecialStateNtf>(stream, this.Data);
		}

		// Token: 0x0600E62D RID: 58925 RVA: 0x0033E0CB File Offset: 0x0033C2CB
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SpecialStateNtf>(stream);
		}

		// Token: 0x0600E62E RID: 58926 RVA: 0x0033E0DA File Offset: 0x0033C2DA
		public override void Process()
		{
			Process_PtcG2C_SpecialStateNtf.Process(this);
		}

		// Token: 0x04006474 RID: 25716
		public SpecialStateNtf Data = new SpecialStateNtf();
	}
}
