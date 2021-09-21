using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000EC5 RID: 3781
	internal class RpcC2G_EnhanceItem : Rpc
	{
		// Token: 0x0600C8B0 RID: 51376 RVA: 0x002CEF24 File Offset: 0x002CD124
		public override uint GetRpcType()
		{
			return 3744U;
		}

		// Token: 0x0600C8B1 RID: 51377 RVA: 0x002CEF3B File Offset: 0x002CD13B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<EnhanceItemArg>(stream, this.oArg);
		}

		// Token: 0x0600C8B2 RID: 51378 RVA: 0x002CEF4B File Offset: 0x002CD14B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<EnhanceItemRes>(stream);
		}

		// Token: 0x0600C8B3 RID: 51379 RVA: 0x002CEF5A File Offset: 0x002CD15A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_EnhanceItem.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600C8B4 RID: 51380 RVA: 0x002CEF76 File Offset: 0x002CD176
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_EnhanceItem.OnTimeout(this.oArg);
		}

		// Token: 0x040058C1 RID: 22721
		public EnhanceItemArg oArg = new EnhanceItemArg();

		// Token: 0x040058C2 RID: 22722
		public EnhanceItemRes oRes = null;
	}
}
