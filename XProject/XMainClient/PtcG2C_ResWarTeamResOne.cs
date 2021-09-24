using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_ResWarTeamResOne : Protocol
	{

		public override uint GetProtoType()
		{
			return 8869U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ResWarAllTeamBaseInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ResWarAllTeamBaseInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_ResWarTeamResOne.Process(this);
		}

		public ResWarAllTeamBaseInfo Data = new ResWarAllTeamBaseInfo();
	}
}
