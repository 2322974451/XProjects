using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001279 RID: 4729
	internal class RpcC2M_AskGuildSkillInfoNew : Rpc
	{
		// Token: 0x0600DEBB RID: 57019 RVA: 0x0033398C File Offset: 0x00331B8C
		public override uint GetRpcType()
		{
			return 35479U;
		}

		// Token: 0x0600DEBC RID: 57020 RVA: 0x003339A3 File Offset: 0x00331BA3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AskGuildSkillInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600DEBD RID: 57021 RVA: 0x003339B3 File Offset: 0x00331BB3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AskGuildSkillInfoReq>(stream);
		}

		// Token: 0x0600DEBE RID: 57022 RVA: 0x003339C2 File Offset: 0x00331BC2
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_AskGuildSkillInfoNew.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DEBF RID: 57023 RVA: 0x003339DE File Offset: 0x00331BDE
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_AskGuildSkillInfoNew.OnTimeout(this.oArg);
		}

		// Token: 0x04006304 RID: 25348
		public AskGuildSkillInfoArg oArg = new AskGuildSkillInfoArg();

		// Token: 0x04006305 RID: 25349
		public AskGuildSkillInfoReq oRes = null;
	}
}
