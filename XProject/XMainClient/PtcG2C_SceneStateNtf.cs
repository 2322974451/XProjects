using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001454 RID: 5204
	internal class PtcG2C_SceneStateNtf : Protocol
	{
		// Token: 0x0600E659 RID: 58969 RVA: 0x0033E55C File Offset: 0x0033C75C
		public override uint GetProtoType()
		{
			return 4376U;
		}

		// Token: 0x0600E65A RID: 58970 RVA: 0x0033E573 File Offset: 0x0033C773
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SceneStateNtf>(stream, this.Data);
		}

		// Token: 0x0600E65B RID: 58971 RVA: 0x0033E583 File Offset: 0x0033C783
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SceneStateNtf>(stream);
		}

		// Token: 0x0600E65C RID: 58972 RVA: 0x0033E592 File Offset: 0x0033C792
		public override void Process()
		{
			Process_PtcG2C_SceneStateNtf.Process(this);
		}

		// Token: 0x0400647B RID: 25723
		public SceneStateNtf Data = new SceneStateNtf();
	}
}
