using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_PersonalCareer : Rpc
	{

		public override uint GetRpcType()
		{
			return 64048U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PersonalCareerArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<PersonalCareerRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_PersonalCareer.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_PersonalCareer.OnTimeout(this.oArg);
		}

		public PersonalCareerArg oArg = new PersonalCareerArg();

		public PersonalCareerRes oRes = null;
	}
}
