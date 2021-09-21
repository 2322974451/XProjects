using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013F0 RID: 5104
	internal class PtcM2C_MakePartnerResultNtf : Protocol
	{
		// Token: 0x0600E4C4 RID: 58564 RVA: 0x0033C1B4 File Offset: 0x0033A3B4
		public override uint GetProtoType()
		{
			return 49652U;
		}

		// Token: 0x0600E4C5 RID: 58565 RVA: 0x0033C1CB File Offset: 0x0033A3CB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MakePartnerResult>(stream, this.Data);
		}

		// Token: 0x0600E4C6 RID: 58566 RVA: 0x0033C1DB File Offset: 0x0033A3DB
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<MakePartnerResult>(stream);
		}

		// Token: 0x0600E4C7 RID: 58567 RVA: 0x0033C1EA File Offset: 0x0033A3EA
		public override void Process()
		{
			Process_PtcM2C_MakePartnerResultNtf.Process(this);
		}

		// Token: 0x04006430 RID: 25648
		public MakePartnerResult Data = new MakePartnerResult();
	}
}
