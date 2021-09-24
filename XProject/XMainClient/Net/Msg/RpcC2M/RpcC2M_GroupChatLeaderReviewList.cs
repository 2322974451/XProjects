using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GroupChatLeaderReviewList : Rpc
	{

		public override uint GetRpcType()
		{
			return 33836U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatLeaderReviewListC2S>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GroupChatLeaderReviewListS2C>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GroupChatLeaderReviewList.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GroupChatLeaderReviewList.OnTimeout(this.oArg);
		}

		public GroupChatLeaderReviewListC2S oArg = new GroupChatLeaderReviewListC2S();

		public GroupChatLeaderReviewListS2C oRes = null;
	}
}
