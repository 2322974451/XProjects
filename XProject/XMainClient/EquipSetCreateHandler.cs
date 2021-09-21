using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CDA RID: 3290
	internal class EquipSetCreateHandler : DlgHandlerBase
	{
		// Token: 0x0600B876 RID: 47222 RVA: 0x00252500 File Offset: 0x00250700
		protected override void Init()
		{
			base.Init();
			this.mEquipCreateDoc = XEquipCreateDocument.Doc;
			Transform transform = base.PanelObject.transform.Find("Do");
			this.mBtnDo = (transform.GetComponent("XUIButton") as IXUIButton);
			transform = base.PanelObject.transform.Find("Text");
			this.mLbText = (transform.GetComponent("XUILabel") as IXUILabel);
			transform = base.PanelObject.transform.Find("Do/T");
			this.mLbBtnDo = (transform.GetComponent("XUILabel") as IXUILabel);
			this.mItemView = new EquipSetItemBaseView();
			this.mItemView.FindFrom(base.PanelObject.transform);
			transform = base.PanelObject.transform.Find("Making");
			this.mBarView = transform.gameObject;
			transform = base.PanelObject.transform.Find("Making/Bar");
			this.mSprBar = (transform.GetComponent("XUISprite") as IXUISprite);
			transform = base.PanelObject.transform.Find("Suc");
			this.mSuccessEffect = transform.gameObject;
			this.mBarFullWidth = this.mSprBar.spriteWidth;
		}

		// Token: 0x0600B877 RID: 47223 RVA: 0x00252647 File Offset: 0x00250847
		public override void RegisterEvent()
		{
			base.Init();
			this.mBtnDo.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickButtonOK));
		}

		// Token: 0x0600B878 RID: 47224 RVA: 0x0025266C File Offset: 0x0025086C
		public void SetEquipInfo(int _itemID)
		{
			bool flag = this.mItemView.goItem != null;
			if (flag)
			{
				this.mItemView.goItem.SetActive(false);
			}
		}

		// Token: 0x0600B879 RID: 47225 RVA: 0x002526A4 File Offset: 0x002508A4
		public void SetFinishEquipInfo(XItem item)
		{
			bool flag = this.mItemView.goItem != null;
			if (flag)
			{
				this.mItemView.goItem.SetActive(true);
			}
			bool flag2 = item != null && item.uid > 0UL && item.itemID > 0;
			if (flag2)
			{
				bool flag3 = base.IsVisible() && this.mItemView != null;
				if (flag3)
				{
					EquipSetItemBaseView.stEquipInfoParam param;
					param.isShowTooltip = false;
					param.playerProf = 0;
					this.mItemView.SetItemInfo(item, param, item.bBinding);
				}
				this.mItemView.SetFinishItem(item);
			}
		}

		// Token: 0x0600B87A RID: 47226 RVA: 0x00252743 File Offset: 0x00250943
		public void SetBar(int percent)
		{
			percent = Mathf.Clamp(percent, 1, 100);
			this.mSprBar.spriteWidth = this.mBarFullWidth * percent / 100;
		}

		// Token: 0x0600B87B RID: 47227 RVA: 0x00252768 File Offset: 0x00250968
		public void HideBtn()
		{
			this.mBtnDo.SetVisible(false);
		}

		// Token: 0x0600B87C RID: 47228 RVA: 0x00252778 File Offset: 0x00250978
		public void SetFinishState(bool bFinish)
		{
			this.mBarView.SetActive(!bFinish);
			this.mSuccessEffect.SetActive(bFinish);
			this.mBtnDo.SetVisible(true);
			if (bFinish)
			{
				this.HideEffect();
				XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/UI_Upgrade_Gear", true, AudioChannel.Action);
				this.mLbText.SetText(XStringDefineProxy.GetString("EQUIPCREATE_EQUIPSET_SUCCESS").Replace("{n}", "\n"));
				this.mLbBtnDo.SetText(XStringDefineProxy.GetString(XStringDefine.COMMON_OK));
				this.mBtnDo.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickButtonOK));
			}
			else
			{
				this.ShowEffect();
				this.mLbText.SetText(XStringDefineProxy.GetString("EQUIPCREATE_EQUIPSET_MAKING"));
				this.mLbBtnDo.SetText(XStringDefineProxy.GetString(XStringDefine.COMMON_CANCEL));
				this.mBtnDo.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickButtonCancel));
			}
		}

		// Token: 0x0600B87D RID: 47229 RVA: 0x0025286C File Offset: 0x00250A6C
		private void ShowEffect()
		{
			bool flag = this.m_creatFx == null;
			if (flag)
			{
				this.m_creatFx = XSingleton<XFxMgr>.singleton.CreateFx(this.CreatePath, null, true);
			}
			else
			{
				this.m_creatFx.SetActive(true);
			}
			this.m_creatFx.Play(base.PanelObject.transform.FindChild("Bg"), Vector3.zero, Vector3.one, 1f, true, false);
			XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/UI_datie", true, AudioChannel.Action);
		}

		// Token: 0x17003280 RID: 12928
		// (get) Token: 0x0600B87E RID: 47230 RVA: 0x002528F8 File Offset: 0x00250AF8
		public string CreatePath
		{
			get
			{
				bool flag = string.IsNullOrEmpty(this.m_createPath);
				if (flag)
				{
					this.m_createPath = XSingleton<XGlobalConfig>.singleton.GetValue("EquipCreatEffectPath");
				}
				return this.m_createPath;
			}
		}

		// Token: 0x0600B87F RID: 47231 RVA: 0x00252934 File Offset: 0x00250B34
		private void HideEffect()
		{
			bool flag = this.m_creatFx != null;
			if (flag)
			{
				this.m_creatFx.SetActive(false);
				this.m_creatFx.Stop();
			}
		}

		// Token: 0x0600B880 RID: 47232 RVA: 0x0025296C File Offset: 0x00250B6C
		private bool OnClickButtonOK(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x0600B881 RID: 47233 RVA: 0x00252988 File Offset: 0x00250B88
		private bool OnClickButtonCancel(IXUIButton btn)
		{
			bool isCreating = XEquipCreateDocument.Doc.IsCreating;
			bool result;
			if (isCreating)
			{
				result = true;
			}
			else
			{
				base.SetVisible(false);
				this.mEquipCreateDoc.CancelCreateEquip();
				result = true;
			}
			return result;
		}

		// Token: 0x0600B882 RID: 47234 RVA: 0x0019F00C File Offset: 0x0019D20C
		protected override void OnShow()
		{
			base.OnShow();
		}

		// Token: 0x0600B883 RID: 47235 RVA: 0x002529C4 File Offset: 0x00250BC4
		protected override void OnHide()
		{
			base.OnHide();
			this.HideEffect();
			bool flag = null != this.mSuccessEffect;
			if (flag)
			{
				this.mSuccessEffect.SetActive(false);
			}
			base.PanelObject.SetActive(false);
		}

		// Token: 0x0600B884 RID: 47236 RVA: 0x00252A0C File Offset: 0x00250C0C
		public override void OnUnload()
		{
			this.mEquipCreateDoc = null;
			bool flag = this.m_creatFx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_creatFx, true);
				this.m_creatFx = null;
			}
			this.mSuccessEffect = null;
			base.OnUnload();
		}

		// Token: 0x04004901 RID: 18689
		private IXUIButton mBtnDo;

		// Token: 0x04004902 RID: 18690
		private IXUILabel mLbBtnDo;

		// Token: 0x04004903 RID: 18691
		private IXUILabel mLbText;

		// Token: 0x04004904 RID: 18692
		private IXUISprite mSprBar;

		// Token: 0x04004905 RID: 18693
		private EquipSetItemBaseView mItemView;

		// Token: 0x04004906 RID: 18694
		private GameObject mBarView;

		// Token: 0x04004907 RID: 18695
		private GameObject mSuccessEffect;

		// Token: 0x04004908 RID: 18696
		private int mBarFullWidth;

		// Token: 0x04004909 RID: 18697
		private XEquipCreateDocument mEquipCreateDoc;

		// Token: 0x0400490A RID: 18698
		private XFx m_creatFx = null;

		// Token: 0x0400490B RID: 18699
		private string m_createPath = string.Empty;
	}
}
