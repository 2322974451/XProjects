using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_GuildSchoolHallUpdatePoint : Protocol
	{

		public override uint GetProtoType()
		{
			return 65336U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildHallUpdatePoint>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildHallUpdatePoint>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_GuildSchoolHallUpdatePoint.Process(this);
		}

		public GuildHallUpdatePoint Data = new GuildHallUpdatePoint();
	}
}
