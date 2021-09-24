using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_QueryGuildCheckinNew : Rpc
	{

		public override uint GetRpcType()
		{
			return 56433U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QueryGuildCheckinArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<QueryGuildCheckinRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_QueryGuildCheckinNew.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_QueryGuildCheckinNew.OnTimeout(this.oArg);
		}

		public QueryGuildCheckinArg oArg = new QueryGuildCheckinArg();

		public QueryGuildCheckinRes oRes = null;
	}
}
