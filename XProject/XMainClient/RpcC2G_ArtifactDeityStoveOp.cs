using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ArtifactDeityStoveOp : Rpc
	{

		public override uint GetRpcType()
		{
			return 35155U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ArtifactDeityStoveOpArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ArtifactDeityStoveOpRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ArtifactDeityStoveOp.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ArtifactDeityStoveOp.OnTimeout(this.oArg);
		}

		public ArtifactDeityStoveOpArg oArg = new ArtifactDeityStoveOpArg();

		public ArtifactDeityStoveOpRes oRes = null;
	}
}
