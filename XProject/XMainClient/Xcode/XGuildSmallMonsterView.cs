using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildSmallMonsterView : DlgBase<XGuildSmallMonsterView, XGuildSmallMonsterBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Guild/GuildSystem/GuildSmallMonsterDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override int group
		{
			get
			{
				return 1;
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
				return true;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XGuildSmallMonsterDocument>(XGuildSmallMonsterDocument.uuID);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_BeginGame.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBeginGameClicked));
			base.uiBehaviour.m_btnrwdRank.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRwdRankClick));
			base.uiBehaviour.m_btnHelp.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClick));
		}

		protected override void OnLoad()
		{
			base.OnLoad();
			DlgHandlerBase.EnsureCreate<GuildCampRankHandler>(ref this._rankHandler, base.uiBehaviour.gameObject.transform, false, this);
		}

		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<GuildCampRankHandler>(ref this._rankHandler);
			base.OnUnload();
		}

		private bool OnCloseClicked(IXUIButton button)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool OnBeginGameClicked(IXUIButton button)
		{
			this._doc.OpenTeamView();
			return true;
		}

		private bool OnRwdRankClick(IXUIButton button)
		{
			this._rankHandler.SetVisible(true);
			return true;
		}

		private bool OnHelpClick(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(this._doc.currCamp.Name, this._doc.currCamp.Description);
			return true;
		}

		public bool CloseRankHandler(IXUIButton btn)
		{
			this._rankHandler.SetVisible(false);
			return true;
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshRedp();
			this._doc.SendQuerySmallMonterInfo();
			this.SetupDetailFrame();
			this.SetupRankFrame();
		}

		public void SetupDetailFrame()
		{
			base.uiBehaviour.m_RemainTime.SetText(string.Format("{0}/{1}", this._doc.LeftEnterCount, this._doc.DayLimit));
			base.uiBehaviour.m_CurrentLevel.SetText(string.Format("Lv.{0}", 0));
			SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(this._doc.Small_Monster_SceneID);
			base.uiBehaviour.m_DropItemPool.FakeReturnAll();
			bool flag = sceneData.ViewableDropList != null;
			if (flag)
			{
				for (int i = 0; i < sceneData.ViewableDropList.Length; i++)
				{
					GameObject gameObject = base.uiBehaviour.m_DropItemPool.FetchGameObject(false);
					gameObject.name = "drop" + sceneData.ViewableDropList[i];
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, sceneData.ViewableDropList[i], 0, false);
					gameObject.transform.localPosition = base.uiBehaviour.m_DropItemPool.TplPos + new Vector3((float)(i * base.uiBehaviour.m_DropItemPool.TplWidth), 0f);
					IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = (ulong)sceneData.ViewableDropList[i];
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
				}
			}
			base.uiBehaviour.m_lblThisday.SetText(this._doc.currCamp.Name);
			base.uiBehaviour.m_lblNextday.SetText(this._doc.nextCamp.Name);
			base.uiBehaviour.m_lblWin.SetText(this._doc.currCamp.Condition);
			base.uiBehaviour.m_DropItemPool.ActualReturnAll(false);
		}

		public void SetupRankFrame()
		{
			base.uiBehaviour.m_KillRankPool.FakeReturnAll();
			base.uiBehaviour.m_lblEmpt.SetVisible(this._doc.RankList.Count <= 0);
			base.uiBehaviour.m_lblType.SetText(this._doc.currCamp.RankDes);
			for (int i = 0; i < this._doc.RankList.Count; i++)
			{
				GameObject gameObject = base.uiBehaviour.m_KillRankPool.FetchGameObject(false);
				IXUILabel ixuilabel = gameObject.transform.FindChild("Rank").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = gameObject.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = gameObject.transform.FindChild("Condition").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite = gameObject.transform.FindChild("RankImage").GetComponent("XUISprite") as IXUISprite;
				ixuilabel.SetVisible(i >= 3);
				ixuilabel.SetText(string.Format("No.{0}", i + 1));
				ixuisprite.SetVisible(i < 3);
				ixuisprite.SetSprite("N" + (i + 1));
				ixuisprite.MakePixelPerfect();
				string text = string.Empty;
				for (int j = 0; j < this._doc.RankList[i].roles.Count; j++)
				{
					text += this._doc.RankList[i].roles[j].name;
					bool flag = j < this._doc.RankList[i].roles.Count - 1;
					if (flag)
					{
						text += "\n";
					}
				}
				ixuilabel2.SetText(text);
				bool flag2 = this._doc.currCamp.Type == 2;
				if (flag2)
				{
					ixuilabel3.SetText(this._doc.RankList[i].rankVar.ToString());
				}
				else
				{
					int num = this._doc.RankList[i].rankVar / 60;
					int num2 = this._doc.RankList[i].rankVar % 60;
					string str = (num < 10) ? ("0" + num) : num.ToString();
					string str2 = (num2 < 10) ? ("0" + num2) : num2.ToString();
					ixuilabel3.SetText(str + ":" + str2);
				}
				gameObject.transform.localPosition = base.uiBehaviour.m_KillRankPool.TplPos - new Vector3(0f, (float)(i * base.uiBehaviour.m_KillRankPool.TplHeight));
			}
			base.uiBehaviour.m_KillRankPool.ActualReturnAll(false);
		}

		public void RefreshRedp()
		{
			bool flag = this._doc == null;
			if (flag)
			{
				this._doc = XDocuments.GetSpecificDocument<XGuildSmallMonsterDocument>(XGuildSmallMonsterDocument.uuID);
			}
			XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			bool flag2 = XGuildDocument.GuildConfig.IsSysUnlock(XSysDefine.XSys_GuildDungeon_SmallMonter, specificDocument.Level);
			XSingleton<XGameSysMgr>.singleton.SetSysRedState(XSysDefine.XSys_GuildDungeon_SmallMonter, this._doc.LeftEnterCount > 0 && flag2 && this._doc.CheckEnterLevel());
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_GuildDungeon_SmallMonter, true);
		}

		private XGuildSmallMonsterDocument _doc = null;

		private GuildCampRankHandler _rankHandler;
	}
}
