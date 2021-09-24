using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetWeeklyTaskReward : Rpc
	{

		public override uint GetRpcType()
		{
			return 30588U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetWeeklyTaskRewardArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetWeeklyTaskRewardRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetWeeklyTaskReward.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetWeeklyTaskReward.OnTimeout(this.oArg);
		}

		public GetWeeklyTaskRewardArg oArg = new GetWeeklyTaskRewardArg();

		public GetWeeklyTaskRewardRes oRes = null;
	}
}
