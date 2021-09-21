using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200140C RID: 5132
	internal class PtcG2C_HeroBattleDataNtf : Protocol
	{
		// Token: 0x0600E536 RID: 58678 RVA: 0x0033CA64 File Offset: 0x0033AC64
		public override uint GetProtoType()
		{
			return 60769U;
		}

		// Token: 0x0600E537 RID: 58679 RVA: 0x0033CA7B File Offset: 0x0033AC7B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HeroBattleData>(stream, this.Data);
		}

		// Token: 0x0600E538 RID: 58680 RVA: 0x0033CA8B File Offset: 0x0033AC8B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HeroBattleData>(stream);
		}

		// Token: 0x0600E539 RID: 58681 RVA: 0x0033CA9A File Offset: 0x0033AC9A
		public override void Process()
		{
			Process_PtcG2C_HeroBattleDataNtf.Process(this);
		}

		// Token: 0x04006446 RID: 25670
		public HeroBattleData Data = new HeroBattleData();
	}
}
