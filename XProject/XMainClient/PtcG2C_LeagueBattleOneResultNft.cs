using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_LeagueBattleOneResultNft : Protocol
	{

		public override uint GetProtoType()
		{
			return 40599U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LeagueBattleOneResultNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<LeagueBattleOneResultNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_LeagueBattleOneResultNft.Process(this);
		}

		public LeagueBattleOneResultNtf Data = new LeagueBattleOneResultNtf();
	}
}
