using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012EA RID: 4842
	internal class PtcC2M_GuildCardRankReq : Protocol
	{
		// Token: 0x0600E093 RID: 57491 RVA: 0x00336448 File Offset: 0x00334648
		public override uint GetProtoType()
		{
			return 50768U;
		}

		// Token: 0x0600E094 RID: 57492 RVA: 0x0033645F File Offset: 0x0033465F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildCardRankReq>(stream, this.Data);
		}

		// Token: 0x0600E095 RID: 57493 RVA: 0x0033646F File Offset: 0x0033466F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildCardRankReq>(stream);
		}

		// Token: 0x0600E096 RID: 57494 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x04006362 RID: 25442
		public GuildCardRankReq Data = new GuildCardRankReq();
	}
}
