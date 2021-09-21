using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013F2 RID: 5106
	internal class RpcC2M_CancelLeavePartner : Rpc
	{
		// Token: 0x0600E4CB RID: 58571 RVA: 0x0033C220 File Offset: 0x0033A420
		public override uint GetRpcType()
		{
			return 27794U;
		}

		// Token: 0x0600E4CC RID: 58572 RVA: 0x0033C237 File Offset: 0x0033A437
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CancelLeavePartnerArg>(stream, this.oArg);
		}

		// Token: 0x0600E4CD RID: 58573 RVA: 0x0033C247 File Offset: 0x0033A447
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<CancelLeavePartnerRes>(stream);
		}

		// Token: 0x0600E4CE RID: 58574 RVA: 0x0033C256 File Offset: 0x0033A456
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_CancelLeavePartner.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E4CF RID: 58575 RVA: 0x0033C272 File Offset: 0x0033A472
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_CancelLeavePartner.OnTimeout(this.oArg);
		}

		// Token: 0x04006431 RID: 25649
		public CancelLeavePartnerArg oArg = new CancelLeavePartnerArg();

		// Token: 0x04006432 RID: 25650
		public CancelLeavePartnerRes oRes = null;
	}
}
