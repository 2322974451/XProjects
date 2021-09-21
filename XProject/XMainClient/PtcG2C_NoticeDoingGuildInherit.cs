using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013A4 RID: 5028
	internal class PtcG2C_NoticeDoingGuildInherit : Protocol
	{
		// Token: 0x0600E38E RID: 58254 RVA: 0x0033A850 File Offset: 0x00338A50
		public override uint GetProtoType()
		{
			return 61639U;
		}

		// Token: 0x0600E38F RID: 58255 RVA: 0x0033A867 File Offset: 0x00338A67
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NoticeDoingGuildInherit>(stream, this.Data);
		}

		// Token: 0x0600E390 RID: 58256 RVA: 0x0033A877 File Offset: 0x00338A77
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NoticeDoingGuildInherit>(stream);
		}

		// Token: 0x0600E391 RID: 58257 RVA: 0x0033A886 File Offset: 0x00338A86
		public override void Process()
		{
			Process_PtcG2C_NoticeDoingGuildInherit.Process(this);
		}

		// Token: 0x040063F5 RID: 25589
		public NoticeDoingGuildInherit Data = new NoticeDoingGuildInherit();
	}
}
