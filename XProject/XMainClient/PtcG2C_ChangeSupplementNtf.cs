using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_ChangeSupplementNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 11250U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChangeSupplementNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ChangeSupplementNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_ChangeSupplementNtf.Process(this);
		}

		public ChangeSupplementNtf Data = new ChangeSupplementNtf();
	}
}
