using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AncientTaskView : DlgBase<AncientTaskView, AnicentTaskBhaviour>
	{

		public override string fileName
		{
			get
			{
				return "OperatingActivity/AncientTask";
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return false;
			}
		}

		public override bool pushstack
		{
			get
			{
				return false;
			}
		}

		public override bool fullscreenui
		{
			get
			{
				return false;
			}
		}

		protected override void Init()
		{
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_btnClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBtnClose));
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_tabpool.ReturnAll(false);
			int i = 0;
			int num = XAncientDocument.ancientTask.Table.Length;
			while (i < num)
			{
				GameObject gameObject = base.uiBehaviour.m_tabpool.FetchGameObject(false);
				XSingleton<UiUtility>.singleton.AddChild(base.uiBehaviour.boxTpl.transform.parent.gameObject, gameObject);
				gameObject.transform.localPosition = base.uiBehaviour.boxTpl.transform.localPosition - new Vector3(0f, (float)(base.uiBehaviour.m_tabpool.TplHeight * i));
				IXUICheckBox ixuicheckBox = gameObject.transform.GetComponent("XUICheckBox") as IXUICheckBox;
				ixuicheckBox.ID = (ulong)XAncientDocument.ancientTask.Table[i].ID;
				ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTabClick));
				ixuicheckBox.ForceSetFlag(i == 0);
				IXUILabel ixuilabel = gameObject.transform.Find("t1").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = gameObject.transform.Find("selected/t2").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(XAncientDocument.ancientTask.Table[i].title);
				ixuilabel2.SetText(XAncientDocument.ancientTask.Table[i].title);
				i++;
			}
		}

		private bool OnBtnClose(IXUIButton brn)
		{
			this.SetVisible(false, true);
			return true;
		}

		private bool OnTabClick(IXUICheckBox box)
		{
			bool bChecked = box.bChecked;
			if (bChecked)
			{
				int i = 0;
				int num = XAncientDocument.ancientTask.Table.Length;
				while (i < num)
				{
					AncientTask.RowData rowData = XAncientDocument.ancientTask.Table[i];
					bool flag = rowData.ID == (uint)box.ID;
					if (flag)
					{
						this.RefreshContent(rowData);
						this.RefreshRwd(rowData);
						break;
					}
					i++;
				}
			}
			return true;
		}

		private void RefreshContent(AncientTask.RowData row)
		{
			this.m_uiBehaviour.m_time.SetText(row.time);
			base.uiBehaviour.m_content.SetText(row.content);
		}

		private void RefreshRwd(AncientTask.RowData row)
		{
			base.uiBehaviour.m_rwdpool.ReturnAll(false);
			int i = 0;
			int count = (int)row.rewards.count;
			while (i < count)
			{
				GameObject gameObject = base.uiBehaviour.m_rwdpool.FetchGameObject(false);
				XSingleton<UiUtility>.singleton.AddChild(base.uiBehaviour.itemTpl.transform.parent.gameObject, gameObject);
				gameObject.transform.localPosition = base.uiBehaviour.itemTpl.transform.localPosition + new Vector3((float)(base.uiBehaviour.m_rwdpool.TplWidth * i), 0f);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)row.rewards[i, 0], (int)row.rewards[i, 1], false);
				IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)row.rewards[i, 0];
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
				i++;
			}
		}
	}
}
