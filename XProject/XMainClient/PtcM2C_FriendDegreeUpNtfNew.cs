using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011AE RID: 4526
	internal class PtcM2C_FriendDegreeUpNtfNew : Protocol
	{
		// Token: 0x0600DB83 RID: 56195 RVA: 0x0032F2E0 File Offset: 0x0032D4E0
		public override uint GetProtoType()
		{
			return 36126U;
		}

		// Token: 0x0600DB84 RID: 56196 RVA: 0x0032F2F7 File Offset: 0x0032D4F7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FriendDegreeUpNtf>(stream, this.Data);
		}

		// Token: 0x0600DB85 RID: 56197 RVA: 0x0032F307 File Offset: 0x0032D507
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<FriendDegreeUpNtf>(stream);
		}

		// Token: 0x0600DB86 RID: 56198 RVA: 0x0032F316 File Offset: 0x0032D516
		public override void Process()
		{
			Process_PtcM2C_FriendDegreeUpNtfNew.Process(this);
		}

		// Token: 0x04006268 RID: 25192
		public FriendDegreeUpNtf Data = new FriendDegreeUpNtf();
	}
}
