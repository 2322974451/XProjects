using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CB0 RID: 3248
	internal class SkyArenaBattleHandler : DlgHandlerBase
	{
		// Token: 0x0600B6D0 RID: 46800 RVA: 0x00244F2C File Offset: 0x0024312C
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

		// Token: 0x17003251 RID: 12881
		// (get) Token: 0x0600B6D1 RID: 46801 RVA: 0x00245080 File Offset: 0x00243280
		protected override string FileName
		{
			get
			{
				return "Battle/SkyArenaBattle";
			}
		}

		// Token: 0x0600B6D2 RID: 46802 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void RegisterEvent()
		{
		}

		// Token: 0x0600B6D3 RID: 46803 RVA: 0x00245097 File Offset: 0x00243297
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshInfo();
		}

		// Token: 0x0600B6D4 RID: 46804 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600B6D5 RID: 46805 RVA: 0x002450A8 File Offset: 0x002432A8
		public override void OnUnload()
		{
			this.doc.BattleHandler = null;
			base.OnUnload();
		}

		// Token: 0x0600B6D6 RID: 46806 RVA: 0x002450BE File Offset: 0x002432BE
		public override void OnUpdate()
		{
			base.OnUpdate();
			this._CDCounter.Update();
		}

		// Token: 0x0600B6D7 RID: 46807 RVA: 0x002450D4 File Offset: 0x002432D4
		private void RefreshInfo()
		{
			this.m_BlueScore.SetText("0");
			this.m_RedScore.SetText("0");
			this.m_BlueDamage.SetText("0");
			this.m_RedDamage.SetText("0");
			DlgBase<BattleMain, BattleMainBehaviour>.singleton.HideLeftTime();
			this.m_RestTip.gameObject.SetActive(false);
		}

		// Token: 0x0600B6D8 RID: 46808 RVA: 0x00245144 File Offset: 0x00243344
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

		// Token: 0x0600B6D9 RID: 46809 RVA: 0x00245184 File Offset: 0x00243384
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

		// Token: 0x0600B6DA RID: 46810 RVA: 0x002451C4 File Offset: 0x002433C4
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

		// Token: 0x0600B6DB RID: 46811 RVA: 0x002453FD File Offset: 0x002435FD
		private void _OnLeftTimeOver(object o)
		{
			this.m_TimeLabel.SetText(XSingleton<XStringTable>.singleton.GetString("SKY_ARENA_MATCHING"));
		}

		// Token: 0x0600B6DC RID: 46812 RVA: 0x0024541B File Offset: 0x0024361B
		public void HideTime()
		{
			DlgBase<BattleMain, BattleMainBehaviour>.singleton.HideLeftTime();
			this.m_TimeLabel.gameObject.SetActive(false);
		}

		// Token: 0x0600B6DD RID: 46813 RVA: 0x0024543B File Offset: 0x0024363B
		private void HideInfo()
		{
			this.m_Info.gameObject.SetActive(false);
		}

		// Token: 0x0400479D RID: 18333
		private XSkyArenaBattleDocument doc = null;

		// Token: 0x0400479E RID: 18334
		private SkyCityTimeType m_CurStatus;

		// Token: 0x0400479F RID: 18335
		private XLeftTimeCounter _CDCounter;

		// Token: 0x040047A0 RID: 18336
		private Transform m_Info;

		// Token: 0x040047A1 RID: 18337
		private IXUILabel m_BlueScore;

		// Token: 0x040047A2 RID: 18338
		private IXUILabel m_RedScore;

		// Token: 0x040047A3 RID: 18339
		private IXUILabel m_BlueDamage;

		// Token: 0x040047A4 RID: 18340
		private IXUILabel m_RedDamage;

		// Token: 0x040047A5 RID: 18341
		private IXUILabel m_TimeLabel;

		// Token: 0x040047A6 RID: 18342
		private IXUILabel m_RestTip;
	}
}
