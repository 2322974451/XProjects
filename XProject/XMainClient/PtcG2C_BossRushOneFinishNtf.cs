using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200124D RID: 4685
	internal class PtcG2C_BossRushOneFinishNtf : Protocol
	{
		// Token: 0x0600DE08 RID: 56840 RVA: 0x00332BB8 File Offset: 0x00330DB8
		public override uint GetProtoType()
		{
			return 21034U;
		}

		// Token: 0x0600DE09 RID: 56841 RVA: 0x00332BCF File Offset: 0x00330DCF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BossRushPara>(stream, this.Data);
		}

		// Token: 0x0600DE0A RID: 56842 RVA: 0x00332BDF File Offset: 0x00330DDF
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BossRushPara>(stream);
		}

		// Token: 0x0600DE0B RID: 56843 RVA: 0x00332BEE File Offset: 0x00330DEE
		public override void Process()
		{
			Process_PtcG2C_BossRushOneFinishNtf.Process(this);
		}

		// Token: 0x040062E2 RID: 25314
		public BossRushPara Data = new BossRushPara();
	}
}
