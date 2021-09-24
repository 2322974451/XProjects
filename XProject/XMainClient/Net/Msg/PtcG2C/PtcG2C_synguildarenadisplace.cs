using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_synguildarenadisplace : Protocol
	{

		public override uint GetProtoType()
		{
			return 21037U;
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
			Process_PtcG2C_synguildarenadisplace.Process(this);
		}

		public guildarenadisplace Data = new guildarenadisplace();
	}
}
