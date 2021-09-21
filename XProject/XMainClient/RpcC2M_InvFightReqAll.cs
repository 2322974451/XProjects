using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013F4 RID: 5108
	internal class RpcC2M_InvFightReqAll : Rpc
	{
		// Token: 0x0600E4D4 RID: 58580 RVA: 0x0033C2AC File Offset: 0x0033A4AC
		public override uint GetRpcType()
		{
			return 56726U;
		}

		// Token: 0x0600E4D5 RID: 58581 RVA: 0x0033C2C3 File Offset: 0x0033A4C3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<InvFightArg>(stream, this.oArg);
		}

		// Token: 0x0600E4D6 RID: 58582 RVA: 0x0033C2D3 File Offset: 0x0033A4D3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<InvFightRes>(stream);
		}

		// Token: 0x0600E4D7 RID: 58583 RVA: 0x0033C2E2 File Offset: 0x0033A4E2
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_InvFightReqAll.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E4D8 RID: 58584 RVA: 0x0033C2FE File Offset: 0x0033A4FE
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_InvFightReqAll.OnTimeout(this.oArg);
		}

		// Token: 0x04006433 RID: 25651
		public InvFightArg oArg = new InvFightArg();

		// Token: 0x04006434 RID: 25652
		public InvFightRes oRes = null;
	}
}
