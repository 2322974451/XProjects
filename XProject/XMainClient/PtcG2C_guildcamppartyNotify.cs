using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_guildcamppartyNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 23338U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<guildcamppartyNotifyNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<guildcamppartyNotifyNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_guildcamppartyNotify.Process(this);
		}

		public guildcamppartyNotifyNtf Data = new guildcamppartyNotifyNtf();
	}
}
