using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2G_SetVoipMemberState : Protocol
	{

		public override uint GetProtoType()
		{
			return 3881U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SetVoipMemberState>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SetVoipMemberState>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public SetVoipMemberState Data = new SetVoipMemberState();
	}
}
