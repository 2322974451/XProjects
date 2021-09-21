using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001422 RID: 5154
	internal class PtcG2C_HeroBattleOverTime : Protocol
	{
		// Token: 0x0600E58F RID: 58767 RVA: 0x0033D278 File Offset: 0x0033B478
		public override uint GetProtoType()
		{
			return 2950U;
		}

		// Token: 0x0600E590 RID: 58768 RVA: 0x0033D28F File Offset: 0x0033B48F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HeroBattleOverTimeData>(stream, this.Data);
		}

		// Token: 0x0600E591 RID: 58769 RVA: 0x0033D29F File Offset: 0x0033B49F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HeroBattleOverTimeData>(stream);
		}

		// Token: 0x0600E592 RID: 58770 RVA: 0x0033D2AE File Offset: 0x0033B4AE
		public override void Process()
		{
			Process_PtcG2C_HeroBattleOverTime.Process(this);
		}

		// Token: 0x04006457 RID: 25687
		public HeroBattleOverTimeData Data = new HeroBattleOverTimeData();
	}
}
