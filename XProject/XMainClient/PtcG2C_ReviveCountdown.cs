using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_ReviveCountdown : Protocol
	{

		public override uint GetProtoType()
		{
			return 54507U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReviveCountdownInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ReviveCountdownInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_ReviveCountdown.Process(this);
		}

		public ReviveCountdownInfo Data = new ReviveCountdownInfo();
	}
}
