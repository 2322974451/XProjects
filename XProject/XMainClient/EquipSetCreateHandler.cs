using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class EquipSetCreateHandler : DlgHandlerBase
	{

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

		public override void RegisterEvent()
		{
			base.Init();
			this.mBtnDo.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickButtonOK));
		}

		public void SetEquipInfo(int _itemID)
		{
			bool flag = this.mItemView.goItem != null;
			if (flag)
			{
				this.mItemView.goItem.SetActive(false);
			}
		}

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

		public void SetBar(int percent)
		{
			percent = Mathf.Clamp(percent, 1, 100);
			this.mSprBar.spriteWidth = this.mBarFullWidth * percent / 100;
		}

		public void HideBtn()
		{
			this.mBtnDo.SetVisible(false);
		}

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

		private void HideEffect()
		{
			bool flag = this.m_creatFx != null;
			if (flag)
			{
				this.m_creatFx.SetActive(false);
				this.m_creatFx.Stop();
			}
		}

		private bool OnClickButtonOK(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

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

		protected override void OnShow()
		{
			base.OnShow();
		}

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

		private IXUIButton mBtnDo;

		private IXUILabel mLbBtnDo;

		private IXUILabel mLbText;

		private IXUISprite mSprBar;

		private EquipSetItemBaseView mItemView;

		private GameObject mBarView;

		private GameObject mSuccessEffect;

		private int mBarFullWidth;

		private XEquipCreateDocument mEquipCreateDoc;

		private XFx m_creatFx = null;

		private string m_createPath = string.Empty;
	}
}
