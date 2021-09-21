using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014BD RID: 5309
	internal class PtcG2C_GiftIBBackInfoNtf : Protocol
	{
		// Token: 0x0600E7FD RID: 59389 RVA: 0x00340C38 File Offset: 0x0033EE38
		public override uint GetProtoType()
		{
			return 6953U;
		}

		// Token: 0x0600E7FE RID: 59390 RVA: 0x00340C4F File Offset: 0x0033EE4F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GiftIBBackInfo>(stream, this.Data);
		}

		// Token: 0x0600E7FF RID: 59391 RVA: 0x00340C5F File Offset: 0x0033EE5F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GiftIBBackInfo>(stream);
		}

		// Token: 0x0600E800 RID: 59392 RVA: 0x00340C6E File Offset: 0x0033EE6E
		public override void Process()
		{
			Process_PtcG2C_GiftIBBackInfoNtf.Process(this);
		}

		// Token: 0x040064C8 RID: 25800
		public GiftIBBackInfo Data = new GiftIBBackInfo();
	}
}
