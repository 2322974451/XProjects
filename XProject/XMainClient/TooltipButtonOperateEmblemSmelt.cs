using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C97 RID: 3223
	internal class TooltipButtonOperateEmblemSmelt : TooltipButtonOperateBase
	{
		// Token: 0x0600B5FB RID: 46587 RVA: 0x002409E4 File Offset: 0x0023EBE4
		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("SMELT_REPLACE");
		}

		// Token: 0x0600B5FC RID: 46588 RVA: 0x00240A00 File Offset: 0x0023EC00
		public override bool IsButtonVisible(XItem item)
		{
			XEmblemItem xemblemItem = item as XEmblemItem;
			return !xemblemItem.bIsSkillEmblem && XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Emblem_Smelting) && (int)item.itemConf.ReqLevel >= XSingleton<XGlobalConfig>.singleton.GetInt("SmeltEmblemMinLevel") && xemblemItem.changeAttr.Count > 0;
		}

		// Token: 0x0600B5FD RID: 46589 RVA: 0x00240A5C File Offset: 0x0023EC5C
		public override bool HasRedPoint(XItem item)
		{
			return XSmeltDocument.Doc.IsHadRedDot(item);
		}

		// Token: 0x0600B5FE RID: 46590 RVA: 0x00240A79 File Offset: 0x0023EC79
		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			XSmeltDocument.Doc.SelectEquip(this.mainItemUID);
		}
	}
}
