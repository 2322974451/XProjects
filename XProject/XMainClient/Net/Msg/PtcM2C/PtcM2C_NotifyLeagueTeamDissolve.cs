using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_NotifyLeagueTeamDissolve : Protocol
	{

		public override uint GetProtoType()
		{
			return 11033U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NotifyLeagueTeamDissolve>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NotifyLeagueTeamDissolve>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_NotifyLeagueTeamDissolve.Process(this);
		}

		public NotifyLeagueTeamDissolve Data = new NotifyLeagueTeamDissolve();
	}
}
