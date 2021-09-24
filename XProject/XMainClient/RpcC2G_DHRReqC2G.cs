using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_DHRReqC2G : Rpc
	{

		public override uint GetRpcType()
		{
			return 12451U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DHRArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DHRRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_DHRReqC2G.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_DHRReqC2G.OnTimeout(this.oArg);
		}

		public DHRArg oArg = new DHRArg();

		public DHRRes oRes = null;
	}
}
