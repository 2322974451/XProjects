using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001464 RID: 5220
	internal class PtcG2C_SkillInitCoolNtf : Protocol
	{
		// Token: 0x0600E697 RID: 59031 RVA: 0x0033EC30 File Offset: 0x0033CE30
		public override uint GetProtoType()
		{
			return 4132U;
		}

		// Token: 0x0600E698 RID: 59032 RVA: 0x0033EC47 File Offset: 0x0033CE47
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SkillInitCoolPara>(stream, this.Data);
		}

		// Token: 0x0600E699 RID: 59033 RVA: 0x0033EC57 File Offset: 0x0033CE57
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SkillInitCoolPara>(stream);
		}

		// Token: 0x0600E69A RID: 59034 RVA: 0x0033EC66 File Offset: 0x0033CE66
		public override void Process()
		{
			Process_PtcG2C_SkillInitCoolNtf.Process(this);
		}

		// Token: 0x04006486 RID: 25734
		public SkillInitCoolPara Data = new SkillInitCoolPara();
	}
}
