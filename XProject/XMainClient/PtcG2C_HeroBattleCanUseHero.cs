using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200147C RID: 5244
	internal class PtcG2C_HeroBattleCanUseHero : Protocol
	{
		// Token: 0x0600E6F5 RID: 59125 RVA: 0x0033F538 File Offset: 0x0033D738
		public override uint GetProtoType()
		{
			return 20354U;
		}

		// Token: 0x0600E6F6 RID: 59126 RVA: 0x0033F54F File Offset: 0x0033D74F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HeroBattleCanUseHeroData>(stream, this.Data);
		}

		// Token: 0x0600E6F7 RID: 59127 RVA: 0x0033F55F File Offset: 0x0033D75F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HeroBattleCanUseHeroData>(stream);
		}

		// Token: 0x0600E6F8 RID: 59128 RVA: 0x0033F56E File Offset: 0x0033D76E
		public override void Process()
		{
			Process_PtcG2C_HeroBattleCanUseHero.Process(this);
		}

		// Token: 0x04006497 RID: 25751
		public HeroBattleCanUseHeroData Data = new HeroBattleCanUseHeroData();
	}
}
