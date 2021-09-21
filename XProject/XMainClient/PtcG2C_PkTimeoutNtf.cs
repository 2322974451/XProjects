using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010B3 RID: 4275
	internal class PtcG2C_PkTimeoutNtf : Protocol
	{
		// Token: 0x0600D787 RID: 55175 RVA: 0x00328518 File Offset: 0x00326718
		public override uint GetProtoType()
		{
			return 58692U;
		}

		// Token: 0x0600D788 RID: 55176 RVA: 0x0032852F File Offset: 0x0032672F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PkTimeoutNtf>(stream, this.Data);
		}

		// Token: 0x0600D789 RID: 55177 RVA: 0x0032853F File Offset: 0x0032673F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PkTimeoutNtf>(stream);
		}

		// Token: 0x0600D78A RID: 55178 RVA: 0x0032854E File Offset: 0x0032674E
		public override void Process()
		{
			Process_PtcG2C_PkTimeoutNtf.Process(this);
		}

		// Token: 0x040061AB RID: 25003
		public PkTimeoutNtf Data = new PkTimeoutNtf();
	}
}
