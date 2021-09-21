using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001424 RID: 5156
	internal class PtcC2M_PayParameterInfoNtf : Protocol
	{
		// Token: 0x0600E596 RID: 58774 RVA: 0x0033D2FC File Offset: 0x0033B4FC
		public override uint GetProtoType()
		{
			return 1181U;
		}

		// Token: 0x0600E597 RID: 58775 RVA: 0x0033D313 File Offset: 0x0033B513
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PayParameterInfo>(stream, this.Data);
		}

		// Token: 0x0600E598 RID: 58776 RVA: 0x0033D323 File Offset: 0x0033B523
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PayParameterInfo>(stream);
		}

		// Token: 0x0600E599 RID: 58777 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x04006458 RID: 25688
		public PayParameterInfo Data = new PayParameterInfo();
	}
}
