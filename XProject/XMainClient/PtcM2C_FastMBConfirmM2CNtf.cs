using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011F7 RID: 4599
	internal class PtcM2C_FastMBConfirmM2CNtf : Protocol
	{
		// Token: 0x0600DCA2 RID: 56482 RVA: 0x00330A48 File Offset: 0x0032EC48
		public override uint GetProtoType()
		{
			return 58099U;
		}

		// Token: 0x0600DCA3 RID: 56483 RVA: 0x00330A5F File Offset: 0x0032EC5F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FMBArg>(stream, this.Data);
		}

		// Token: 0x0600DCA4 RID: 56484 RVA: 0x00330A6F File Offset: 0x0032EC6F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<FMBArg>(stream);
		}

		// Token: 0x0600DCA5 RID: 56485 RVA: 0x00330A7E File Offset: 0x0032EC7E
		public override void Process()
		{
			Process_PtcM2C_FastMBConfirmM2CNtf.Process(this);
		}

		// Token: 0x0400629B RID: 25243
		public FMBArg Data = new FMBArg();
	}
}
