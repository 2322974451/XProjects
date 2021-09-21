using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200143E RID: 5182
	internal class RpcC2G_SetHeroInHeroBattle : Rpc
	{
		// Token: 0x0600E602 RID: 58882 RVA: 0x0033DBD8 File Offset: 0x0033BDD8
		public override uint GetRpcType()
		{
			return 18341U;
		}

		// Token: 0x0600E603 RID: 58883 RVA: 0x0033DBEF File Offset: 0x0033BDEF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SetHeroInHeroBattleArg>(stream, this.oArg);
		}

		// Token: 0x0600E604 RID: 58884 RVA: 0x0033DBFF File Offset: 0x0033BDFF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SetHeroInHeroBattleRes>(stream);
		}

		// Token: 0x0600E605 RID: 58885 RVA: 0x0033DC0E File Offset: 0x0033BE0E
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_SetHeroInHeroBattle.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E606 RID: 58886 RVA: 0x0033DC2A File Offset: 0x0033BE2A
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_SetHeroInHeroBattle.OnTimeout(this.oArg);
		}

		// Token: 0x0400646C RID: 25708
		public SetHeroInHeroBattleArg oArg = new SetHeroInHeroBattleArg();

		// Token: 0x0400646D RID: 25709
		public SetHeroInHeroBattleRes oRes = null;
	}
}
