using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_HeroBattleCanUseHero : Protocol
	{

		public override uint GetProtoType()
		{
			return 20354U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HeroBattleCanUseHeroData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HeroBattleCanUseHeroData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_HeroBattleCanUseHero.Process(this);
		}

		public HeroBattleCanUseHeroData Data = new HeroBattleCanUseHeroData();
	}
}
