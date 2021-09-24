using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_PkReqC2M : Rpc
	{

		public override uint GetRpcType()
		{
			return 41221U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PkReqArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<PkReqRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_PkReqC2M.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_PkReqC2M.OnTimeout(this.oArg);
		}

		public PkReqArg oArg = new PkReqArg();

		public PkReqRes oRes = null;
	}
}
