using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001301 RID: 4865
	internal class PtcM2C_AnswerAckNtf : Protocol
	{
		// Token: 0x0600E0F1 RID: 57585 RVA: 0x00336C90 File Offset: 0x00334E90
		public override uint GetProtoType()
		{
			return 60141U;
		}

		// Token: 0x0600E0F2 RID: 57586 RVA: 0x00336CA7 File Offset: 0x00334EA7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AnswerAckNtf>(stream, this.Data);
		}

		// Token: 0x0600E0F3 RID: 57587 RVA: 0x00336CB7 File Offset: 0x00334EB7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<AnswerAckNtf>(stream);
		}

		// Token: 0x0600E0F4 RID: 57588 RVA: 0x00336CC6 File Offset: 0x00334EC6
		public override void Process()
		{
			Process_PtcM2C_AnswerAckNtf.Process(this);
		}

		// Token: 0x04006373 RID: 25459
		public AnswerAckNtf Data = new AnswerAckNtf();
	}
}
