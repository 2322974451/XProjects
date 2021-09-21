using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001450 RID: 5200
	internal class RpcC2G_BuyHeroInHeroBattle : Rpc
	{
		// Token: 0x0600E649 RID: 58953 RVA: 0x0033E3A8 File Offset: 0x0033C5A8
		public override uint GetRpcType()
		{
			return 7735U;
		}

		// Token: 0x0600E64A RID: 58954 RVA: 0x0033E3BF File Offset: 0x0033C5BF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BuyHeroInHeroBattleArg>(stream, this.oArg);
		}

		// Token: 0x0600E64B RID: 58955 RVA: 0x0033E3CF File Offset: 0x0033C5CF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BuyHeroInHeroBattleRes>(stream);
		}

		// Token: 0x0600E64C RID: 58956 RVA: 0x0033E3DE File Offset: 0x0033C5DE
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_BuyHeroInHeroBattle.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E64D RID: 58957 RVA: 0x0033E3FA File Offset: 0x0033C5FA
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_BuyHeroInHeroBattle.OnTimeout(this.oArg);
		}

		// Token: 0x04006478 RID: 25720
		public BuyHeroInHeroBattleArg oArg = new BuyHeroInHeroBattleArg();

		// Token: 0x04006479 RID: 25721
		public BuyHeroInHeroBattleRes oRes = null;
	}
}
