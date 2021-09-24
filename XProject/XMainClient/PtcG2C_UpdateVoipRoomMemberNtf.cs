using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_UpdateVoipRoomMemberNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 25546U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<UpdateVoipRoomMemberNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<UpdateVoipRoomMemberNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_UpdateVoipRoomMemberNtf.Process(this);
		}

		public UpdateVoipRoomMemberNtf Data = new UpdateVoipRoomMemberNtf();
	}
}
