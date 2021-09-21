using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001619 RID: 5657
	internal class PtcG2C_NpcFlNtf : Protocol
	{
		// Token: 0x0600ED9E RID: 60830 RVA: 0x00348A54 File Offset: 0x00346C54
		public override uint GetProtoType()
		{
			return 18961U;
		}

		// Token: 0x0600ED9F RID: 60831 RVA: 0x00348A6B File Offset: 0x00346C6B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NpcFlRes>(stream, this.Data);
		}

		// Token: 0x0600EDA0 RID: 60832 RVA: 0x00348A7B File Offset: 0x00346C7B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NpcFlRes>(stream);
		}

		// Token: 0x0600EDA1 RID: 60833 RVA: 0x00348A8A File Offset: 0x00346C8A
		public override void Process()
		{
			Process_PtcG2C_NpcFlNtf.Process(this);
		}

		// Token: 0x040065E8 RID: 26088
		public NpcFlRes Data = new NpcFlRes();
	}
}
