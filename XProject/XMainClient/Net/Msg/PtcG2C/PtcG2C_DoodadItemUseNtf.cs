using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_DoodadItemUseNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 13498U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DoodadItemUseNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<DoodadItemUseNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_DoodadItemUseNtf.Process(this);
		}

		public DoodadItemUseNtf Data = new DoodadItemUseNtf();
	}
}
