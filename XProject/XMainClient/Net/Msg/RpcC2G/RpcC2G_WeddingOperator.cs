using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_WeddingOperator : Rpc
	{

		public override uint GetRpcType()
		{
			return 38050U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WeddingOperatorArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<WeddingOperatorRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_WeddingOperator.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_WeddingOperator.OnTimeout(this.oArg);
		}

		public WeddingOperatorArg oArg = new WeddingOperatorArg();

		public WeddingOperatorRes oRes = null;
	}
}
