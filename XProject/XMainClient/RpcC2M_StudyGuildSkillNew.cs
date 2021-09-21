using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200127B RID: 4731
	internal class RpcC2M_StudyGuildSkillNew : Rpc
	{
		// Token: 0x0600DEC4 RID: 57028 RVA: 0x00333A78 File Offset: 0x00331C78
		public override uint GetRpcType()
		{
			return 45669U;
		}

		// Token: 0x0600DEC5 RID: 57029 RVA: 0x00333A8F File Offset: 0x00331C8F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<StudyGuildSkillArg>(stream, this.oArg);
		}

		// Token: 0x0600DEC6 RID: 57030 RVA: 0x00333A9F File Offset: 0x00331C9F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<StudyGuildSkillRes>(stream);
		}

		// Token: 0x0600DEC7 RID: 57031 RVA: 0x00333AAE File Offset: 0x00331CAE
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_StudyGuildSkillNew.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DEC8 RID: 57032 RVA: 0x00333ACA File Offset: 0x00331CCA
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_StudyGuildSkillNew.OnTimeout(this.oArg);
		}

		// Token: 0x04006306 RID: 25350
		public StudyGuildSkillArg oArg = new StudyGuildSkillArg();

		// Token: 0x04006307 RID: 25351
		public StudyGuildSkillRes oRes = null;
	}
}
