using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013EC RID: 5100
	internal class RpcC2M_LeavePartner : Rpc
	{
		// Token: 0x0600E4B2 RID: 58546 RVA: 0x0033C038 File Offset: 0x0033A238
		public override uint GetRpcType()
		{
			return 63769U;
		}

		// Token: 0x0600E4B3 RID: 58547 RVA: 0x0033C04F File Offset: 0x0033A24F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LeavePartnerArg>(stream, this.oArg);
		}

		// Token: 0x0600E4B4 RID: 58548 RVA: 0x0033C05F File Offset: 0x0033A25F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<LeavePartnerRes>(stream);
		}

		// Token: 0x0600E4B5 RID: 58549 RVA: 0x0033C06E File Offset: 0x0033A26E
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_LeavePartner.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E4B6 RID: 58550 RVA: 0x0033C08A File Offset: 0x0033A28A
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_LeavePartner.OnTimeout(this.oArg);
		}

		// Token: 0x0400642C RID: 25644
		public LeavePartnerArg oArg = new LeavePartnerArg();

		// Token: 0x0400642D RID: 25645
		public LeavePartnerRes oRes = null;
	}
}
