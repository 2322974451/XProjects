using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011FB RID: 4603
	internal class PtcC2M_FMBRefuseC2M : Protocol
	{
		// Token: 0x0600DCB0 RID: 56496 RVA: 0x00330B34 File Offset: 0x0032ED34
		public override uint GetProtoType()
		{
			return 44407U;
		}

		// Token: 0x0600DCB1 RID: 56497 RVA: 0x00330B4B File Offset: 0x0032ED4B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FMBRes>(stream, this.Data);
		}

		// Token: 0x0600DCB2 RID: 56498 RVA: 0x00330B5B File Offset: 0x0032ED5B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<FMBRes>(stream);
		}

		// Token: 0x0600DCB3 RID: 56499 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x0400629D RID: 25245
		public FMBRes Data = new FMBRes();
	}
}
