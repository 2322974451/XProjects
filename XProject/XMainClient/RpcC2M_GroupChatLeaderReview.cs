using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001578 RID: 5496
	internal class RpcC2M_GroupChatLeaderReview : Rpc
	{
		// Token: 0x0600EAFF RID: 60159 RVA: 0x0034515C File Offset: 0x0034335C
		public override uint GetRpcType()
		{
			return 21611U;
		}

		// Token: 0x0600EB00 RID: 60160 RVA: 0x00345173 File Offset: 0x00343373
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatLeaderReviewC2S>(stream, this.oArg);
		}

		// Token: 0x0600EB01 RID: 60161 RVA: 0x00345183 File Offset: 0x00343383
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GroupChatLeaderReviewS2C>(stream);
		}

		// Token: 0x0600EB02 RID: 60162 RVA: 0x00345192 File Offset: 0x00343392
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GroupChatLeaderReview.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EB03 RID: 60163 RVA: 0x003451AE File Offset: 0x003433AE
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GroupChatLeaderReview.OnTimeout(this.oArg);
		}

		// Token: 0x04006565 RID: 25957
		public GroupChatLeaderReviewC2S oArg = new GroupChatLeaderReviewC2S();

		// Token: 0x04006566 RID: 25958
		public GroupChatLeaderReviewS2C oRes = null;
	}
}
