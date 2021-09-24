using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2I_QueryGateIP : Rpc
	{

		public override uint GetRpcType()
		{
			return 9179U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QueryGateArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<QueryGateRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2I_QueryGateIP.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2I_QueryGateIP.OnTimeout(this.oArg);
		}

		public QueryGateArg oArg = new QueryGateArg();

		public QueryGateRes oRes = new QueryGateRes();
	}
}
