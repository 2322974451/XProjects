using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012FD RID: 4861
	internal class PtcC2M_CommitAnswerNtf : Protocol
	{
		// Token: 0x0600E0E0 RID: 57568 RVA: 0x00336B60 File Offset: 0x00334D60
		public override uint GetProtoType()
		{
			return 12159U;
		}

		// Token: 0x0600E0E1 RID: 57569 RVA: 0x00336B77 File Offset: 0x00334D77
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CommitAnswerNtf>(stream, this.Data);
		}

		// Token: 0x0600E0E2 RID: 57570 RVA: 0x00336B87 File Offset: 0x00334D87
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<CommitAnswerNtf>(stream);
		}

		// Token: 0x0600E0E3 RID: 57571 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x04006370 RID: 25456
		public CommitAnswerNtf Data = new CommitAnswerNtf();
	}
}
