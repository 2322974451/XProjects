using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015FF RID: 5631
	internal class PtcG2C_BFFightTimeNtf : Protocol
	{
		// Token: 0x0600ED2D RID: 60717 RVA: 0x00348040 File Offset: 0x00346240
		public override uint GetProtoType()
		{
			return 39352U;
		}

		// Token: 0x0600ED2E RID: 60718 RVA: 0x00348057 File Offset: 0x00346257
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BFFightTime>(stream, this.Data);
		}

		// Token: 0x0600ED2F RID: 60719 RVA: 0x00348067 File Offset: 0x00346267
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BFFightTime>(stream);
		}

		// Token: 0x0600ED30 RID: 60720 RVA: 0x00348076 File Offset: 0x00346276
		public override void Process()
		{
			Process_PtcG2C_BFFightTimeNtf.Process(this);
		}

		// Token: 0x040065D0 RID: 26064
		public BFFightTime Data = new BFFightTime();
	}
}
