using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000B52 RID: 2898
	internal class PtcC2N_CheckQueuingReq : Protocol
	{
		// Token: 0x0600A8CA RID: 43210 RVA: 0x001E10CC File Offset: 0x001DF2CC
		public override uint GetProtoType()
		{
			return 28232U;
		}

		// Token: 0x0600A8CB RID: 43211 RVA: 0x001E10E3 File Offset: 0x001DF2E3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CheckQueuingReq>(stream, this.Data);
		}

		// Token: 0x0600A8CC RID: 43212 RVA: 0x001E10F3 File Offset: 0x001DF2F3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<CheckQueuingReq>(stream);
		}

		// Token: 0x0600A8CD RID: 43213 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x04003E87 RID: 16007
		public CheckQueuingReq Data = new CheckQueuingReq();
	}
}
