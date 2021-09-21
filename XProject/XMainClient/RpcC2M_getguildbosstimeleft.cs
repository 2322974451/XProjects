using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001291 RID: 4753
	internal class RpcC2M_getguildbosstimeleft : Rpc
	{
		// Token: 0x0600DF22 RID: 57122 RVA: 0x003341A8 File Offset: 0x003323A8
		public override uint GetRpcType()
		{
			return 25923U;
		}

		// Token: 0x0600DF23 RID: 57123 RVA: 0x003341BF File Offset: 0x003323BF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<getguildbosstimeleftArg>(stream, this.oArg);
		}

		// Token: 0x0600DF24 RID: 57124 RVA: 0x003341CF File Offset: 0x003323CF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<getguildbosstimeleftRes>(stream);
		}

		// Token: 0x0600DF25 RID: 57125 RVA: 0x003341DE File Offset: 0x003323DE
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_getguildbosstimeleft.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DF26 RID: 57126 RVA: 0x003341FA File Offset: 0x003323FA
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_getguildbosstimeleft.OnTimeout(this.oArg);
		}

		// Token: 0x04006319 RID: 25369
		public getguildbosstimeleftArg oArg = new getguildbosstimeleftArg();

		// Token: 0x0400631A RID: 25370
		public getguildbosstimeleftRes oRes = null;
	}
}
