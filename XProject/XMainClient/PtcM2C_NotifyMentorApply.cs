using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013DC RID: 5084
	internal class PtcM2C_NotifyMentorApply : Protocol
	{
		// Token: 0x0600E46F RID: 58479 RVA: 0x0033BC14 File Offset: 0x00339E14
		public override uint GetProtoType()
		{
			return 61023U;
		}

		// Token: 0x0600E470 RID: 58480 RVA: 0x0033BC2B File Offset: 0x00339E2B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NotifyMentorApplyData>(stream, this.Data);
		}

		// Token: 0x0600E471 RID: 58481 RVA: 0x0033BC3B File Offset: 0x00339E3B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NotifyMentorApplyData>(stream);
		}

		// Token: 0x0600E472 RID: 58482 RVA: 0x0033BC4A File Offset: 0x00339E4A
		public override void Process()
		{
			Process_PtcM2C_NotifyMentorApply.Process(this);
		}

		// Token: 0x0400641F RID: 25631
		public NotifyMentorApplyData Data = new NotifyMentorApplyData();
	}
}
