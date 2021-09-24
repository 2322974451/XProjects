using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_ExecuteLevelScriptNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 47978U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ExecuteLevelScriptNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ExecuteLevelScriptNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_ExecuteLevelScriptNtf.Process(this);
		}

		public ExecuteLevelScriptNtf Data = new ExecuteLevelScriptNtf();
	}
}
