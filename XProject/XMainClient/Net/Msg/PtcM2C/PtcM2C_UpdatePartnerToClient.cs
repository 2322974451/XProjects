using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_UpdatePartnerToClient : Protocol
	{

		public override uint GetProtoType()
		{
			return 63692U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<UpdatePartnerToClient>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<UpdatePartnerToClient>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_UpdatePartnerToClient.Process(this);
		}

		public UpdatePartnerToClient Data = new UpdatePartnerToClient();
	}
}
