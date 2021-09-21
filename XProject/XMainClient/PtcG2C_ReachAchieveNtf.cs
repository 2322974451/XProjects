using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010F3 RID: 4339
	internal class PtcG2C_ReachAchieveNtf : Protocol
	{
		// Token: 0x0600D887 RID: 55431 RVA: 0x00329B5C File Offset: 0x00327D5C
		public override uint GetProtoType()
		{
			return 1479U;
		}

		// Token: 0x0600D888 RID: 55432 RVA: 0x00329B73 File Offset: 0x00327D73
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReachAchieveNtf>(stream, this.Data);
		}

		// Token: 0x0600D889 RID: 55433 RVA: 0x00329B83 File Offset: 0x00327D83
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ReachAchieveNtf>(stream);
		}

		// Token: 0x0600D88A RID: 55434 RVA: 0x00329B92 File Offset: 0x00327D92
		public override void Process()
		{
			Process_PtcG2C_ReachAchieveNtf.Process(this);
		}

		// Token: 0x040061D8 RID: 25048
		public ReachAchieveNtf Data = new ReachAchieveNtf();
	}
}
