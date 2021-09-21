using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001684 RID: 5764
	internal class PtcM2C_CrossGvgStateNtf : Protocol
	{
		// Token: 0x0600EF61 RID: 61281 RVA: 0x0034B3FC File Offset: 0x003495FC
		public override uint GetProtoType()
		{
			return 24216U;
		}

		// Token: 0x0600EF62 RID: 61282 RVA: 0x0034B413 File Offset: 0x00349613
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CrossGvgStateNtf>(stream, this.Data);
		}

		// Token: 0x0600EF63 RID: 61283 RVA: 0x0034B423 File Offset: 0x00349623
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<CrossGvgStateNtf>(stream);
		}

		// Token: 0x0600EF64 RID: 61284 RVA: 0x0034B432 File Offset: 0x00349632
		public override void Process()
		{
			Process_PtcM2C_CrossGvgStateNtf.Process(this);
		}

		// Token: 0x0400664A RID: 26186
		public CrossGvgStateNtf Data = new CrossGvgStateNtf();
	}
}
