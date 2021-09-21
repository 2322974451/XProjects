using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011A1 RID: 4513
	internal class PtcC2M_FriendQueryReportNew : Protocol
	{
		// Token: 0x0600DB48 RID: 56136 RVA: 0x0032ECF8 File Offset: 0x0032CEF8
		public override uint GetProtoType()
		{
			return 15079U;
		}

		// Token: 0x0600DB49 RID: 56137 RVA: 0x0032ED0F File Offset: 0x0032CF0F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FriendQueryReportNew>(stream, this.Data);
		}

		// Token: 0x0600DB4A RID: 56138 RVA: 0x0032ED1F File Offset: 0x0032CF1F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<FriendQueryReportNew>(stream);
		}

		// Token: 0x0600DB4B RID: 56139 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x0400625B RID: 25179
		public FriendQueryReportNew Data = new FriendQueryReportNew();
	}
}
