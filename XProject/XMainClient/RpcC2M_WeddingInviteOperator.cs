using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200159E RID: 5534
	internal class RpcC2M_WeddingInviteOperator : Rpc
	{
		// Token: 0x0600EBA0 RID: 60320 RVA: 0x00346128 File Offset: 0x00344328
		public override uint GetRpcType()
		{
			return 8562U;
		}

		// Token: 0x0600EBA1 RID: 60321 RVA: 0x0034613F File Offset: 0x0034433F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WeddingInviteOperatorArg>(stream, this.oArg);
		}

		// Token: 0x0600EBA2 RID: 60322 RVA: 0x0034614F File Offset: 0x0034434F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<WeddingInviteOperatorRes>(stream);
		}

		// Token: 0x0600EBA3 RID: 60323 RVA: 0x0034615E File Offset: 0x0034435E
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_WeddingInviteOperator.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EBA4 RID: 60324 RVA: 0x0034617A File Offset: 0x0034437A
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_WeddingInviteOperator.OnTimeout(this.oArg);
		}

		// Token: 0x04006586 RID: 25990
		public WeddingInviteOperatorArg oArg = new WeddingInviteOperatorArg();

		// Token: 0x04006587 RID: 25991
		public WeddingInviteOperatorRes oRes = null;
	}
}
