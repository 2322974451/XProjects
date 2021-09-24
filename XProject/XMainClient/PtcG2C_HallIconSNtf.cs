using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_HallIconSNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 17871U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HallIconPara>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HallIconPara>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_HallIconSNtf.Process(this);
		}

		public HallIconPara Data = new HallIconPara();
	}
}
