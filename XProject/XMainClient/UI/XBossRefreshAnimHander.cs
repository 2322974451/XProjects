using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	public class XBossRefreshAnimHander : XSingleton<XBossRefreshAnimHander>
	{

		public void Init(GameObject _go)
		{
			this._doc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XBossBushDocument.uuID) as XBossBushDocument);
			this.PanelObject = _go;
			this.m_lblTitle = (_go.transform.Find("Avatar/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_sprIcon = (_go.transform.Find("Avatar/Avatar").GetComponent("XUISprite") as IXUISprite);
			this.m_lblDiff = (_go.transform.Find("Diff").GetComponent("XUILabel") as IXUILabel);
			this.m_slider = (_go.transform.Find("Progress").GetComponent("XUIProgress") as IXUIProgress);
			this.m_sprBuff1 = (_go.transform.Find("T/Icon1").GetComponent("XUISprite") as IXUISprite);
			this.m_lblBuff1 = (_go.transform.Find("T/Icon1/T2").GetComponent("XUILabel") as IXUILabel);
			this.m_sprBuff2 = (_go.transform.Find("T/Icon").GetComponent("XUISprite") as IXUISprite);
			this.m_lblBuff2 = (_go.transform.Find("T/Icon/T2").GetComponent("XUILabel") as IXUILabel);
			this.m_objFx = _go.transform.Find("Avatar/FX").gameObject;
			this.m_tween1 = (_go.transform.Find("Avatar/FX/q1").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_tween2 = (_go.transform.Find("Avatar/FX/q2").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_tween3 = (_go.transform.Find("Avatar/FX/q3").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.frames.Clear();
			string value = XSingleton<XGlobalConfig>.singleton.GetValue("BossRush_Ani");
			string[] array = value.Split(new char[]
			{
				'|'
			});
			for (int i = 0; i < array.Length; i++)
			{
				this.frames.Add(int.Parse(array[i]));
			}
		}

		public void Show()
		{
			this._doc = XDocuments.GetSpecificDocument<XBossBushDocument>(XBossBushDocument.uuID);
			this.state = XBossRefreshAnimHander.State.BEGIN;
			bool flag = !this.PanelObject.activeSelf;
			if (flag)
			{
				this.PanelObject.SetActive(true);
			}
			bool flag2 = this.timePass != null;
			if (flag2)
			{
				this.timePass.LeftTime = 10f;
			}
		}

		public void OnUpdate()
		{
			bool flag = this.state == XBossRefreshAnimHander.State.BEGIN;
			if (flag)
			{
				this.m_lblDiff.gameObject.SetActive(false);
				this.m_slider.gameObject.SetActive(true);
				bool activeSelf = this.m_objFx.activeSelf;
				if (activeSelf)
				{
					this.m_objFx.SetActive(false);
				}
				this.m_playCnt = 0U;
				this.m_accTime = 0U;
				this.state = XBossRefreshAnimHander.State.PLAY;
				this.m_slider.value = 0f;
			}
			else
			{
				bool flag2 = this.state == XBossRefreshAnimHander.State.PLAY;
				if (flag2)
				{
					this.timePass.Update();
					this.m_accTime = (uint)(this.timePass.PassTime * 1000f);
					bool flag3 = (ulong)this.m_accTime > (ulong)((long)this.GetFrame(this.m_playCnt));
					if (flag3)
					{
						this.timePass.LeftTime = 1f;
						this.m_accTime = 0U;
						this.m_playCnt += 1U;
						this.UpdateSlider();
						this.RefreshRandBoss();
						bool flag4 = this.m_playCnt >= this.m_allCnt;
						if (flag4)
						{
							this.m_playCnt = 0U;
							this.state = XBossRefreshAnimHander.State.Idle;
						}
					}
				}
				else
				{
					bool flag5 = this.state == XBossRefreshAnimHander.State.Idle;
					if (flag5)
					{
						this.state = XBossRefreshAnimHander.State.None;
						this.m_lblDiff.gameObject.SetActive(true);
						this.m_slider.gameObject.SetActive(false);
						bool flag6 = this._doc != null && this._doc.respData != null;
						if (flag6)
						{
							this.RefreshBoss(this._doc.respData.confid, false);
						}
						this.PlayFxEff();
						this.m_timertoken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.PlayEndTimer), null);
					}
					else
					{
						bool flag7 = this.state == XBossRefreshAnimHander.State.FADE;
						if (flag7)
						{
							bool activeSelf2 = this.PanelObject.activeSelf;
							if (activeSelf2)
							{
								this.PanelObject.SetActive(false);
							}
							bool activeSelf3 = this.m_objFx.activeSelf;
							if (activeSelf3)
							{
								this.m_objFx.SetActive(false);
							}
							DlgBase<BossRushDlg, BossRushBehavior>.singleton.PlayRefreshEff();
							DlgBase<BossRushDlg, BossRushBehavior>.singleton.DelayRefresh();
							this.state = XBossRefreshAnimHander.State.None;
						}
					}
				}
			}
		}

		private int GetFrame(uint index)
		{
			bool flag = this.frames.Count <= 0;
			int result;
			if (flag)
			{
				result = 15;
			}
			else
			{
				bool flag2 = (long)this.frames.Count <= (long)((ulong)index);
				if (flag2)
				{
					result = this.frames[this.frames.Count - 1];
				}
				else
				{
					result = this.frames[(int)index];
				}
			}
			return result;
		}

		public void OnUnload()
		{
			bool flag = this.m_timertoken > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this.m_timertoken);
			}
		}

		private void PlayFxEff()
		{
			this.m_objFx.SetActive(true);
			this.m_tween1.ResetTween(true);
			this.m_tween2.ResetTween(true);
			this.m_tween3.ResetTween(true);
			this.m_tween1.PlayTween(true, -1f);
			this.m_tween2.ResetTween(true);
			this.m_tween3.ResetTween(true);
		}

		private void PlayEndTimer(object o)
		{
			this.state = XBossRefreshAnimHander.State.FADE;
		}

		private void RefreshRandBoss()
		{
			int num = XBossBushDocument.bossRushTable.Table.Length - 2;
			int uid = UnityEngine.Random.Range(1, num);
			this.RefreshBoss(uid, true);
		}

		private void RefreshBoss(int uid, bool rand)
		{
			BossRushTable.RowData bossRushRow = this._doc.GetBossRushRow(uid);
			XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID((uint)bossRushRow.bossid);
			XEntityPresentation.RowData byPresentID = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(byID.PresentID);
			this.m_lblTitle.SetText(this.MakeBossName(byID.Name, (int)bossRushRow.bossdifficult[0]));
			this.m_lblDiff.SetText(XStringDefineProxy.GetString("BOSSRUSH_DIF" + bossRushRow.bossdifficult[0]));
			this.m_sprIcon.SetSprite(byPresentID.Avatar, byPresentID.Atlas, false);
			if (rand)
			{
				BossRushBuffTable.RowData[] randBuffs = this._doc.GetRandBuffs();
				this.m_sprBuff1.SetSprite(randBuffs[0].icon);
				this.m_lblBuff1.SetText(randBuffs[0].Comment);
				this.m_sprBuff2.SetSprite(randBuffs[1].icon);
				this.m_lblBuff2.SetText(randBuffs[1].Comment);
				int quality = randBuffs[0].Quality;
				int quality2 = randBuffs[1].Quality;
				string value = XSingleton<XGlobalConfig>.singleton.GetValue("Quality" + quality + "Color");
				string value2 = XSingleton<XGlobalConfig>.singleton.GetValue("Quality" + quality2 + "Color");
				this.m_lblBuff1.SetColor(XSingleton<UiUtility>.singleton.ParseColor(value, 0));
				this.m_sprBuff1.SetColor(XSingleton<UiUtility>.singleton.ParseColor(value, 0));
				this.m_lblBuff2.SetColor(XSingleton<UiUtility>.singleton.ParseColor(value2, 0));
				this.m_sprBuff2.SetColor(XSingleton<UiUtility>.singleton.ParseColor(value2, 0));
			}
			else
			{
				this.m_sprBuff1.SetSprite(this._doc.bossBuff1Row.icon);
				this.m_lblBuff1.SetText(this._doc.bossBuff1Row.Comment);
				this.m_sprBuff2.SetSprite(this._doc.bossBuff2Row.icon);
				this.m_lblBuff2.SetText(this._doc.bossBuff2Row.Comment);
				int quality3 = this._doc.bossBuff1Row.Quality;
				int quality4 = this._doc.bossBuff2Row.Quality;
				string value3 = XSingleton<XGlobalConfig>.singleton.GetValue("Quality" + quality3 + "Color");
				string value4 = XSingleton<XGlobalConfig>.singleton.GetValue("Quality" + quality4 + "Color");
				this.m_lblBuff1.SetColor(XSingleton<UiUtility>.singleton.ParseColor(value3, 0));
				this.m_sprBuff1.SetColor(XSingleton<UiUtility>.singleton.ParseColor(value3, 0));
				this.m_lblBuff2.SetColor(XSingleton<UiUtility>.singleton.ParseColor(value4, 0));
				this.m_sprBuff2.SetColor(XSingleton<UiUtility>.singleton.ParseColor(value4, 0));
			}
		}

		private string MakeBossName(string name, int diff)
		{
			return DlgBase<BossRushDlg, BossRushBehavior>.singleton.colors[diff - 1] + name;
		}

		private void UpdateSlider()
		{
			float value = this.m_playCnt / this.m_allCnt;
			this.m_slider.value = value;
		}

		private GameObject PanelObject;

		private IXUILabel m_lblTitle;

		private IXUISprite m_sprIcon;

		private IXUILabel m_lblDiff;

		private IXUIProgress m_slider;

		private IXUISprite m_sprBuff1;

		private IXUILabel m_lblBuff1;

		private IXUISprite m_sprBuff2;

		private IXUILabel m_lblBuff2;

		public GameObject m_objFx;

		public IXUITweenTool m_tween1;

		public IXUITweenTool m_tween2;

		public IXUITweenTool m_tween3;

		private uint m_timertoken = 0U;

		public XBossRefreshAnimHander.State state = XBossRefreshAnimHander.State.None;

		public List<int> frames = new List<int>();

		private XBossBushDocument _doc = null;

		private XElapseTimer timePass = new XElapseTimer();

		private uint m_accTime = 0U;

		private uint m_allCnt = 35U;

		private uint m_playCnt = 0U;

		public enum State
		{

			BEGIN,

			PLAY,

			Idle,

			FADE,

			None
		}
	}
}
