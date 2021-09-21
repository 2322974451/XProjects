using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011F9 RID: 4601
	internal class PtcM2C_fastMBDismissM2CNtf : Protocol
	{
		// Token: 0x0600DCA9 RID: 56489 RVA: 0x00330AA0 File Offset: 0x0032ECA0
		public override uint GetProtoType()
		{
			return 38301U;
		}

		// Token: 0x0600DCAA RID: 56490 RVA: 0x00330AB7 File Offset: 0x0032ECB7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FMDArg>(stream, this.Data);
		}

		// Token: 0x0600DCAB RID: 56491 RVA: 0x00330AC7 File Offset: 0x0032ECC7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<FMDArg>(stream);
		}

		// Token: 0x0600DCAC RID: 56492 RVA: 0x00330AD6 File Offset: 0x0032ECD6
		public override void Process()
		{
			Process_PtcM2C_fastMBDismissM2CNtf.Process(this);
		}

		// Token: 0x0400629C RID: 25244
		public FMDArg Data = new FMDArg();
	}
}
