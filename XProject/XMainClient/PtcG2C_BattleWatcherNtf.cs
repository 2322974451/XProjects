using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200118C RID: 4492
	internal class PtcG2C_BattleWatcherNtf : Protocol
	{
		// Token: 0x0600DAFB RID: 56059 RVA: 0x0032E564 File Offset: 0x0032C764
		public override uint GetProtoType()
		{
			return 54652U;
		}

		// Token: 0x0600DAFC RID: 56060 RVA: 0x0032E57B File Offset: 0x0032C77B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BattleWatcherNtf>(stream, this.Data);
		}

		// Token: 0x0600DAFD RID: 56061 RVA: 0x0032E58B File Offset: 0x0032C78B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BattleWatcherNtf>(stream);
		}

		// Token: 0x0600DAFE RID: 56062 RVA: 0x0032E59A File Offset: 0x0032C79A
		public override void Process()
		{
			Process_PtcG2C_BattleWatcherNtf.Process(this);
		}

		// Token: 0x0400624F RID: 25167
		public BattleWatcherNtf Data = new BattleWatcherNtf();
	}
}
