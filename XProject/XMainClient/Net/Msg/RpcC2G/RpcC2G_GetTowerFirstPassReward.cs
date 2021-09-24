using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetTowerFirstPassReward : Rpc
	{

		public override uint GetRpcType()
		{
			return 55009U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetTowerFirstPassRewardArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetTowerFirstPassRewardRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetTowerFirstPassReward.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetTowerFirstPassReward.OnTimeout(this.oArg);
		}

		public GetTowerFirstPassRewardArg oArg = new GetTowerFirstPassRewardArg();

		public GetTowerFirstPassRewardRes oRes = new GetTowerFirstPassRewardRes();
	}
}
