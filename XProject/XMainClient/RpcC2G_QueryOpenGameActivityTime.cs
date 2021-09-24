using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_QueryOpenGameActivityTime : Rpc
	{

		public override uint GetRpcType()
		{
			return 24079U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QueryOpenGameArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<QueryOpenGameRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_QueryOpenGameActivityTime.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_QueryOpenGameActivityTime.OnTimeout(this.oArg);
		}

		public QueryOpenGameArg oArg = new QueryOpenGameArg();

		public QueryOpenGameRes oRes = new QueryOpenGameRes();
	}
}
