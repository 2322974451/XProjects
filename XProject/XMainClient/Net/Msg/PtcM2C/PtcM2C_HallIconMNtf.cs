using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_HallIconMNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 51500U;
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
			Process_PtcM2C_HallIconMNtf.Process(this);
		}

		public HallIconPara Data = new HallIconPara();
	}
}
