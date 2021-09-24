using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetHeroBattleWeekReward : Rpc
	{

		public override uint GetRpcType()
		{
			return 63058U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetHeroBattleWeekRewardArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetHeroBattleWeekRewardRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetHeroBattleWeekReward.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetHeroBattleWeekReward.OnTimeout(this.oArg);
		}

		public GetHeroBattleWeekRewardArg oArg = new GetHeroBattleWeekRewardArg();

		public GetHeroBattleWeekRewardRes oRes = null;
	}
}
