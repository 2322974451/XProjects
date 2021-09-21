using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001273 RID: 4723
	internal class PtcM2C_NoticeGuildArenaBeginNew : Protocol
	{
		// Token: 0x0600DEA6 RID: 56998 RVA: 0x00333830 File Offset: 0x00331A30
		public override uint GetProtoType()
		{
			return 12290U;
		}

		// Token: 0x0600DEA7 RID: 56999 RVA: 0x00333847 File Offset: 0x00331A47
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NoticeGuildArenaBegin>(stream, this.Data);
		}

		// Token: 0x0600DEA8 RID: 57000 RVA: 0x00333857 File Offset: 0x00331A57
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NoticeGuildArenaBegin>(stream);
		}

		// Token: 0x0600DEA9 RID: 57001 RVA: 0x00333866 File Offset: 0x00331A66
		public override void Process()
		{
			Process_PtcM2C_NoticeGuildArenaBeginNew.Process(this);
		}

		// Token: 0x04006301 RID: 25345
		public NoticeGuildArenaBegin Data = new NoticeGuildArenaBegin();
	}
}
