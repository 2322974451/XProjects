using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_FriendOpNtfNew : Protocol
	{

		public override uint GetProtoType()
		{
			return 22609U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FriendOpNotify>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<FriendOpNotify>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_FriendOpNtfNew.Process(this);
		}

		public FriendOpNotify Data = new FriendOpNotify();
	}
}
