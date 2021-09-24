using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_OutLookChangeNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 28395U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<OutLookChange>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<OutLookChange>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_OutLookChangeNtf.Process(this);
		}

		public OutLookChange Data = new OutLookChange();
	}
}
