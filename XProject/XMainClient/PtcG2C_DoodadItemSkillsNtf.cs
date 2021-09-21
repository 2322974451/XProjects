using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200164E RID: 5710
	internal class PtcG2C_DoodadItemSkillsNtf : Protocol
	{
		// Token: 0x0600EE83 RID: 61059 RVA: 0x00349E28 File Offset: 0x00348028
		public override uint GetProtoType()
		{
			return 45490U;
		}

		// Token: 0x0600EE84 RID: 61060 RVA: 0x00349E3F File Offset: 0x0034803F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DoodadItemAllSkill>(stream, this.Data);
		}

		// Token: 0x0600EE85 RID: 61061 RVA: 0x00349E4F File Offset: 0x0034804F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<DoodadItemAllSkill>(stream);
		}

		// Token: 0x0600EE86 RID: 61062 RVA: 0x00349E5E File Offset: 0x0034805E
		public override void Process()
		{
			Process_PtcG2C_DoodadItemSkillsNtf.Process(this);
		}

		// Token: 0x04006618 RID: 26136
		public DoodadItemAllSkill Data = new DoodadItemAllSkill();
	}
}
