using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014DB RID: 5339
	internal class PtcM2C_SkyCraftMatchNtf : Protocol
	{
		// Token: 0x0600E879 RID: 59513 RVA: 0x00341578 File Offset: 0x0033F778
		public override uint GetProtoType()
		{
			return 4938U;
		}

		// Token: 0x0600E87A RID: 59514 RVA: 0x0034158F File Offset: 0x0033F78F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SkyCraftMatchNtf>(stream, this.Data);
		}

		// Token: 0x0600E87B RID: 59515 RVA: 0x0034159F File Offset: 0x0033F79F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SkyCraftMatchNtf>(stream);
		}

		// Token: 0x0600E87C RID: 59516 RVA: 0x003415AE File Offset: 0x0033F7AE
		public override void Process()
		{
			Process_PtcM2C_SkyCraftMatchNtf.Process(this);
		}

		// Token: 0x040064E0 RID: 25824
		public SkyCraftMatchNtf Data = new SkyCraftMatchNtf();
	}
}
