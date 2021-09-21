using System;

namespace XMainClient
{
	// Token: 0x02000D29 RID: 3369
	internal class XGuildLogJoin : XGuildLogBase
	{
		// Token: 0x0600BB32 RID: 47922 RVA: 0x002670D4 File Offset: 0x002652D4
		public XGuildLogJoin()
		{
			this.eType = GuildLogType.GLT_JOIN;
		}

		// Token: 0x0600BB33 RID: 47923 RVA: 0x002670E8 File Offset: 0x002652E8
		public override string GetContent()
		{
			return XLabelSymbolHelper.FormatName(this.name, this.uid, "00ffff") + XStringDefineProxy.GetString("GUILD_LOG_JOIN");
		}

		// Token: 0x0600BB34 RID: 47924 RVA: 0x0026711F File Offset: 0x0026531F
		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XGuildLogJoin>.Recycle(this);
		}
	}
}
