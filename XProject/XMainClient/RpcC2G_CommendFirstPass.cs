using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_CommendFirstPass : Rpc
	{

		public override uint GetRpcType()
		{
			return 8467U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CommendFirstPassArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<CommendFirstPassRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_CommendFirstPass.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_CommendFirstPass.OnTimeout(this.oArg);
		}

		public CommendFirstPassArg oArg = new CommendFirstPassArg();

		public CommendFirstPassRes oRes = new CommendFirstPassRes();
	}
}
