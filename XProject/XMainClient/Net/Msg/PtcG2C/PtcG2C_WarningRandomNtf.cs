using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_WarningRandomNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 8594U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WarningRandomSet>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<WarningRandomSet>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_WarningRandomNtf.Process(this);
		}

		public WarningRandomSet Data = new WarningRandomSet();
	}
}
