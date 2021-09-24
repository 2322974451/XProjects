using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetPayReward : Rpc
	{

		public override uint GetRpcType()
		{
			return 63038U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetPayRewardArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetPayRewardRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetPayReward.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetPayReward.OnTimeout(this.oArg);
		}

		public GetPayRewardArg oArg = new GetPayRewardArg();

		public GetPayRewardRes oRes = null;
	}
}
