using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001123 RID: 4387
	internal class PtcG2C_PvpBattleKill : Protocol
	{
		// Token: 0x0600D94E RID: 55630 RVA: 0x0032ACE4 File Offset: 0x00328EE4
		public override uint GetProtoType()
		{
			return 61000U;
		}

		// Token: 0x0600D94F RID: 55631 RVA: 0x0032ACFB File Offset: 0x00328EFB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PvpBattleKill>(stream, this.Data);
		}

		// Token: 0x0600D950 RID: 55632 RVA: 0x0032AD0B File Offset: 0x00328F0B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PvpBattleKill>(stream);
		}

		// Token: 0x0600D951 RID: 55633 RVA: 0x0032AD1A File Offset: 0x00328F1A
		public override void Process()
		{
			Process_PtcG2C_PvpBattleKill.Process(this);
		}

		// Token: 0x040061FE RID: 25086
		public PvpBattleKill Data = new PvpBattleKill();
	}
}
