using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_EnchantTransfer : Rpc
	{

		public override uint GetRpcType()
		{
			return 54906U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<EnchantTransferArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<EnchantTransferRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_EnchantTransfer.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_EnchantTransfer.OnTimeout(this.oArg);
		}

		public EnchantTransferArg oArg = new EnchantTransferArg();

		public EnchantTransferRes oRes = null;
	}
}
