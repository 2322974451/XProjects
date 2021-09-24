using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_WorldLevelNtf2Client : Protocol
	{

		public override uint GetProtoType()
		{
			return 63449U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WorldLevel>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<WorldLevel>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_WorldLevelNtf2Client.Process(this);
		}

		public WorldLevel Data = new WorldLevel();
	}
}
