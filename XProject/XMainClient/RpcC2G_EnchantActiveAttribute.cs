using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200150A RID: 5386
	internal class RpcC2G_EnchantActiveAttribute : Rpc
	{
		// Token: 0x0600E93F RID: 59711 RVA: 0x003426EC File Offset: 0x003408EC
		public override uint GetRpcType()
		{
			return 19086U;
		}

		// Token: 0x0600E940 RID: 59712 RVA: 0x00342703 File Offset: 0x00340903
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<EnchantActiveAttributeArg>(stream, this.oArg);
		}

		// Token: 0x0600E941 RID: 59713 RVA: 0x00342713 File Offset: 0x00340913
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<EnchantActiveAttributeRes>(stream);
		}

		// Token: 0x0600E942 RID: 59714 RVA: 0x00342722 File Offset: 0x00340922
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_EnchantActiveAttribute.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E943 RID: 59715 RVA: 0x0034273E File Offset: 0x0034093E
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_EnchantActiveAttribute.OnTimeout(this.oArg);
		}

		// Token: 0x04006508 RID: 25864
		public EnchantActiveAttributeArg oArg = new EnchantActiveAttributeArg();

		// Token: 0x04006509 RID: 25865
		public EnchantActiveAttributeRes oRes = null;
	}
}
