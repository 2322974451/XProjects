using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_QueryQQFriendsVipInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 11531U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QueryQQFriendsVipInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<QueryQQFriendsVipInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_QueryQQFriendsVipInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_QueryQQFriendsVipInfo.OnTimeout(this.oArg);
		}

		public QueryQQFriendsVipInfoArg oArg = new QueryQQFriendsVipInfoArg();

		public QueryQQFriendsVipInfoRes oRes = null;
	}
}
