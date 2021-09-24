using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ActivateFashionCharm : Rpc
	{

		public override uint GetRpcType()
		{
			return 58036U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ActivateFashionArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ActivateFashionRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ActivateFashionCharm.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ActivateFashionCharm.OnTimeout(this.oArg);
		}

		public ActivateFashionArg oArg = new ActivateFashionArg();

		public ActivateFashionRes oRes = null;
	}
}
