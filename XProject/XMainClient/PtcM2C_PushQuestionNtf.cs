using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001305 RID: 4869
	internal class PtcM2C_PushQuestionNtf : Protocol
	{
		// Token: 0x0600E0FF RID: 57599 RVA: 0x00336D8C File Offset: 0x00334F8C
		public override uint GetProtoType()
		{
			return 45138U;
		}

		// Token: 0x0600E100 RID: 57600 RVA: 0x00336DA3 File Offset: 0x00334FA3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PushQuestionNtf>(stream, this.Data);
		}

		// Token: 0x0600E101 RID: 57601 RVA: 0x00336DB3 File Offset: 0x00334FB3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PushQuestionNtf>(stream);
		}

		// Token: 0x0600E102 RID: 57602 RVA: 0x00336DC2 File Offset: 0x00334FC2
		public override void Process()
		{
			Process_PtcM2C_PushQuestionNtf.Process(this);
		}

		// Token: 0x04006375 RID: 25461
		public PushQuestionNtf Data = new PushQuestionNtf();
	}
}
