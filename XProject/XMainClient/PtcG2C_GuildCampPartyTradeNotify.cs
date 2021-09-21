using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001506 RID: 5382
	internal class PtcG2C_GuildCampPartyTradeNotify : Protocol
	{
		// Token: 0x0600E92F RID: 59695 RVA: 0x003424EC File Offset: 0x003406EC
		public override uint GetProtoType()
		{
			return 62988U;
		}

		// Token: 0x0600E930 RID: 59696 RVA: 0x00342503 File Offset: 0x00340703
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildCampPartyTradeNotifyArg>(stream, this.Data);
		}

		// Token: 0x0600E931 RID: 59697 RVA: 0x00342513 File Offset: 0x00340713
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildCampPartyTradeNotifyArg>(stream);
		}

		// Token: 0x0600E932 RID: 59698 RVA: 0x00342522 File Offset: 0x00340722
		public override void Process()
		{
			Process_PtcG2C_GuildCampPartyTradeNotify.Process(this);
		}

		// Token: 0x04006505 RID: 25861
		public GuildCampPartyTradeNotifyArg Data = new GuildCampPartyTradeNotifyArg();
	}
}
