using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetFlowerActivityReward : Rpc
	{

		public override uint GetRpcType()
		{
			return 36979U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetFlowerActivityRewardArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetFlowerActivityRewardRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetFlowerActivityReward.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetFlowerActivityReward.OnTimeout(this.oArg);
		}

		public GetFlowerActivityRewardArg oArg = new GetFlowerActivityRewardArg();

		public GetFlowerActivityRewardRes oRes = null;
	}
}
