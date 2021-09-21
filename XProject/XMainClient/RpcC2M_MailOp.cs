using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000B50 RID: 2896
	internal class RpcC2M_MailOp : Rpc
	{
		// Token: 0x0600A8BF RID: 43199 RVA: 0x001E0FFC File Offset: 0x001DF1FC
		public override uint GetRpcType()
		{
			return 50122U;
		}

		// Token: 0x0600A8C0 RID: 43200 RVA: 0x001E1013 File Offset: 0x001DF213
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MailOpArg>(stream, this.oArg);
		}

		// Token: 0x0600A8C1 RID: 43201 RVA: 0x001E1023 File Offset: 0x001DF223
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<MailOpRes>(stream);
		}

		// Token: 0x0600A8C2 RID: 43202 RVA: 0x001E1032 File Offset: 0x001DF232
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_MailOp.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600A8C3 RID: 43203 RVA: 0x001E104E File Offset: 0x001DF24E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_MailOp.OnTimeout(this.oArg);
		}

		// Token: 0x04003E84 RID: 16004
		public MailOpArg oArg = new MailOpArg();

		// Token: 0x04003E85 RID: 16005
		public MailOpRes oRes = null;
	}
}
