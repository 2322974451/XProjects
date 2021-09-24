using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetGuildWageReward : Rpc
	{

		public override uint GetRpcType()
		{
			return 50133U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetGuildWageRewardArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetGuildWageReward>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetGuildWageReward.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetGuildWageReward.OnTimeout(this.oArg);
		}

		public GetGuildWageRewardArg oArg = new GetGuildWageRewardArg();

		public GetGuildWageReward oRes = null;
	}
}
