using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetAchievePointRewardReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 13722U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetAchievePointRewardReq>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetAchievePointRewardRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetAchievePointRewardReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetAchievePointRewardReq.OnTimeout(this.oArg);
		}

		public GetAchievePointRewardReq oArg = new GetAchievePointRewardReq();

		public GetAchievePointRewardRes oRes = new GetAchievePointRewardRes();
	}
}
