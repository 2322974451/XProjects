using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015C9 RID: 5577
	internal class PtcC2G_ShareReport : Protocol
	{
		// Token: 0x0600EC4C RID: 60492 RVA: 0x00346DE0 File Offset: 0x00344FE0
		public override uint GetProtoType()
		{
			return 31884U;
		}

		// Token: 0x0600EC4D RID: 60493 RVA: 0x00346DF7 File Offset: 0x00344FF7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ShareReportData>(stream, this.Data);
		}

		// Token: 0x0600EC4E RID: 60494 RVA: 0x00346E07 File Offset: 0x00345007
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ShareReportData>(stream);
		}

		// Token: 0x0600EC4F RID: 60495 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x040065A4 RID: 26020
		public ShareReportData Data = new ShareReportData();
	}
}
