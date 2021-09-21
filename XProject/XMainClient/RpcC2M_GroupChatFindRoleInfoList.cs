using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001570 RID: 5488
	internal class RpcC2M_GroupChatFindRoleInfoList : Rpc
	{
		// Token: 0x0600EADB RID: 60123 RVA: 0x00344ECC File Offset: 0x003430CC
		public override uint GetRpcType()
		{
			return 7283U;
		}

		// Token: 0x0600EADC RID: 60124 RVA: 0x00344EE3 File Offset: 0x003430E3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatFindRoleInfoListC2S>(stream, this.oArg);
		}

		// Token: 0x0600EADD RID: 60125 RVA: 0x00344EF3 File Offset: 0x003430F3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GroupChatFindRoleInfoListS2C>(stream);
		}

		// Token: 0x0600EADE RID: 60126 RVA: 0x00344F02 File Offset: 0x00343102
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GroupChatFindRoleInfoList.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EADF RID: 60127 RVA: 0x00344F1E File Offset: 0x0034311E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GroupChatFindRoleInfoList.OnTimeout(this.oArg);
		}

		// Token: 0x0400655D RID: 25949
		public GroupChatFindRoleInfoListC2S oArg = new GroupChatFindRoleInfoListC2S();

		// Token: 0x0400655E RID: 25950
		public GroupChatFindRoleInfoListS2C oRes = null;
	}
}
