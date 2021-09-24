using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GCFFightInfoReqC2M : Rpc
	{

		public override uint GetRpcType()
		{
			return 42852U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GCFFightInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GCFFightInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GCFFightInfoReqC2M.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GCFFightInfoReqC2M.OnTimeout(this.oArg);
		}

		public GCFFightInfoArg oArg = new GCFFightInfoArg();

		public GCFFightInfoRes oRes = null;
	}
}
