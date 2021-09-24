using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_GuildCardMatchNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 64513U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildCardMatchNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildCardMatchNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_GuildCardMatchNtf.Process(this);
		}

		public GuildCardMatchNtf Data = new GuildCardMatchNtf();
	}
}
