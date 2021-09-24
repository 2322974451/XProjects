using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_WeddingInviteOperator : Rpc
	{

		public override uint GetRpcType()
		{
			return 8562U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WeddingInviteOperatorArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<WeddingInviteOperatorRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_WeddingInviteOperator.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_WeddingInviteOperator.OnTimeout(this.oArg);
		}

		public WeddingInviteOperatorArg oArg = new WeddingInviteOperatorArg();

		public WeddingInviteOperatorRes oRes = null;
	}
}
