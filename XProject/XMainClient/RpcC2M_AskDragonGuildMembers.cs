using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001636 RID: 5686
	internal class RpcC2M_AskDragonGuildMembers : Rpc
	{
		// Token: 0x0600EE17 RID: 60951 RVA: 0x00349490 File Offset: 0x00347690
		public override uint GetRpcType()
		{
			return 26644U;
		}

		// Token: 0x0600EE18 RID: 60952 RVA: 0x003494A7 File Offset: 0x003476A7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DragonGuildMemberArg>(stream, this.oArg);
		}

		// Token: 0x0600EE19 RID: 60953 RVA: 0x003494B7 File Offset: 0x003476B7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DragonGuildMemberRes>(stream);
		}

		// Token: 0x0600EE1A RID: 60954 RVA: 0x003494C6 File Offset: 0x003476C6
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_AskDragonGuildMembers.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EE1B RID: 60955 RVA: 0x003494E2 File Offset: 0x003476E2
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_AskDragonGuildMembers.OnTimeout(this.oArg);
		}

		// Token: 0x04006600 RID: 26112
		public DragonGuildMemberArg oArg = new DragonGuildMemberArg();

		// Token: 0x04006601 RID: 26113
		public DragonGuildMemberRes oRes = null;
	}
}
