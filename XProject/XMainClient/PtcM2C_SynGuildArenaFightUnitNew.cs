using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200126F RID: 4719
	internal class PtcM2C_SynGuildArenaFightUnitNew : Protocol
	{
		// Token: 0x0600DE98 RID: 56984 RVA: 0x0033375C File Offset: 0x0033195C
		public override uint GetProtoType()
		{
			return 34513U;
		}

		// Token: 0x0600DE99 RID: 56985 RVA: 0x00333773 File Offset: 0x00331973
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SynGuildArenaFightUnit>(stream, this.Data);
		}

		// Token: 0x0600DE9A RID: 56986 RVA: 0x00333783 File Offset: 0x00331983
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SynGuildArenaFightUnit>(stream);
		}

		// Token: 0x0600DE9B RID: 56987 RVA: 0x00333792 File Offset: 0x00331992
		public override void Process()
		{
			Process_PtcM2C_SynGuildArenaFightUnitNew.Process(this);
		}

		// Token: 0x040062FF RID: 25343
		public SynGuildArenaFightUnit Data = new SynGuildArenaFightUnit();
	}
}
