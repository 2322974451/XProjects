using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200105C RID: 4188
	internal class PtcG2C_UpdateBuyGoldAndFatigueInfo : Protocol
	{
		// Token: 0x0600D629 RID: 54825 RVA: 0x00325BC0 File Offset: 0x00323DC0
		public override uint GetProtoType()
		{
			return 2587U;
		}

		// Token: 0x0600D62A RID: 54826 RVA: 0x00325BD7 File Offset: 0x00323DD7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BuyGoldFatInfo>(stream, this.Data);
		}

		// Token: 0x0600D62B RID: 54827 RVA: 0x00325BE7 File Offset: 0x00323DE7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BuyGoldFatInfo>(stream);
		}

		// Token: 0x0600D62C RID: 54828 RVA: 0x00325BF6 File Offset: 0x00323DF6
		public override void Process()
		{
			Process_PtcG2C_UpdateBuyGoldAndFatigueInfo.Process(this);
		}

		// Token: 0x0400616C RID: 24940
		public BuyGoldFatInfo Data = new BuyGoldFatInfo();
	}
}
