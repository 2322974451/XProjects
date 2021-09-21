using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011BD RID: 4541
	internal class PtcC2M_RoleStateReportNew : Protocol
	{
		// Token: 0x0600DBB9 RID: 56249 RVA: 0x0032F6A8 File Offset: 0x0032D8A8
		public override uint GetProtoType()
		{
			return 10217U;
		}

		// Token: 0x0600DBBA RID: 56250 RVA: 0x0032F6BF File Offset: 0x0032D8BF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<RoleStateReport>(stream, this.Data);
		}

		// Token: 0x0600DBBB RID: 56251 RVA: 0x0032F6CF File Offset: 0x0032D8CF
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<RoleStateReport>(stream);
		}

		// Token: 0x0600DBBC RID: 56252 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x04006270 RID: 25200
		public RoleStateReport Data = new RoleStateReport();
	}
}
