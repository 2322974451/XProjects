using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200103B RID: 4155
	internal class PtcG2C_CheckinInfoNotify : Protocol
	{
		// Token: 0x0600D59B RID: 54683 RVA: 0x00324600 File Offset: 0x00322800
		public override uint GetProtoType()
		{
			return 29332U;
		}

		// Token: 0x0600D59C RID: 54684 RVA: 0x00324617 File Offset: 0x00322817
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CheckinInfoNotify>(stream, this.Data);
		}

		// Token: 0x0600D59D RID: 54685 RVA: 0x00324627 File Offset: 0x00322827
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<CheckinInfoNotify>(stream);
		}

		// Token: 0x0600D59E RID: 54686 RVA: 0x00324636 File Offset: 0x00322836
		public override void Process()
		{
			Process_PtcG2C_CheckinInfoNotify.Process(this);
		}

		// Token: 0x0400612B RID: 24875
		public CheckinInfoNotify Data = new CheckinInfoNotify();
	}
}
