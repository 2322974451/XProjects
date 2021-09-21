using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001603 RID: 5635
	internal class PtcG2C_PayScoreNtf : Protocol
	{
		// Token: 0x0600ED3D RID: 60733 RVA: 0x00348148 File Offset: 0x00346348
		public override uint GetProtoType()
		{
			return 61859U;
		}

		// Token: 0x0600ED3E RID: 60734 RVA: 0x0034815F File Offset: 0x0034635F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PayScoreData>(stream, this.Data);
		}

		// Token: 0x0600ED3F RID: 60735 RVA: 0x0034816F File Offset: 0x0034636F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PayScoreData>(stream);
		}

		// Token: 0x0600ED40 RID: 60736 RVA: 0x0034817E File Offset: 0x0034637E
		public override void Process()
		{
			Process_PtcG2C_PayScoreNtf.Process(this);
		}

		// Token: 0x040065D3 RID: 26067
		public PayScoreData Data = new PayScoreData();
	}
}
