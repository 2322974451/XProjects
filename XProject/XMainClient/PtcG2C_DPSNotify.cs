using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001329 RID: 4905
	internal class PtcG2C_DPSNotify : Protocol
	{
		// Token: 0x0600E193 RID: 57747 RVA: 0x00337C90 File Offset: 0x00335E90
		public override uint GetProtoType()
		{
			return 36800U;
		}

		// Token: 0x0600E194 RID: 57748 RVA: 0x00337CA7 File Offset: 0x00335EA7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DPSNotify>(stream, this.Data);
		}

		// Token: 0x0600E195 RID: 57749 RVA: 0x00337CB7 File Offset: 0x00335EB7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<DPSNotify>(stream);
		}

		// Token: 0x0600E196 RID: 57750 RVA: 0x00337CC6 File Offset: 0x00335EC6
		public override void Process()
		{
			Process_PtcG2C_DPSNotify.Process(this);
		}

		// Token: 0x04006392 RID: 25490
		public DPSNotify Data = new DPSNotify();
	}
}
