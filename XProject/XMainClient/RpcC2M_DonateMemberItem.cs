using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001395 RID: 5013
	internal class RpcC2M_DonateMemberItem : Rpc
	{
		// Token: 0x0600E34E RID: 58190 RVA: 0x0033A2D8 File Offset: 0x003384D8
		public override uint GetRpcType()
		{
			return 4241U;
		}

		// Token: 0x0600E34F RID: 58191 RVA: 0x0033A2EF File Offset: 0x003384EF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DonateMemberItemArg>(stream, this.oArg);
		}

		// Token: 0x0600E350 RID: 58192 RVA: 0x0033A2FF File Offset: 0x003384FF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DonateMemberItemRes>(stream);
		}

		// Token: 0x0600E351 RID: 58193 RVA: 0x0033A30E File Offset: 0x0033850E
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_DonateMemberItem.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E352 RID: 58194 RVA: 0x0033A32A File Offset: 0x0033852A
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_DonateMemberItem.OnTimeout(this.oArg);
		}

		// Token: 0x040063E8 RID: 25576
		public DonateMemberItemArg oArg = new DonateMemberItemArg();

		// Token: 0x040063E9 RID: 25577
		public DonateMemberItemRes oRes = null;
	}
}
