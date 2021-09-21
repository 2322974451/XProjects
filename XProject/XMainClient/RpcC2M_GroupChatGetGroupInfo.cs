using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200157C RID: 5500
	internal class RpcC2M_GroupChatGetGroupInfo : Rpc
	{
		// Token: 0x0600EB11 RID: 60177 RVA: 0x003452A4 File Offset: 0x003434A4
		public override uint GetRpcType()
		{
			return 64081U;
		}

		// Token: 0x0600EB12 RID: 60178 RVA: 0x003452BB File Offset: 0x003434BB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatGetGroupInfoC2S>(stream, this.oArg);
		}

		// Token: 0x0600EB13 RID: 60179 RVA: 0x003452CB File Offset: 0x003434CB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GroupChatGetGroupInfoS2C>(stream);
		}

		// Token: 0x0600EB14 RID: 60180 RVA: 0x003452DA File Offset: 0x003434DA
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GroupChatGetGroupInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EB15 RID: 60181 RVA: 0x003452F6 File Offset: 0x003434F6
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GroupChatGetGroupInfo.OnTimeout(this.oArg);
		}

		// Token: 0x04006569 RID: 25961
		public GroupChatGetGroupInfoC2S oArg = new GroupChatGetGroupInfoC2S();

		// Token: 0x0400656A RID: 25962
		public GroupChatGetGroupInfoS2C oRes = null;
	}
}
