using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2M_LeaveLargeRoom : Protocol
	{

		public override uint GetProtoType()
		{
			return 55577U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LeaveLargeRoomParam>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<LeaveLargeRoomParam>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public LeaveLargeRoomParam Data = new LeaveLargeRoomParam();
	}
}
