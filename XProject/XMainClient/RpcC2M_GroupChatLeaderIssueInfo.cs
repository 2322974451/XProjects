using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GroupChatLeaderIssueInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 9594U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatLeaderIssueInfoC2S>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GroupChatLeaderIssueInfoS2C>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GroupChatLeaderIssueInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GroupChatLeaderIssueInfo.OnTimeout(this.oArg);
		}

		public GroupChatLeaderIssueInfoC2S oArg = new GroupChatLeaderIssueInfoC2S();

		public GroupChatLeaderIssueInfoS2C oRes = null;
	}
}
