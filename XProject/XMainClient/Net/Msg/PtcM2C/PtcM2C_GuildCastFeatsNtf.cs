using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_GuildCastFeatsNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 32885U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildCastFeats>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildCastFeats>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_GuildCastFeatsNtf.Process(this);
		}

		public GuildCastFeats Data = new GuildCastFeats();
	}
}
