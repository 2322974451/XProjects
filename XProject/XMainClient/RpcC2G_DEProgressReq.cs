using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_DEProgressReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 5238U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DEProgressArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DEProgressRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_DEProgressReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_DEProgressReq.OnTimeout(this.oArg);
		}

		public DEProgressArg oArg = new DEProgressArg();

		public DEProgressRes oRes = new DEProgressRes();
	}
}
