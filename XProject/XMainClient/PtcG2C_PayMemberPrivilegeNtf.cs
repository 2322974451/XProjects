using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001371 RID: 4977
	internal class PtcG2C_PayMemberPrivilegeNtf : Protocol
	{
		// Token: 0x0600E2BD RID: 58045 RVA: 0x00339838 File Offset: 0x00337A38
		public override uint GetProtoType()
		{
			return 33306U;
		}

		// Token: 0x0600E2BE RID: 58046 RVA: 0x0033984F File Offset: 0x00337A4F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PayMemberPrivilege>(stream, this.Data);
		}

		// Token: 0x0600E2BF RID: 58047 RVA: 0x0033985F File Offset: 0x00337A5F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PayMemberPrivilege>(stream);
		}

		// Token: 0x0600E2C0 RID: 58048 RVA: 0x0033986E File Offset: 0x00337A6E
		public override void Process()
		{
			Process_PtcG2C_PayMemberPrivilegeNtf.Process(this);
		}

		// Token: 0x040063CD RID: 25549
		public PayMemberPrivilege Data = new PayMemberPrivilege();
	}
}
