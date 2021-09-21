using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012CA RID: 4810
	internal class PtcG2C_UpdateTaskStatus : Protocol
	{
		// Token: 0x0600E00D RID: 57357 RVA: 0x00335804 File Offset: 0x00333A04
		public override uint GetProtoType()
		{
			return 1609U;
		}

		// Token: 0x0600E00E RID: 57358 RVA: 0x0033581B File Offset: 0x00333A1B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TaskInfo>(stream, this.Data);
		}

		// Token: 0x0600E00F RID: 57359 RVA: 0x0033582B File Offset: 0x00333A2B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<TaskInfo>(stream);
		}

		// Token: 0x0600E010 RID: 57360 RVA: 0x0033583A File Offset: 0x00333A3A
		public override void Process()
		{
			Process_PtcG2C_UpdateTaskStatus.Process(this);
		}

		// Token: 0x04006347 RID: 25415
		public TaskInfo Data = new TaskInfo();
	}
}
