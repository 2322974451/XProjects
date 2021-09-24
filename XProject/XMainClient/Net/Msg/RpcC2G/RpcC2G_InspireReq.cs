using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_InspireReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 54147U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<InspireArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<InspireRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_InspireReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_InspireReq.OnTimeout(this.oArg);
		}

		public InspireArg oArg = new InspireArg();

		public InspireRes oRes = new InspireRes();
	}
}
