using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001522 RID: 5410
	internal class PtcM2C_TarjaBriefNtf : Protocol
	{
		// Token: 0x0600E9A1 RID: 59809 RVA: 0x00342FE4 File Offset: 0x003411E4
		public override uint GetProtoType()
		{
			return 35068U;
		}

		// Token: 0x0600E9A2 RID: 59810 RVA: 0x00342FFB File Offset: 0x003411FB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TarjaBrief>(stream, this.Data);
		}

		// Token: 0x0600E9A3 RID: 59811 RVA: 0x0034300B File Offset: 0x0034120B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<TarjaBrief>(stream);
		}

		// Token: 0x0600E9A4 RID: 59812 RVA: 0x0034301A File Offset: 0x0034121A
		public override void Process()
		{
			Process_PtcM2C_TarjaBriefNtf.Process(this);
		}

		// Token: 0x0400651B RID: 25883
		public TarjaBrief Data = new TarjaBrief();
	}
}
