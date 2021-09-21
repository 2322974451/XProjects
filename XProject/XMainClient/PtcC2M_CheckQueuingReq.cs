using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200120A RID: 4618
	internal class PtcC2M_CheckQueuingReq : Protocol
	{
		// Token: 0x0600DCF0 RID: 56560 RVA: 0x00331034 File Offset: 0x0032F234
		public override uint GetProtoType()
		{
			return 28232U;
		}

		// Token: 0x0600DCF1 RID: 56561 RVA: 0x0033104B File Offset: 0x0032F24B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CheckQueuingReq>(stream, this.Data);
		}

		// Token: 0x0600DCF2 RID: 56562 RVA: 0x0033105B File Offset: 0x0032F25B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<CheckQueuingReq>(stream);
		}

		// Token: 0x0600DCF3 RID: 56563 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x040062AA RID: 25258
		public CheckQueuingReq Data = new CheckQueuingReq();
	}
}
