using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_QueryClientIp : Rpc
	{

		public override uint GetRpcType()
		{
			return 24918U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QueryClientIpArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<QueryClientIpRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_QueryClientIp.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_QueryClientIp.OnTimeout(this.oArg);
		}

		public QueryClientIpArg oArg = new QueryClientIpArg();

		public QueryClientIpRes oRes = null;
	}
}
