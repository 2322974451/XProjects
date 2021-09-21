using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200132F RID: 4911
	internal class PtcG2C_SkillCoolNtf : Protocol
	{
		// Token: 0x0600E1AA RID: 57770 RVA: 0x00337E9C File Offset: 0x0033609C
		public override uint GetProtoType()
		{
			return 55142U;
		}

		// Token: 0x0600E1AB RID: 57771 RVA: 0x00337EB3 File Offset: 0x003360B3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SkillCoolPara>(stream, this.Data);
		}

		// Token: 0x0600E1AC RID: 57772 RVA: 0x00337EC3 File Offset: 0x003360C3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SkillCoolPara>(stream);
		}

		// Token: 0x0600E1AD RID: 57773 RVA: 0x00337ED2 File Offset: 0x003360D2
		public override void Process()
		{
			Process_PtcG2C_SkillCoolNtf.Process(this);
		}

		// Token: 0x04006396 RID: 25494
		public SkillCoolPara Data = new SkillCoolPara();
	}
}
