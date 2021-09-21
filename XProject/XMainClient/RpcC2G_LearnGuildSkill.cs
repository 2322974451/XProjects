using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200128C RID: 4748
	internal class RpcC2G_LearnGuildSkill : Rpc
	{
		// Token: 0x0600DF0B RID: 57099 RVA: 0x00333FD0 File Offset: 0x003321D0
		public override uint GetRpcType()
		{
			return 62806U;
		}

		// Token: 0x0600DF0C RID: 57100 RVA: 0x00333FE7 File Offset: 0x003321E7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LearnGuildSkillAgr>(stream, this.oArg);
		}

		// Token: 0x0600DF0D RID: 57101 RVA: 0x00333FF7 File Offset: 0x003321F7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<LearnGuildSkillRes>(stream);
		}

		// Token: 0x0600DF0E RID: 57102 RVA: 0x00334006 File Offset: 0x00332206
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_LearnGuildSkill.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DF0F RID: 57103 RVA: 0x00334022 File Offset: 0x00332222
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_LearnGuildSkill.OnTimeout(this.oArg);
		}

		// Token: 0x04006314 RID: 25364
		public LearnGuildSkillAgr oArg = new LearnGuildSkillAgr();

		// Token: 0x04006315 RID: 25365
		public LearnGuildSkillRes oRes = new LearnGuildSkillRes();
	}
}
