using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_CoverDesignationNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 45821U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CoverDesignationNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<CoverDesignationNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_CoverDesignationNtf.Process(this);
		}

		public CoverDesignationNtf Data = new CoverDesignationNtf();
	}
}
