using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001470 RID: 5232
	internal class PtcM2C_LeagueBattleStartMatchNtf : Protocol
	{
		// Token: 0x0600E6C5 RID: 59077 RVA: 0x0033F000 File Offset: 0x0033D200
		public override uint GetProtoType()
		{
			return 61870U;
		}

		// Token: 0x0600E6C6 RID: 59078 RVA: 0x0033F017 File Offset: 0x0033D217
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LeagueBattleStartMatchNtf>(stream, this.Data);
		}

		// Token: 0x0600E6C7 RID: 59079 RVA: 0x0033F027 File Offset: 0x0033D227
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<LeagueBattleStartMatchNtf>(stream);
		}

		// Token: 0x0600E6C8 RID: 59080 RVA: 0x0033F036 File Offset: 0x0033D236
		public override void Process()
		{
			Process_PtcM2C_LeagueBattleStartMatchNtf.Process(this);
		}

		// Token: 0x0400648E RID: 25742
		public LeagueBattleStartMatchNtf Data = new LeagueBattleStartMatchNtf();
	}
}
