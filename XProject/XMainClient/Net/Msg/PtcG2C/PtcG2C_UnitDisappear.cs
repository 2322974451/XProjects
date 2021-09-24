using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_UnitDisappear : Protocol
	{

		public override uint GetProtoType()
		{
			return 26347U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<UnitAppearance>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<UnitAppearance>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_UnitDisappear.Process(this);
		}

		public UnitAppearance Data = new UnitAppearance();
	}
}
