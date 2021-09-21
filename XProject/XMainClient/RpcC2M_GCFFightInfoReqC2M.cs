using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001429 RID: 5161
	internal class RpcC2M_GCFFightInfoReqC2M : Rpc
	{
		// Token: 0x0600E5A9 RID: 58793 RVA: 0x0033D414 File Offset: 0x0033B614
		public override uint GetRpcType()
		{
			return 42852U;
		}

		// Token: 0x0600E5AA RID: 58794 RVA: 0x0033D42B File Offset: 0x0033B62B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GCFFightInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600E5AB RID: 58795 RVA: 0x0033D43B File Offset: 0x0033B63B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GCFFightInfoRes>(stream);
		}

		// Token: 0x0600E5AC RID: 58796 RVA: 0x0033D44A File Offset: 0x0033B64A
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GCFFightInfoReqC2M.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E5AD RID: 58797 RVA: 0x0033D466 File Offset: 0x0033B666
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GCFFightInfoReqC2M.OnTimeout(this.oArg);
		}

		// Token: 0x0400645A RID: 25690
		public GCFFightInfoArg oArg = new GCFFightInfoArg();

		// Token: 0x0400645B RID: 25691
		public GCFFightInfoRes oRes = null;
	}
}
