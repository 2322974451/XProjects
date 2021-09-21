using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015EB RID: 5611
	internal class RpcC2G_BattleFieldAwardNumReq : Rpc
	{
		// Token: 0x0600ECD9 RID: 60633 RVA: 0x0034799C File Offset: 0x00345B9C
		public override uint GetRpcType()
		{
			return 59171U;
		}

		// Token: 0x0600ECDA RID: 60634 RVA: 0x003479B3 File Offset: 0x00345BB3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BattleFieldAwardNumArg>(stream, this.oArg);
		}

		// Token: 0x0600ECDB RID: 60635 RVA: 0x003479C3 File Offset: 0x00345BC3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BattleFieldAwardNumRes>(stream);
		}

		// Token: 0x0600ECDC RID: 60636 RVA: 0x003479D2 File Offset: 0x00345BD2
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_BattleFieldAwardNumReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600ECDD RID: 60637 RVA: 0x003479EE File Offset: 0x00345BEE
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_BattleFieldAwardNumReq.OnTimeout(this.oArg);
		}

		// Token: 0x040065BF RID: 26047
		public BattleFieldAwardNumArg oArg = new BattleFieldAwardNumArg();

		// Token: 0x040065C0 RID: 26048
		public BattleFieldAwardNumRes oRes = null;
	}
}
