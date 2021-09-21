using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012FF RID: 4863
	internal class PtcM2C_QAOverNtf : Protocol
	{
		// Token: 0x0600E0EA RID: 57578 RVA: 0x00336BF8 File Offset: 0x00334DF8
		public override uint GetProtoType()
		{
			return 29361U;
		}

		// Token: 0x0600E0EB RID: 57579 RVA: 0x00336C0F File Offset: 0x00334E0F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QAOverNtf>(stream, this.Data);
		}

		// Token: 0x0600E0EC RID: 57580 RVA: 0x00336C1F File Offset: 0x00334E1F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<QAOverNtf>(stream);
		}

		// Token: 0x0600E0ED RID: 57581 RVA: 0x00336C2E File Offset: 0x00334E2E
		public override void Process()
		{
			Process_PtcM2C_QAOverNtf.Process(this);
		}

		// Token: 0x04006372 RID: 25458
		public QAOverNtf Data = new QAOverNtf();
	}
}
