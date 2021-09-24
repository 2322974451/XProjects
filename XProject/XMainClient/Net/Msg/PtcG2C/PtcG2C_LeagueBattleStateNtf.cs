using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_LeagueBattleStateNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 59496U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LeagueBattleStateNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<LeagueBattleStateNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_LeagueBattleStateNtf.Process(this);
		}

		public LeagueBattleStateNtf Data = new LeagueBattleStateNtf();
	}
}
