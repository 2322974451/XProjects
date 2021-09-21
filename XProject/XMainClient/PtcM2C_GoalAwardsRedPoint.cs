using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015E9 RID: 5609
	internal class PtcM2C_GoalAwardsRedPoint : Protocol
	{
		// Token: 0x0600ECD2 RID: 60626 RVA: 0x00347914 File Offset: 0x00345B14
		public override uint GetProtoType()
		{
			return 11570U;
		}

		// Token: 0x0600ECD3 RID: 60627 RVA: 0x0034792B File Offset: 0x00345B2B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GoalAwardsRedPointNtf>(stream, this.Data);
		}

		// Token: 0x0600ECD4 RID: 60628 RVA: 0x0034793B File Offset: 0x00345B3B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GoalAwardsRedPointNtf>(stream);
		}

		// Token: 0x0600ECD5 RID: 60629 RVA: 0x0034794A File Offset: 0x00345B4A
		public override void Process()
		{
			Process_PtcM2C_GoalAwardsRedPoint.Process(this);
		}

		// Token: 0x040065BE RID: 26046
		public GoalAwardsRedPointNtf Data = new GoalAwardsRedPointNtf();
	}
}
