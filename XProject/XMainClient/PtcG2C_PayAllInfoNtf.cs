using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011D4 RID: 4564
	internal class PtcG2C_PayAllInfoNtf : Protocol
	{
		// Token: 0x0600DC18 RID: 56344 RVA: 0x0032FDAC File Offset: 0x0032DFAC
		public override uint GetProtoType()
		{
			return 4976U;
		}

		// Token: 0x0600DC19 RID: 56345 RVA: 0x0032FDC3 File Offset: 0x0032DFC3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PayAllInfo>(stream, this.Data);
		}

		// Token: 0x0600DC1A RID: 56346 RVA: 0x0032FDD3 File Offset: 0x0032DFD3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PayAllInfo>(stream);
		}

		// Token: 0x0600DC1B RID: 56347 RVA: 0x0032FDE2 File Offset: 0x0032DFE2
		public override void Process()
		{
			Process_PtcG2C_PayAllInfoNtf.Process(this);
		}

		// Token: 0x04006282 RID: 25218
		public PayAllInfo Data = new PayAllInfo();
	}
}
