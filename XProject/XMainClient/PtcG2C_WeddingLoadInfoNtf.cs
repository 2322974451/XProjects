using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015A9 RID: 5545
	internal class PtcG2C_WeddingLoadInfoNtf : Protocol
	{
		// Token: 0x0600EBCC RID: 60364 RVA: 0x0034640C File Offset: 0x0034460C
		public override uint GetProtoType()
		{
			return 61694U;
		}

		// Token: 0x0600EBCD RID: 60365 RVA: 0x00346423 File Offset: 0x00344623
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WeddingLoadInfoNtf>(stream, this.Data);
		}

		// Token: 0x0600EBCE RID: 60366 RVA: 0x00346433 File Offset: 0x00344633
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<WeddingLoadInfoNtf>(stream);
		}

		// Token: 0x0600EBCF RID: 60367 RVA: 0x00346442 File Offset: 0x00344642
		public override void Process()
		{
			Process_PtcG2C_WeddingLoadInfoNtf.Process(this);
		}

		// Token: 0x0400658D RID: 25997
		public WeddingLoadInfoNtf Data = new WeddingLoadInfoNtf();
	}
}
