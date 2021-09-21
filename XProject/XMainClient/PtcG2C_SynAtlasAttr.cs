using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200124F RID: 4687
	internal class PtcG2C_SynAtlasAttr : Protocol
	{
		// Token: 0x0600DE0F RID: 56847 RVA: 0x00332C88 File Offset: 0x00330E88
		public override uint GetProtoType()
		{
			return 1285U;
		}

		// Token: 0x0600DE10 RID: 56848 RVA: 0x00332C9F File Offset: 0x00330E9F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AllSynCardAttr>(stream, this.Data);
		}

		// Token: 0x0600DE11 RID: 56849 RVA: 0x00332CAF File Offset: 0x00330EAF
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<AllSynCardAttr>(stream);
		}

		// Token: 0x0600DE12 RID: 56850 RVA: 0x00332CBE File Offset: 0x00330EBE
		public override void Process()
		{
			Process_PtcG2C_SynAtlasAttr.Process(this);
		}

		// Token: 0x040062E3 RID: 25315
		public AllSynCardAttr Data = new AllSynCardAttr();
	}
}
