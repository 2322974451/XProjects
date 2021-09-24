using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_TakeOffAllJade : Rpc
	{

		public override uint GetRpcType()
		{
			return 21793U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TakeOffAllJadeArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<TakeOffAllJadeRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_TakeOffAllJade.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_TakeOffAllJade.OnTimeout(this.oArg);
		}

		public TakeOffAllJadeArg oArg = new TakeOffAllJadeArg();

		public TakeOffAllJadeRes oRes = new TakeOffAllJadeRes();
	}
}
