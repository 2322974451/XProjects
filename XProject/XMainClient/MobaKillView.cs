using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	public class MobaKillView : DlgBase<MobaKillView, MobaKillBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Battle/MobaKillDlg";
			}
		}

		public void Enqueue(MobaReminder info)
		{
			this.m_killInfos.Enqueue(info);
			bool flag = !base.IsVisible();
			if (flag)
			{
				this.SetVisibleWithAnimation(true, null);
			}
		}

		public override int layer
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

		protected override void Init()
		{
			base.Init();
			this.m_uiBehaviour.m_playGroup.StopTween();
		}

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

		private void SwichReminderForMessage(MobaReminder killInfo)
		{
			base.uiBehaviour.KillTransform.gameObject.SetActive(false);
			base.uiBehaviour.MessageTransform.gameObject.SetActive(true);
			base.uiBehaviour.m_MessageLabel.SetText(killInfo.ReminderText);
		}

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

		private Queue<MobaReminder> m_killInfos = new Queue<MobaReminder>();

		private XElapseTimer m_showTimer = new XElapseTimer();
	}
}
