using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001535 RID: 5429
	internal class PtcG2C_MobaRoleChangeNtf : Protocol
	{
		// Token: 0x0600E9EF RID: 59887 RVA: 0x0034373C File Offset: 0x0034193C
		public override uint GetProtoType()
		{
			return 12958U;
		}

		// Token: 0x0600E9F0 RID: 59888 RVA: 0x00343753 File Offset: 0x00341953
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MobaRoleChangeData>(stream, this.Data);
		}

		// Token: 0x0600E9F1 RID: 59889 RVA: 0x00343763 File Offset: 0x00341963
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<MobaRoleChangeData>(stream);
		}

		// Token: 0x0600E9F2 RID: 59890 RVA: 0x00343772 File Offset: 0x00341972
		public override void Process()
		{
			Process_PtcG2C_MobaRoleChangeNtf.Process(this);
		}

		// Token: 0x0400652A RID: 25898
		public MobaRoleChangeData Data = new MobaRoleChangeData();
	}
}
