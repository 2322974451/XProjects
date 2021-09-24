using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GCFReadysInfoReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 19040U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GCFReadyInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GCFReadyInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GCFReadysInfoReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GCFReadysInfoReq.OnTimeout(this.oArg);
		}

		public GCFReadyInfoArg oArg = new GCFReadyInfoArg();

		public GCFReadyInfoRes oRes = null;
	}
}
