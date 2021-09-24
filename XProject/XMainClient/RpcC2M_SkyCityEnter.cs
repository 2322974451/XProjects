using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_SkyCityEnter : Rpc
	{

		public override uint GetRpcType()
		{
			return 49485U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SkyCityEnterArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SkyCityEnterRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_SkyCityEnter.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_SkyCityEnter.OnTimeout(this.oArg);
		}

		public SkyCityEnterArg oArg = new SkyCityEnterArg();

		public SkyCityEnterRes oRes = null;
	}
}
