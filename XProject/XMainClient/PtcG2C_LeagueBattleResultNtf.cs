using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000B4B RID: 2891
	internal class PtcG2C_LeagueBattleResultNtf : Protocol
	{
		// Token: 0x0600A8A3 RID: 43171 RVA: 0x001E0DCC File Offset: 0x001DEFCC
		public override uint GetProtoType()
		{
			return 29255U;
		}

		// Token: 0x0600A8A4 RID: 43172 RVA: 0x001E0DE3 File Offset: 0x001DEFE3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LeagueBattleResultNtf>(stream, this.Data);
		}

		// Token: 0x0600A8A5 RID: 43173 RVA: 0x001E0DF3 File Offset: 0x001DEFF3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<LeagueBattleResultNtf>(stream);
		}

		// Token: 0x0600A8A6 RID: 43174 RVA: 0x001E0E02 File Offset: 0x001DF002
		public override void Process()
		{
			Process_PtcG2C_LeagueBattleResultNtf.Process(this);
		}

		// Token: 0x04003E7C RID: 15996
		public LeagueBattleResultNtf Data = new LeagueBattleResultNtf();
	}
}
