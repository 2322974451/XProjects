using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200181B RID: 6171
	public class XBossRefreshAnimHander : XSingleton<XBossRefreshAnimHander>
	{
		// Token: 0x06010030 RID: 65584 RVA: 0x003CC9F4 File Offset: 0x003CABF4
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

		// Token: 0x06010031 RID: 65585 RVA: 0x003CCC30 File Offset: 0x003CAE30
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

		// Token: 0x06010032 RID: 65586 RVA: 0x003CCC94 File Offset: 0x003CAE94
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

		// Token: 0x06010033 RID: 65587 RVA: 0x003CCEE0 File Offset: 0x003CB0E0
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

		// Token: 0x06010034 RID: 65588 RVA: 0x003CCF50 File Offset: 0x003CB150
		public void OnUnload()
		{
			bool flag = this.m_timertoken > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this.m_timertoken);
			}
		}

		// Token: 0x06010035 RID: 65589 RVA: 0x003CCF80 File Offset: 0x003CB180
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

		// Token: 0x06010036 RID: 65590 RVA: 0x003CCFEE File Offset: 0x003CB1EE
		private void PlayEndTimer(object o)
		{
			this.state = XBossRefreshAnimHander.State.FADE;
		}

		// Token: 0x06010037 RID: 65591 RVA: 0x003CCFF8 File Offset: 0x003CB1F8
		private void RefreshRandBoss()
		{
			int num = XBossBushDocument.bossRushTable.Table.Length - 2;
			int uid = UnityEngine.Random.Range(1, num);
			this.RefreshBoss(uid, true);
		}

		// Token: 0x06010038 RID: 65592 RVA: 0x003CD028 File Offset: 0x003CB228
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

		// Token: 0x06010039 RID: 65593 RVA: 0x003CD33C File Offset: 0x003CB53C
		private string MakeBossName(string name, int diff)
		{
			return DlgBase<BossRushDlg, BossRushBehavior>.singleton.colors[diff - 1] + name;
		}

		// Token: 0x0601003A RID: 65594 RVA: 0x003CD364 File Offset: 0x003CB564
		private void UpdateSlider()
		{
			float value = this.m_playCnt / this.m_allCnt;
			this.m_slider.value = value;
		}

		// Token: 0x040071A8 RID: 29096
		private GameObject PanelObject;

		// Token: 0x040071A9 RID: 29097
		private IXUILabel m_lblTitle;

		// Token: 0x040071AA RID: 29098
		private IXUISprite m_sprIcon;

		// Token: 0x040071AB RID: 29099
		private IXUILabel m_lblDiff;

		// Token: 0x040071AC RID: 29100
		private IXUIProgress m_slider;

		// Token: 0x040071AD RID: 29101
		private IXUISprite m_sprBuff1;

		// Token: 0x040071AE RID: 29102
		private IXUILabel m_lblBuff1;

		// Token: 0x040071AF RID: 29103
		private IXUISprite m_sprBuff2;

		// Token: 0x040071B0 RID: 29104
		private IXUILabel m_lblBuff2;

		// Token: 0x040071B1 RID: 29105
		public GameObject m_objFx;

		// Token: 0x040071B2 RID: 29106
		public IXUITweenTool m_tween1;

		// Token: 0x040071B3 RID: 29107
		public IXUITweenTool m_tween2;

		// Token: 0x040071B4 RID: 29108
		public IXUITweenTool m_tween3;

		// Token: 0x040071B5 RID: 29109
		private uint m_timertoken = 0U;

		// Token: 0x040071B6 RID: 29110
		public XBossRefreshAnimHander.State state = XBossRefreshAnimHander.State.None;

		// Token: 0x040071B7 RID: 29111
		public List<int> frames = new List<int>();

		// Token: 0x040071B8 RID: 29112
		private XBossBushDocument _doc = null;

		// Token: 0x040071B9 RID: 29113
		private XElapseTimer timePass = new XElapseTimer();

		// Token: 0x040071BA RID: 29114
		private uint m_accTime = 0U;

		// Token: 0x040071BB RID: 29115
		private uint m_allCnt = 35U;

		// Token: 0x040071BC RID: 29116
		private uint m_playCnt = 0U;

		// Token: 0x02001A12 RID: 6674
		public enum State
		{
			// Token: 0x04008234 RID: 33332
			BEGIN,
			// Token: 0x04008235 RID: 33333
			PLAY,
			// Token: 0x04008236 RID: 33334
			Idle,
			// Token: 0x04008237 RID: 33335
			FADE,
			// Token: 0x04008238 RID: 33336
			None
		}
	}
}
