using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class RaceEntranceView : DlgBase<RaceEntranceView, RaceEntranceBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/Race/RaceEntranceDlg";
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

		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_MulActivity_Race);
			}
		}

		protected override void Init()
		{
			base.uiBehaviour.m_GameRule.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("RACE_RULE")));
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_SingleJoin.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnStartSingleClicked));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
		}

		public bool OnCloseClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool OnHelpClicked(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_MulActivity_Race);
			return true;
		}

		private bool OnStartSingleClicked(IXUIButton btn)
		{
			bool flag = XTeamDocument.GoSingleBattleBeforeNeed(new ButtonClickEventHandler(this.OnStartSingleClicked), btn);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				PtcC2G_EnterSceneReq ptcC2G_EnterSceneReq = new PtcC2G_EnterSceneReq();
				ptcC2G_EnterSceneReq.Data.sceneID = 50U;
				XSingleton<XClientNetwork>.singleton.Send(ptcC2G_EnterSceneReq);
				result = true;
			}
			return result;
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshPage();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		protected override void OnUnload()
		{
			base.OnUnload();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
		}

		public void RefreshPage()
		{
			string[] array = XSingleton<XGlobalConfig>.singleton.GetValue("RaceShowRaward").Split(new char[]
			{
				'|'
			});
			base.uiBehaviour.m_RewardPool.FakeReturnAll();
			for (int i = 0; i < array.Length; i++)
			{
				GameObject gameObject = base.uiBehaviour.m_RewardPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3((float)(i * base.uiBehaviour.m_RewardPool.TplWidth), 0f, 0f);
				uint num = uint.Parse(array[i]);
				Transform transform = gameObject.transform.Find("Item");
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(transform.gameObject, (int)num, 0, false);
				IXUISprite ixuisprite = transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)num;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnItemClick));
			}
			base.uiBehaviour.m_RewardPool.ActualReturnAll(false);
		}

		private void _OnItemClick(IXUISprite iSp)
		{
			XSingleton<UiUtility>.singleton.ShowTooltipDialog((int)iSp.ID, null);
		}

		public void SetMainInterfaceBtnState(bool state)
		{
			this.MainInterfaceState = state;
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_MulActivity_Race, true);
		}

		public bool MainInterfaceState = false;
	}
}
