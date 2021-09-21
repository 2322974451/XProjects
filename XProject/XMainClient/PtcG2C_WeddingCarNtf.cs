using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015D3 RID: 5587
	internal class PtcG2C_WeddingCarNtf : Protocol
	{
		// Token: 0x0600EC76 RID: 60534 RVA: 0x0034722C File Offset: 0x0034542C
		public override uint GetProtoType()
		{
			return 48301U;
		}

		// Token: 0x0600EC77 RID: 60535 RVA: 0x00347243 File Offset: 0x00345443
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WeddingCarNotify>(stream, this.Data);
		}

		// Token: 0x0600EC78 RID: 60536 RVA: 0x00347253 File Offset: 0x00345453
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<WeddingCarNotify>(stream);
		}

		// Token: 0x0600EC79 RID: 60537 RVA: 0x00347262 File Offset: 0x00345462
		public override void Process()
		{
			Process_PtcG2C_WeddingCarNtf.Process(this);
		}

		// Token: 0x040065AC RID: 26028
		public WeddingCarNotify Data = new WeddingCarNotify();
	}
}
