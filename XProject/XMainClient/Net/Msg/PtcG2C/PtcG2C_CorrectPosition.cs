using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_CorrectPosition : Protocol
	{

		public override uint GetProtoType()
		{
			return 53665U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<Position>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<Position>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_CorrectPosition.Process(this);
		}

		public Position Data = new Position();
	}
}
