using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_UpdateLeagueEleRoomStateNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 15800U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<UpdateLeagueEleRoomStateNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<UpdateLeagueEleRoomStateNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_UpdateLeagueEleRoomStateNtf.Process(this);
		}

		public UpdateLeagueEleRoomStateNtf Data = new UpdateLeagueEleRoomStateNtf();
	}
}
