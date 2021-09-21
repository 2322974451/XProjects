using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200146A RID: 5226
	internal class RpcC2M_LeaveLeagueTeam : Rpc
	{
		// Token: 0x0600E6AC RID: 59052 RVA: 0x0033EDB0 File Offset: 0x0033CFB0
		public override uint GetRpcType()
		{
			return 47239U;
		}

		// Token: 0x0600E6AD RID: 59053 RVA: 0x0033EDC7 File Offset: 0x0033CFC7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LeaveLeagueTeamArg>(stream, this.oArg);
		}

		// Token: 0x0600E6AE RID: 59054 RVA: 0x0033EDD7 File Offset: 0x0033CFD7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<LeaveLeagueTeamRes>(stream);
		}

		// Token: 0x0600E6AF RID: 59055 RVA: 0x0033EDE6 File Offset: 0x0033CFE6
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_LeaveLeagueTeam.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E6B0 RID: 59056 RVA: 0x0033EE02 File Offset: 0x0033D002
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_LeaveLeagueTeam.OnTimeout(this.oArg);
		}

		// Token: 0x04006489 RID: 25737
		public LeaveLeagueTeamArg oArg = new LeaveLeagueTeamArg();

		// Token: 0x0400648A RID: 25738
		public LeaveLeagueTeamRes oRes = null;
	}
}
