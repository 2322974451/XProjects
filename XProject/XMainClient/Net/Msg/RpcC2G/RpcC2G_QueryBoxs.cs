using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_QueryBoxs : Rpc
	{

		public override uint GetRpcType()
		{
			return 12558U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QueryBoxsArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<QueryBoxsRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_QueryBoxs.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_QueryBoxs.OnTimeout(this.oArg);
		}

		public QueryBoxsArg oArg = new QueryBoxsArg();

		public QueryBoxsRes oRes = null;
	}
}
