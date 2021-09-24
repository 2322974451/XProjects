using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_LeagueBattleBaseDataNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 19581U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LeagueBattleBaseDataNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<LeagueBattleBaseDataNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_LeagueBattleBaseDataNtf.Process(this);
		}

		public LeagueBattleBaseDataNtf Data = new LeagueBattleBaseDataNtf();
	}
}
