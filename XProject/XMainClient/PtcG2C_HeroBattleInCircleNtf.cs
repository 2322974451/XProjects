using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200141E RID: 5150
	internal class PtcG2C_HeroBattleInCircleNtf : Protocol
	{
		// Token: 0x0600E57F RID: 58751 RVA: 0x0033D140 File Offset: 0x0033B340
		public override uint GetProtoType()
		{
			return 40409U;
		}

		// Token: 0x0600E580 RID: 58752 RVA: 0x0033D157 File Offset: 0x0033B357
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HeroBattleInCircle>(stream, this.Data);
		}

		// Token: 0x0600E581 RID: 58753 RVA: 0x0033D167 File Offset: 0x0033B367
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HeroBattleInCircle>(stream);
		}

		// Token: 0x0600E582 RID: 58754 RVA: 0x0033D176 File Offset: 0x0033B376
		public override void Process()
		{
			Process_PtcG2C_HeroBattleInCircleNtf.Process(this);
		}

		// Token: 0x04006454 RID: 25684
		public HeroBattleInCircle Data = new HeroBattleInCircle();
	}
}
