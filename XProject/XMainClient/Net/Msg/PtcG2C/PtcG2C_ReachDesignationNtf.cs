using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_ReachDesignationNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 17457U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReachDesignationNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ReachDesignationNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_ReachDesignationNtf.Process(this);
		}

		public ReachDesignationNtf Data = new ReachDesignationNtf();
	}
}
