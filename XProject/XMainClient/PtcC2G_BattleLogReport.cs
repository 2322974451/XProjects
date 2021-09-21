using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000B40 RID: 2880
	internal class PtcC2G_BattleLogReport : Protocol
	{
		// Token: 0x0600A869 RID: 43113 RVA: 0x001E0994 File Offset: 0x001DEB94
		public override uint GetProtoType()
		{
			return 10382U;
		}

		// Token: 0x0600A86A RID: 43114 RVA: 0x001E09AB File Offset: 0x001DEBAB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BattleLogReport>(stream, this.Data);
		}

		// Token: 0x0600A86B RID: 43115 RVA: 0x001E09BB File Offset: 0x001DEBBB
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BattleLogReport>(stream);
		}

		// Token: 0x0600A86C RID: 43116 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x04003E6E RID: 15982
		public BattleLogReport Data = new BattleLogReport();
	}
}
