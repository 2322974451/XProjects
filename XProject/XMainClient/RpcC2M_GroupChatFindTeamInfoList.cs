using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200156E RID: 5486
	internal class RpcC2M_GroupChatFindTeamInfoList : Rpc
	{
		// Token: 0x0600EAD2 RID: 60114 RVA: 0x00344E28 File Offset: 0x00343028
		public override uint GetRpcType()
		{
			return 46399U;
		}

		// Token: 0x0600EAD3 RID: 60115 RVA: 0x00344E3F File Offset: 0x0034303F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatFindTeamInfoListC2S>(stream, this.oArg);
		}

		// Token: 0x0600EAD4 RID: 60116 RVA: 0x00344E4F File Offset: 0x0034304F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GroupChatFindTeamInfoListS2C>(stream);
		}

		// Token: 0x0600EAD5 RID: 60117 RVA: 0x00344E5E File Offset: 0x0034305E
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GroupChatFindTeamInfoList.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EAD6 RID: 60118 RVA: 0x00344E7A File Offset: 0x0034307A
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GroupChatFindTeamInfoList.OnTimeout(this.oArg);
		}

		// Token: 0x0400655B RID: 25947
		public GroupChatFindTeamInfoListC2S oArg = new GroupChatFindTeamInfoListC2S();

		// Token: 0x0400655C RID: 25948
		public GroupChatFindTeamInfoListS2C oRes = null;
	}
}
