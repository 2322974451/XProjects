using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_ThemeActivityChangeNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 25642U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ThemeActivityChangeData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ThemeActivityChangeData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_ThemeActivityChangeNtf.Process(this);
		}

		public ThemeActivityChangeData Data = new ThemeActivityChangeData();
	}
}
