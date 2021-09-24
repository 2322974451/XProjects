using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_TeamSelectNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 25174U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TeamSelect>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<TeamSelect>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_TeamSelectNotify.Process(this);
		}

		public TeamSelect Data = new TeamSelect();
	}
}
