using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class TooltipButtonOperateEmblemSmelt : TooltipButtonOperateBase
	{

		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("SMELT_REPLACE");
		}

		public override bool IsButtonVisible(XItem item)
		{
			XEmblemItem xemblemItem = item as XEmblemItem;
			return !xemblemItem.bIsSkillEmblem && XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Emblem_Smelting) && (int)item.itemConf.ReqLevel >= XSingleton<XGlobalConfig>.singleton.GetInt("SmeltEmblemMinLevel") && xemblemItem.changeAttr.Count > 0;
		}

		public override bool HasRedPoint(XItem item)
		{
			return XSmeltDocument.Doc.IsHadRedDot(item);
		}

		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			XSmeltDocument.Doc.SelectEquip(this.mainItemUID);
		}
	}
}
