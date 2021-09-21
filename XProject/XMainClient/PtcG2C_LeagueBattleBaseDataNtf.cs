using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000B48 RID: 2888
	internal class PtcG2C_LeagueBattleBaseDataNtf : Protocol
	{
		// Token: 0x0600A894 RID: 43156 RVA: 0x001E0CC4 File Offset: 0x001DEEC4
		public override uint GetProtoType()
		{
			return 19581U;
		}

		// Token: 0x0600A895 RID: 43157 RVA: 0x001E0CDB File Offset: 0x001DEEDB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LeagueBattleBaseDataNtf>(stream, this.Data);
		}

		// Token: 0x0600A896 RID: 43158 RVA: 0x001E0CEB File Offset: 0x001DEEEB
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<LeagueBattleBaseDataNtf>(stream);
		}

		// Token: 0x0600A897 RID: 43159 RVA: 0x001E0CFA File Offset: 0x001DEEFA
		public override void Process()
		{
			Process_PtcG2C_LeagueBattleBaseDataNtf.Process(this);
		}

		// Token: 0x04003E79 RID: 15993
		public LeagueBattleBaseDataNtf Data = new LeagueBattleBaseDataNtf();
	}
}
