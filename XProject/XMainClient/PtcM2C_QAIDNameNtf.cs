using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001303 RID: 4867
	internal class PtcM2C_QAIDNameNtf : Protocol
	{
		// Token: 0x0600E0F8 RID: 57592 RVA: 0x00336D0C File Offset: 0x00334F0C
		public override uint GetProtoType()
		{
			return 987U;
		}

		// Token: 0x0600E0F9 RID: 57593 RVA: 0x00336D23 File Offset: 0x00334F23
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QAIDNameList>(stream, this.Data);
		}

		// Token: 0x0600E0FA RID: 57594 RVA: 0x00336D33 File Offset: 0x00334F33
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<QAIDNameList>(stream);
		}

		// Token: 0x0600E0FB RID: 57595 RVA: 0x00336D42 File Offset: 0x00334F42
		public override void Process()
		{
			Process_PtcM2C_QAIDNameNtf.Process(this);
		}

		// Token: 0x04006374 RID: 25460
		public QAIDNameList Data = new QAIDNameList();
	}
}
