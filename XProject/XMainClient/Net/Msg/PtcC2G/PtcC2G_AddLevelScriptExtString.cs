using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2G_AddLevelScriptExtString : Protocol
	{

		public override uint GetProtoType()
		{
			return 34579U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AddLevelScriptExtString>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<AddLevelScriptExtString>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public AddLevelScriptExtString Data = new AddLevelScriptExtString();
	}
}
