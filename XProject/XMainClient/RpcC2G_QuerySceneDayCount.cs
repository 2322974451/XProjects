using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_QuerySceneDayCount : Rpc
	{

		public override uint GetRpcType()
		{
			return 1676U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QuerySceneDayCountArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<QuerySceneDayCountRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_QuerySceneDayCount.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_QuerySceneDayCount.OnTimeout(this.oArg);
		}

		public QuerySceneDayCountArg oArg = new QuerySceneDayCountArg();

		public QuerySceneDayCountRes oRes = new QuerySceneDayCountRes();
	}
}
