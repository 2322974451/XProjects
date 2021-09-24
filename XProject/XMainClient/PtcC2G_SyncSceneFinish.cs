using System;
using System.IO;

namespace XMainClient
{

	internal class PtcC2G_SyncSceneFinish : Protocol
	{

		public override uint GetProtoType()
		{
			return 559U;
		}

		public override void Serialize(MemoryStream stream)
		{
		}

		public override void DeSerialize(MemoryStream stream)
		{
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}
	}
}
