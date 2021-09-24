using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_BattleStatisticsNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 65061U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BattleStatisticsNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BattleStatisticsNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_BattleStatisticsNtf.Process(this);
		}

		public BattleStatisticsNtf Data = new BattleStatisticsNtf();
	}
}
