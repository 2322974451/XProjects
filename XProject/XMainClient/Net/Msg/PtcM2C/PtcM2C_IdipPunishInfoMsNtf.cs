using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_IdipPunishInfoMsNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 8208U;
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
			Process_PtcM2C_IdipPunishInfoMsNtf.Process(this);
		}

		public IdipPunishInfo Data = new IdipPunishInfo();
	}
}
