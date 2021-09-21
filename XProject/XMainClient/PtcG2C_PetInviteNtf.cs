using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200154D RID: 5453
	internal class PtcG2C_PetInviteNtf : Protocol
	{
		// Token: 0x0600EA4F RID: 59983 RVA: 0x00344054 File Offset: 0x00342254
		public override uint GetProtoType()
		{
			return 19818U;
		}

		// Token: 0x0600EA50 RID: 59984 RVA: 0x0034406B File Offset: 0x0034226B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PetInviteNtf>(stream, this.Data);
		}

		// Token: 0x0600EA51 RID: 59985 RVA: 0x0034407B File Offset: 0x0034227B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PetInviteNtf>(stream);
		}

		// Token: 0x0600EA52 RID: 59986 RVA: 0x0034408A File Offset: 0x0034228A
		public override void Process()
		{
			Process_PtcG2C_PetInviteNtf.Process(this);
		}

		// Token: 0x0400653C RID: 25916
		public PetInviteNtf Data = new PetInviteNtf();
	}
}
