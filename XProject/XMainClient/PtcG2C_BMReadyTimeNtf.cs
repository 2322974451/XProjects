using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200155A RID: 5466
	internal class PtcG2C_BMReadyTimeNtf : Protocol
	{
		// Token: 0x0600EA82 RID: 60034 RVA: 0x00344660 File Offset: 0x00342860
		public override uint GetProtoType()
		{
			return 8612U;
		}

		// Token: 0x0600EA83 RID: 60035 RVA: 0x00344677 File Offset: 0x00342877
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BMReadyTime>(stream, this.Data);
		}

		// Token: 0x0600EA84 RID: 60036 RVA: 0x00344687 File Offset: 0x00342887
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BMReadyTime>(stream);
		}

		// Token: 0x0600EA85 RID: 60037 RVA: 0x00344696 File Offset: 0x00342896
		public override void Process()
		{
			Process_PtcG2C_BMReadyTimeNtf.Process(this);
		}

		// Token: 0x0400654C RID: 25932
		public BMReadyTime Data = new BMReadyTime();
	}
}
