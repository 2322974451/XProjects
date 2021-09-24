using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_MSGetFlowerRewardList : Rpc
	{

		public override uint GetRpcType()
		{
			return 16271U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NewGetFlowerRewardListArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<NewGetFlowerRewardListRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_MSGetFlowerRewardList.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_MSGetFlowerRewardList.OnTimeout(this.oArg);
		}

		public NewGetFlowerRewardListArg oArg = new NewGetFlowerRewardListArg();

		public NewGetFlowerRewardListRes oRes = null;
	}
}
