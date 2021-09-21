using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001510 RID: 5392
	internal class PtcG2C_UpdateDisplayItems : Protocol
	{
		// Token: 0x0600E958 RID: 59736 RVA: 0x0034292C File Offset: 0x00340B2C
		public override uint GetProtoType()
		{
			return 12217U;
		}

		// Token: 0x0600E959 RID: 59737 RVA: 0x00342943 File Offset: 0x00340B43
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<UpdateDisplayItems>(stream, this.Data);
		}

		// Token: 0x0600E95A RID: 59738 RVA: 0x00342953 File Offset: 0x00340B53
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<UpdateDisplayItems>(stream);
		}

		// Token: 0x0600E95B RID: 59739 RVA: 0x00342962 File Offset: 0x00340B62
		public override void Process()
		{
			Process_PtcG2C_UpdateDisplayItems.Process(this);
		}

		// Token: 0x0400650D RID: 25869
		public UpdateDisplayItems Data = new UpdateDisplayItems();
	}
}
