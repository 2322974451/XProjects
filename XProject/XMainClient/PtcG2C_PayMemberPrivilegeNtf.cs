using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_PayMemberPrivilegeNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 33306U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PayMemberPrivilege>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PayMemberPrivilege>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_PayMemberPrivilegeNtf.Process(this);
		}

		public PayMemberPrivilege Data = new PayMemberPrivilege();
	}
}
