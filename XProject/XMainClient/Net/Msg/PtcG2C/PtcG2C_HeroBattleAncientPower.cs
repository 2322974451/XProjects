using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_HeroBattleAncientPower : Protocol
	{

		public override uint GetProtoType()
		{
			return 37102U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HeroBattleAncientPowerData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HeroBattleAncientPowerData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_HeroBattleAncientPower.Process(this);
		}

		public HeroBattleAncientPowerData Data = new HeroBattleAncientPowerData();
	}
}
