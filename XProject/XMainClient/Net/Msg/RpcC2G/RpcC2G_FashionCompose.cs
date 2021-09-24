using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_FashionCompose : Rpc
	{

		public override uint GetRpcType()
		{
			return 46372U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FashionComposeArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<FashionComposeRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_FashionCompose.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_FashionCompose.OnTimeout(this.oArg);
		}

		public FashionComposeArg oArg = new FashionComposeArg();

		public FashionComposeRes oRes = new FashionComposeRes();
	}
}
