using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001221 RID: 4641
	internal class RpcC2M_ClearPrivateChatList : Rpc
	{
		// Token: 0x0600DD50 RID: 56656 RVA: 0x00331B18 File Offset: 0x0032FD18
		public override uint GetRpcType()
		{
			return 27304U;
		}

		// Token: 0x0600DD51 RID: 56657 RVA: 0x00331B2F File Offset: 0x0032FD2F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ClearPrivateChatListArg>(stream, this.oArg);
		}

		// Token: 0x0600DD52 RID: 56658 RVA: 0x00331B3F File Offset: 0x0032FD3F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ClearPrivateChatListRes>(stream);
		}

		// Token: 0x0600DD53 RID: 56659 RVA: 0x00331B4E File Offset: 0x0032FD4E
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ClearPrivateChatList.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DD54 RID: 56660 RVA: 0x00331B6A File Offset: 0x0032FD6A
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ClearPrivateChatList.OnTimeout(this.oArg);
		}

		// Token: 0x040062BD RID: 25277
		public ClearPrivateChatListArg oArg = new ClearPrivateChatListArg();

		// Token: 0x040062BE RID: 25278
		public ClearPrivateChatListRes oRes = null;
	}
}
