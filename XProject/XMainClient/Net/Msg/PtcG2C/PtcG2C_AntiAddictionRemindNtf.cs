using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_AntiAddictionRemindNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 17999U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AntiAddictionRemindInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<AntiAddictionRemindInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_AntiAddictionRemindNtf.Process(this);
		}

		public AntiAddictionRemindInfo Data = new AntiAddictionRemindInfo();
	}
}
