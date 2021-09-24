using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_ServerOpenDayNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 23820U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ServerOpenDay>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ServerOpenDay>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_ServerOpenDayNtf.Process(this);
		}

		public ServerOpenDay Data = new ServerOpenDay();
	}
}
