using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2G_ChangeSupplementReport : Protocol
	{

		public override uint GetProtoType()
		{
			return 42193U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChangeSupplementReport>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ChangeSupplementReport>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public ChangeSupplementReport Data = new ChangeSupplementReport();
	}
}
