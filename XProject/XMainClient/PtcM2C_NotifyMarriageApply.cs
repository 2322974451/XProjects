using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015A2 RID: 5538
	internal class PtcM2C_NotifyMarriageApply : Protocol
	{
		// Token: 0x0600EBB0 RID: 60336 RVA: 0x00346270 File Offset: 0x00344470
		public override uint GetProtoType()
		{
			return 42923U;
		}

		// Token: 0x0600EBB1 RID: 60337 RVA: 0x00346287 File Offset: 0x00344487
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NotifyMarriageApplyData>(stream, this.Data);
		}

		// Token: 0x0600EBB2 RID: 60338 RVA: 0x00346297 File Offset: 0x00344497
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NotifyMarriageApplyData>(stream);
		}

		// Token: 0x0600EBB3 RID: 60339 RVA: 0x003462A6 File Offset: 0x003444A6
		public override void Process()
		{
			Process_PtcM2C_NotifyMarriageApply.Process(this);
		}

		// Token: 0x04006589 RID: 25993
		public NotifyMarriageApplyData Data = new NotifyMarriageApplyData();
	}
}
