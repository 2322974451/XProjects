using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001029 RID: 4137
	internal class RpcC2G_DrawLottery : Rpc
	{
		// Token: 0x0600D54E RID: 54606 RVA: 0x00323BE0 File Offset: 0x00321DE0
		public override uint GetRpcType()
		{
			return 27802U;
		}

		// Token: 0x0600D54F RID: 54607 RVA: 0x00323BF7 File Offset: 0x00321DF7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DrawLotteryArg>(stream, this.oArg);
		}

		// Token: 0x0600D550 RID: 54608 RVA: 0x00323C07 File Offset: 0x00321E07
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DrawLotteryRes>(stream);
		}

		// Token: 0x0600D551 RID: 54609 RVA: 0x00323C16 File Offset: 0x00321E16
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_DrawLottery.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D552 RID: 54610 RVA: 0x00323C32 File Offset: 0x00321E32
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_DrawLottery.OnTimeout(this.oArg);
		}

		// Token: 0x0400611B RID: 24859
		public DrawLotteryArg oArg = new DrawLotteryArg();

		// Token: 0x0400611C RID: 24860
		public DrawLotteryRes oRes = new DrawLotteryRes();
	}
}
