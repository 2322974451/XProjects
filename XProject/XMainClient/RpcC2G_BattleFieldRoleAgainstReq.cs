using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015FB RID: 5627
	internal class RpcC2G_BattleFieldRoleAgainstReq : Rpc
	{
		// Token: 0x0600ED1B RID: 60699 RVA: 0x00347EE4 File Offset: 0x003460E4
		public override uint GetRpcType()
		{
			return 12475U;
		}

		// Token: 0x0600ED1C RID: 60700 RVA: 0x00347EFB File Offset: 0x003460FB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BattleFieldRoleAgainstArg>(stream, this.oArg);
		}

		// Token: 0x0600ED1D RID: 60701 RVA: 0x00347F0B File Offset: 0x0034610B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BattleFieldRoleAgainst>(stream);
		}

		// Token: 0x0600ED1E RID: 60702 RVA: 0x00347F1A File Offset: 0x0034611A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_BattleFieldRoleAgainstReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600ED1F RID: 60703 RVA: 0x00347F36 File Offset: 0x00346136
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_BattleFieldRoleAgainstReq.OnTimeout(this.oArg);
		}

		// Token: 0x040065CC RID: 26060
		public BattleFieldRoleAgainstArg oArg = new BattleFieldRoleAgainstArg();

		// Token: 0x040065CD RID: 26061
		public BattleFieldRoleAgainst oRes = null;
	}
}
