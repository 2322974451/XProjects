using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_FiveDayRewardReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 63999U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FiveRewardRes>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<FiveRewardRet>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_FiveDayRewardReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_FiveDayRewardReq.OnTimeout(this.oArg);
		}

		public FiveRewardRes oArg = new FiveRewardRes();

		public FiveRewardRet oRes = new FiveRewardRet();
	}
}
