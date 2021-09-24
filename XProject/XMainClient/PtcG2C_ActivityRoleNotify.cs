using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_ActivityRoleNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 2548U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ActivityRoleNotify>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ActivityRoleNotify>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_ActivityRoleNotify.Process(this);
		}

		public ActivityRoleNotify Data = new ActivityRoleNotify();
	}
}
