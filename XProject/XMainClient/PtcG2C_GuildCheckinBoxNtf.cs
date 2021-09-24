using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_GuildCheckinBoxNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 5114U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildCheckinBoxNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildCheckinBoxNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_GuildCheckinBoxNtf.Process(this);
		}

		public GuildCheckinBoxNtf Data = new GuildCheckinBoxNtf();
	}
}
