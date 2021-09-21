using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C52 RID: 3154
	public class MobaKillView : DlgBase<MobaKillView, MobaKillBehaviour>
	{
		// Token: 0x17003196 RID: 12694
		// (get) Token: 0x0600B2E2 RID: 45794 RVA: 0x0022B02C File Offset: 0x0022922C
		public override string fileName
		{
			get
			{
				return "Battle/MobaKillDlg";
			}
		}

		// Token: 0x0600B2E3 RID: 45795 RVA: 0x0022B044 File Offset: 0x00229244
		public void Enqueue(MobaReminder info)
		{
			this.m_killInfos.Enqueue(info);
			bool flag = !base.IsVisible();
			if (flag)
			{
				this.SetVisibleWithAnimation(true, null);
			}
		}

		// Token: 0x17003197 RID: 12695
		// (get) Token: 0x0600B2E4 RID: 45796 RVA: 0x0022B078 File Offset: 0x00229278
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003198 RID: 12696
		// (get) Token: 0x0600B2E5 RID: 45797 RVA: 0x0022B08C File Offset: 0x0022928C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600B2E6 RID: 45798 RVA: 0x0022B09F File Offset: 0x0022929F
		protected override void Init()
		{
			base.Init();
			this.m_uiBehaviour.m_playGroup.StopTween();
		}

		// Token: 0x0600B2E7 RID: 45799 RVA: 0x0022B0BC File Offset: 0x002292BC
		public override void OnUpdate()
		{
			bool flag = this.m_showTimer != null && this.m_showTimer.LeftTime > 0f;
			if (flag)
			{
				this.m_showTimer.Update();
			}
			else
			{
				bool flag2 = this.m_killInfos.Count > 0;
				if (flag2)
				{
					this.SetKillerInfo(this.m_killInfos.Dequeue());
					bool flag3 = this.m_showTimer == null;
					if (flag3)
					{
						this.m_showTimer = new XElapseTimer();
					}
					this.m_showTimer.LeftTime = 3f;
				}
				else
				{
					this.SetVisibleWithAnimation(false, null);
				}
			}
		}

		// Token: 0x0600B2E8 RID: 45800 RVA: 0x0022B158 File Offset: 0x00229358
		private void SetKillerInfo(MobaReminder killInfo)
		{
			MobaReminderEnum reminder = killInfo.reminder;
			if (reminder != MobaReminderEnum.KILLER)
			{
				if (reminder == MobaReminderEnum.MESSAGE)
				{
					this.SwichReminderForMessage(killInfo);
				}
			}
			else
			{
				this.SwichReminderForKiller(killInfo);
			}
			bool flag = !string.IsNullOrEmpty(killInfo.AudioName);
			if (flag)
			{
				XSingleton<XAudioMgr>.singleton.PlayUISound(killInfo.AudioName, true, AudioChannel.Action);
			}
			base.uiBehaviour.m_playGroup.ResetTween(true);
			base.uiBehaviour.m_playGroup.PlayTween(true);
			killInfo.Recycle();
		}

		// Token: 0x0600B2E9 RID: 45801 RVA: 0x0022B1DC File Offset: 0x002293DC
		private void SwichReminderForMessage(MobaReminder killInfo)
		{
			base.uiBehaviour.KillTransform.gameObject.SetActive(false);
			base.uiBehaviour.MessageTransform.gameObject.SetActive(true);
			base.uiBehaviour.m_MessageLabel.SetText(killInfo.ReminderText);
		}

		// Token: 0x0600B2EA RID: 45802 RVA: 0x0022B230 File Offset: 0x00229430
		private void SwichReminderForKiller(MobaReminder killInfo)
		{
			base.uiBehaviour.KillTransform.gameObject.SetActive(true);
			base.uiBehaviour.MessageTransform.gameObject.SetActive(false);
			this.SetHeader(base.uiBehaviour.m_leftHeader, killInfo.killer);
			this.SetHeader(base.uiBehaviour.m_rightHeader, killInfo.deader);
			int i = 0;
			int num = base.uiBehaviour.m_killTypes.Length;
			while (i < num)
			{
				bool flag = base.uiBehaviour.m_killTypes[i] == null;
				if (!flag)
				{
					base.uiBehaviour.m_killTypes[i].gameObject.SetActive(i == killInfo.type);
				}
				i++;
			}
			base.uiBehaviour.m_helpMembers.ReturnAll(false);
			bool flag2 = killInfo.assists.Count > 0;
			if (flag2)
			{
				base.uiBehaviour.m_helpTransform.gameObject.SetActive(true);
				i = 0;
				num = killInfo.assists.Count;
				while (i < num)
				{
					GameObject gameObject = base.uiBehaviour.m_helpMembers.FetchGameObject(false);
					gameObject.transform.localScale = Vector3.one;
					gameObject.transform.localPosition = new Vector3(0f, (float)(base.uiBehaviour.m_helpMembers.TplWidth * i), 0f);
					this.SetHeader(gameObject.transform, killInfo.assists[i]);
					i++;
				}
			}
			else
			{
				base.uiBehaviour.m_helpTransform.gameObject.SetActive(false);
			}
		}

		// Token: 0x0600B2EB RID: 45803 RVA: 0x0022B3E4 File Offset: 0x002295E4
		private void SetHeader(Transform t, HeroKillUnit unit)
		{
			IXUISprite ixuisprite = t.Find("HeroIcon").GetComponent("XUISprite") as IXUISprite;
			IXUISprite ixuisprite2 = t.Find("team").GetComponent("XUISprite") as IXUISprite;
			XMobaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XMobaBattleDocument>(XMobaBattleDocument.uuID);
			ixuisprite2.SetSprite(specificDocument.isAlly((int)unit.teamid) ? "HeroHeadB" : "HeroHeadR");
			string strAtlas = "";
			string strSprite = "";
			bool flag = unit.type == HeroKillUnitType.HeroKillUnit_Hero;
			if (flag)
			{
				XHeroBattleDocument.GetIconByHeroID(unit.id, out strAtlas, out strSprite);
			}
			else
			{
				XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(unit.id);
				bool flag2 = byID != null;
				if (flag2)
				{
					XEntityPresentation.RowData byPresentID = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(byID.PresentID);
					bool flag3 = byPresentID != null;
					if (flag3)
					{
						strAtlas = byPresentID.Atlas2;
						strSprite = byPresentID.Avatar2;
					}
				}
			}
			ixuisprite.SetSprite(strSprite, strAtlas, false);
		}

		// Token: 0x0400451F RID: 17695
		private Queue<MobaReminder> m_killInfos = new Queue<MobaReminder>();

		// Token: 0x04004520 RID: 17696
		private XElapseTimer m_showTimer = new XElapseTimer();
	}
}
