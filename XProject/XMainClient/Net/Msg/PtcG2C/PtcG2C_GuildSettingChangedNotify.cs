using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_GuildSettingChangedNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 63721U;
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
			Process_PtcG2C_GuildSettingChangedNotify.Process(this);
		}

		public GuildSettingChanged Data = new GuildSettingChanged();
	}
}
