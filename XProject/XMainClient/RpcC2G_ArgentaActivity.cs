using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ArgentaActivity : Rpc
	{

		public override uint GetRpcType()
		{
			return 838U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ArgentaActivityArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ArgentaActivityRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ArgentaActivity.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ArgentaActivity.OnTimeout(this.oArg);
		}

		public ArgentaActivityArg oArg = new ArgentaActivityArg();

		public ArgentaActivityRes oRes = null;
	}
}
