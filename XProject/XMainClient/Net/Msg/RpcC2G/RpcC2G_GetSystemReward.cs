using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetSystemReward : Rpc
	{

		public override uint GetRpcType()
		{
			return 11595U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetSystemRewardArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetSystemRewardRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetSystemReward.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetSystemReward.OnTimeout(this.oArg);
		}

		public GetSystemRewardArg oArg = new GetSystemRewardArg();

		public GetSystemRewardRes oRes = new GetSystemRewardRes();
	}
}
