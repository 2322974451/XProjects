using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_GuildCampPartyTradeNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 62988U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildCampPartyTradeNotifyArg>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildCampPartyTradeNotifyArg>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_GuildCampPartyTradeNotify.Process(this);
		}

		public GuildCampPartyTradeNotifyArg Data = new GuildCampPartyTradeNotifyArg();
	}
}
