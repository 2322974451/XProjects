using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001260 RID: 4704
	internal class RpcC2G_ReEnterRiskBattle : Rpc
	{
		// Token: 0x0600DE58 RID: 56920 RVA: 0x003331DC File Offset: 0x003313DC
		public override uint GetRpcType()
		{
			return 1615U;
		}

		// Token: 0x0600DE59 RID: 56921 RVA: 0x003331F3 File Offset: 0x003313F3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReEnterRiskBattleArg>(stream, this.oArg);
		}

		// Token: 0x0600DE5A RID: 56922 RVA: 0x00333203 File Offset: 0x00331403
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ReEnterRiskBattleRes>(stream);
		}

		// Token: 0x0600DE5B RID: 56923 RVA: 0x00333212 File Offset: 0x00331412
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ReEnterRiskBattle.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DE5C RID: 56924 RVA: 0x0033322E File Offset: 0x0033142E
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ReEnterRiskBattle.OnTimeout(this.oArg);
		}

		// Token: 0x040062F2 RID: 25330
		public ReEnterRiskBattleArg oArg = new ReEnterRiskBattleArg();

		// Token: 0x040062F3 RID: 25331
		public ReEnterRiskBattleRes oRes = new ReEnterRiskBattleRes();
	}
}
