using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2G_UpdateTutorial : Protocol
	{

		public override uint GetProtoType()
		{
			return 31917U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TutorialInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<TutorialInfo>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public TutorialInfo Data = new TutorialInfo();
	}
}
