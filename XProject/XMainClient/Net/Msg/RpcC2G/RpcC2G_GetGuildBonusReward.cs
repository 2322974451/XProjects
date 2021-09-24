using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetGuildBonusReward : Rpc
	{

		public override uint GetRpcType()
		{
			return 55720U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetGuildBonusRewardArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetGuildBonusRewardResult>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetGuildBonusReward.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetGuildBonusReward.OnTimeout(this.oArg);
		}

		public GetGuildBonusRewardArg oArg = new GetGuildBonusRewardArg();

		public GetGuildBonusRewardResult oRes = new GetGuildBonusRewardResult();
	}
}
