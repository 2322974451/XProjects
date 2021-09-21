using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200161B RID: 5659
	internal class PtcM2C_DailyTaskEventNtf : Protocol
	{
		// Token: 0x0600EDA5 RID: 60837 RVA: 0x00348AD0 File Offset: 0x00346CD0
		public override uint GetProtoType()
		{
			return 26376U;
		}

		// Token: 0x0600EDA6 RID: 60838 RVA: 0x00348AE7 File Offset: 0x00346CE7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DailyTaskEventNtf>(stream, this.Data);
		}

		// Token: 0x0600EDA7 RID: 60839 RVA: 0x00348AF7 File Offset: 0x00346CF7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<DailyTaskEventNtf>(stream);
		}

		// Token: 0x0600EDA8 RID: 60840 RVA: 0x00348B06 File Offset: 0x00346D06
		public override void Process()
		{
			Process_PtcM2C_DailyTaskEventNtf.Process(this);
		}

		// Token: 0x040065E9 RID: 26089
		public DailyTaskEventNtf Data = new DailyTaskEventNtf();
	}
}
