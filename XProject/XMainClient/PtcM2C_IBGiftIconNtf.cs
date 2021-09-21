using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014F6 RID: 5366
	internal class PtcM2C_IBGiftIconNtf : Protocol
	{
		// Token: 0x0600E8ED RID: 59629 RVA: 0x00341F78 File Offset: 0x00340178
		public override uint GetProtoType()
		{
			return 44659U;
		}

		// Token: 0x0600E8EE RID: 59630 RVA: 0x00341F8F File Offset: 0x0034018F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<IBGiftIcon>(stream, this.Data);
		}

		// Token: 0x0600E8EF RID: 59631 RVA: 0x00341F9F File Offset: 0x0034019F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<IBGiftIcon>(stream);
		}

		// Token: 0x0600E8F0 RID: 59632 RVA: 0x00341FAE File Offset: 0x003401AE
		public override void Process()
		{
			Process_PtcM2C_IBGiftIconNtf.Process(this);
		}

		// Token: 0x040064F8 RID: 25848
		public IBGiftIcon Data = new IBGiftIcon();
	}
}
