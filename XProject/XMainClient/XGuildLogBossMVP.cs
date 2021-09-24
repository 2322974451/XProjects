using System;

namespace XMainClient
{

	internal class XGuildLogBossMVP : XGuildLogBase
	{

		public XGuildLogBossMVP()
		{
			this.eType = GuildLogType.GLT_MVP;
		}

		public override string GetContent()
		{
			return XLabelSymbolHelper.FormatName(this.name, this.uid, "00ffff") + XStringDefineProxy.GetString("GUILD_LOG_MVP");
		}

		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XGuildLogBossMVP>.Recycle(this);
		}
	}
}
