using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_GuildCardRankNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 63693U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildCardRankNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildCardRankNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_GuildCardRankNtf.Process(this);
		}

		public GuildCardRankNtf Data = new GuildCardRankNtf();
	}
}
