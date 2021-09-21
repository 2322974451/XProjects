using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010A6 RID: 4262
	internal class PtcG2C_TakeRandomTask : Protocol
	{
		// Token: 0x0600D758 RID: 55128 RVA: 0x00327C14 File Offset: 0x00325E14
		public override uint GetProtoType()
		{
			return 8442U;
		}

		// Token: 0x0600D759 RID: 55129 RVA: 0x00327C2B File Offset: 0x00325E2B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<randomtask>(stream, this.Data);
		}

		// Token: 0x0600D75A RID: 55130 RVA: 0x00327C3B File Offset: 0x00325E3B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<randomtask>(stream);
		}

		// Token: 0x0600D75B RID: 55131 RVA: 0x00327C4A File Offset: 0x00325E4A
		public override void Process()
		{
			Process_PtcG2C_TakeRandomTask.Process(this);
		}

		// Token: 0x040061A4 RID: 24996
		public randomtask Data = new randomtask();
	}
}
