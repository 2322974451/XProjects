using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011B1 RID: 4529
	internal class PtcM2C_BlackListNtfNew : Protocol
	{
		// Token: 0x0600DB8F RID: 56207 RVA: 0x0032F3D4 File Offset: 0x0032D5D4
		public override uint GetProtoType()
		{
			return 1537U;
		}

		// Token: 0x0600DB90 RID: 56208 RVA: 0x0032F3EB File Offset: 0x0032D5EB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BlackListNtf>(stream, this.Data);
		}

		// Token: 0x0600DB91 RID: 56209 RVA: 0x0032F3FB File Offset: 0x0032D5FB
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BlackListNtf>(stream);
		}

		// Token: 0x0600DB92 RID: 56210 RVA: 0x0032F40A File Offset: 0x0032D60A
		public override void Process()
		{
			Process_PtcM2C_BlackListNtfNew.Process(this);
		}

		// Token: 0x0400626A RID: 25194
		public BlackListNtf Data = new BlackListNtf();
	}
}
