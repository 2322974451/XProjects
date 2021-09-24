using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_GuildBestCardsNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 44473U;
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
			Process_PtcG2C_GuildBestCardsNtf.Process(this);
		}

		public GuildBestCardsNtf Data = new GuildBestCardsNtf();
	}
}
