using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_BackFlowBuyOp : Rpc
	{

		public override uint GetRpcType()
		{
			return 16261U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BackFlowBuyOpArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BackFlowBuyOpRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_BackFlowBuyOp.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_BackFlowBuyOp.OnTimeout(this.oArg);
		}

		public BackFlowBuyOpArg oArg = new BackFlowBuyOpArg();

		public BackFlowBuyOpRes oRes = null;
	}
}
