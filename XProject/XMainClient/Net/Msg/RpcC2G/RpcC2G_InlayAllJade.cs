using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_InlayAllJade : Rpc
	{

		public override uint GetRpcType()
		{
			return 58864U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<InlayAllJadeArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<InlayAllJadeRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_InlayAllJade.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_InlayAllJade.OnTimeout(this.oArg);
		}

		public InlayAllJadeArg oArg = new InlayAllJadeArg();

		public InlayAllJadeRes oRes = null;
	}
}
