using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_GCFSynG2CNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 31469U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GCFG2CSynPara>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GCFG2CSynPara>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_GCFSynG2CNtf.Process(this);
		}

		public GCFG2CSynPara Data = new GCFG2CSynPara();
	}
}
