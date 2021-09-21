using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200137D RID: 4989
	internal class PtcG2C_KillEnemyScoreNtf : Protocol
	{
		// Token: 0x0600E2EB RID: 58091 RVA: 0x00339B50 File Offset: 0x00337D50
		public override uint GetProtoType()
		{
			return 50119U;
		}

		// Token: 0x0600E2EC RID: 58092 RVA: 0x00339B67 File Offset: 0x00337D67
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<KillEnemyScoreData>(stream, this.Data);
		}

		// Token: 0x0600E2ED RID: 58093 RVA: 0x00339B77 File Offset: 0x00337D77
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<KillEnemyScoreData>(stream);
		}

		// Token: 0x0600E2EE RID: 58094 RVA: 0x00339B86 File Offset: 0x00337D86
		public override void Process()
		{
			Process_PtcG2C_KillEnemyScoreNtf.Process(this);
		}

		// Token: 0x040063D5 RID: 25557
		public KillEnemyScoreData Data = new KillEnemyScoreData();
	}
}
