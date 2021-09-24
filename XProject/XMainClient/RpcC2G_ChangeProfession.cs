using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ChangeProfession : Rpc
	{

		public override uint GetRpcType()
		{
			return 48822U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChangeProfessionArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ChangeProfessionRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ChangeProfession.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ChangeProfession.OnTimeout(this.oArg);
		}

		public ChangeProfessionArg oArg = new ChangeProfessionArg();

		public ChangeProfessionRes oRes = null;
	}
}
