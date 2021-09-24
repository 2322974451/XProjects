using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_AttributeChangeNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 57626U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChangedAttribute>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ChangedAttribute>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_AttributeChangeNotify.Process(this);
		}

		public ChangedAttribute Data = new ChangedAttribute();
	}
}
