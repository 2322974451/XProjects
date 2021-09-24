using System;
using System.IO;

namespace XMainClient
{

	internal class PtcC2G_LeaveSceneReq : Protocol
	{

		public override uint GetProtoType()
		{
			return 27927U;
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
