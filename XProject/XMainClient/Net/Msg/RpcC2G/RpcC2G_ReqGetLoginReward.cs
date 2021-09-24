using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ReqGetLoginReward : Rpc
	{

		public override uint GetRpcType()
		{
			return 44079U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LoginRewardGetReq>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<LoginRewardGetRet>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ReqGetLoginReward.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ReqGetLoginReward.OnTimeout(this.oArg);
		}

		public LoginRewardGetReq oArg = new LoginRewardGetReq();

		public LoginRewardGetRet oRes = new LoginRewardGetRet();
	}
}
