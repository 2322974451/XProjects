using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetFlowerRewardList : Rpc
	{

		public override uint GetRpcType()
		{
			return 26656U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetFlowerRewardListArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetFlowerRewardListRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetFlowerRewardList.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetFlowerRewardList.OnTimeout(this.oArg);
		}

		public GetFlowerRewardListArg oArg = new GetFlowerRewardListArg();

		public GetFlowerRewardListRes oRes = new GetFlowerRewardListRes();
	}
}
