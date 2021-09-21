using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015A7 RID: 5543
	internal class PtcG2C_BattleStatisticsNtf : Protocol
	{
		// Token: 0x0600EBC5 RID: 60357 RVA: 0x00346390 File Offset: 0x00344590
		public override uint GetProtoType()
		{
			return 65061U;
		}

		// Token: 0x0600EBC6 RID: 60358 RVA: 0x003463A7 File Offset: 0x003445A7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BattleStatisticsNtf>(stream, this.Data);
		}

		// Token: 0x0600EBC7 RID: 60359 RVA: 0x003463B7 File Offset: 0x003445B7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BattleStatisticsNtf>(stream);
		}

		// Token: 0x0600EBC8 RID: 60360 RVA: 0x003463C6 File Offset: 0x003445C6
		public override void Process()
		{
			Process_PtcG2C_BattleStatisticsNtf.Process(this);
		}

		// Token: 0x0400658C RID: 25996
		public BattleStatisticsNtf Data = new BattleStatisticsNtf();
	}
}
