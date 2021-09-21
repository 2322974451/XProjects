using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200149B RID: 5275
	internal class PtcC2M_CloseLeagueEleNtf : Protocol
	{
		// Token: 0x0600E775 RID: 59253 RVA: 0x003400E0 File Offset: 0x0033E2E0
		public override uint GetProtoType()
		{
			return 8195U;
		}

		// Token: 0x0600E776 RID: 59254 RVA: 0x003400F7 File Offset: 0x0033E2F7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CloseLeagueEleNtf>(stream, this.Data);
		}

		// Token: 0x0600E777 RID: 59255 RVA: 0x00340107 File Offset: 0x0033E307
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<CloseLeagueEleNtf>(stream);
		}

		// Token: 0x0600E778 RID: 59256 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x040064B0 RID: 25776
		public CloseLeagueEleNtf Data = new CloseLeagueEleNtf();
	}
}
