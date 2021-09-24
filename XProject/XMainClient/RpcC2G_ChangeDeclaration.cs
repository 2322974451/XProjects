using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ChangeDeclaration : Rpc
	{

		public override uint GetRpcType()
		{
			return 1588U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChangeDeclarationArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ChangeDeclarationRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ChangeDeclaration.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ChangeDeclaration.OnTimeout(this.oArg);
		}

		public ChangeDeclarationArg oArg = new ChangeDeclarationArg();

		public ChangeDeclarationRes oRes = null;
	}
}
