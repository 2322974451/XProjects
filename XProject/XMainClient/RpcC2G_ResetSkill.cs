using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200101D RID: 4125
	internal class RpcC2G_ResetSkill : Rpc
	{
		// Token: 0x0600D51A RID: 54554 RVA: 0x00322FB4 File Offset: 0x003211B4
		public override uint GetRpcType()
		{
			return 26941U;
		}

		// Token: 0x0600D51B RID: 54555 RVA: 0x00322FCB File Offset: 0x003211CB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ResetSkillArg>(stream, this.oArg);
		}

		// Token: 0x0600D51C RID: 54556 RVA: 0x00322FDB File Offset: 0x003211DB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ResetSkillRes>(stream);
		}

		// Token: 0x0600D51D RID: 54557 RVA: 0x00322FEA File Offset: 0x003211EA
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ResetSkill.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D51E RID: 54558 RVA: 0x00323006 File Offset: 0x00321206
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ResetSkill.OnTimeout(this.oArg);
		}

		// Token: 0x04006110 RID: 24848
		public ResetSkillArg oArg = new ResetSkillArg();

		// Token: 0x04006111 RID: 24849
		public ResetSkillRes oRes = new ResetSkillRes();
	}
}
