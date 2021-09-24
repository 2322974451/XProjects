using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_SynGuildInheritNumInfo : Protocol
	{

		public override uint GetProtoType()
		{
			return 54442U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SynGuildInheritNumInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SynGuildInheritNumInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_SynGuildInheritNumInfo.Process(this);
		}

		public SynGuildInheritNumInfo Data = new SynGuildInheritNumInfo();
	}
}
