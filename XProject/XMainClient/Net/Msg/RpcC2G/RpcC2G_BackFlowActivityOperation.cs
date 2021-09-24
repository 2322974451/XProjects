using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_BackFlowActivityOperation : Rpc
	{

		public override uint GetRpcType()
		{
			return 61579U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BackFlowActivityOperationArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BackFlowActivityOperationRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_BackFlowActivityOperation.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_BackFlowActivityOperation.OnTimeout(this.oArg);
		}

		public BackFlowActivityOperationArg oArg = new BackFlowActivityOperationArg();

		public BackFlowActivityOperationRes oRes = null;
	}
}
