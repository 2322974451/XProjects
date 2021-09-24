using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GCFCommonReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 28945U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GCFCommonArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GCFCommonRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GCFCommonReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GCFCommonReq.OnTimeout(this.oArg);
		}

		public GCFCommonArg oArg = new GCFCommonArg();

		public GCFCommonRes oRes = null;
	}
}
