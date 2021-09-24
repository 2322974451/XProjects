using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GroupChatLeaderReview : Rpc
	{

		public override uint GetRpcType()
		{
			return 21611U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatLeaderReviewC2S>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GroupChatLeaderReviewS2C>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GroupChatLeaderReview.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GroupChatLeaderReview.OnTimeout(this.oArg);
		}

		public GroupChatLeaderReviewC2S oArg = new GroupChatLeaderReviewC2S();

		public GroupChatLeaderReviewS2C oRes = null;
	}
}
