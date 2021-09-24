using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_JadeComposeNew : Rpc
	{

		public override uint GetRpcType()
		{
			return 46652U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<JadeComposeNewArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<JadeComposeNewRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_JadeComposeNew.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_JadeComposeNew.OnTimeout(this.oArg);
		}

		public JadeComposeNewArg oArg = new JadeComposeNewArg();

		public JadeComposeNewRes oRes = null;
	}
}
