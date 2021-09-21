using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200111A RID: 4378
	internal class PtcG2C_SyncStepNotify : Protocol
	{
		// Token: 0x0600D92D RID: 55597 RVA: 0x0032AA30 File Offset: 0x00328C30
		public override uint GetProtoType()
		{
			return 37999U;
		}

		// Token: 0x0600D92E RID: 55598 RVA: 0x0032AA47 File Offset: 0x00328C47
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<StepSyncInfo>(stream, this.Data);
		}

		// Token: 0x0600D92F RID: 55599 RVA: 0x0032AA57 File Offset: 0x00328C57
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data.StepFrame = 0U;
			this.Data.StepFrameSpecified = false;
			this.Data.DataList.Clear();
			Serializer.Merge<StepSyncInfo>(stream, this.Data);
		}

		// Token: 0x0600D930 RID: 55600 RVA: 0x0032AA92 File Offset: 0x00328C92
		public override void Process()
		{
			Process_PtcG2C_SyncStepNotify.Process(this);
		}

		// Token: 0x040061F9 RID: 25081
		public StepSyncInfo Data = new StepSyncInfo();
	}
}
