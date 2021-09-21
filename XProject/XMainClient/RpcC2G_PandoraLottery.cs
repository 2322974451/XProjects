using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001418 RID: 5144
	internal class RpcC2G_PandoraLottery : Rpc
	{
		// Token: 0x0600E568 RID: 58728 RVA: 0x0033CED8 File Offset: 0x0033B0D8
		public override uint GetRpcType()
		{
			return 12575U;
		}

		// Token: 0x0600E569 RID: 58729 RVA: 0x0033CEEF File Offset: 0x0033B0EF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PandoraLotteryArg>(stream, this.oArg);
		}

		// Token: 0x0600E56A RID: 58730 RVA: 0x0033CEFF File Offset: 0x0033B0FF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<PandoraLotteryRes>(stream);
		}

		// Token: 0x0600E56B RID: 58731 RVA: 0x0033CF0E File Offset: 0x0033B10E
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_PandoraLottery.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E56C RID: 58732 RVA: 0x0033CF2A File Offset: 0x0033B12A
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_PandoraLottery.OnTimeout(this.oArg);
		}

		// Token: 0x04006450 RID: 25680
		public PandoraLotteryArg oArg = new PandoraLotteryArg();

		// Token: 0x04006451 RID: 25681
		public PandoraLotteryRes oRes = null;
	}
}
