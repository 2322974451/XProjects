using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_SelectRoleNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 19493U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SelectRoleNtfData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SelectRoleNtfData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_SelectRoleNtf.Process(this);
		}

		public SelectRoleNtfData Data = new SelectRoleNtfData();
	}
}
