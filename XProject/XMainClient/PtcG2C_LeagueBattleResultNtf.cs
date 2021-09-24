using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_LeagueBattleResultNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 29255U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LeagueBattleResultNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<LeagueBattleResultNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_LeagueBattleResultNtf.Process(this);
		}

		public LeagueBattleResultNtf Data = new LeagueBattleResultNtf();
	}
}
