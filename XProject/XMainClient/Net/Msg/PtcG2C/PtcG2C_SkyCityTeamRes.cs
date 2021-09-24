using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_SkyCityTeamRes : Protocol
	{

		public override uint GetProtoType()
		{
			return 49519U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SkyCityAllTeamBaseInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SkyCityAllTeamBaseInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_SkyCityTeamRes.Process(this);
		}

		public SkyCityAllTeamBaseInfo Data = new SkyCityAllTeamBaseInfo();
	}
}
