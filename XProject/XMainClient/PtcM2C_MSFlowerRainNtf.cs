using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011F1 RID: 4593
	internal class PtcM2C_MSFlowerRainNtf : Protocol
	{
		// Token: 0x0600DC8B RID: 56459 RVA: 0x00330864 File Offset: 0x0032EA64
		public override uint GetProtoType()
		{
			return 11986U;
		}

		// Token: 0x0600DC8C RID: 56460 RVA: 0x0033087B File Offset: 0x0032EA7B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReceiveFlowerData>(stream, this.Data);
		}

		// Token: 0x0600DC8D RID: 56461 RVA: 0x0033088B File Offset: 0x0032EA8B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ReceiveFlowerData>(stream);
		}

		// Token: 0x0600DC8E RID: 56462 RVA: 0x0033089A File Offset: 0x0032EA9A
		public override void Process()
		{
			Process_PtcM2C_MSFlowerRainNtf.Process(this);
		}

		// Token: 0x04006297 RID: 25239
		public ReceiveFlowerData Data = new ReceiveFlowerData();
	}
}
