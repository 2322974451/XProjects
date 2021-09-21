using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200113D RID: 4413
	internal class PtcC2G_FMBRefuse : Protocol
	{
		// Token: 0x0600D9BB RID: 55739 RVA: 0x0032B834 File Offset: 0x00329A34
		public override uint GetProtoType()
		{
			return 50821U;
		}

		// Token: 0x0600D9BC RID: 55740 RVA: 0x0032B84B File Offset: 0x00329A4B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FMBRes>(stream, this.Data);
		}

		// Token: 0x0600D9BD RID: 55741 RVA: 0x0032B85B File Offset: 0x00329A5B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<FMBRes>(stream);
		}

		// Token: 0x0600D9BE RID: 55742 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x04006213 RID: 25107
		public FMBRes Data = new FMBRes();
	}
}
