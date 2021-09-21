using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001180 RID: 4480
	internal class PtcG2C_SynGuildArenaBattleInfo : Protocol
	{
		// Token: 0x0600DAD1 RID: 56017 RVA: 0x0032E284 File Offset: 0x0032C484
		public override uint GetProtoType()
		{
			return 1906U;
		}

		// Token: 0x0600DAD2 RID: 56018 RVA: 0x0032E29B File Offset: 0x0032C49B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SynGuildArenaBattleInfo>(stream, this.Data);
		}

		// Token: 0x0600DAD3 RID: 56019 RVA: 0x0032E2AB File Offset: 0x0032C4AB
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SynGuildArenaBattleInfo>(stream);
		}

		// Token: 0x0600DAD4 RID: 56020 RVA: 0x0032E2BA File Offset: 0x0032C4BA
		public override void Process()
		{
			Process_PtcG2C_SynGuildArenaBattleInfo.Process(this);
		}

		// Token: 0x0400624A RID: 25162
		public SynGuildArenaBattleInfo Data = new SynGuildArenaBattleInfo();
	}
}
