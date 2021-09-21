using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001231 RID: 4657
	internal class PtcG2C_FightGroupChangeNtf : Protocol
	{
		// Token: 0x0600DD92 RID: 56722 RVA: 0x0033214C File Offset: 0x0033034C
		public override uint GetProtoType()
		{
			return 2142U;
		}

		// Token: 0x0600DD93 RID: 56723 RVA: 0x00332163 File Offset: 0x00330363
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FightGroupChangeNtf>(stream, this.Data);
		}

		// Token: 0x0600DD94 RID: 56724 RVA: 0x00332173 File Offset: 0x00330373
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<FightGroupChangeNtf>(stream);
		}

		// Token: 0x0600DD95 RID: 56725 RVA: 0x00332182 File Offset: 0x00330382
		public override void Process()
		{
			Process_PtcG2C_FightGroupChangeNtf.Process(this);
		}

		// Token: 0x040062CA RID: 25290
		public FightGroupChangeNtf Data = new FightGroupChangeNtf();
	}
}
