using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001442 RID: 5186
	internal class PtcM2C_GuildBonusGetAll : Protocol
	{
		// Token: 0x0600E612 RID: 58898 RVA: 0x0033DD6C File Offset: 0x0033BF6C
		public override uint GetProtoType()
		{
			return 55177U;
		}

		// Token: 0x0600E613 RID: 58899 RVA: 0x0033DD83 File Offset: 0x0033BF83
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildBonusGetAllData>(stream, this.Data);
		}

		// Token: 0x0600E614 RID: 58900 RVA: 0x0033DD93 File Offset: 0x0033BF93
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildBonusGetAllData>(stream);
		}

		// Token: 0x0600E615 RID: 58901 RVA: 0x0033DDA2 File Offset: 0x0033BFA2
		public override void Process()
		{
			Process_PtcM2C_GuildBonusGetAll.Process(this);
		}

		// Token: 0x0400646F RID: 25711
		public GuildBonusGetAllData Data = new GuildBonusGetAllData();
	}
}
