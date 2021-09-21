using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001456 RID: 5206
	internal class PtcC2G_QueryRoleStateReq : Protocol
	{
		// Token: 0x0600E660 RID: 58976 RVA: 0x0033E60C File Offset: 0x0033C80C
		public override uint GetProtoType()
		{
			return 54208U;
		}

		// Token: 0x0600E661 RID: 58977 RVA: 0x0033E623 File Offset: 0x0033C823
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QueryRoleStateReq>(stream, this.Data);
		}

		// Token: 0x0600E662 RID: 58978 RVA: 0x0033E633 File Offset: 0x0033C833
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<QueryRoleStateReq>(stream);
		}

		// Token: 0x0600E663 RID: 58979 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x0400647C RID: 25724
		public QueryRoleStateReq Data = new QueryRoleStateReq();
	}
}
