using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	public class XBossRewardDlg : XSingleton<XBossRewardDlg>
	{

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

		private string GetName(int index)
		{
			string str = this._Doc.dicRewardName[index];
			return XStringDefineProxy.GetString(str + "_TITLE");
		}

		private string GetLabel(int index)
		{
			string key = this._Doc.dicRewardName[index];
			return XStringDefineProxy.GetString(key);
		}

		private string GetDes(int index)
		{
			string key = this._Doc.dicRewardDes[index];
			return XStringDefineProxy.GetString(key);
		}

		public void RefreshGuildRoleRank()
		{
			this.m_WrapContent.SetContentCount(this._Doc.currentRewardList.Count, false);
			this.m_ScrollView.ResetPosition();
		}

		private bool OnCloseClick(IXUIButton button)
		{
			this.PanelObject.SetActive(false);
			return true;
		}

		private XGuildDragonDocument _Doc = null;

		private GameObject PanelObject;

		private IXUIButton m_lblClose;

		public IXUIScrollView m_ScrollView;

		private IXUIWrapContent m_WrapContent;
	}
}
