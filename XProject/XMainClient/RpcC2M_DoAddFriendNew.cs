using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011A2 RID: 4514
	internal class RpcC2M_DoAddFriendNew : Rpc
	{
		// Token: 0x0600DB4D RID: 56141 RVA: 0x0032ED4C File Offset: 0x0032CF4C
		public override uint GetRpcType()
		{
			return 23397U;
		}

		// Token: 0x0600DB4E RID: 56142 RVA: 0x0032ED63 File Offset: 0x0032CF63
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DoAddFriendArg>(stream, this.oArg);
		}

		// Token: 0x0600DB4F RID: 56143 RVA: 0x0032ED73 File Offset: 0x0032CF73
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DoAddFriendRes>(stream);
		}

		// Token: 0x0600DB50 RID: 56144 RVA: 0x0032ED82 File Offset: 0x0032CF82
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_DoAddFriendNew.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DB51 RID: 56145 RVA: 0x0032ED9E File Offset: 0x0032CF9E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_DoAddFriendNew.OnTimeout(this.oArg);
		}

		// Token: 0x0400625C RID: 25180
		public DoAddFriendArg oArg = new DoAddFriendArg();

		// Token: 0x0400625D RID: 25181
		public DoAddFriendRes oRes = null;
	}
}
