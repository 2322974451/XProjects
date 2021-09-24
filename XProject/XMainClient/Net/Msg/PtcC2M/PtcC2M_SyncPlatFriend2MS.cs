using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2M_SyncPlatFriend2MS : Protocol
	{

		public override uint GetProtoType()
		{
			return 38885U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SyncPlatFriend2MSData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SyncPlatFriend2MSData>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public SyncPlatFriend2MSData Data = new SyncPlatFriend2MSData();
	}
}
