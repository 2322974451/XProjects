using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001202 RID: 4610
	internal class RpcC2G_ChooseRollReq : Rpc
	{
		// Token: 0x0600DCCC RID: 56524 RVA: 0x00330D98 File Offset: 0x0032EF98
		public override uint GetRpcType()
		{
			return 50047U;
		}

		// Token: 0x0600DCCD RID: 56525 RVA: 0x00330DAF File Offset: 0x0032EFAF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChooseRollReqArg>(stream, this.oArg);
		}

		// Token: 0x0600DCCE RID: 56526 RVA: 0x00330DBF File Offset: 0x0032EFBF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ChooseRollReqRes>(stream);
		}

		// Token: 0x0600DCCF RID: 56527 RVA: 0x00330DCE File Offset: 0x0032EFCE
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ChooseRollReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DCD0 RID: 56528 RVA: 0x00330DEA File Offset: 0x0032EFEA
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ChooseRollReq.OnTimeout(this.oArg);
		}

		// Token: 0x040062A2 RID: 25250
		public ChooseRollReqArg oArg = new ChooseRollReqArg();

		// Token: 0x040062A3 RID: 25251
		public ChooseRollReqRes oRes = new ChooseRollReqRes();
	}
}
