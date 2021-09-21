using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011AA RID: 4522
	internal class RpcC2M_FriendGiftOpNew : Rpc
	{
		// Token: 0x0600DB71 RID: 56177 RVA: 0x0032F0F4 File Offset: 0x0032D2F4
		public override uint GetRpcType()
		{
			return 35639U;
		}

		// Token: 0x0600DB72 RID: 56178 RVA: 0x0032F10B File Offset: 0x0032D30B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FriendGiftOpArg>(stream, this.oArg);
		}

		// Token: 0x0600DB73 RID: 56179 RVA: 0x0032F11B File Offset: 0x0032D31B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<FriendGiftOpRes>(stream);
		}

		// Token: 0x0600DB74 RID: 56180 RVA: 0x0032F12A File Offset: 0x0032D32A
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_FriendGiftOpNew.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DB75 RID: 56181 RVA: 0x0032F146 File Offset: 0x0032D346
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_FriendGiftOpNew.OnTimeout(this.oArg);
		}

		// Token: 0x04006264 RID: 25188
		public FriendGiftOpArg oArg = new FriendGiftOpArg();

		// Token: 0x04006265 RID: 25189
		public FriendGiftOpRes oRes = null;
	}
}
