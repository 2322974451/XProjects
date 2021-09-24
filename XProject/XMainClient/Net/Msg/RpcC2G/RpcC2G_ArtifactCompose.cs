using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ArtifactCompose : Rpc
	{

		public override uint GetRpcType()
		{
			return 599U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ArtifactComposeArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ArtifactComposeRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ArtifactCompose.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ArtifactCompose.OnTimeout(this.oArg);
		}

		public ArtifactComposeArg oArg = new ArtifactComposeArg();

		public ArtifactComposeRes oRes = null;
	}
}
