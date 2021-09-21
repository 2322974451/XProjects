using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014C5 RID: 5317
	internal class PtcG2C_WorldBossGuildAddAttrSyncClientNtf : Protocol
	{
		// Token: 0x0600E81D RID: 59421 RVA: 0x00340ED8 File Offset: 0x0033F0D8
		public override uint GetProtoType()
		{
			return 65314U;
		}

		// Token: 0x0600E81E RID: 59422 RVA: 0x00340EEF File Offset: 0x0033F0EF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WorldBossGuildAddAttrSyncClient>(stream, this.Data);
		}

		// Token: 0x0600E81F RID: 59423 RVA: 0x00340EFF File Offset: 0x0033F0FF
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<WorldBossGuildAddAttrSyncClient>(stream);
		}

		// Token: 0x0600E820 RID: 59424 RVA: 0x00340F0E File Offset: 0x0033F10E
		public override void Process()
		{
			Process_PtcG2C_WorldBossGuildAddAttrSyncClientNtf.Process(this);
		}

		// Token: 0x040064CE RID: 25806
		public WorldBossGuildAddAttrSyncClient Data = new WorldBossGuildAddAttrSyncClient();
	}
}
