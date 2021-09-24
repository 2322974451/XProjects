using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_SynGuildArenaBattleInfoNew : Protocol
	{

		public override uint GetProtoType()
		{
			return 3680U;
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
			Process_PtcM2C_SynGuildArenaBattleInfoNew.Process(this);
		}

		public SynGuildArenaBattleInfo Data = new SynGuildArenaBattleInfo();
	}
}
