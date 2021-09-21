using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015A4 RID: 5540
	internal class RpcC2M_GroupChatLeaderAddRole : Rpc
	{
		// Token: 0x0600EBB7 RID: 60343 RVA: 0x003462DC File Offset: 0x003444DC
		public override uint GetRpcType()
		{
			return 44703U;
		}

		// Token: 0x0600EBB8 RID: 60344 RVA: 0x003462F3 File Offset: 0x003444F3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatLeaderAddRoleC2S>(stream, this.oArg);
		}

		// Token: 0x0600EBB9 RID: 60345 RVA: 0x00346303 File Offset: 0x00344503
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GroupChatLeaderAddRoleS2C>(stream);
		}

		// Token: 0x0600EBBA RID: 60346 RVA: 0x00346312 File Offset: 0x00344512
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GroupChatLeaderAddRole.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EBBB RID: 60347 RVA: 0x0034632E File Offset: 0x0034452E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GroupChatLeaderAddRole.OnTimeout(this.oArg);
		}

		// Token: 0x0400658A RID: 25994
		public GroupChatLeaderAddRoleC2S oArg = new GroupChatLeaderAddRoleC2S();

		// Token: 0x0400658B RID: 25995
		public GroupChatLeaderAddRoleS2C oRes = null;
	}
}
