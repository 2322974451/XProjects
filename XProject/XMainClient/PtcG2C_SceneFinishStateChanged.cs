using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_SceneFinishStateChanged : Protocol
	{

		public override uint GetProtoType()
		{
			return 60400U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FinishStateInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<FinishStateInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_SceneFinishStateChanged.Process(this);
		}

		public FinishStateInfo Data = new FinishStateInfo();
	}
}
