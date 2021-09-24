using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_TarjaBriefNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 35068U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TarjaBrief>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<TarjaBrief>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_TarjaBriefNtf.Process(this);
		}

		public TarjaBrief Data = new TarjaBrief();
	}
}
