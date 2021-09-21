using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001096 RID: 4246
	internal class PtcG2C_NextDayRewardNtf : Protocol
	{
		// Token: 0x0600D717 RID: 55063 RVA: 0x0032721C File Offset: 0x0032541C
		public override uint GetProtoType()
		{
			return 50036U;
		}

		// Token: 0x0600D718 RID: 55064 RVA: 0x00327233 File Offset: 0x00325433
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NextDayRewardNtf>(stream, this.Data);
		}

		// Token: 0x0600D719 RID: 55065 RVA: 0x00327243 File Offset: 0x00325443
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NextDayRewardNtf>(stream);
		}

		// Token: 0x0600D71A RID: 55066 RVA: 0x00327252 File Offset: 0x00325452
		public override void Process()
		{
			Process_PtcG2C_NextDayRewardNtf.Process(this);
		}

		// Token: 0x04006198 RID: 24984
		public NextDayRewardNtf Data = new NextDayRewardNtf();
	}
}
