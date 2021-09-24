using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_UpdateLeagueTeamState : Protocol
	{

		public override uint GetProtoType()
		{
			return 7643U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<UpdateLeagueTeamState>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<UpdateLeagueTeamState>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_UpdateLeagueTeamState.Process(this);
		}

		public UpdateLeagueTeamState Data = new UpdateLeagueTeamState();
	}
}
