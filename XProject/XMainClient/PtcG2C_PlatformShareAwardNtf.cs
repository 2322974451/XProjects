using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001526 RID: 5414
	internal class PtcG2C_PlatformShareAwardNtf : Protocol
	{
		// Token: 0x0600E9B1 RID: 59825 RVA: 0x00343174 File Offset: 0x00341374
		public override uint GetProtoType()
		{
			return 24055U;
		}

		// Token: 0x0600E9B2 RID: 59826 RVA: 0x0034318B File Offset: 0x0034138B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PlatformShareAwardPara>(stream, this.Data);
		}

		// Token: 0x0600E9B3 RID: 59827 RVA: 0x0034319B File Offset: 0x0034139B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PlatformShareAwardPara>(stream);
		}

		// Token: 0x0600E9B4 RID: 59828 RVA: 0x003431AA File Offset: 0x003413AA
		public override void Process()
		{
			Process_PtcG2C_PlatformShareAwardNtf.Process(this);
		}

		// Token: 0x0400651E RID: 25886
		public PlatformShareAwardPara Data = new PlatformShareAwardPara();
	}
}
