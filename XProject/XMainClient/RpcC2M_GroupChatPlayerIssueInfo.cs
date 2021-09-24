using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GroupChatPlayerIssueInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 48317U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatPlayerIssueInfoC2S>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GroupChatPlayerIssueInfoS2C>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GroupChatPlayerIssueInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GroupChatPlayerIssueInfo.OnTimeout(this.oArg);
		}

		public GroupChatPlayerIssueInfoC2S oArg = new GroupChatPlayerIssueInfoC2S();

		public GroupChatPlayerIssueInfoS2C oRes = null;
	}
}
