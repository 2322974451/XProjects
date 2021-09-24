using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetFirstPassReward : Rpc
	{

		public override uint GetRpcType()
		{
			return 12301U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetFirstPassRewardArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetFirstPassRewardRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetFirstPassReward.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetFirstPassReward.OnTimeout(this.oArg);
		}

		public GetFirstPassRewardArg oArg = new GetFirstPassRewardArg();

		public GetFirstPassRewardRes oRes = new GetFirstPassRewardRes();
	}
}
