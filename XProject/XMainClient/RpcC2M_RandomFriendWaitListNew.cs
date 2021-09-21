using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011AC RID: 4524
	internal class RpcC2M_RandomFriendWaitListNew : Rpc
	{
		// Token: 0x0600DB7A RID: 56186 RVA: 0x0032F1B0 File Offset: 0x0032D3B0
		public override uint GetRpcType()
		{
			return 65353U;
		}

		// Token: 0x0600DB7B RID: 56187 RVA: 0x0032F1C7 File Offset: 0x0032D3C7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<RandomFriendWaitListArg>(stream, this.oArg);
		}

		// Token: 0x0600DB7C RID: 56188 RVA: 0x0032F1D7 File Offset: 0x0032D3D7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<RandomFriendWaitListRes>(stream);
		}

		// Token: 0x0600DB7D RID: 56189 RVA: 0x0032F1E6 File Offset: 0x0032D3E6
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_RandomFriendWaitListNew.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DB7E RID: 56190 RVA: 0x0032F202 File Offset: 0x0032D402
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_RandomFriendWaitListNew.OnTimeout(this.oArg);
		}

		// Token: 0x04006266 RID: 25190
		public RandomFriendWaitListArg oArg = new RandomFriendWaitListArg();

		// Token: 0x04006267 RID: 25191
		public RandomFriendWaitListRes oRes = null;
	}
}
