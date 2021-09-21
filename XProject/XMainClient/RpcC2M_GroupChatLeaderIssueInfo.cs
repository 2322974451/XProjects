using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001576 RID: 5494
	internal class RpcC2M_GroupChatLeaderIssueInfo : Rpc
	{
		// Token: 0x0600EAF6 RID: 60150 RVA: 0x003450B8 File Offset: 0x003432B8
		public override uint GetRpcType()
		{
			return 9594U;
		}

		// Token: 0x0600EAF7 RID: 60151 RVA: 0x003450CF File Offset: 0x003432CF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatLeaderIssueInfoC2S>(stream, this.oArg);
		}

		// Token: 0x0600EAF8 RID: 60152 RVA: 0x003450DF File Offset: 0x003432DF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GroupChatLeaderIssueInfoS2C>(stream);
		}

		// Token: 0x0600EAF9 RID: 60153 RVA: 0x003450EE File Offset: 0x003432EE
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GroupChatLeaderIssueInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EAFA RID: 60154 RVA: 0x0034510A File Offset: 0x0034330A
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GroupChatLeaderIssueInfo.OnTimeout(this.oArg);
		}

		// Token: 0x04006563 RID: 25955
		public GroupChatLeaderIssueInfoC2S oArg = new GroupChatLeaderIssueInfoC2S();

		// Token: 0x04006564 RID: 25956
		public GroupChatLeaderIssueInfoS2C oRes = null;
	}
}
