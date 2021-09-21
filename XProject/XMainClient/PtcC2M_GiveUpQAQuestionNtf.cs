using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012FE RID: 4862
	internal class PtcC2M_GiveUpQAQuestionNtf : Protocol
	{
		// Token: 0x0600E0E5 RID: 57573 RVA: 0x00336BAC File Offset: 0x00334DAC
		public override uint GetProtoType()
		{
			return 17022U;
		}

		// Token: 0x0600E0E6 RID: 57574 RVA: 0x00336BC3 File Offset: 0x00334DC3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GiveUpQuestionNtf>(stream, this.Data);
		}

		// Token: 0x0600E0E7 RID: 57575 RVA: 0x00336BD3 File Offset: 0x00334DD3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GiveUpQuestionNtf>(stream);
		}

		// Token: 0x0600E0E8 RID: 57576 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x04006371 RID: 25457
		public GiveUpQuestionNtf Data = new GiveUpQuestionNtf();
	}
}
