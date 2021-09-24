using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_QueryBigMeleeRank : Rpc
	{

		public override uint GetRpcType()
		{
			return 33332U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QueryMayhemRankArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<QueryMayhemRankRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_QueryBigMeleeRank.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_QueryBigMeleeRank.OnTimeout(this.oArg);
		}

		public QueryMayhemRankArg oArg = new QueryMayhemRankArg();

		public QueryMayhemRankRes oRes = null;
	}
}
