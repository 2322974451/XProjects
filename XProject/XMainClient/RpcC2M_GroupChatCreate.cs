using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001584 RID: 5508
	internal class RpcC2M_GroupChatCreate : Rpc
	{
		// Token: 0x0600EB33 RID: 60211 RVA: 0x00345660 File Offset: 0x00343860
		public override uint GetRpcType()
		{
			return 59293U;
		}

		// Token: 0x0600EB34 RID: 60212 RVA: 0x00345677 File Offset: 0x00343877
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatCreateC2S>(stream, this.oArg);
		}

		// Token: 0x0600EB35 RID: 60213 RVA: 0x00345687 File Offset: 0x00343887
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GroupChatCreateS2C>(stream);
		}

		// Token: 0x0600EB36 RID: 60214 RVA: 0x00345696 File Offset: 0x00343896
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GroupChatCreate.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EB37 RID: 60215 RVA: 0x003456B2 File Offset: 0x003438B2
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GroupChatCreate.OnTimeout(this.oArg);
		}

		// Token: 0x04006570 RID: 25968
		public GroupChatCreateC2S oArg = new GroupChatCreateC2S();

		// Token: 0x04006571 RID: 25969
		public GroupChatCreateS2C oRes = null;
	}
}
