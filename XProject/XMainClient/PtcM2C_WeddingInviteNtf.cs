using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015A0 RID: 5536
	internal class PtcM2C_WeddingInviteNtf : Protocol
	{
		// Token: 0x0600EBA9 RID: 60329 RVA: 0x0034620C File Offset: 0x0034440C
		public override uint GetProtoType()
		{
			return 35104U;
		}

		// Token: 0x0600EBAA RID: 60330 RVA: 0x00346223 File Offset: 0x00344423
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WeddingInviteNtf>(stream, this.Data);
		}

		// Token: 0x0600EBAB RID: 60331 RVA: 0x00346233 File Offset: 0x00344433
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<WeddingInviteNtf>(stream);
		}

		// Token: 0x0600EBAC RID: 60332 RVA: 0x00346242 File Offset: 0x00344442
		public override void Process()
		{
			Process_PtcM2C_WeddingInviteNtf.Process(this);
		}

		// Token: 0x04006588 RID: 25992
		public WeddingInviteNtf Data = new WeddingInviteNtf();
	}
}
