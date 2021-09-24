using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_HeroBattleOverTime : Protocol
	{

		public override uint GetProtoType()
		{
			return 2950U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HeroBattleOverTimeData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HeroBattleOverTimeData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_HeroBattleOverTime.Process(this);
		}

		public HeroBattleOverTimeData Data = new HeroBattleOverTimeData();
	}
}
