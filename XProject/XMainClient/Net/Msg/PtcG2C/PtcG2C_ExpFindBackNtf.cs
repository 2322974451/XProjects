using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_ExpFindBackNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 4933U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ExpFindBackData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ExpFindBackData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_ExpFindBackNtf.Process(this);
		}

		public ExpFindBackData Data = new ExpFindBackData();
	}
}
