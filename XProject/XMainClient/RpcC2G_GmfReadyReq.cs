using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GmfReadyReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 12219U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GmfReadyArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GmfReadyRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GmfReadyReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GmfReadyReq.OnTimeout(this.oArg);
		}

		public GmfReadyArg oArg = new GmfReadyArg();

		public GmfReadyRes oRes = new GmfReadyRes();
	}
}
