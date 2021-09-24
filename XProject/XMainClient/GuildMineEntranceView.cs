using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class GuildMineEntranceView : DlgBase<GuildMineEntranceView, GuildMineEntranceBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Guild/GuildMine/GuildMineEntrance";
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

		public override bool fullscreenui
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
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_GuildMine);
			}
		}

		protected override void Init()
		{
			this.doc = XDocuments.GetSpecificDocument<XGuildMineEntranceDocument>(XGuildMineEntranceDocument.uuID);
			this.doc.View = this;
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
			base.uiBehaviour.m_Join.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnJoinClicked));
		}

		public bool OnCloseClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool OnHelpClicked(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_GuildMine);
			return true;
		}

		private bool OnJoinClicked(IXUIButton btn)
		{
			this.doc.ReqEnterMine();
			return true;
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.InitShow();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		protected override void OnUnload()
		{
			this.doc.View = null;
			base.OnUnload();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
		}

		private void InitShow()
		{
			base.uiBehaviour.m_GameRule.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("GUILD_MINE_RLUE")));
			base.uiBehaviour.m_ActivityTime.SetText(XSingleton<XStringTable>.singleton.GetString("GUILD_MINE_START_TIME"));
			string[] array = XSingleton<XGlobalConfig>.singleton.GetValue("GuildMineReward").Split(new char[]
			{
				'|'
			});
			string[] array2 = XSingleton<XGlobalConfig>.singleton.GetValue("GuildMineGuildReward").Split(new char[]
			{
				'|'
			});
			base.uiBehaviour.m_RewardPool.FakeReturnAll();
			for (int i = 0; i < array.Length + array2.Length; i++)
			{
				GameObject gameObject = base.uiBehaviour.m_RewardPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3((float)(i * base.uiBehaviour.m_RewardPool.TplWidth), 0f, 0f) + base.uiBehaviour.m_RewardPool.TplPos;
				bool flag = i < array.Length;
				uint num;
				if (flag)
				{
					num = uint.Parse(array[i]);
				}
				else
				{
					num = uint.Parse(array2[i - array.Length]);
				}
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)num, 0, false);
				Transform transform = gameObject.transform.Find("Tag");
				transform.gameObject.SetActive(i >= array.Length);
				IXUISprite ixuisprite = gameObject.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)num;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnItemClick));
			}
			base.uiBehaviour.m_RewardPool.ActualReturnAll(false);
		}

		private void _OnItemClick(IXUISprite iSp)
		{
			XSingleton<UiUtility>.singleton.ShowTooltipDialog((int)iSp.ID, null);
		}

		private XGuildMineEntranceDocument doc = null;
	}
}
