using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013CA RID: 5066
	internal class PtcG2C_HorseWaitTimeNtf : Protocol
	{
		// Token: 0x0600E422 RID: 58402 RVA: 0x0033B424 File Offset: 0x00339624
		public override uint GetProtoType()
		{
			return 34138U;
		}

		// Token: 0x0600E423 RID: 58403 RVA: 0x0033B43B File Offset: 0x0033963B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HorseWaitTime>(stream, this.Data);
		}

		// Token: 0x0600E424 RID: 58404 RVA: 0x0033B44B File Offset: 0x0033964B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HorseWaitTime>(stream);
		}

		// Token: 0x0600E425 RID: 58405 RVA: 0x0033B45A File Offset: 0x0033965A
		public override void Process()
		{
			Process_PtcG2C_HorseWaitTimeNtf.Process(this);
		}

		// Token: 0x0400640F RID: 25615
		public HorseWaitTime Data = new HorseWaitTime();
	}
}
