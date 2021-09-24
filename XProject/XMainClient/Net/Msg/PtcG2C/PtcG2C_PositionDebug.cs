using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_PositionDebug : Protocol
	{

		public override uint GetProtoType()
		{
			return 42493U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PositionCheckList>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PositionCheckList>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_PositionDebug.Process(this);
		}

		public PositionCheckList Data = new PositionCheckList();
	}
}
