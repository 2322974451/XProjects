using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001307 RID: 4871
	internal class PtcM2C_QARoomRankNtf : Protocol
	{
		// Token: 0x0600E106 RID: 57606 RVA: 0x00336E18 File Offset: 0x00335018
		public override uint GetProtoType()
		{
			return 36888U;
		}

		// Token: 0x0600E107 RID: 57607 RVA: 0x00336E2F File Offset: 0x0033502F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QARoomRankNtf>(stream, this.Data);
		}

		// Token: 0x0600E108 RID: 57608 RVA: 0x00336E3F File Offset: 0x0033503F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<QARoomRankNtf>(stream);
		}

		// Token: 0x0600E109 RID: 57609 RVA: 0x00336E4E File Offset: 0x0033504E
		public override void Process()
		{
			Process_PtcM2C_QARoomRankNtf.Process(this);
		}

		// Token: 0x04006376 RID: 25462
		public QARoomRankNtf Data = new QARoomRankNtf();
	}
}
