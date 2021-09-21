using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001433 RID: 5171
	internal class RpcC2A_AudioText : Rpc
	{
		// Token: 0x0600E5D4 RID: 58836 RVA: 0x0033D7D4 File Offset: 0x0033B9D4
		public override uint GetRpcType()
		{
			return 42254U;
		}

		// Token: 0x0600E5D5 RID: 58837 RVA: 0x0033D7EB File Offset: 0x0033B9EB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AudioTextArg>(stream, this.oArg);
		}

		// Token: 0x0600E5D6 RID: 58838 RVA: 0x0033D7FB File Offset: 0x0033B9FB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AudioTextRes>(stream);
		}

		// Token: 0x0600E5D7 RID: 58839 RVA: 0x0033D80A File Offset: 0x0033BA0A
		public override void Process()
		{
			base.Process();
			Process_RpcC2A_AudioText.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E5D8 RID: 58840 RVA: 0x0033D826 File Offset: 0x0033BA26
		public override void OnTimeout(object args)
		{
			Process_RpcC2A_AudioText.OnTimeout(this.oArg);
		}

		// Token: 0x04006463 RID: 25699
		public AudioTextArg oArg = new AudioTextArg();

		// Token: 0x04006464 RID: 25700
		public AudioTextRes oRes = null;
	}
}
