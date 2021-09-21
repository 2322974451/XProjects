using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001188 RID: 4488
	internal class PtcG2C_WorldBossStateNtf : Protocol
	{
		// Token: 0x0600DAED RID: 56045 RVA: 0x0032E444 File Offset: 0x0032C644
		public override uint GetProtoType()
		{
			return 5473U;
		}

		// Token: 0x0600DAEE RID: 56046 RVA: 0x0032E45B File Offset: 0x0032C65B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WorldBossStateNtf>(stream, this.Data);
		}

		// Token: 0x0600DAEF RID: 56047 RVA: 0x0032E46B File Offset: 0x0032C66B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<WorldBossStateNtf>(stream);
		}

		// Token: 0x0600DAF0 RID: 56048 RVA: 0x0032E47A File Offset: 0x0032C67A
		public override void Process()
		{
			Process_PtcG2C_WorldBossStateNtf.Process(this);
		}

		// Token: 0x0400624E RID: 25166
		public WorldBossStateNtf Data = new WorldBossStateNtf();
	}
}
