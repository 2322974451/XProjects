using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_PayClick : Rpc
	{

		public override uint GetRpcType()
		{
			return 20376U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PayClickArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<PayClickRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_PayClick.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_PayClick.OnTimeout(this.oArg);
		}

		public PayClickArg oArg = new PayClickArg();

		public PayClickRes oRes = new PayClickRes();
	}
}
