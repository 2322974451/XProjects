using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_GprAllFightEndNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 58789U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GprAllFightEnd>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GprAllFightEnd>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_GprAllFightEndNtf.Process(this);
		}

		public GprAllFightEnd Data = new GprAllFightEnd();
	}
}
