using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200157E RID: 5502
	internal class RpcC2M_GroupChatManager : Rpc
	{
		// Token: 0x0600EB1A RID: 60186 RVA: 0x003453C4 File Offset: 0x003435C4
		public override uint GetRpcType()
		{
			return 35391U;
		}

		// Token: 0x0600EB1B RID: 60187 RVA: 0x003453DB File Offset: 0x003435DB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatManagerC2S>(stream, this.oArg);
		}

		// Token: 0x0600EB1C RID: 60188 RVA: 0x003453EB File Offset: 0x003435EB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GroupChatManagerS2C>(stream);
		}

		// Token: 0x0600EB1D RID: 60189 RVA: 0x003453FA File Offset: 0x003435FA
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GroupChatManager.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EB1E RID: 60190 RVA: 0x00345416 File Offset: 0x00343616
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GroupChatManager.OnTimeout(this.oArg);
		}

		// Token: 0x0400656B RID: 25963
		public GroupChatManagerC2S oArg = new GroupChatManagerC2S();

		// Token: 0x0400656C RID: 25964
		public GroupChatManagerS2C oRes = null;
	}
}
