using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200169C RID: 5788
	internal class PtcM2C_GuildSchoolHallUpdatePoint : Protocol
	{
		// Token: 0x0600EFC7 RID: 61383 RVA: 0x0034BE28 File Offset: 0x0034A028
		public override uint GetProtoType()
		{
			return 65336U;
		}

		// Token: 0x0600EFC8 RID: 61384 RVA: 0x0034BE3F File Offset: 0x0034A03F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildHallUpdatePoint>(stream, this.Data);
		}

		// Token: 0x0600EFC9 RID: 61385 RVA: 0x0034BE4F File Offset: 0x0034A04F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildHallUpdatePoint>(stream);
		}

		// Token: 0x0600EFCA RID: 61386 RVA: 0x0034BE5E File Offset: 0x0034A05E
		public override void Process()
		{
			Process_PtcM2C_GuildSchoolHallUpdatePoint.Process(this);
		}

		// Token: 0x0400665F RID: 26207
		public GuildHallUpdatePoint Data = new GuildHallUpdatePoint();
	}
}
