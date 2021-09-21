using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010D2 RID: 4306
	internal class PtcG2C_CorrectPosition : Protocol
	{
		// Token: 0x0600D802 RID: 55298 RVA: 0x00328E84 File Offset: 0x00327084
		public override uint GetProtoType()
		{
			return 53665U;
		}

		// Token: 0x0600D803 RID: 55299 RVA: 0x00328E9B File Offset: 0x0032709B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<Position>(stream, this.Data);
		}

		// Token: 0x0600D804 RID: 55300 RVA: 0x00328EAB File Offset: 0x003270AB
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<Position>(stream);
		}

		// Token: 0x0600D805 RID: 55301 RVA: 0x00328EBA File Offset: 0x003270BA
		public override void Process()
		{
			Process_PtcG2C_CorrectPosition.Process(this);
		}

		// Token: 0x040061BF RID: 25023
		public Position Data = new Position();
	}
}
