using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_synGuildInheritExp : Protocol
	{

		public override uint GetProtoType()
		{
			return 15872U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<synGuildInheritExp>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<synGuildInheritExp>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_synGuildInheritExp.Process(this);
		}

		public synGuildInheritExp Data = new synGuildInheritExp();
	}
}
