using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_ScenePrepareInfoNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 65478U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ScenePrepareInfoNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ScenePrepareInfoNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_ScenePrepareInfoNtf.Process(this);
		}

		public ScenePrepareInfoNtf Data = new ScenePrepareInfoNtf();
	}
}
