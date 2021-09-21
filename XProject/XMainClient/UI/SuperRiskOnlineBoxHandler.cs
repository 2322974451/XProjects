using System;
using UILib;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001818 RID: 6168
	internal class SuperRiskOnlineBoxHandler : DlgHandlerBase
	{
		// Token: 0x0601000F RID: 65551 RVA: 0x003CB6A0 File Offset: 0x003C98A0
		protected override void Init()
		{
			this._doc = XSuperRiskDocument.Doc;
			this.m_CancleBtn = (base.PanelObject.transform.Find("no").GetComponent("XUIButton") as IXUIButton);
			this.m_BuyBtn = (base.PanelObject.transform.Find("Buy").GetComponent("XUIButton") as IXUIButton);
			this.m_CostLab = (base.PanelObject.transform.Find("Buy/Cost").GetComponent("XUILabel") as IXUILabel);
			this.m_CostIcon = (base.PanelObject.transform.Find("Buy/Cost/b").GetComponent("XUISprite") as IXUISprite);
			this.m_BoxTween = (base.PanelObject.transform.Find("Box").GetComponent("XUIPlayTween") as IXUITweenTool);
		}

		// Token: 0x06010010 RID: 65552 RVA: 0x003CB78B File Offset: 0x003C998B
		public override void RegisterEvent()
		{
			this.m_CancleBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCancleClick));
			this.m_BuyBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBuyClick));
			base.RegisterEvent();
		}

		// Token: 0x06010011 RID: 65553 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x06010012 RID: 65554 RVA: 0x003CB7C5 File Offset: 0x003C99C5
		protected override void OnShow()
		{
			this.FillContent();
			base.OnShow();
		}

		// Token: 0x06010013 RID: 65555 RVA: 0x003CB7D8 File Offset: 0x003C99D8
		private void FillContent()
		{
			bool flag = this._doc.OnlineBoxCost != null;
			if (flag)
			{
				this.m_CostLab.SetText(this._doc.OnlineBoxCost.itemCount.ToString());
				ItemList.RowData itemConf = XBagDocument.GetItemConf((int)this._doc.OnlineBoxCost.itemID);
				this.m_CostIcon.SetSprite(itemConf.ItemIcon1[0]);
			}
			XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/UI_Anim_DiceGame_OpenChest", true, AudioChannel.Action);
			this.m_BoxTween.SetTweenGroup(0);
			this.m_BoxTween.ResetTweenByGroup(true, 0);
			this.m_BoxTween.PlayTween(true, -1f);
		}

		// Token: 0x06010014 RID: 65556 RVA: 0x003CB888 File Offset: 0x003C9A88
		private bool OnCancleClick(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x06010015 RID: 65557 RVA: 0x003CB8A4 File Offset: 0x003C9AA4
		private bool OnBuyClick(IXUIButton btn)
		{
			bool flag = this._doc.OnlineBoxCost == null;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				ulong itemCount = XBagDocument.BagDoc.GetItemCount((int)this._doc.OnlineBoxCost.itemID);
				bool flag2 = (ulong)this._doc.OnlineBoxCost.itemCount > itemCount;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowItemAccess((int)this._doc.OnlineBoxCost.itemID, null);
					result = true;
				}
				else
				{
					this._doc.ReqBuyOnlineBox();
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0400718E RID: 29070
		private XSuperRiskDocument _doc;

		// Token: 0x0400718F RID: 29071
		private IXUITweenTool m_BoxTween;

		// Token: 0x04007190 RID: 29072
		private IXUIButton m_BuyBtn;

		// Token: 0x04007191 RID: 29073
		private IXUIButton m_CancleBtn;

		// Token: 0x04007192 RID: 29074
		private IXUILabel m_CostLab;

		// Token: 0x04007193 RID: 29075
		private IXUISprite m_CostIcon;
	}
}
