using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetSweepTowerReward : Rpc
	{

		public override uint GetRpcType()
		{
			return 23703U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetSweepTowerRewardArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetSweepTowerRewardRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetSweepTowerReward.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetSweepTowerReward.OnTimeout(this.oArg);
		}

		public GetSweepTowerRewardArg oArg = new GetSweepTowerRewardArg();

		public GetSweepTowerRewardRes oRes = new GetSweepTowerRewardRes();
	}
}
