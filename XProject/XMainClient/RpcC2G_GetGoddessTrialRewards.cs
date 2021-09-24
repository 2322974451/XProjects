using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetGoddessTrialRewards : Rpc
	{

		public override uint GetRpcType()
		{
			return 41420U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetGoddessTrialRewardsArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetGoddessTrialRewardsRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetGoddessTrialRewards.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetGoddessTrialRewards.OnTimeout(this.oArg);
		}

		public GetGoddessTrialRewardsArg oArg = new GetGoddessTrialRewardsArg();

		public GetGoddessTrialRewardsRes oRes = new GetGoddessTrialRewardsRes();
	}
}
