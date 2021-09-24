using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_TeamChangeM2CNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 53586U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TeamChanged>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<TeamChanged>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_TeamChangeM2CNtf.Process(this);
		}

		public TeamChanged Data = new TeamChanged();
	}
}
