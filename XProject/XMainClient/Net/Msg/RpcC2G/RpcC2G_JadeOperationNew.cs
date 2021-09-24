using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_JadeOperationNew : Rpc
	{

		public override uint GetRpcType()
		{
			return 40839U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<JadeOperationNewArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<JadeOperationNewRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_JadeOperationNew.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_JadeOperationNew.OnTimeout(this.oArg);
		}

		public JadeOperationNewArg oArg = new JadeOperationNewArg();

		public JadeOperationNewRes oRes = null;
	}
}
