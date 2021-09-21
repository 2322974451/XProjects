using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200108E RID: 4238
	internal class PtcG2C_GuildBestCardsNtf : Protocol
	{
		// Token: 0x0600D6F9 RID: 55033 RVA: 0x00327010 File Offset: 0x00325210
		public override uint GetProtoType()
		{
			return 44473U;
		}

		// Token: 0x0600D6FA RID: 55034 RVA: 0x00327027 File Offset: 0x00325227
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildBestCardsNtf>(stream, this.Data);
		}

		// Token: 0x0600D6FB RID: 55035 RVA: 0x00327037 File Offset: 0x00325237
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildBestCardsNtf>(stream);
		}

		// Token: 0x0600D6FC RID: 55036 RVA: 0x00327046 File Offset: 0x00325246
		public override void Process()
		{
			Process_PtcG2C_GuildBestCardsNtf.Process(this);
		}

		// Token: 0x04006193 RID: 24979
		public GuildBestCardsNtf Data = new GuildBestCardsNtf();
	}
}
