using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200147E RID: 5246
	internal class PtcG2C_HeroBattleTipsNtf : Protocol
	{
		// Token: 0x0600E6FC RID: 59132 RVA: 0x0033F5B4 File Offset: 0x0033D7B4
		public override uint GetProtoType()
		{
			return 15389U;
		}

		// Token: 0x0600E6FD RID: 59133 RVA: 0x0033F5CB File Offset: 0x0033D7CB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HeroBattleTipsData>(stream, this.Data);
		}

		// Token: 0x0600E6FE RID: 59134 RVA: 0x0033F5DB File Offset: 0x0033D7DB
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HeroBattleTipsData>(stream);
		}

		// Token: 0x0600E6FF RID: 59135 RVA: 0x0033F5EA File Offset: 0x0033D7EA
		public override void Process()
		{
			Process_PtcG2C_HeroBattleTipsNtf.Process(this);
		}

		// Token: 0x04006498 RID: 25752
		public HeroBattleTipsData Data = new HeroBattleTipsData();
	}
}
