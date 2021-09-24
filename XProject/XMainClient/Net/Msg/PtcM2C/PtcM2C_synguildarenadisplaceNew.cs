using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_synguildarenadisplaceNew : Protocol
	{

		public override uint GetProtoType()
		{
			return 56166U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<guildarenadisplace>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<guildarenadisplace>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_synguildarenadisplaceNew.Process(this);
		}

		public guildarenadisplace Data = new guildarenadisplace();
	}
}
