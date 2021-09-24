using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetOnlineReward : Rpc
	{

		public override uint GetRpcType()
		{
			return 21137U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetOnlineRewardArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetOnlineRewardRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetOnlineReward.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetOnlineReward.OnTimeout(this.oArg);
		}

		public GetOnlineRewardArg oArg = new GetOnlineRewardArg();

		public GetOnlineRewardRes oRes = new GetOnlineRewardRes();
	}
}
