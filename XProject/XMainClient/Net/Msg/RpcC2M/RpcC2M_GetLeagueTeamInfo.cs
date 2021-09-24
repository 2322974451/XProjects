using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetLeagueTeamInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 12488U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetLeagueTeamInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetLeagueTeamInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetLeagueTeamInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetLeagueTeamInfo.OnTimeout(this.oArg);
		}

		public GetLeagueTeamInfoArg oArg = new GetLeagueTeamInfoArg();

		public GetLeagueTeamInfoRes oRes = null;
	}
}
