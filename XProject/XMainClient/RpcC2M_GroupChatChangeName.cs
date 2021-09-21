using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015B9 RID: 5561
	internal class RpcC2M_GroupChatChangeName : Rpc
	{
		// Token: 0x0600EC08 RID: 60424 RVA: 0x00346880 File Offset: 0x00344A80
		public override uint GetRpcType()
		{
			return 44170U;
		}

		// Token: 0x0600EC09 RID: 60425 RVA: 0x00346897 File Offset: 0x00344A97
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatChangeNameC2S>(stream, this.oArg);
		}

		// Token: 0x0600EC0A RID: 60426 RVA: 0x003468A7 File Offset: 0x00344AA7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GroupChatChangeNameS2C>(stream);
		}

		// Token: 0x0600EC0B RID: 60427 RVA: 0x003468B6 File Offset: 0x00344AB6
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GroupChatChangeName.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EC0C RID: 60428 RVA: 0x003468D2 File Offset: 0x00344AD2
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GroupChatChangeName.OnTimeout(this.oArg);
		}

		// Token: 0x04006596 RID: 26006
		public GroupChatChangeNameC2S oArg = new GroupChatChangeNameC2S();

		// Token: 0x04006597 RID: 26007
		public GroupChatChangeNameS2C oRes = null;
	}
}
