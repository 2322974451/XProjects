using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001674 RID: 5748
	internal class PtcG2C_UpdateStageInfoNtf : Protocol
	{
		// Token: 0x0600EF1F RID: 61215 RVA: 0x0034AC8C File Offset: 0x00348E8C
		public override uint GetProtoType()
		{
			return 21189U;
		}

		// Token: 0x0600EF20 RID: 61216 RVA: 0x0034ACA3 File Offset: 0x00348EA3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<UpdateStageInfoNtf>(stream, this.Data);
		}

		// Token: 0x0600EF21 RID: 61217 RVA: 0x0034ACB3 File Offset: 0x00348EB3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<UpdateStageInfoNtf>(stream);
		}

		// Token: 0x0600EF22 RID: 61218 RVA: 0x0034ACC2 File Offset: 0x00348EC2
		public override void Process()
		{
			Process_PtcG2C_UpdateStageInfoNtf.Process(this);
		}

		// Token: 0x0400663D RID: 26173
		public UpdateStageInfoNtf Data = new UpdateStageInfoNtf();
	}
}
