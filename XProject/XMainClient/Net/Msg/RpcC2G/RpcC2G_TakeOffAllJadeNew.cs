using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_TakeOffAllJadeNew : Rpc
	{

		public override uint GetRpcType()
		{
			return 33760U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TakeOffAllJadeNewArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<TakeOffAllJadeNewRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_TakeOffAllJadeNew.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_TakeOffAllJadeNew.OnTimeout(this.oArg);
		}

		public TakeOffAllJadeNewArg oArg = new TakeOffAllJadeNewArg();

		public TakeOffAllJadeNewRes oRes = null;
	}
}
