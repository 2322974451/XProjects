using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_TeamFullDataNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 48618U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TeamFullDataNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<TeamFullDataNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_TeamFullDataNtf.Process(this);
		}

		public TeamFullDataNtf Data = new TeamFullDataNtf();
	}
}
