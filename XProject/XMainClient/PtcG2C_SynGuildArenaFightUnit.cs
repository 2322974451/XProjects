using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001182 RID: 4482
	internal class PtcG2C_SynGuildArenaFightUnit : Protocol
	{
		// Token: 0x0600DAD8 RID: 56024 RVA: 0x0032E300 File Offset: 0x0032C500
		public override uint GetProtoType()
		{
			return 59912U;
		}

		// Token: 0x0600DAD9 RID: 56025 RVA: 0x0032E317 File Offset: 0x0032C517
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SynGuildArenaFightUnit>(stream, this.Data);
		}

		// Token: 0x0600DADA RID: 56026 RVA: 0x0032E327 File Offset: 0x0032C527
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SynGuildArenaFightUnit>(stream);
		}

		// Token: 0x0600DADB RID: 56027 RVA: 0x0032E336 File Offset: 0x0032C536
		public override void Process()
		{
			Process_PtcG2C_SynGuildArenaFightUnit.Process(this);
		}

		// Token: 0x0400624B RID: 25163
		public SynGuildArenaFightUnit Data = new SynGuildArenaFightUnit();
	}
}
