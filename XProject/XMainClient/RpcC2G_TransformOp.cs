using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_TransformOp : Rpc
	{

		public override uint GetRpcType()
		{
			return 7373U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TransformOpArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<TransformOpRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_TransformOp.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_TransformOp.OnTimeout(this.oArg);
		}

		public TransformOpArg oArg = new TransformOpArg();

		public TransformOpRes oRes = null;
	}
}
