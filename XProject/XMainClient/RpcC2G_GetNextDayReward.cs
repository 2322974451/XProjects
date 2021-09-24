using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetNextDayReward : Rpc
	{

		public override uint GetRpcType()
		{
			return 40997U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetNextDayRewardArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetNextDayRewardRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetNextDayReward.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetNextDayReward.OnTimeout(this.oArg);
		}

		public GetNextDayRewardArg oArg = new GetNextDayRewardArg();

		public GetNextDayRewardRes oRes = new GetNextDayRewardRes();
	}
}
