using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_FatigueRecoverTimeNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 14296U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FatigueRecoverTimeInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<FatigueRecoverTimeInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_FatigueRecoverTimeNotify.Process(this);
		}

		public FatigueRecoverTimeInfo Data = new FatigueRecoverTimeInfo();
	}
}
