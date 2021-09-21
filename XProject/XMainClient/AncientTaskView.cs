using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C55 RID: 3157
	internal class AncientTaskView : DlgBase<AncientTaskView, AnicentTaskBhaviour>
	{
		// Token: 0x1700319E RID: 12702
		// (get) Token: 0x0600B2FC RID: 45820 RVA: 0x0022B958 File Offset: 0x00229B58
		public override string fileName
		{
			get
			{
				return "OperatingActivity/AncientTask";
			}
		}

		// Token: 0x1700319F RID: 12703
		// (get) Token: 0x0600B2FD RID: 45821 RVA: 0x0022B970 File Offset: 0x00229B70
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170031A0 RID: 12704
		// (get) Token: 0x0600B2FE RID: 45822 RVA: 0x0022B984 File Offset: 0x00229B84
		public override bool hideMainMenu
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170031A1 RID: 12705
		// (get) Token: 0x0600B2FF RID: 45823 RVA: 0x0022B998 File Offset: 0x00229B98
		public override bool pushstack
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170031A2 RID: 12706
		// (get) Token: 0x0600B300 RID: 45824 RVA: 0x0022B9AC File Offset: 0x00229BAC
		public override bool fullscreenui
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600B301 RID: 45825 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void Init()
		{
		}

		// Token: 0x0600B302 RID: 45826 RVA: 0x0022B9BF File Offset: 0x00229BBF
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_btnClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBtnClose));
		}

		// Token: 0x0600B303 RID: 45827 RVA: 0x0022B9E8 File Offset: 0x00229BE8
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

		// Token: 0x0600B304 RID: 45828 RVA: 0x0022BB74 File Offset: 0x00229D74
		private bool OnBtnClose(IXUIButton brn)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600B305 RID: 45829 RVA: 0x0022BB90 File Offset: 0x00229D90
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

		// Token: 0x0600B306 RID: 45830 RVA: 0x0022BC07 File Offset: 0x00229E07
		private void RefreshContent(AncientTask.RowData row)
		{
			this.m_uiBehaviour.m_time.SetText(row.time);
			base.uiBehaviour.m_content.SetText(row.content);
		}

		// Token: 0x0600B307 RID: 45831 RVA: 0x0022BC38 File Offset: 0x00229E38
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
