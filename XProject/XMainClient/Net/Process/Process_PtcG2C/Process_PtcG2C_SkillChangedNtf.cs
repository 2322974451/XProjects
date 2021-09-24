using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_SkillChangedNtf
	{

		public static void Process(PtcG2C_SkillChangedNtf roPtc)
		{
			XPlayerAttributes xplayerData = XSingleton<XAttributeMgr>.singleton.XPlayerData;
			for (int i = 0; i < roPtc.Data.newSkill.Count; i++)
			{
				xplayerData.SkillLevelInfo.SetSkillLevel(roPtc.Data.newSkill[i], roPtc.Data.newSkillLevel[i]);
			}
			for (int i = 0; i < roPtc.Data.changedSkillHash.Count; i++)
			{
				xplayerData.SkillLevelInfo.SetSkillLevel(roPtc.Data.changedSkillHash[i], roPtc.Data.changedSkillLevel[i]);
			}
			for (int i = 0; i < roPtc.Data.removeSkill.Count; i++)
			{
				xplayerData.SkillLevelInfo.RemoveSkill(roPtc.Data.removeSkill[i]);
			}
			xplayerData.SkillLevelInfo.RefreshSkillFlags();
			xplayerData.SkillLevelInfo.RefreshSelfLinkedLevels(XSingleton<XEntityMgr>.singleton.Player);
			bool flag = roPtc.Data.skillType == 0;
			if (flag)
			{
				bool flag2 = XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillPageIndex == 0U;
				if (flag2)
				{
					XSingleton<XGame>.singleton.Doc.XBagDoc.SetVirtualItemCount(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.SKILL_POINT), (ulong)((long)roPtc.Data.skillpoint));
					XSingleton<XGame>.singleton.Doc.XBagDoc.SetVirtualItemCount(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.SKILL_POINT_TWO), (ulong)roPtc.Data.skillpointtwo);
					XSingleton<XGame>.singleton.Doc.XBagDoc.SetVirtualItemCount(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.AWAKE_SKILL_POINT), (ulong)roPtc.Data.awakepoint);
					XSingleton<XGame>.singleton.Doc.XBagDoc.SetVirtualItemCount(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.AWAKE_SKILL_POINT_TWO), (ulong)roPtc.Data.awakepointtwo);
				}
				else
				{
					XSingleton<XGame>.singleton.Doc.XBagDoc.SetVirtualItemCount(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.SKILL_POINT_TWO), (ulong)((long)roPtc.Data.skillpoint));
					XSingleton<XGame>.singleton.Doc.XBagDoc.SetVirtualItemCount(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.SKILL_POINT), (ulong)roPtc.Data.skillpointtwo);
					XSingleton<XGame>.singleton.Doc.XBagDoc.SetVirtualItemCount(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.AWAKE_SKILL_POINT), (ulong)roPtc.Data.awakepointtwo);
					XSingleton<XGame>.singleton.Doc.XBagDoc.SetVirtualItemCount(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.AWAKE_SKILL_POINT_TWO), (ulong)roPtc.Data.awakepoint);
				}
			}
			else
			{
				bool flag3 = roPtc.Data.skillType == 1;
				if (flag3)
				{
					XSingleton<XGame>.singleton.Doc.XBagDoc.SetVirtualItemCount(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.GUILD_CONTRIBUTE), (ulong)((long)roPtc.Data.skillpoint));
				}
			}
			XSkillTreeDocument specificDocument = XDocuments.GetSpecificDocument<XSkillTreeDocument>(XSkillTreeDocument.uuID);
			bool flag4 = roPtc.Data.skillSlot != null && roPtc.Data.skillSlot.Count > 0;
			if (flag4)
			{
				List<int> list = new List<int>();
				for (int i = 0; i < roPtc.Data.skillSlot.Count; i++)
				{
					bool flag5 = roPtc.Data.skillSlot[i] == 0U && xplayerData.skillSlot[i] > 0U;
					if (flag5)
					{
						list.Add(i);
					}
				}
				specificDocument.ShowEmblemTips(list);
			}
			for (int i = 0; i < roPtc.Data.skillSlot.Count; i++)
			{
				xplayerData.skillSlot[i] = roPtc.Data.skillSlot[i];
			}
			bool flag6 = roPtc.Data.skillSlot != null && roPtc.Data.skillSlot.Count > 0;
			if (flag6)
			{
				XEmblemDocument specificDocument2 = XDocuments.GetSpecificDocument<XEmblemDocument>(XEmblemDocument.uuID);
				specificDocument2.UpdateRedPoints();
			}
			specificDocument.SkillRefresh(false, false);
			XSingleton<XTutorialHelper>.singleton.SkillLevelup = true;
		}
	}
}
