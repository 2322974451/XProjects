using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014A8 RID: 5288
	internal class RpcC2G_PersonalCareer : Rpc
	{
		// Token: 0x0600E7AA RID: 59306 RVA: 0x00340568 File Offset: 0x0033E768
		public override uint GetRpcType()
		{
			return 64048U;
		}

		// Token: 0x0600E7AB RID: 59307 RVA: 0x0034057F File Offset: 0x0033E77F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PersonalCareerArg>(stream, this.oArg);
		}

		// Token: 0x0600E7AC RID: 59308 RVA: 0x0034058F File Offset: 0x0033E78F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<PersonalCareerRes>(stream);
		}

		// Token: 0x0600E7AD RID: 59309 RVA: 0x0034059E File Offset: 0x0033E79E
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_PersonalCareer.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E7AE RID: 59310 RVA: 0x003405BA File Offset: 0x0033E7BA
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_PersonalCareer.OnTimeout(this.oArg);
		}

		// Token: 0x040064B9 RID: 25785
		public PersonalCareerArg oArg = new PersonalCareerArg();

		// Token: 0x040064BA RID: 25786
		public PersonalCareerRes oRes = null;
	}
}
