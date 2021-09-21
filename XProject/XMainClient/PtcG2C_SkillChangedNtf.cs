using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001021 RID: 4129
	internal class PtcG2C_SkillChangedNtf : Protocol
	{
		// Token: 0x0600D52C RID: 54572 RVA: 0x00323354 File Offset: 0x00321554
		public override uint GetProtoType()
		{
			return 38872U;
		}

		// Token: 0x0600D52D RID: 54573 RVA: 0x0032336B File Offset: 0x0032156B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SkillChangedData>(stream, this.Data);
		}

		// Token: 0x0600D52E RID: 54574 RVA: 0x0032337B File Offset: 0x0032157B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SkillChangedData>(stream);
		}

		// Token: 0x0600D52F RID: 54575 RVA: 0x0032338A File Offset: 0x0032158A
		public override void Process()
		{
			Process_PtcG2C_SkillChangedNtf.Process(this);
		}

		// Token: 0x04006114 RID: 24852
		public SkillChangedData Data = new SkillChangedData();
	}
}
