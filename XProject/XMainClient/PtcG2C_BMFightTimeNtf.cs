using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200155C RID: 5468
	internal class PtcG2C_BMFightTimeNtf : Protocol
	{
		// Token: 0x0600EA89 RID: 60041 RVA: 0x003446E0 File Offset: 0x003428E0
		public override uint GetProtoType()
		{
			return 4101U;
		}

		// Token: 0x0600EA8A RID: 60042 RVA: 0x003446F7 File Offset: 0x003428F7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BMFightTime>(stream, this.Data);
		}

		// Token: 0x0600EA8B RID: 60043 RVA: 0x00344707 File Offset: 0x00342907
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BMFightTime>(stream);
		}

		// Token: 0x0600EA8C RID: 60044 RVA: 0x00344716 File Offset: 0x00342916
		public override void Process()
		{
			Process_PtcG2C_BMFightTimeNtf.Process(this);
		}

		// Token: 0x0400654D RID: 25933
		public BMFightTime Data = new BMFightTime();
	}
}
