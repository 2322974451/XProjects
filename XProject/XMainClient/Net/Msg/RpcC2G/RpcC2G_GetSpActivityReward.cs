using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetSpActivityReward : Rpc
	{

		public override uint GetRpcType()
		{
			return 7905U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetSpActivityRewardArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetSpActivityRewardRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetSpActivityReward.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetSpActivityReward.OnTimeout(this.oArg);
		}

		public GetSpActivityRewardArg oArg = new GetSpActivityRewardArg();

		public GetSpActivityRewardRes oRes = new GetSpActivityRewardRes();
	}
}
