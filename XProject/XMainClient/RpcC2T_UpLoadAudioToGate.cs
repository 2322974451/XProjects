using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001524 RID: 5412
	internal class RpcC2T_UpLoadAudioToGate : Rpc
	{
		// Token: 0x0600E9A8 RID: 59816 RVA: 0x0034306C File Offset: 0x0034126C
		public override uint GetRpcType()
		{
			return 23176U;
		}

		// Token: 0x0600E9A9 RID: 59817 RVA: 0x00343083 File Offset: 0x00341283
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<UpLoadAudioReq>(stream, this.oArg);
		}

		// Token: 0x0600E9AA RID: 59818 RVA: 0x00343093 File Offset: 0x00341293
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<UpLoadAudioRes>(stream);
		}

		// Token: 0x0600E9AB RID: 59819 RVA: 0x003430A2 File Offset: 0x003412A2
		public override void Process()
		{
			base.Process();
			Process_RpcC2T_UpLoadAudioToGate.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E9AC RID: 59820 RVA: 0x003430BE File Offset: 0x003412BE
		public override void OnTimeout(object args)
		{
			Process_RpcC2T_UpLoadAudioToGate.OnTimeout(this.oArg);
		}

		// Token: 0x0400651C RID: 25884
		public UpLoadAudioReq oArg = new UpLoadAudioReq();

		// Token: 0x0400651D RID: 25885
		public UpLoadAudioRes oRes = null;
	}
}
