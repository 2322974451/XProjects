using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200132B RID: 4907
	internal class PtcM2C_NoticeGuildArenaNextTime : Protocol
	{
		// Token: 0x0600E19A RID: 57754 RVA: 0x00337D14 File Offset: 0x00335F14
		public override uint GetProtoType()
		{
			return 21612U;
		}

		// Token: 0x0600E19B RID: 57755 RVA: 0x00337D2B File Offset: 0x00335F2B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NoticeGuildArenaNextTime>(stream, this.Data);
		}

		// Token: 0x0600E19C RID: 57756 RVA: 0x00337D3B File Offset: 0x00335F3B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NoticeGuildArenaNextTime>(stream);
		}

		// Token: 0x0600E19D RID: 57757 RVA: 0x00337D4A File Offset: 0x00335F4A
		public override void Process()
		{
			Process_PtcM2C_NoticeGuildArenaNextTime.Process(this);
		}

		// Token: 0x04006393 RID: 25491
		public NoticeGuildArenaNextTime Data = new NoticeGuildArenaNextTime();
	}
}
