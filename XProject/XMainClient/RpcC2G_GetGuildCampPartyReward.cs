using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetGuildCampPartyReward : Rpc
	{

		public override uint GetRpcType()
		{
			return 58935U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetGuildCampPartyRewardArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetGuildCampPartyRewardRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetGuildCampPartyReward.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetGuildCampPartyReward.OnTimeout(this.oArg);
		}

		public GetGuildCampPartyRewardArg oArg = new GetGuildCampPartyRewardArg();

		public GetGuildCampPartyRewardRes oRes = null;
	}
}
