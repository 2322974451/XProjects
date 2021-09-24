using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_QueryGuildCard : Rpc
	{

		public override uint GetRpcType()
		{
			return 55524U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QueryGuildCardArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<QueryGuildCardRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_QueryGuildCard.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_QueryGuildCard.OnTimeout(this.oArg);
		}

		public QueryGuildCardArg oArg = new QueryGuildCardArg();

		public QueryGuildCardRes oRes = new QueryGuildCardRes();
	}
}
