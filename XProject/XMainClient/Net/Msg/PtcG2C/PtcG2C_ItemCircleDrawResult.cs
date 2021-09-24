using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_ItemCircleDrawResult : Protocol
	{

		public override uint GetProtoType()
		{
			return 34574U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CircleDrawGive>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<CircleDrawGive>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_ItemCircleDrawResult.Process(this);
		}

		public CircleDrawGive Data = new CircleDrawGive();
	}
}
