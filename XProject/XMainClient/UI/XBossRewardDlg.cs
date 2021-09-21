using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001839 RID: 6201
	public class XBossRewardDlg : XSingleton<XBossRewardDlg>
	{
		// Token: 0x060101BC RID: 65980 RVA: 0x003D96E0 File Offset: 0x003D78E0
		public void Init(GameObject _go)
		{
			bool flag = this.PanelObject == null || this.PanelObject != _go;
			if (flag)
			{
				this.PanelObject = _go;
				this._Doc = XDocuments.GetSpecificDocument<XGuildDragonDocument>(XGuildDragonDocument.uuID);
				this.m_lblClose = (_go.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
				this.m_lblClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
				this.m_ScrollView = (_go.transform.FindChild("Bg/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
				this.m_WrapContent = (_go.transform.FindChild("Bg/ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
				this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.GuildRankWrapContentItemUpdated));
			}
			this.RefreshGuildRoleRank();
		}

		// Token: 0x060101BD RID: 65981 RVA: 0x003D97D4 File Offset: 0x003D79D4
		private void GuildRankWrapContentItemUpdated(Transform t, int index)
		{
			List<Seq2<uint>> currentRewardList = this._Doc.currentRewardList;
			bool flag = index < 0 || index >= currentRewardList.Count;
			if (!flag)
			{
				Seq2<uint> seq = currentRewardList[index];
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(t.FindChild("ItemTpl").gameObject, (int)seq.value0, (int)seq.value1, false);
				IXUISprite ixuisprite = t.FindChild("ItemTpl/Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)seq.value0;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
				IXUILabel ixuilabel = t.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(this.GetName(index));
				IXUILabel ixuilabel2 = t.FindChild("Des").GetComponent("XUILabel") as IXUILabel;
				ixuilabel2.SetText(this.GetDes(index));
				IXUILabel ixuilabel3 = t.FindChild("ItemTpl/ssssss").GetComponent("XUILabel") as IXUILabel;
				ixuilabel3.SetText(this.GetLabel(index));
			}
		}

		// Token: 0x060101BE RID: 65982 RVA: 0x003D9900 File Offset: 0x003D7B00
		private string GetName(int index)
		{
			string str = this._Doc.dicRewardName[index];
			return XStringDefineProxy.GetString(str + "_TITLE");
		}

		// Token: 0x060101BF RID: 65983 RVA: 0x003D9934 File Offset: 0x003D7B34
		private string GetLabel(int index)
		{
			string key = this._Doc.dicRewardName[index];
			return XStringDefineProxy.GetString(key);
		}

		// Token: 0x060101C0 RID: 65984 RVA: 0x003D9960 File Offset: 0x003D7B60
		private string GetDes(int index)
		{
			string key = this._Doc.dicRewardDes[index];
			return XStringDefineProxy.GetString(key);
		}

		// Token: 0x060101C1 RID: 65985 RVA: 0x003D998A File Offset: 0x003D7B8A
		public void RefreshGuildRoleRank()
		{
			this.m_WrapContent.SetContentCount(this._Doc.currentRewardList.Count, false);
			this.m_ScrollView.ResetPosition();
		}

		// Token: 0x060101C2 RID: 65986 RVA: 0x003D99B8 File Offset: 0x003D7BB8
		private bool OnCloseClick(IXUIButton button)
		{
			this.PanelObject.SetActive(false);
			return true;
		}

		// Token: 0x040072D6 RID: 29398
		private XGuildDragonDocument _Doc = null;

		// Token: 0x040072D7 RID: 29399
		private GameObject PanelObject;

		// Token: 0x040072D8 RID: 29400
		private IXUIButton m_lblClose;

		// Token: 0x040072D9 RID: 29401
		public IXUIScrollView m_ScrollView;

		// Token: 0x040072DA RID: 29402
		private IXUIWrapContent m_WrapContent;
	}
}
