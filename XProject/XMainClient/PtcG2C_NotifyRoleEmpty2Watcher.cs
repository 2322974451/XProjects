using System;
using System.IO;

namespace XMainClient
{

	internal class PtcG2C_NotifyRoleEmpty2Watcher : Protocol
	{

		public override uint GetProtoType()
		{
			return 1540U;
		}

		public override void Serialize(MemoryStream stream)
		{
		}

		public override void DeSerialize(MemoryStream stream)
		{
		}

		public override void Process()
		{
			Process_PtcG2C_NotifyRoleEmpty2Watcher.Process(this);
		}
	}
}
