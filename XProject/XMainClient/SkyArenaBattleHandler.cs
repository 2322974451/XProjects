using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class SkyArenaBattleHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XSkyArenaBattleDocument>(XSkyArenaBattleDocument.uuID);
			this.doc.BattleHandler = this;
			this.m_Info = base.transform.FindChild("Bg/Info");
			this.m_BlueScore = (base.transform.FindChild("Bg/Info/Blue/Score").GetComponent("XUILabel") as IXUILabel);
			this.m_RedScore = (base.transform.FindChild("Bg/Info/Red/Score").GetComponent("XUILabel") as IXUILabel);
			this.m_BlueDamage = (base.transform.FindChild("Bg/Info/Blue/Damage").GetComponent("XUILabel") as IXUILabel);
			this.m_RedDamage = (base.transform.FindChild("Bg/Info/Red/Damage").GetComponent("XUILabel") as IXUILabel);
			this.m_RestTip = (base.transform.FindChild("Bg/start").GetComponent("XUILabel") as IXUILabel);
			this.m_TimeLabel = (base.transform.FindChild("Bg/Time").GetComponent("XUILabel") as IXUILabel);
			this.m_TimeLabel.SetText(XSingleton<XStringTable>.singleton.GetString("SKY_ARENA_BEGIN_WAIT_TIP"));
			this._CDCounter = new XLeftTimeCounter(this.m_TimeLabel, false);
		}

		protected override string FileName
		{
			get
			{
				return "Battle/SkyArenaBattle";
			}
		}

		public override void RegisterEvent()
		{
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshInfo();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void OnUnload()
		{
			this.doc.BattleHandler = null;
			base.OnUnload();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			this._CDCounter.Update();
		}

		private void RefreshInfo()
		{
			this.m_BlueScore.SetText("0");
			this.m_RedScore.SetText("0");
			this.m_BlueDamage.SetText("0");
			this.m_RedDamage.SetText("0");
			DlgBase<BattleMain, BattleMainBehaviour>.singleton.HideLeftTime();
			this.m_RestTip.gameObject.SetActive(false);
		}

		public void SetScore(uint score, bool isBlue)
		{
			if (isBlue)
			{
				this.m_BlueScore.SetText(score.ToString());
			}
			else
			{
				this.m_RedScore.SetText(score.ToString());
			}
		}

		public void SetDamage(ulong damage, bool isBlue)
		{
			if (isBlue)
			{
				this.m_BlueDamage.SetText(damage.ToString());
			}
			else
			{
				this.m_RedDamage.SetText(damage.ToString());
			}
		}

		public void RefreshStatusTime(SkyCityTimeType status, uint time)
		{
			XSingleton<XDebug>.singleton.AddGreenLog(string.Concat(new object[]
			{
				"status:",
				status,
				"\ntime:",
				time
			}), null, null, null, null, null);
			bool flag = time == 0U;
			if (!flag)
			{
				bool flag2 = status == SkyCityTimeType.Race;
				if (flag2)
				{
					bool flag3 = this.m_TimeLabel.IsVisible();
					if (flag3)
					{
						this.m_TimeLabel.gameObject.SetActive(false);
					}
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetLeftTime(time, -1);
					XSingleton<UiUtility>.singleton.SetMiniMapOpponentStatus(false);
					this.m_RestTip.gameObject.SetActive(false);
				}
				else
				{
					bool flag4 = status == SkyCityTimeType.FirstWaiting;
					if (flag4)
					{
						bool flag5 = !this.m_TimeLabel.IsVisible();
						if (flag5)
						{
							this.m_TimeLabel.gameObject.SetActive(true);
						}
						this._CDCounter.SetLeftTime(time, -1);
						this._CDCounter.SetFinishEventHandler(null, null);
						this._CDCounter.SetFormatString(XSingleton<XStringTable>.singleton.GetString("SKY_ARENA_REST_TIME"));
						bool flag6 = this.m_CurStatus != status;
						if (flag6)
						{
							DlgBase<XShowGetItemView, XShowGetItemBehaviour>.singleton.ShowTip(XSingleton<XStringTable>.singleton.GetString("SKY_ARENA_ROUND_END_REST"));
						}
						DlgBase<BattleMain, BattleMainBehaviour>.singleton.HideLeftTime();
						XSingleton<UiUtility>.singleton.SetMiniMapOpponentStatus(true);
						this.m_RestTip.gameObject.SetActive(true);
					}
					else
					{
						bool flag7 = status == SkyCityTimeType.SecondWaiting;
						if (flag7)
						{
							bool flag8 = this.m_CurStatus == status;
							if (flag8)
							{
								return;
							}
							bool flag9 = !this.m_TimeLabel.IsVisible();
							if (flag9)
							{
								this.m_TimeLabel.gameObject.SetActive(true);
							}
							this._CDCounter.SetLeftTime(time, -1);
							this._CDCounter.SetFinishEventHandler(new TimeOverFinishEventHandler(this._OnLeftTimeOver), null);
							this._CDCounter.SetFormatString(XSingleton<XStringTable>.singleton.GetString("SKY_ARENA_NEXT_BATTLE_TIME"));
							this.HideInfo();
							DlgBase<BattleMain, BattleMainBehaviour>.singleton.HideLeftTime();
							XSingleton<UiUtility>.singleton.SetMiniMapOpponentStatus(true);
						}
						else
						{
							bool flag10 = status == SkyCityTimeType.MidleEndInRest;
							if (flag10)
							{
							}
						}
					}
				}
				this.m_CurStatus = status;
			}
		}

		private void _OnLeftTimeOver(object o)
		{
			this.m_TimeLabel.SetText(XSingleton<XStringTable>.singleton.GetString("SKY_ARENA_MATCHING"));
		}

		public void HideTime()
		{
			DlgBase<BattleMain, BattleMainBehaviour>.singleton.HideLeftTime();
			this.m_TimeLabel.gameObject.SetActive(false);
		}

		private void HideInfo()
		{
			this.m_Info.gameObject.SetActive(false);
		}

		private XSkyArenaBattleDocument doc = null;

		private SkyCityTimeType m_CurStatus;

		private XLeftTimeCounter _CDCounter;

		private Transform m_Info;

		private IXUILabel m_BlueScore;

		private IXUILabel m_RedScore;

		private IXUILabel m_BlueDamage;

		private IXUILabel m_RedDamage;

		private IXUILabel m_TimeLabel;

		private IXUILabel m_RestTip;
	}
}
