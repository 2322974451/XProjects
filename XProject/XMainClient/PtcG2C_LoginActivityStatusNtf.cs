using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000B59 RID: 2905
	internal class PtcG2C_LoginActivityStatusNtf : Protocol
	{
		// Token: 0x0600A8F1 RID: 43249 RVA: 0x001E13D0 File Offset: 0x001DF5D0
		public override uint GetProtoType()
		{
			return 34113U;
		}

		// Token: 0x0600A8F2 RID: 43250 RVA: 0x001E13E7 File Offset: 0x001DF5E7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LoginActivityStatus>(stream, this.Data);
		}

		// Token: 0x0600A8F3 RID: 43251 RVA: 0x001E13F7 File Offset: 0x001DF5F7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<LoginActivityStatus>(stream);
		}

		// Token: 0x0600A8F4 RID: 43252 RVA: 0x001E1406 File Offset: 0x001DF606
		public override void Process()
		{
			Process_PtcG2C_LoginActivityStatusNtf.Process(this);
		}

		// Token: 0x04003E92 RID: 16018
		public LoginActivityStatus Data = new LoginActivityStatus();
	}
}
