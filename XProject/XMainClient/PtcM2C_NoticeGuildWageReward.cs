using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001348 RID: 4936
	internal class PtcM2C_NoticeGuildWageReward : Protocol
	{
		// Token: 0x0600E215 RID: 57877 RVA: 0x0033888C File Offset: 0x00336A8C
		public override uint GetProtoType()
		{
			return 29986U;
		}

		// Token: 0x0600E216 RID: 57878 RVA: 0x003388A3 File Offset: 0x00336AA3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NoticeGuildWageReward>(stream, this.Data);
		}

		// Token: 0x0600E217 RID: 57879 RVA: 0x003388B3 File Offset: 0x00336AB3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NoticeGuildWageReward>(stream);
		}

		// Token: 0x0600E218 RID: 57880 RVA: 0x003388C2 File Offset: 0x00336AC2
		public override void Process()
		{
			Process_PtcM2C_NoticeGuildWageReward.Process(this);
		}

		// Token: 0x040063AC RID: 25516
		public NoticeGuildWageReward Data = new NoticeGuildWageReward();
	}
}
