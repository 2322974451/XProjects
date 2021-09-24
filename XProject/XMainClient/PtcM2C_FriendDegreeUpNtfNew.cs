using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_FriendDegreeUpNtfNew : Protocol
	{

		public override uint GetProtoType()
		{
			return 36126U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FriendDegreeUpNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<FriendDegreeUpNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_FriendDegreeUpNtfNew.Process(this);
		}

		public FriendDegreeUpNtf Data = new FriendDegreeUpNtf();
	}
}
