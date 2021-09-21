using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001484 RID: 5252
	internal class PtcG2C_LeagueBattleStateNtf : Protocol
	{
		// Token: 0x0600E715 RID: 59157 RVA: 0x0033F840 File Offset: 0x0033DA40
		public override uint GetProtoType()
		{
			return 59496U;
		}

		// Token: 0x0600E716 RID: 59158 RVA: 0x0033F857 File Offset: 0x0033DA57
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LeagueBattleStateNtf>(stream, this.Data);
		}

		// Token: 0x0600E717 RID: 59159 RVA: 0x0033F867 File Offset: 0x0033DA67
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<LeagueBattleStateNtf>(stream);
		}

		// Token: 0x0600E718 RID: 59160 RVA: 0x0033F876 File Offset: 0x0033DA76
		public override void Process()
		{
			Process_PtcG2C_LeagueBattleStateNtf.Process(this);
		}

		// Token: 0x0400649D RID: 25757
		public LeagueBattleStateNtf Data = new LeagueBattleStateNtf();
	}
}
