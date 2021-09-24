using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ChooseProfession : Rpc
	{

		public override uint GetRpcType()
		{
			return 24314U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChooseProfArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ChooseProfRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ChooseProfession.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ChooseProfession.OnTimeout(this.oArg);
		}

		public ChooseProfArg oArg = new ChooseProfArg();

		public ChooseProfRes oRes = null;
	}
}
