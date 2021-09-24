using System;

namespace XMainClient
{

	internal class XGuildLogLeave : XGuildLogBase
	{

		public XGuildLogLeave()
		{
			this.eType = GuildLogType.GLT_LEAVE;
		}

		public override string GetContent()
		{
			return XLabelSymbolHelper.FormatName(this.name, this.uid, "00ffff") + XStringDefineProxy.GetString("GUILD_LOG_LEAVE");
		}

		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XGuildLogLeave>.Recycle(this);
		}
	}
}
