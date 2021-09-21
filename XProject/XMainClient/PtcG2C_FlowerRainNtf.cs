using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200114C RID: 4428
	internal class PtcG2C_FlowerRainNtf : Protocol
	{
		// Token: 0x0600D9F9 RID: 55801 RVA: 0x0032C778 File Offset: 0x0032A978
		public override uint GetProtoType()
		{
			return 30604U;
		}

		// Token: 0x0600D9FA RID: 55802 RVA: 0x0032C78F File Offset: 0x0032A98F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReceiveFlowerData>(stream, this.Data);
		}

		// Token: 0x0600D9FB RID: 55803 RVA: 0x0032C79F File Offset: 0x0032A99F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ReceiveFlowerData>(stream);
		}

		// Token: 0x0600D9FC RID: 55804 RVA: 0x0032C7AE File Offset: 0x0032A9AE
		public override void Process()
		{
			Process_PtcG2C_FlowerRainNtf.Process(this);
		}

		// Token: 0x0400621F RID: 25119
		public ReceiveFlowerData Data = new ReceiveFlowerData();
	}
}
