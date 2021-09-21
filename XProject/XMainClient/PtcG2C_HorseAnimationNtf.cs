using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013CC RID: 5068
	internal class PtcG2C_HorseAnimationNtf : Protocol
	{
		// Token: 0x0600E429 RID: 58409 RVA: 0x0033B4A4 File Offset: 0x003396A4
		public override uint GetProtoType()
		{
			return 21212U;
		}

		// Token: 0x0600E42A RID: 58410 RVA: 0x0033B4BB File Offset: 0x003396BB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HorseAnimation>(stream, this.Data);
		}

		// Token: 0x0600E42B RID: 58411 RVA: 0x0033B4CB File Offset: 0x003396CB
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HorseAnimation>(stream);
		}

		// Token: 0x0600E42C RID: 58412 RVA: 0x0033B4DA File Offset: 0x003396DA
		public override void Process()
		{
			Process_PtcG2C_HorseAnimationNtf.Process(this);
		}

		// Token: 0x04006410 RID: 25616
		public HorseAnimation Data = new HorseAnimation();
	}
}
