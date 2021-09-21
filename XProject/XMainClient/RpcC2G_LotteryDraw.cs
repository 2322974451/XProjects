using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200160D RID: 5645
	internal class RpcC2G_LotteryDraw : Rpc
	{
		// Token: 0x0600ED68 RID: 60776 RVA: 0x00348480 File Offset: 0x00346680
		public override uint GetRpcType()
		{
			return 47060U;
		}

		// Token: 0x0600ED69 RID: 60777 RVA: 0x00348497 File Offset: 0x00346697
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LotteryDrawReq>(stream, this.oArg);
		}

		// Token: 0x0600ED6A RID: 60778 RVA: 0x003484A7 File Offset: 0x003466A7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<LotteryDrawRes>(stream);
		}

		// Token: 0x0600ED6B RID: 60779 RVA: 0x003484B6 File Offset: 0x003466B6
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_LotteryDraw.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600ED6C RID: 60780 RVA: 0x003484D2 File Offset: 0x003466D2
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_LotteryDraw.OnTimeout(this.oArg);
		}

		// Token: 0x040065DC RID: 26076
		public LotteryDrawReq oArg = new LotteryDrawReq();

		// Token: 0x040065DD RID: 26077
		public LotteryDrawRes oRes = null;
	}
}
