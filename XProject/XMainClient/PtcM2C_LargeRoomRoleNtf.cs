using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_LargeRoomRoleNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 36333U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LargeRoomRoleParam>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<LargeRoomRoleParam>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_LargeRoomRoleNtf.Process(this);
		}

		public LargeRoomRoleParam Data = new LargeRoomRoleParam();
	}
}
