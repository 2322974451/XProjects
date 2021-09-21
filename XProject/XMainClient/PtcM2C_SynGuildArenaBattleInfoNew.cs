using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001271 RID: 4721
	internal class PtcM2C_SynGuildArenaBattleInfoNew : Protocol
	{
		// Token: 0x0600DE9F RID: 56991 RVA: 0x003337B4 File Offset: 0x003319B4
		public override uint GetProtoType()
		{
			return 3680U;
		}

		// Token: 0x0600DEA0 RID: 56992 RVA: 0x003337CB File Offset: 0x003319CB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SynGuildArenaBattleInfo>(stream, this.Data);
		}

		// Token: 0x0600DEA1 RID: 56993 RVA: 0x003337DB File Offset: 0x003319DB
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SynGuildArenaBattleInfo>(stream);
		}

		// Token: 0x0600DEA2 RID: 56994 RVA: 0x003337EA File Offset: 0x003319EA
		public override void Process()
		{
			Process_PtcM2C_SynGuildArenaBattleInfoNew.Process(this);
		}

		// Token: 0x04006300 RID: 25344
		public SynGuildArenaBattleInfo Data = new SynGuildArenaBattleInfo();
	}
}
