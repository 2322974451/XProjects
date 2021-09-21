using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200134C RID: 4940
	internal class PtcG2C_GmfGuildCombatNtf : Protocol
	{
		// Token: 0x0600E225 RID: 57893 RVA: 0x00338A08 File Offset: 0x00336C08
		public override uint GetProtoType()
		{
			return 55102U;
		}

		// Token: 0x0600E226 RID: 57894 RVA: 0x00338A1F File Offset: 0x00336C1F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GmfGuildCombatPara>(stream, this.Data);
		}

		// Token: 0x0600E227 RID: 57895 RVA: 0x00338A2F File Offset: 0x00336C2F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GmfGuildCombatPara>(stream);
		}

		// Token: 0x0600E228 RID: 57896 RVA: 0x00338A3E File Offset: 0x00336C3E
		public override void Process()
		{
			Process_PtcG2C_GmfGuildCombatNtf.Process(this);
		}

		// Token: 0x040063AF RID: 25519
		public GmfGuildCombatPara Data = new GmfGuildCombatPara();
	}
}
