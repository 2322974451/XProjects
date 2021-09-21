using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001437 RID: 5175
	internal class PtcM2C_NoticeGuildTerrWar : Protocol
	{
		// Token: 0x0600E5E6 RID: 58854 RVA: 0x0033D97C File Offset: 0x0033BB7C
		public override uint GetProtoType()
		{
			return 17274U;
		}

		// Token: 0x0600E5E7 RID: 58855 RVA: 0x0033D993 File Offset: 0x0033BB93
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NoticeGuildTerrWar>(stream, this.Data);
		}

		// Token: 0x0600E5E8 RID: 58856 RVA: 0x0033D9A3 File Offset: 0x0033BBA3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NoticeGuildTerrWar>(stream);
		}

		// Token: 0x0600E5E9 RID: 58857 RVA: 0x0033D9B2 File Offset: 0x0033BBB2
		public override void Process()
		{
			Process_PtcM2C_NoticeGuildTerrWar.Process(this);
		}

		// Token: 0x04006467 RID: 25703
		public NoticeGuildTerrWar Data = new NoticeGuildTerrWar();
	}
}
