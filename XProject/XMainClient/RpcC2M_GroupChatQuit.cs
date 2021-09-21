using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001580 RID: 5504
	internal class RpcC2M_GroupChatQuit : Rpc
	{
		// Token: 0x0600EB23 RID: 60195 RVA: 0x003454CC File Offset: 0x003436CC
		public override uint GetRpcType()
		{
			return 58833U;
		}

		// Token: 0x0600EB24 RID: 60196 RVA: 0x003454E3 File Offset: 0x003436E3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatQuitC2S>(stream, this.oArg);
		}

		// Token: 0x0600EB25 RID: 60197 RVA: 0x003454F3 File Offset: 0x003436F3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GroupChatQuitS2C>(stream);
		}

		// Token: 0x0600EB26 RID: 60198 RVA: 0x00345502 File Offset: 0x00343702
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GroupChatQuit.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EB27 RID: 60199 RVA: 0x0034551E File Offset: 0x0034371E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GroupChatQuit.OnTimeout(this.oArg);
		}

		// Token: 0x0400656D RID: 25965
		public GroupChatQuitC2S oArg = new GroupChatQuitC2S();

		// Token: 0x0400656E RID: 25966
		public GroupChatQuitS2C oRes = null;
	}
}
