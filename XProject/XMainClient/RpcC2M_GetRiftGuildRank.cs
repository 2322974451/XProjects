using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetRiftGuildRank : Rpc
	{

		public override uint GetRpcType()
		{
			return 28195U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetRiftGuildRankArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetRiftGuildRankRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetRiftGuildRank.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetRiftGuildRank.OnTimeout(this.oArg);
		}

		public GetRiftGuildRankArg oArg = new GetRiftGuildRankArg();

		public GetRiftGuildRankRes oRes = null;
	}
}
