using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001116 RID: 4374
	internal class RpcC2G_ThanksForBonus : Rpc
	{
		// Token: 0x0600D91B RID: 55579 RVA: 0x0032A804 File Offset: 0x00328A04
		public override uint GetRpcType()
		{
			return 42614U;
		}

		// Token: 0x0600D91C RID: 55580 RVA: 0x0032A81B File Offset: 0x00328A1B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ThanksForBonusArg>(stream, this.oArg);
		}

		// Token: 0x0600D91D RID: 55581 RVA: 0x0032A82B File Offset: 0x00328A2B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ThanksForBonusRes>(stream);
		}

		// Token: 0x0600D91E RID: 55582 RVA: 0x0032A83A File Offset: 0x00328A3A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ThanksForBonus.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D91F RID: 55583 RVA: 0x0032A856 File Offset: 0x00328A56
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ThanksForBonus.OnTimeout(this.oArg);
		}

		// Token: 0x040061F5 RID: 25077
		public ThanksForBonusArg oArg = new ThanksForBonusArg();

		// Token: 0x040061F6 RID: 25078
		public ThanksForBonusRes oRes = new ThanksForBonusRes();
	}
}
