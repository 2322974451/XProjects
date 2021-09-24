using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_ReviveNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 16213U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReviveInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ReviveInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_ReviveNotify.Process(this);
		}

		public ReviveInfo Data = new ReviveInfo();
	}
}
