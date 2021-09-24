using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetFlowerReward : Rpc
	{

		public override uint GetRpcType()
		{
			return 65090U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetFlowerRewardArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetFlowerRewardRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetFlowerReward.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetFlowerReward.OnTimeout(this.oArg);
		}

		public GetFlowerRewardArg oArg = new GetFlowerRewardArg();

		public GetFlowerRewardRes oRes = new GetFlowerRewardRes();
	}
}
