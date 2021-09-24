using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_JoinRoomReply : Protocol
	{

		public override uint GetProtoType()
		{
			return 23084U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<JoinRoomReply>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<JoinRoomReply>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_JoinRoomReply.Process(this);
		}

		public JoinRoomReply Data = new JoinRoomReply();
	}
}
