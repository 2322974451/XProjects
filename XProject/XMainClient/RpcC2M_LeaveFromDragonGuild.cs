using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001630 RID: 5680
	internal class RpcC2M_LeaveFromDragonGuild : Rpc
	{
		// Token: 0x0600EDFE RID: 60926 RVA: 0x00349264 File Offset: 0x00347464
		public override uint GetRpcType()
		{
			return 9882U;
		}

		// Token: 0x0600EDFF RID: 60927 RVA: 0x0034927B File Offset: 0x0034747B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LeaveDragonGuildArg>(stream, this.oArg);
		}

		// Token: 0x0600EE00 RID: 60928 RVA: 0x0034928B File Offset: 0x0034748B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<LeaveDragonGuildRes>(stream);
		}

		// Token: 0x0600EE01 RID: 60929 RVA: 0x0034929A File Offset: 0x0034749A
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_LeaveFromDragonGuild.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EE02 RID: 60930 RVA: 0x003492B6 File Offset: 0x003474B6
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_LeaveFromDragonGuild.OnTimeout(this.oArg);
		}

		// Token: 0x040065FB RID: 26107
		public LeaveDragonGuildArg oArg = new LeaveDragonGuildArg();

		// Token: 0x040065FC RID: 26108
		public LeaveDragonGuildRes oRes = null;
	}
}
