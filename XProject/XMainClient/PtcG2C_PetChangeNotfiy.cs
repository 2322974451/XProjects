using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_PetChangeNotfiy : Protocol
	{

		public override uint GetProtoType()
		{
			return 22264U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PetChangeNotfiy>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PetChangeNotfiy>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_PetChangeNotfiy.Process(this);
		}

		public PetChangeNotfiy Data = new PetChangeNotfiy();
	}
}
