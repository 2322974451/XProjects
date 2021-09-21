using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000B43 RID: 2883
	internal class RpcC2M_AddFriendNew : Rpc
	{
		// Token: 0x0600A878 RID: 43128 RVA: 0x001E0AA0 File Offset: 0x001DECA0
		public override uint GetRpcType()
		{
			return 5634U;
		}

		// Token: 0x0600A879 RID: 43129 RVA: 0x001E0AB7 File Offset: 0x001DECB7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AddFriendArg>(stream, this.oArg);
		}

		// Token: 0x0600A87A RID: 43130 RVA: 0x001E0AC7 File Offset: 0x001DECC7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AddFriendRes>(stream);
		}

		// Token: 0x0600A87B RID: 43131 RVA: 0x001E0AD6 File Offset: 0x001DECD6
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_AddFriendNew.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600A87C RID: 43132 RVA: 0x001E0AF2 File Offset: 0x001DECF2
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_AddFriendNew.OnTimeout(this.oArg);
		}

		// Token: 0x04003E71 RID: 15985
		public AddFriendArg oArg = new AddFriendArg();

		// Token: 0x04003E72 RID: 15986
		public AddFriendRes oRes = null;
	}
}
