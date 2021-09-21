using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001142 RID: 4418
	internal class RpcC2G_TeamInviteListReq : Rpc
	{
		// Token: 0x0600D9D0 RID: 55760 RVA: 0x0032BA10 File Offset: 0x00329C10
		public override uint GetRpcType()
		{
			return 11403U;
		}

		// Token: 0x0600D9D1 RID: 55761 RVA: 0x0032BA27 File Offset: 0x00329C27
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TeamInviteArg>(stream, this.oArg);
		}

		// Token: 0x0600D9D2 RID: 55762 RVA: 0x0032BA37 File Offset: 0x00329C37
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<TeamInviteRes>(stream);
		}

		// Token: 0x0600D9D3 RID: 55763 RVA: 0x0032BA46 File Offset: 0x00329C46
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_TeamInviteListReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D9D4 RID: 55764 RVA: 0x0032BA62 File Offset: 0x00329C62
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_TeamInviteListReq.OnTimeout(this.oArg);
		}

		// Token: 0x04006217 RID: 25111
		public TeamInviteArg oArg = new TeamInviteArg();

		// Token: 0x04006218 RID: 25112
		public TeamInviteRes oRes = new TeamInviteRes();
	}
}
