using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetDailyTaskReward : Rpc
	{

		public override uint GetRpcType()
		{
			return 59899U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetDailyTaskRewardArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetDailyTaskRewardRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetDailyTaskReward.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetDailyTaskReward.OnTimeout(this.oArg);
		}

		public GetDailyTaskRewardArg oArg = new GetDailyTaskRewardArg();

		public GetDailyTaskRewardRes oRes = new GetDailyTaskRewardRes();
	}
}
