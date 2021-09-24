using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_LeaveLeagueTeam : Rpc
	{

		public override uint GetRpcType()
		{
			return 47239U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LeaveLeagueTeamArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<LeaveLeagueTeamRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_LeaveLeagueTeam.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_LeaveLeagueTeam.OnTimeout(this.oArg);
		}

		public LeaveLeagueTeamArg oArg = new LeaveLeagueTeamArg();

		public LeaveLeagueTeamRes oRes = null;
	}
}
