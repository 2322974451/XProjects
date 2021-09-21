using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001572 RID: 5490
	internal class RpcC2M_GroupChatLeaderReviewList : Rpc
	{
		// Token: 0x0600EAE4 RID: 60132 RVA: 0x00344F70 File Offset: 0x00343170
		public override uint GetRpcType()
		{
			return 33836U;
		}

		// Token: 0x0600EAE5 RID: 60133 RVA: 0x00344F87 File Offset: 0x00343187
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatLeaderReviewListC2S>(stream, this.oArg);
		}

		// Token: 0x0600EAE6 RID: 60134 RVA: 0x00344F97 File Offset: 0x00343197
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GroupChatLeaderReviewListS2C>(stream);
		}

		// Token: 0x0600EAE7 RID: 60135 RVA: 0x00344FA6 File Offset: 0x003431A6
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GroupChatLeaderReviewList.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EAE8 RID: 60136 RVA: 0x00344FC2 File Offset: 0x003431C2
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GroupChatLeaderReviewList.OnTimeout(this.oArg);
		}

		// Token: 0x0400655F RID: 25951
		public GroupChatLeaderReviewListC2S oArg = new GroupChatLeaderReviewListC2S();

		// Token: 0x04006560 RID: 25952
		public GroupChatLeaderReviewListS2C oRes = null;
	}
}
