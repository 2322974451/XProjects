using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_JadeOperation : Rpc
	{

		public override uint GetRpcType()
		{
			return 55991U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<JadeOperationArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<JadeOperationRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_JadeOperation.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_JadeOperation.OnTimeout(this.oArg);
		}

		public JadeOperationArg oArg = new JadeOperationArg();

		public JadeOperationRes oRes = new JadeOperationRes();
	}
}
