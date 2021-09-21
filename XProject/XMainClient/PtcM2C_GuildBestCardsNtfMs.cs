using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012AD RID: 4781
	internal class PtcM2C_GuildBestCardsNtfMs : Protocol
	{
		// Token: 0x0600DF94 RID: 57236 RVA: 0x00334CEC File Offset: 0x00332EEC
		public override uint GetProtoType()
		{
			return 31828U;
		}

		// Token: 0x0600DF95 RID: 57237 RVA: 0x00334D03 File Offset: 0x00332F03
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildBestCardsNtf>(stream, this.Data);
		}

		// Token: 0x0600DF96 RID: 57238 RVA: 0x00334D13 File Offset: 0x00332F13
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildBestCardsNtf>(stream);
		}

		// Token: 0x0600DF97 RID: 57239 RVA: 0x00334D22 File Offset: 0x00332F22
		public override void Process()
		{
			Process_PtcM2C_GuildBestCardsNtfMs.Process(this);
		}

		// Token: 0x0400632F RID: 25391
		public GuildBestCardsNtf Data = new GuildBestCardsNtf();
	}
}
