using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetSkyCraftTeamInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 25015U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetSkyCraftTeamInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetSkyCraftTeamInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetSkyCraftTeamInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetSkyCraftTeamInfo.OnTimeout(this.oArg);
		}

		public GetSkyCraftTeamInfoArg oArg = new GetSkyCraftTeamInfoArg();

		public GetSkyCraftTeamInfoRes oRes = null;
	}
}
