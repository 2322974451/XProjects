using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_GuildBestCardsNtfMs : Protocol
	{

		public override uint GetProtoType()
		{
			return 31828U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildBestCardsNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildBestCardsNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_GuildBestCardsNtfMs.Process(this);
		}

		public GuildBestCardsNtf Data = new GuildBestCardsNtf();
	}
}
