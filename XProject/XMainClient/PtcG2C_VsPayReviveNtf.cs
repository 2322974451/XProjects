using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200169E RID: 5790
	internal class PtcG2C_VsPayReviveNtf : Protocol
	{
		// Token: 0x0600EFCE RID: 61390 RVA: 0x0034BEF4 File Offset: 0x0034A0F4
		public override uint GetProtoType()
		{
			return 8168U;
		}

		// Token: 0x0600EFCF RID: 61391 RVA: 0x0034BF0B File Offset: 0x0034A10B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<VsPayRevivePara>(stream, this.Data);
		}

		// Token: 0x0600EFD0 RID: 61392 RVA: 0x0034BF1B File Offset: 0x0034A11B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<VsPayRevivePara>(stream);
		}

		// Token: 0x0600EFD1 RID: 61393 RVA: 0x0034BF2A File Offset: 0x0034A12A
		public override void Process()
		{
			Process_PtcG2C_VsPayReviveNtf.Process(this);
		}

		// Token: 0x04006660 RID: 26208
		public VsPayRevivePara Data = new VsPayRevivePara();
	}
}
