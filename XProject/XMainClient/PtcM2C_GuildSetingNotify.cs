using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_GuildSetingNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 21944U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildSettingChanged>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildSettingChanged>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_GuildSetingNotify.Process(this);
		}

		public GuildSettingChanged Data = new GuildSettingChanged();
	}
}
