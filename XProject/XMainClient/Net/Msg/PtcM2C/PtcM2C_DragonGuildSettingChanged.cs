using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_DragonGuildSettingChanged : Protocol
	{

		public override uint GetProtoType()
		{
			return 42603U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DragonGuildSettingChanged>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<DragonGuildSettingChanged>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_DragonGuildSettingChanged.Process(this);
		}

		public DragonGuildSettingChanged Data = new DragonGuildSettingChanged();
	}
}
