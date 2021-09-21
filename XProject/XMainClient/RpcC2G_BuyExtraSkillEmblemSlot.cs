using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200150C RID: 5388
	internal class RpcC2G_BuyExtraSkillEmblemSlot : Rpc
	{
		// Token: 0x0600E948 RID: 59720 RVA: 0x00342804 File Offset: 0x00340A04
		public override uint GetRpcType()
		{
			return 17851U;
		}

		// Token: 0x0600E949 RID: 59721 RVA: 0x0034281B File Offset: 0x00340A1B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BuyExtraSkillEmblemSlotArg>(stream, this.oArg);
		}

		// Token: 0x0600E94A RID: 59722 RVA: 0x0034282B File Offset: 0x00340A2B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BuyExtraSkillEmblemSlotRes>(stream);
		}

		// Token: 0x0600E94B RID: 59723 RVA: 0x0034283A File Offset: 0x00340A3A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_BuyExtraSkillEmblemSlot.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E94C RID: 59724 RVA: 0x00342856 File Offset: 0x00340A56
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_BuyExtraSkillEmblemSlot.OnTimeout(this.oArg);
		}

		// Token: 0x0400650A RID: 25866
		public BuyExtraSkillEmblemSlotArg oArg = new BuyExtraSkillEmblemSlotArg();

		// Token: 0x0400650B RID: 25867
		public BuyExtraSkillEmblemSlotRes oRes = null;
	}
}
