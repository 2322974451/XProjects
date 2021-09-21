using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001112 RID: 4370
	internal class RpcC2G_SendGuildBonus : Rpc
	{
		// Token: 0x0600D909 RID: 55561 RVA: 0x0032A654 File Offset: 0x00328854
		public override uint GetRpcType()
		{
			return 61243U;
		}

		// Token: 0x0600D90A RID: 55562 RVA: 0x0032A66B File Offset: 0x0032886B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SendGuildBonusArg>(stream, this.oArg);
		}

		// Token: 0x0600D90B RID: 55563 RVA: 0x0032A67B File Offset: 0x0032887B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SendGuildBonusRes>(stream);
		}

		// Token: 0x0600D90C RID: 55564 RVA: 0x0032A68A File Offset: 0x0032888A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_SendGuildBonus.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D90D RID: 55565 RVA: 0x0032A6A6 File Offset: 0x003288A6
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_SendGuildBonus.OnTimeout(this.oArg);
		}

		// Token: 0x040061F1 RID: 25073
		public SendGuildBonusArg oArg = new SendGuildBonusArg();

		// Token: 0x040061F2 RID: 25074
		public SendGuildBonusRes oRes = new SendGuildBonusRes();
	}
}
