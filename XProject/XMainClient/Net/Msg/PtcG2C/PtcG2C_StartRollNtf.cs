using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_StartRollNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 41146U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<StartRollNtfData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<StartRollNtfData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_StartRollNtf.Process(this);
		}

		public StartRollNtfData Data = new StartRollNtfData();
	}
}
