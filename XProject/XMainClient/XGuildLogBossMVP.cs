using System;

namespace XMainClient
{
	// Token: 0x02000D2C RID: 3372
	internal class XGuildLogBossMVP : XGuildLogBase
	{
		// Token: 0x0600BB3C RID: 47932 RVA: 0x00267210 File Offset: 0x00265410
		public XGuildLogBossMVP()
		{
			this.eType = GuildLogType.GLT_MVP;
		}

		// Token: 0x0600BB3D RID: 47933 RVA: 0x00267224 File Offset: 0x00265424
		public override string GetContent()
		{
			return XLabelSymbolHelper.FormatName(this.name, this.uid, "00ffff") + XStringDefineProxy.GetString("GUILD_LOG_MVP");
		}

		// Token: 0x0600BB3E RID: 47934 RVA: 0x0026725B File Offset: 0x0026545B
		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XGuildLogBossMVP>.Recycle(this);
		}
	}
}
