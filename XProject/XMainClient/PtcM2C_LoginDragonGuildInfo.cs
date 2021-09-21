using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001626 RID: 5670
	internal class PtcM2C_LoginDragonGuildInfo : Protocol
	{
		// Token: 0x0600EDD5 RID: 60885 RVA: 0x00348E80 File Offset: 0x00347080
		public override uint GetProtoType()
		{
			return 21856U;
		}

		// Token: 0x0600EDD6 RID: 60886 RVA: 0x00348E97 File Offset: 0x00347097
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MyDragonGuild>(stream, this.Data);
		}

		// Token: 0x0600EDD7 RID: 60887 RVA: 0x00348EA7 File Offset: 0x003470A7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<MyDragonGuild>(stream);
		}

		// Token: 0x0600EDD8 RID: 60888 RVA: 0x00348EB6 File Offset: 0x003470B6
		public override void Process()
		{
			Process_PtcM2C_LoginDragonGuildInfo.Process(this);
		}

		// Token: 0x040065F3 RID: 26099
		public MyDragonGuild Data = new MyDragonGuild();
	}
}
