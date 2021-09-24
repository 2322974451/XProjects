using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_Get520FestivalRedPacket : Protocol
	{

		public override uint GetProtoType()
		{
			return 28202U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<Get520FestivalRedPacket>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<Get520FestivalRedPacket>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_Get520FestivalRedPacket.Process(this);
		}

		public Get520FestivalRedPacket Data = new Get520FestivalRedPacket();
	}
}
