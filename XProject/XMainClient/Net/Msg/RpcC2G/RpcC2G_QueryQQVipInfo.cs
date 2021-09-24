using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_QueryQQVipInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 43943U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QueryQQVipInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<QueryQQVipInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_QueryQQVipInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_QueryQQVipInfo.OnTimeout(this.oArg);
		}

		public QueryQQVipInfoArg oArg = new QueryQQVipInfoArg();

		public QueryQQVipInfoRes oRes = new QueryQQVipInfoRes();
	}
}
