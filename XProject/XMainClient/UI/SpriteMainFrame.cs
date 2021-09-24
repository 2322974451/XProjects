using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class SpriteMainFrame : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/SpriteSystem/SpriteMainFrame";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
			this._feedInterval = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("SpriteFeedIntervalTime"));
			this._feedStart = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("SpriteFeedStartTime"));
			this.m_AwakeBtn = (base.PanelObject.transform.Find("Other/AwakeBtn").GetComponent("XUISprite") as IXUISprite);
			this.m_StarUpBtn = (base.PanelObject.transform.Find("Other/StarUpBtn").GetComponent("XUISprite") as IXUISprite);
			this.m_FeedGo = base.PanelObject.transform.Find("Other/FeedBtn").gameObject;
			this.m_FeedBtnRedPoint = this.m_FeedGo.transform.Find("RedPoint").gameObject;
			this.m_FoodList = base.PanelObject.transform.Find("Other/FoodList").gameObject;
			this.m_Exp = (base.PanelObject.transform.Find("Other/Exp/ProgressBar").GetComponent("XUIProgress") as IXUIProgress);
			this.m_ExpNum = (base.PanelObject.transform.Find("Other/Exp/Progress").GetComponent("XUILabel") as IXUILabel);
			this.m_Level = (base.PanelObject.transform.Find("Other/Level").GetComponent("XUILabel") as IXUILabel);
			this.m_EffectParent = base.PanelObject.transform.Find("Other/FeedEffect");
			Transform transform = base.PanelObject.transform.Find("Other/FoodList/ItemTpl");
			this.m_FoodPool.SetupPool(transform.parent.gameObject, transform.gameObject, 3U, false);
			IXUICheckBox ixuicheckBox = this.m_FeedGo.GetComponent("XUICheckBox") as IXUICheckBox;
			ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnFeedBtnClick));
			Vector3 tplPos = this.m_FoodPool.TplPos;
			this.m_FoodNum = new IXUILabel[(int)this._doc.FoodList.Count];
			for (int i = 0; i < (int)this._doc.FoodList.Count; i++)
			{
				GameObject gameObject = this.m_FoodPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3(tplPos.x, tplPos.y + (float)(((int)this._doc.FoodList.Count - i - 1) * this.m_FoodPool.TplHeight));
				IXUISprite ixuisprite = gameObject.GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)((long)i);
				ixuisprite.RegisterSpritePressEventHandler(new SpritePressEventHandler(this.OnFoodBtnPress));
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, this._doc.FoodList[i, 0], 2, false);
				this.m_FoodNum[i] = (ixuisprite.gameObject.transform.Find("Num").GetComponent("XUILabel") as IXUILabel);
			}
			DlgHandlerBase.EnsureCreate<XSpriteAttributeHandler>(ref this._SpritePropertyHandler, base.PanelObject.transform.Find("PropertyHandlerParent"), true, this);
			DlgHandlerBase.EnsureCreate<XSpriteAvatarHandler>(ref this._SpriteAvatarHandler, base.PanelObject.transform.Find("AvatarHandlerParent"), true, this);
			DlgHandlerBase.EnsureCreate<SpriteSelectHandler>(ref this._SpriteSelectHandler, base.PanelObject.transform.Find("SelectHandlerParent"), false, this);
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._SpriteAvatarHandler.SetVisible(true);
			this._SpriteAvatarHandler.HideAvatar();
			this.m_Exp.value = 0f;
			this.m_ExpNum.SetText("0/0");
			this.m_Level.SetText("Lv.0");
			this.CurrentClick = 10000;
			this._SpriteSelectHandler.SetVisible(true);
			this._SpritePropertyHandler.SetSpriteAttributeInfo((this.CurrentClick < this._doc.SpriteList.Count) ? this._doc.SpriteList[this.CurrentClick] : null, XSingleton<XAttributeMgr>.singleton.XPlayerData, null);
			XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			this.RefreshFoodNum();
			this.RefreshAwakeBtn();
		}

		private void CheckLastAwakeFinished()
		{
			bool flag = this._doc._AwakeSpriteData != null;
			if (flag)
			{
				for (int i = 0; i < this._doc.SpriteList.Count; i++)
				{
					bool flag2 = this._doc.SpriteList[i].uid == this._doc._AwakeSpriteData.uid;
					if (flag2)
					{
						DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton.OpenWindows(SpriteWindow.Awake);
						DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._AwakeWindow.SetSpritesInfo(this._doc.SpriteList[i], this._doc._AwakeSpriteData);
						this._doc._AwakeSpriteData = null;
						break;
					}
				}
			}
		}

		protected override void OnHide()
		{
			base.OnHide();
			this._SpriteSelectHandler.SetVisible(false);
			this._SpriteAvatarHandler.SetVisible(false);
			this.CurrentClick = 10000;
			for (int i = 0; i < 3; i++)
			{
				this._feedState[i] = false;
			}
			bool flag = this._fxFirework != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this._fxFirework, true);
				this._fxFirework = null;
			}
			this.AnimEnd = true;
		}

		public override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<SpriteSelectHandler>(ref this._SpriteSelectHandler);
			DlgHandlerBase.EnsureUnload<XSpriteAttributeHandler>(ref this._SpritePropertyHandler);
			DlgHandlerBase.EnsureUnload<XSpriteAvatarHandler>(ref this._SpriteAvatarHandler);
			bool flag = this._fxFirework != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this._fxFirework, true);
				this._fxFirework = null;
			}
			base.OnUnload();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_StarUpBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnStarUpBtnClick));
			this.m_AwakeBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnAwakeBtnClick));
		}

		private void LevelUp()
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SpriteLevelUpTips"), "fece00");
		}

		private void RefreshFoodNum()
		{
			for (int i = 0; i < (int)this._doc.FoodList.Count; i++)
			{
				this.m_FoodNum[i].SetText(XBagDocument.BagDoc.GetItemCount(this._doc.FoodList[i, 0]).ToString());
			}
			this.RefreshFeedBtnRedPoint();
		}

		private void RefreshFeedBtnRedPoint()
		{
			this.m_FeedBtnRedPoint.SetActive(!this._doc.isSpriteFoodEmpty() && this.CurrentClick != 10000 && this._doc.isSpriteFight(this._doc.SpriteList[this.CurrentClick].uid) && this._doc.isSpriteNeed2Feed(this._doc.SpriteList[this.CurrentClick].uid, false));
		}

		public void OnStarUpBtnClick(IXUISprite btn)
		{
			bool flag = this.CurrentClick == 10000;
			if (!flag)
			{
				DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton.OpenWindows(SpriteWindow.StarUp);
			}
		}

		public bool OnFeedBtnClick(IXUICheckBox icb)
		{
			this.m_FoodList.SetActive(icb.bChecked);
			return true;
		}

		public void RefreshAwakeBtn()
		{
		}

		private bool AwakeItemEnough(ref uint consumeCount)
		{
			bool flag = this.CurrentClick > this._doc.SpriteList.Count;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				ulong itemCount = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemCount(XSingleton<XGlobalConfig>.singleton.GetInt("SpriteAwakeItemID"));
				uint spriteQuality = this._doc._SpriteTable.GetBySpriteID(this._doc.SpriteList[this.CurrentClick].SpriteID).SpriteQuality;
				List<string> stringList = XSingleton<XGlobalConfig>.singleton.GetStringList("SpriteAwakeConsume");
				bool flag2 = (ulong)spriteQuality >= (ulong)((long)stringList.Count);
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Sprite Quality Error", null, null, null, null, null);
					result = false;
				}
				else
				{
					consumeCount = uint.Parse(stringList[(int)spriteQuality]);
					bool flag3 = itemCount < (ulong)consumeCount;
					result = !flag3;
				}
			}
			return result;
		}

		public void OnAwakeBtnClick(IXUISprite btn)
		{
			bool flag = this.CurrentClick >= this._doc.SpriteList.Count;
			if (!flag)
			{
				int @int = XSingleton<XGlobalConfig>.singleton.GetInt("SpriteAwakeMinLevel");
				bool flag2 = (ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level < (ulong)((long)@int);
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("SpriteAwakeLevelLimit"), @int), "fece00");
				}
				else
				{
					uint num = 0U;
					bool flag3 = !this.AwakeItemEnough(ref num);
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SpriteAwake_Error", new object[]
						{
							num
						}), "fece00");
						XSingleton<UiUtility>.singleton.ShowItemAccess(XSingleton<XGlobalConfig>.singleton.GetInt("SpriteAwakeItemID"), null);
					}
					else
					{
						bool tempTip = DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.GetTempTip(XTempTipDefine.OD_SPRITE_AWAKE);
						if (tempTip)
						{
							this._doc.ReqSpriteOperation(SpriteType.Sprite_Awake);
						}
						else
						{
							string mainLabel = string.Format("{0}\n{1}\n{2}", XStringDefineProxy.GetString("SpriteAwake_Title"), XStringDefineProxy.GetString("SpriteAwake_Tip"), XStringDefineProxy.GetString("SpriteAwake_Consume", new object[]
							{
								XLabelSymbolHelper.FormatSmallIcon(XSingleton<XGlobalConfig>.singleton.GetInt("SpriteAwakeItemID")),
								num
							}));
							string @string = XStringDefineProxy.GetString("COMMON_OK");
							string string2 = XStringDefineProxy.GetString("COMMON_CANCEL");
							DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(true, true);
							DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetSingleButtonMode(false);
							DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.ShowNoTip(XTempTipDefine.OD_SPRITE_AWAKE);
							DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetLabelsWithSymbols(mainLabel, @string, string2);
							DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetModalCallback(new ButtonClickEventHandler(this.OnEnsureAwakeClick), null);
						}
					}
				}
			}
		}

		private bool OnEnsureAwakeClick(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			this._doc.ReqSpriteOperation(SpriteType.Sprite_Awake);
			return true;
		}

		public void OnServerReturn(ulong uid)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				SpriteInfo spriteInfo = this._doc.SpriteList[this.CurrentClick];
				bool flag2 = uid != spriteInfo.uid;
				if (!flag2)
				{
					this.AnimEnd = false;
					this._animLevelTarget = (int)spriteInfo.Level;
					uint spriteLevelUpExp = this._doc.GetSpriteLevelUpExp(this.CurrentClick);
					this._AnimExpTarget = spriteInfo.Exp * 1f / spriteLevelUpExp;
					this.RefreshFoodNum();
					bool flag3 = this._doc.isSpriteFoodEmpty();
					if (flag3)
					{
						this._SpriteSelectHandler.SetSpriteList(this._doc.SpriteList, false);
					}
					bool flag4 = Time.time - this._lastEffectTime > 3f;
					if (flag4)
					{
						this._lastEffectTime = Time.time;
						bool flag5 = this._fxFirework != null;
						if (flag5)
						{
							XSingleton<XFxMgr>.singleton.DestroyFx(this._fxFirework, true);
						}
						this._fxFirework = XSingleton<XFxMgr>.singleton.CreateAndPlay("Effects/FX_Particle/UIfx/UI_jl_weiyang", this.m_EffectParent, Vector3.zero, Vector3.one, 1f, true, 2f, true);
					}
				}
			}
		}

		public void SetAvatar()
		{
			this._SpriteAvatarHandler.SetSpriteInfoByIndex(this.CurrentClick, 0, false, false);
		}

		private void SetExp()
		{
			SpriteInfo spriteInfo = this._doc.SpriteList[this.CurrentClick];
			uint spriteLevelUpExpByLevel = this._doc.GetSpriteLevelUpExpByLevel(this.CurrentClick, this._animCurrLevel);
			float num = this.m_Exp.value + this._animSpeed;
			bool flag = (this._animCurrLevel == this._animLevelTarget && num > this._AnimExpTarget) || this._animCurrLevel > this._animLevelTarget;
			if (flag)
			{
				this.AnimEnd = true;
				this._animCurrLevel = this._animLevelTarget;
				num = this._AnimExpTarget;
				this._SpriteSelectHandler.SetSpriteList(this._doc.SpriteList, false);
			}
			bool flag2 = num > 1f;
			if (flag2)
			{
				num = 0f;
				this._animCurrLevel++;
				XSingleton<XDebug>.singleton.AddLog(string.Format("Sprite level up to {0}", this._animCurrLevel), null, null, null, null, null, XDebugColor.XDebug_None);
				this.LevelUp();
			}
			this.m_Exp.value = num;
			this.m_ExpNum.SetText(string.Format("{0}/{1}", spriteInfo.Exp, spriteLevelUpExpByLevel));
			this.m_Level.SetText(string.Format("Lv.{0}", this._animCurrLevel));
		}

		public void OnSpriteListClick(IXUISprite iSp)
		{
			bool flag = this.m_CurrentClickSprite != null;
			if (flag)
			{
				this.m_CurrentClickSprite.gameObject.transform.Find("Select").gameObject.SetActive(false);
			}
			bool flag2 = this.CurrentClick != (int)iSp.ID;
			if (flag2)
			{
				this.AnimEnd = true;
			}
			this.CurrentClick = (int)iSp.ID;
			this.m_CurrentClickSprite = iSp;
			this.m_CurrentClickSprite.gameObject.transform.Find("Select").gameObject.SetActive(true);
			SpriteInfo spriteInfo = this._doc.SpriteList[this.CurrentClick];
			this.SetAvatar();
			this.RefreshFeedBtnRedPoint();
			this._SpritePropertyHandler.SetSpriteAttributeInfo(this._doc.SpriteList[this.CurrentClick], XSingleton<XAttributeMgr>.singleton.XPlayerData, null);
			uint spriteLevelUpExp = this._doc.GetSpriteLevelUpExp(this.CurrentClick);
			this.m_Exp.value = spriteInfo.Exp * 1f / spriteLevelUpExp;
			this.m_ExpNum.SetText(string.Format("{0}/{1}", spriteInfo.Exp, spriteLevelUpExp));
			this.m_Level.SetText(string.Format("Lv.{0}", spriteInfo.Level));
			this._animCurrLevel = (int)spriteInfo.Level;
			this.RefreshAwakeBtn();
		}

		private bool OnFoodBtnPress(IXUISprite iSp, bool state)
		{
			this._feedState[(int)iSp.ID] = state;
			if (state)
			{
				this._lastClickTime[(int)iSp.ID] = Time.time;
				bool flag = !this._doc.QueryFeedSprite(this.CurrentClick, (uint)this._doc.FoodList[(int)iSp.ID, 0]);
				if (flag)
				{
					this._feedState[(int)iSp.ID] = false;
				}
			}
			return true;
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			this.RefreshFoodNum();
			this.SetAvatar();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			for (int i = 0; i < 3; i++)
			{
				bool flag = this._feedState[i];
				if (flag)
				{
					bool flag2 = Time.time - this._lastClickTime[i] > this._feedStart && Time.time - this._lastFeedTime[i] > this._feedInterval;
					if (flag2)
					{
						this._lastFeedTime[i] = Time.time;
						bool flag3 = !this._doc.QueryFeedSprite(this.CurrentClick, (uint)this._doc.FoodList[i, 0]);
						if (flag3)
						{
							this._feedState[i] = false;
						}
					}
				}
			}
			bool flag4 = !this.AnimEnd;
			if (flag4)
			{
				this.SetExp();
			}
		}

		private XSpriteSystemDocument _doc;

		public IXUISprite m_StarUpBtn;

		private IXUISprite m_AwakeBtn;

		private GameObject m_FeedGo;

		private GameObject m_FoodList;

		private IXUIProgress m_Exp;

		private IXUILabel m_ExpNum;

		private IXUILabel m_Level;

		private Transform m_EffectParent;

		private GameObject m_FeedBtnRedPoint;

		private XUIPool m_FoodPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public SpriteSelectHandler _SpriteSelectHandler;

		public XSpriteAvatarHandler _SpriteAvatarHandler;

		public XSpriteAttributeHandler _SpritePropertyHandler;

		public int CurrentClick = 10000;

		public IXUISprite m_CurrentClickSprite;

		private float _lastEffectTime = 0f;

		private float[] _lastFeedTime = new float[3];

		private float[] _lastClickTime = new float[3];

		private bool[] _feedState = new bool[3];

		private IXUILabel[] m_FoodNum;

		private float _feedInterval;

		private float _feedStart;

		public bool AnimEnd = true;

		private int _animLevelTarget;

		private int _animCurrLevel;

		private float _AnimExpTarget;

		private float _animSpeed = 0.1f;

		private XFx _fxFirework;
	}
}
