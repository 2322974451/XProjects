using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001531 RID: 5425
	internal class PtcG2C_HeroKillNotify : Protocol
	{
		// Token: 0x0600E9E1 RID: 59873 RVA: 0x00343644 File Offset: 0x00341844
		public override uint GetProtoType()
		{
			return 58962U;
		}

		// Token: 0x0600E9E2 RID: 59874 RVA: 0x0034365B File Offset: 0x0034185B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HeroKillNotifyData>(stream, this.Data);
		}

		// Token: 0x0600E9E3 RID: 59875 RVA: 0x0034366B File Offset: 0x0034186B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HeroKillNotifyData>(stream);
		}

		// Token: 0x0600E9E4 RID: 59876 RVA: 0x0034367A File Offset: 0x0034187A
		public override void Process()
		{
			Process_PtcG2C_HeroKillNotify.Process(this);
		}

		// Token: 0x04006528 RID: 25896
		public HeroKillNotifyData Data = new HeroKillNotifyData();
	}
}
