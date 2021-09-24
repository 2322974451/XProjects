using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_PetInviteNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 19818U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PetInviteNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PetInviteNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_PetInviteNtf.Process(this);
		}

		public PetInviteNtf Data = new PetInviteNtf();
	}
}
