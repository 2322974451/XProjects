using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001323 RID: 4899
	internal class PtcM2C_SpriteStateChangeNtf : Protocol
	{
		// Token: 0x0600E17C RID: 57724 RVA: 0x00337AA8 File Offset: 0x00335CA8
		public override uint GetProtoType()
		{
			return 38584U;
		}

		// Token: 0x0600E17D RID: 57725 RVA: 0x00337ABF File Offset: 0x00335CBF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SpriteState>(stream, this.Data);
		}

		// Token: 0x0600E17E RID: 57726 RVA: 0x00337ACF File Offset: 0x00335CCF
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SpriteState>(stream);
		}

		// Token: 0x0600E17F RID: 57727 RVA: 0x00337ADE File Offset: 0x00335CDE
		public override void Process()
		{
			Process_PtcM2C_SpriteStateChangeNtf.Process(this);
		}

		// Token: 0x0400638E RID: 25486
		public SpriteState Data = new SpriteState();
	}
}
