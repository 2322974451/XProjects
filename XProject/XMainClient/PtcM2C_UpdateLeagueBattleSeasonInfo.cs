using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200145E RID: 5214
	internal class PtcM2C_UpdateLeagueBattleSeasonInfo : Protocol
	{
		// Token: 0x0600E67E RID: 59006 RVA: 0x0033E9F8 File Offset: 0x0033CBF8
		public override uint GetProtoType()
		{
			return 42828U;
		}

		// Token: 0x0600E67F RID: 59007 RVA: 0x0033EA0F File Offset: 0x0033CC0F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<UpdateLeagueBattleSeasonInfo>(stream, this.Data);
		}

		// Token: 0x0600E680 RID: 59008 RVA: 0x0033EA1F File Offset: 0x0033CC1F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<UpdateLeagueBattleSeasonInfo>(stream);
		}

		// Token: 0x0600E681 RID: 59009 RVA: 0x0033EA2E File Offset: 0x0033CC2E
		public override void Process()
		{
			Process_PtcM2C_UpdateLeagueBattleSeasonInfo.Process(this);
		}

		// Token: 0x04006481 RID: 25729
		public UpdateLeagueBattleSeasonInfo Data = new UpdateLeagueBattleSeasonInfo();
	}
}
