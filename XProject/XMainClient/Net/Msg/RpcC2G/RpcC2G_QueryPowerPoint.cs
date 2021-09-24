using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_QueryPowerPoint : Rpc
	{

		public override uint GetRpcType()
		{
			return 44381U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QueryPowerPointArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<QueryPowerPointRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_QueryPowerPoint.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_QueryPowerPoint.OnTimeout(this.oArg);
		}

		public QueryPowerPointArg oArg = new QueryPowerPointArg();

		public QueryPowerPointRes oRes = new QueryPowerPointRes();
	}
}
