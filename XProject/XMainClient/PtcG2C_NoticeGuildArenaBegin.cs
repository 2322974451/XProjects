using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200118E RID: 4494
	internal class PtcG2C_NoticeGuildArenaBegin : Protocol
	{
		// Token: 0x0600DB02 RID: 56066 RVA: 0x0032E5E0 File Offset: 0x0032C7E0
		public override uint GetProtoType()
		{
			return 11695U;
		}

		// Token: 0x0600DB03 RID: 56067 RVA: 0x0032E5F7 File Offset: 0x0032C7F7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NoticeGuildArenaBegin>(stream, this.Data);
		}

		// Token: 0x0600DB04 RID: 56068 RVA: 0x0032E607 File Offset: 0x0032C807
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NoticeGuildArenaBegin>(stream);
		}

		// Token: 0x0600DB05 RID: 56069 RVA: 0x0032E616 File Offset: 0x0032C816
		public override void Process()
		{
			Process_PtcG2C_NoticeGuildArenaBegin.Process(this);
		}

		// Token: 0x04006250 RID: 25168
		public NoticeGuildArenaBegin Data = new NoticeGuildArenaBegin();
	}
}
