using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C1A RID: 3098
	internal class GuildMineEntranceView : DlgBase<GuildMineEntranceView, GuildMineEntranceBehaviour>
	{
		// Token: 0x170030FF RID: 12543
		// (get) Token: 0x0600AFD8 RID: 45016 RVA: 0x00216A34 File Offset: 0x00214C34
		public override string fileName
		{
			get
			{
				return "Guild/GuildMine/GuildMineEntrance";
			}
		}

		// Token: 0x17003100 RID: 12544
		// (get) Token: 0x0600AFD9 RID: 45017 RVA: 0x00216A4C File Offset: 0x00214C4C
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003101 RID: 12545
		// (get) Token: 0x0600AFDA RID: 45018 RVA: 0x00216A60 File Offset: 0x00214C60
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003102 RID: 12546
		// (get) Token: 0x0600AFDB RID: 45019 RVA: 0x00216A74 File Offset: 0x00214C74
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003103 RID: 12547
		// (get) Token: 0x0600AFDC RID: 45020 RVA: 0x00216A88 File Offset: 0x00214C88
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003104 RID: 12548
		// (get) Token: 0x0600AFDD RID: 45021 RVA: 0x00216A9C File Offset: 0x00214C9C
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003105 RID: 12549
		// (get) Token: 0x0600AFDE RID: 45022 RVA: 0x00216AB0 File Offset: 0x00214CB0
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003106 RID: 12550
		// (get) Token: 0x0600AFDF RID: 45023 RVA: 0x00216AC4 File Offset: 0x00214CC4
		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_GuildMine);
			}
		}

		// Token: 0x0600AFE0 RID: 45024 RVA: 0x00216ADD File Offset: 0x00214CDD
		protected override void Init()
		{
			this.doc = XDocuments.GetSpecificDocument<XGuildMineEntranceDocument>(XGuildMineEntranceDocument.uuID);
			this.doc.View = this;
		}

		// Token: 0x0600AFE1 RID: 45025 RVA: 0x00216B00 File Offset: 0x00214D00
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
			base.uiBehaviour.m_Join.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnJoinClicked));
		}

		// Token: 0x0600AFE2 RID: 45026 RVA: 0x00216B68 File Offset: 0x00214D68
		public bool OnCloseClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600AFE3 RID: 45027 RVA: 0x00216B84 File Offset: 0x00214D84
		private bool OnHelpClicked(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_GuildMine);
			return true;
		}

		// Token: 0x0600AFE4 RID: 45028 RVA: 0x00216BA4 File Offset: 0x00214DA4
		private bool OnJoinClicked(IXUIButton btn)
		{
			this.doc.ReqEnterMine();
			return true;
		}

		// Token: 0x0600AFE5 RID: 45029 RVA: 0x00216BC3 File Offset: 0x00214DC3
		protected override void OnShow()
		{
			base.OnShow();
			this.InitShow();
		}

		// Token: 0x0600AFE6 RID: 45030 RVA: 0x00216BD4 File Offset: 0x00214DD4
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600AFE7 RID: 45031 RVA: 0x00216BDE File Offset: 0x00214DDE
		protected override void OnUnload()
		{
			this.doc.View = null;
			base.OnUnload();
		}

		// Token: 0x0600AFE8 RID: 45032 RVA: 0x00216BF5 File Offset: 0x00214DF5
		public override void OnUpdate()
		{
			base.OnUpdate();
		}

		// Token: 0x0600AFE9 RID: 45033 RVA: 0x00216C00 File Offset: 0x00214E00
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

		// Token: 0x0600AFEA RID: 45034 RVA: 0x001EECC3 File Offset: 0x001ECEC3
		private void _OnItemClick(IXUISprite iSp)
		{
			XSingleton<UiUtility>.singleton.ShowTooltipDialog((int)iSp.ID, null);
		}

		// Token: 0x04004328 RID: 17192
		private XGuildMineEntranceDocument doc = null;
	}
}
