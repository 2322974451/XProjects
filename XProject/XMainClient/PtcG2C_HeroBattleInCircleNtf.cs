using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_HeroBattleInCircleNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 40409U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HeroBattleInCircle>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HeroBattleInCircle>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_HeroBattleInCircleNtf.Process(this);
		}

		public HeroBattleInCircle Data = new HeroBattleInCircle();
	}
}
