using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_ReqPlatFriendRankList : Rpc
	{

		public override uint GetRpcType()
		{
			return 43806U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReqPlatFriendRankListArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ReqPlatFriendRankListRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ReqPlatFriendRankList.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ReqPlatFriendRankList.OnTimeout(this.oArg);
		}

		public ReqPlatFriendRankListArg oArg = new ReqPlatFriendRankListArg();

		public ReqPlatFriendRankListRes oRes = null;
	}
}
