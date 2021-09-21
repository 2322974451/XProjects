using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200142F RID: 5167
	internal class PtcG2C_GCFSynG2CNtf : Protocol
	{
		// Token: 0x0600E5C4 RID: 58820 RVA: 0x0033D64C File Offset: 0x0033B84C
		public override uint GetProtoType()
		{
			return 31469U;
		}

		// Token: 0x0600E5C5 RID: 58821 RVA: 0x0033D663 File Offset: 0x0033B863
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GCFG2CSynPara>(stream, this.Data);
		}

		// Token: 0x0600E5C6 RID: 58822 RVA: 0x0033D673 File Offset: 0x0033B873
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GCFG2CSynPara>(stream);
		}

		// Token: 0x0600E5C7 RID: 58823 RVA: 0x0033D682 File Offset: 0x0033B882
		public override void Process()
		{
			Process_PtcG2C_GCFSynG2CNtf.Process(this);
		}

		// Token: 0x04006460 RID: 25696
		public GCFG2CSynPara Data = new GCFG2CSynPara();
	}
}
