using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011B0 RID: 4528
	internal class PtcC2M_BlackListReportNew : Protocol
	{
		// Token: 0x0600DB8A RID: 56202 RVA: 0x0032F388 File Offset: 0x0032D588
		public override uint GetProtoType()
		{
			return 57057U;
		}

		// Token: 0x0600DB8B RID: 56203 RVA: 0x0032F39F File Offset: 0x0032D59F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BlackListReport>(stream, this.Data);
		}

		// Token: 0x0600DB8C RID: 56204 RVA: 0x0032F3AF File Offset: 0x0032D5AF
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BlackListReport>(stream);
		}

		// Token: 0x0600DB8D RID: 56205 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x04006269 RID: 25193
		public BlackListReport Data = new BlackListReport();
	}
}
