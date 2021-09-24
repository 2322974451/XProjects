using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_EnchantActiveAttribute : Rpc
	{

		public override uint GetRpcType()
		{
			return 19086U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<EnchantActiveAttributeArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<EnchantActiveAttributeRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_EnchantActiveAttribute.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_EnchantActiveAttribute.OnTimeout(this.oArg);
		}

		public EnchantActiveAttributeArg oArg = new EnchantActiveAttributeArg();

		public EnchantActiveAttributeRes oRes = null;
	}
}
