using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014A0 RID: 5280
	internal class PtcM2C_GuildAuctItemTimeFresh : Protocol
	{
		// Token: 0x0600E78A RID: 59274 RVA: 0x0034027C File Offset: 0x0033E47C
		public override uint GetProtoType()
		{
			return 49239U;
		}

		// Token: 0x0600E78B RID: 59275 RVA: 0x00340293 File Offset: 0x0033E493
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildAuctItemTime>(stream, this.Data);
		}

		// Token: 0x0600E78C RID: 59276 RVA: 0x003402A3 File Offset: 0x0033E4A3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildAuctItemTime>(stream);
		}

		// Token: 0x0600E78D RID: 59277 RVA: 0x003402B2 File Offset: 0x0033E4B2
		public override void Process()
		{
			Process_PtcM2C_GuildAuctItemTimeFresh.Process(this);
		}

		// Token: 0x040064B3 RID: 25779
		public GuildAuctItemTime Data = new GuildAuctItemTime();
	}
}
