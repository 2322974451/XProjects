using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ShadowCatOperation : Rpc
	{

		public override uint GetRpcType()
		{
			return 7140U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ShadowCatOperationArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ShadowCatOperationRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ShadowCatOperation.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ShadowCatOperation.OnTimeout(this.oArg);
		}

		public ShadowCatOperationArg oArg = new ShadowCatOperationArg();

		public ShadowCatOperationRes oRes = null;
	}
}
