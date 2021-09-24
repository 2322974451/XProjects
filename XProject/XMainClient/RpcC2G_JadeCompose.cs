using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_JadeCompose : Rpc
	{

		public override uint GetRpcType()
		{
			return 35616U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<JadeComposeArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<JadeComposeRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_JadeCompose.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_JadeCompose.OnTimeout(this.oArg);
		}

		public JadeComposeArg oArg = new JadeComposeArg();

		public JadeComposeRes oRes = new JadeComposeRes();
	}
}
