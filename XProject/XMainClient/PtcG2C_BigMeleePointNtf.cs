using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200165D RID: 5725
	internal class PtcG2C_BigMeleePointNtf : Protocol
	{
		// Token: 0x0600EEC3 RID: 61123 RVA: 0x0034A400 File Offset: 0x00348600
		public override uint GetProtoType()
		{
			return 15624U;
		}

		// Token: 0x0600EEC4 RID: 61124 RVA: 0x0034A417 File Offset: 0x00348617
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BigMeleePoint>(stream, this.Data);
		}

		// Token: 0x0600EEC5 RID: 61125 RVA: 0x0034A427 File Offset: 0x00348627
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BigMeleePoint>(stream);
		}

		// Token: 0x0600EEC6 RID: 61126 RVA: 0x0034A436 File Offset: 0x00348636
		public override void Process()
		{
			Process_PtcG2C_BigMeleePointNtf.Process(this);
		}

		// Token: 0x04006625 RID: 26149
		public BigMeleePoint Data = new BigMeleePoint();
	}
}
