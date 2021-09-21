using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001574 RID: 5492
	internal class RpcC2M_GroupChatPlayerIssueInfo : Rpc
	{
		// Token: 0x0600EAED RID: 60141 RVA: 0x00345014 File Offset: 0x00343214
		public override uint GetRpcType()
		{
			return 48317U;
		}

		// Token: 0x0600EAEE RID: 60142 RVA: 0x0034502B File Offset: 0x0034322B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatPlayerIssueInfoC2S>(stream, this.oArg);
		}

		// Token: 0x0600EAEF RID: 60143 RVA: 0x0034503B File Offset: 0x0034323B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GroupChatPlayerIssueInfoS2C>(stream);
		}

		// Token: 0x0600EAF0 RID: 60144 RVA: 0x0034504A File Offset: 0x0034324A
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GroupChatPlayerIssueInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EAF1 RID: 60145 RVA: 0x00345066 File Offset: 0x00343266
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GroupChatPlayerIssueInfo.OnTimeout(this.oArg);
		}

		// Token: 0x04006561 RID: 25953
		public GroupChatPlayerIssueInfoC2S oArg = new GroupChatPlayerIssueInfoC2S();

		// Token: 0x04006562 RID: 25954
		public GroupChatPlayerIssueInfoS2C oRes = null;
	}
}
