using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200157A RID: 5498
	internal class RpcC2M_GroupChatPlayerApply : Rpc
	{
		// Token: 0x0600EB08 RID: 60168 RVA: 0x00345200 File Offset: 0x00343400
		public override uint GetRpcType()
		{
			return 24788U;
		}

		// Token: 0x0600EB09 RID: 60169 RVA: 0x00345217 File Offset: 0x00343417
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatPlayerApplyC2S>(stream, this.oArg);
		}

		// Token: 0x0600EB0A RID: 60170 RVA: 0x00345227 File Offset: 0x00343427
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GroupChatPlayerApplyS2C>(stream);
		}

		// Token: 0x0600EB0B RID: 60171 RVA: 0x00345236 File Offset: 0x00343436
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GroupChatPlayerApply.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EB0C RID: 60172 RVA: 0x00345252 File Offset: 0x00343452
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GroupChatPlayerApply.OnTimeout(this.oArg);
		}

		// Token: 0x04006567 RID: 25959
		public GroupChatPlayerApplyC2S oArg = new GroupChatPlayerApplyC2S();

		// Token: 0x04006568 RID: 25960
		public GroupChatPlayerApplyS2C oRes = null;
	}
}
