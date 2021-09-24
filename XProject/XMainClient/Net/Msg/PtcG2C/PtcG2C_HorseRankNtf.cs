using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_HorseRankNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 22250U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HorseRank>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HorseRank>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_HorseRankNtf.Process(this);
		}

		public HorseRank Data = new HorseRank();
	}
}
