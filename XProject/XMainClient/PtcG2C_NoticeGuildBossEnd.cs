using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200116C RID: 4460
	internal class PtcG2C_NoticeGuildBossEnd : Protocol
	{
		// Token: 0x0600DA85 RID: 55941 RVA: 0x0032DC64 File Offset: 0x0032BE64
		public override uint GetProtoType()
		{
			return 34184U;
		}

		// Token: 0x0600DA86 RID: 55942 RVA: 0x0032DC7B File Offset: 0x0032BE7B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NoticeGuildBossEnd>(stream, this.Data);
		}

		// Token: 0x0600DA87 RID: 55943 RVA: 0x0032DC8B File Offset: 0x0032BE8B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NoticeGuildBossEnd>(stream);
		}

		// Token: 0x0600DA88 RID: 55944 RVA: 0x0032DC9A File Offset: 0x0032BE9A
		public override void Process()
		{
			Process_PtcG2C_NoticeGuildBossEnd.Process(this);
		}

		// Token: 0x0400623D RID: 25149
		public NoticeGuildBossEnd Data = new NoticeGuildBossEnd();
	}
}
