using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_IdipPunishInfoNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 46304U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<IdipPunishInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<IdipPunishInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_IdipPunishInfoNtf.Process(this);
		}

		public IdipPunishInfo Data = new IdipPunishInfo();
	}
}
