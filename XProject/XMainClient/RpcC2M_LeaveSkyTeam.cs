using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014D7 RID: 5335
	internal class RpcC2M_LeaveSkyTeam : Rpc
	{
		// Token: 0x0600E867 RID: 59495 RVA: 0x00341480 File Offset: 0x0033F680
		public override uint GetRpcType()
		{
			return 26181U;
		}

		// Token: 0x0600E868 RID: 59496 RVA: 0x00341497 File Offset: 0x0033F697
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LeaveSkyTeamArg>(stream, this.oArg);
		}

		// Token: 0x0600E869 RID: 59497 RVA: 0x003414A7 File Offset: 0x0033F6A7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<LeaveSkyTeamRes>(stream);
		}

		// Token: 0x0600E86A RID: 59498 RVA: 0x003414B6 File Offset: 0x0033F6B6
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_LeaveSkyTeam.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E86B RID: 59499 RVA: 0x003414D2 File Offset: 0x0033F6D2
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_LeaveSkyTeam.OnTimeout(this.oArg);
		}

		// Token: 0x040064DC RID: 25820
		public LeaveSkyTeamArg oArg = new LeaveSkyTeamArg();

		// Token: 0x040064DD RID: 25821
		public LeaveSkyTeamRes oRes = null;
	}
}
