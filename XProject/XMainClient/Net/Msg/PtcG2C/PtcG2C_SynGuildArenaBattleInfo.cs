using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_SynGuildArenaBattleInfo : Protocol
	{

		public override uint GetProtoType()
		{
			return 1906U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SynGuildArenaBattleInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SynGuildArenaBattleInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_SynGuildArenaBattleInfo.Process(this);
		}

		public SynGuildArenaBattleInfo Data = new SynGuildArenaBattleInfo();
	}
}
