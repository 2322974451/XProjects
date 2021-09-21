using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000B41 RID: 2881
	internal class PtcG2C_OutLookChangeNtf : Protocol
	{
		// Token: 0x0600A86E RID: 43118 RVA: 0x001E09EC File Offset: 0x001DEBEC
		public override uint GetProtoType()
		{
			return 28395U;
		}

		// Token: 0x0600A86F RID: 43119 RVA: 0x001E0A03 File Offset: 0x001DEC03
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<OutLookChange>(stream, this.Data);
		}

		// Token: 0x0600A870 RID: 43120 RVA: 0x001E0A13 File Offset: 0x001DEC13
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<OutLookChange>(stream);
		}

		// Token: 0x0600A871 RID: 43121 RVA: 0x001E0A22 File Offset: 0x001DEC22
		public override void Process()
		{
			Process_PtcG2C_OutLookChangeNtf.Process(this);
		}

		// Token: 0x04003E6F RID: 15983
		public OutLookChange Data = new OutLookChange();
	}
}
