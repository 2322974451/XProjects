using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_NotifyLeagueTeamCreate : Protocol
	{

		public override uint GetProtoType()
		{
			return 22343U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NotifyLeagueTeamCreate>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NotifyLeagueTeamCreate>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_NotifyLeagueTeamCreate.Process(this);
		}

		public NotifyLeagueTeamCreate Data = new NotifyLeagueTeamCreate();
	}
}
