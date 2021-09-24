using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetAchieveRewardReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 1577U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetAchieveRewardReq>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetAchieveRewardRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetAchieveRewardReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetAchieveRewardReq.OnTimeout(this.oArg);
		}

		public GetAchieveRewardReq oArg = new GetAchieveRewardReq();

		public GetAchieveRewardRes oRes = new GetAchieveRewardRes();
	}
}
