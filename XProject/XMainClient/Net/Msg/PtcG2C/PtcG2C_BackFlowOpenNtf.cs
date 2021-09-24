using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_BackFlowOpenNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 27749U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BackFlowOpenNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BackFlowOpenNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_BackFlowOpenNtf.Process(this);
		}

		public BackFlowOpenNtf Data = new BackFlowOpenNtf();
	}
}
