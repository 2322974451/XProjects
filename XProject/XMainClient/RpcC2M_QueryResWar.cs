using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_QueryResWar : Rpc
	{

		public override uint GetRpcType()
		{
			return 41509U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QueryResWarArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<QueryResWarRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_QueryResWar.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_QueryResWar.OnTimeout(this.oArg);
		}

		public QueryResWarArg oArg = new QueryResWarArg();

		public QueryResWarRes oRes = null;
	}
}
