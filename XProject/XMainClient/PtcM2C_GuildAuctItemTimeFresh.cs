using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_GuildAuctItemTimeFresh : Protocol
	{

		public override uint GetProtoType()
		{
			return 49239U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildAuctItemTime>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildAuctItemTime>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_GuildAuctItemTimeFresh.Process(this);
		}

		public GuildAuctItemTime Data = new GuildAuctItemTime();
	}
}
