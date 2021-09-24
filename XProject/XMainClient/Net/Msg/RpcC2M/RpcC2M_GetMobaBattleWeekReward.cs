using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetMobaBattleWeekReward : Rpc
	{

		public override uint GetRpcType()
		{
			return 55678U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetMobaBattleWeekRewardArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetMobaBattleWeekRewardRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetMobaBattleWeekReward.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetMobaBattleWeekReward.OnTimeout(this.oArg);
		}

		public GetMobaBattleWeekRewardArg oArg = new GetMobaBattleWeekRewardArg();

		public GetMobaBattleWeekRewardRes oRes = null;
	}
}
