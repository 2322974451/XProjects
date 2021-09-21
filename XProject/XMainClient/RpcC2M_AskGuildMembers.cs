using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001266 RID: 4710
	internal class RpcC2M_AskGuildMembers : Rpc
	{
		// Token: 0x0600DE73 RID: 56947 RVA: 0x00333434 File Offset: 0x00331634
		public override uint GetRpcType()
		{
			return 57958U;
		}

		// Token: 0x0600DE74 RID: 56948 RVA: 0x0033344B File Offset: 0x0033164B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildMemberArg>(stream, this.oArg);
		}

		// Token: 0x0600DE75 RID: 56949 RVA: 0x0033345B File Offset: 0x0033165B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildMemberRes>(stream);
		}

		// Token: 0x0600DE76 RID: 56950 RVA: 0x0033346A File Offset: 0x0033166A
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_AskGuildMembers.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DE77 RID: 56951 RVA: 0x00333486 File Offset: 0x00331686
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_AskGuildMembers.OnTimeout(this.oArg);
		}

		// Token: 0x040062F8 RID: 25336
		public GuildMemberArg oArg = new GuildMemberArg();

		// Token: 0x040062F9 RID: 25337
		public GuildMemberRes oRes = null;
	}
}
