using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_InvFightBefEnterSceneNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 7135U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<InvFightBefESpara>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<InvFightBefESpara>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_InvFightBefEnterSceneNtf.Process(this);
		}

		public InvFightBefESpara Data = new InvFightBefESpara();
	}
}
