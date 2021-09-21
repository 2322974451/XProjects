using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001223 RID: 4643
	internal class PtcM2C_PkTimeoutM2CNtf : Protocol
	{
		// Token: 0x0600DD59 RID: 56665 RVA: 0x00331B90 File Offset: 0x0032FD90
		public override uint GetProtoType()
		{
			return 4963U;
		}

		// Token: 0x0600DD5A RID: 56666 RVA: 0x00331BA7 File Offset: 0x0032FDA7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PkTimeoutNtf>(stream, this.Data);
		}

		// Token: 0x0600DD5B RID: 56667 RVA: 0x00331BB7 File Offset: 0x0032FDB7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PkTimeoutNtf>(stream);
		}

		// Token: 0x0600DD5C RID: 56668 RVA: 0x00331BC6 File Offset: 0x0032FDC6
		public override void Process()
		{
			Process_PtcM2C_PkTimeoutM2CNtf.Process(this);
		}

		// Token: 0x040062BF RID: 25279
		public PkTimeoutNtf Data = new PkTimeoutNtf();
	}
}
