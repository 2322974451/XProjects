using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_UnitAppear : Protocol
	{

		public override uint GetProtoType()
		{
			return 7458U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<UnitAppearList>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<UnitAppearList>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_UnitAppear.Process(this);
		}

		public UnitAppearList Data = new UnitAppearList();
	}
}
