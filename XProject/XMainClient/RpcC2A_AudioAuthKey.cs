using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001431 RID: 5169
	internal class RpcC2A_AudioAuthKey : Rpc
	{
		// Token: 0x0600E5CB RID: 58827 RVA: 0x0033D6D0 File Offset: 0x0033B8D0
		public override uint GetRpcType()
		{
			return 19391U;
		}

		// Token: 0x0600E5CC RID: 58828 RVA: 0x0033D6E7 File Offset: 0x0033B8E7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AudioAuthKeyArg>(stream, this.oArg);
		}

		// Token: 0x0600E5CD RID: 58829 RVA: 0x0033D6F7 File Offset: 0x0033B8F7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AudioAuthKeyRes>(stream);
		}

		// Token: 0x0600E5CE RID: 58830 RVA: 0x0033D706 File Offset: 0x0033B906
		public override void Process()
		{
			base.Process();
			Process_RpcC2A_AudioAuthKey.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E5CF RID: 58831 RVA: 0x0033D722 File Offset: 0x0033B922
		public override void OnTimeout(object args)
		{
			Process_RpcC2A_AudioAuthKey.OnTimeout(this.oArg);
		}

		// Token: 0x04006461 RID: 25697
		public AudioAuthKeyArg oArg = new AudioAuthKeyArg();

		// Token: 0x04006462 RID: 25698
		public AudioAuthKeyRes oRes = null;
	}
}
