using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012EB RID: 4843
	internal class PtcM2C_GuildCardRankNtf : Protocol
	{
		// Token: 0x0600E098 RID: 57496 RVA: 0x00336494 File Offset: 0x00334694
		public override uint GetProtoType()
		{
			return 63693U;
		}

		// Token: 0x0600E099 RID: 57497 RVA: 0x003364AB File Offset: 0x003346AB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildCardRankNtf>(stream, this.Data);
		}

		// Token: 0x0600E09A RID: 57498 RVA: 0x003364BB File Offset: 0x003346BB
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildCardRankNtf>(stream);
		}

		// Token: 0x0600E09B RID: 57499 RVA: 0x003364CA File Offset: 0x003346CA
		public override void Process()
		{
			Process_PtcM2C_GuildCardRankNtf.Process(this);
		}

		// Token: 0x04006363 RID: 25443
		public GuildCardRankNtf Data = new GuildCardRankNtf();
	}
}
