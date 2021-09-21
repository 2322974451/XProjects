using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200181C RID: 6172
	public class BossRushBehavior : DlgBehaviourBase
	{
		// Token: 0x0601003C RID: 65596 RVA: 0x003CD3EC File Offset: 0x003CB5EC
		private void Awake()
		{
			this.m_sprVip = (base.transform.Find("Bg/tq").GetComponent("XUISprite") as IXUISprite);
			this.m_lblPrivilege = (base.transform.Find("Bg/tq/t").GetComponent("XUILabel") as IXUILabel);
			this.m_sprPrivilegeBg = (base.transform.Find("Bg/tq/p").GetComponent("XUISprite") as IXUISprite);
			this.m_Help = (base.transform.Find("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_lblLayer = (base.transform.Find("Bg/left/Layer").GetComponent("XUILabel") as IXUILabel);
			this.m_lblProgress = (base.transform.Find("Bg/left/RemainTime").GetComponent("XUILabel") as IXUILabel);
			this.m_lblTitle = (base.transform.Find("Bg/left/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_lblDiff = (base.transform.Find("Bg/left/Diff").GetComponent("XUILabel") as IXUILabel);
			this.m_lblDesc = (base.transform.Find("Bg/left/Boss/SkillName").GetComponent("XUILabel") as IXUILabel);
			this.m_objAtt = base.transform.Find("Bg/left/Boss/T/attTpl").gameObject;
			this.m_objDef = base.transform.Find("Bg/left/Boss/T/attTpl").gameObject;
			this.m_objLife = base.transform.Find("Bg/left/Boss/T/attTpl").gameObject;
			this.m_btnClose = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_lblLeft = (base.transform.Find("Bg/times").GetComponent("XUILabel") as IXUILabel);
			this.m_objRwd = base.transform.Find("Bg/right/T1/ItemTpl").gameObject;
			this.m_sprBuff1 = (base.transform.Find("Bg/right/T2/Icon1").GetComponent("XUISprite") as IXUISprite);
			this.m_sprBuff2 = (base.transform.Find("Bg/right/T2/Icon").GetComponent("XUISprite") as IXUISprite);
			this.m_lblBuff1 = (base.transform.Find("Bg/right/T2/Icon1/T2").GetComponent("XUILabel") as IXUILabel);
			this.m_lblBuff2 = (base.transform.Find("Bg/right/T2/Icon/T2").GetComponent("XUILabel") as IXUILabel);
			this.m_txtBoss = (base.transform.Find("Bg/Boss").GetComponent("XUITexture") as IXUITexture);
			this.m_lblRefresh = (base.transform.Find("Bg/btm/Refresh/Ti1").GetComponent("XUILabel") as IXUILabel);
			this.m_lblFree = (base.transform.Find("Bg/btm/Refresh/free").GetComponent("XUILabel") as IXUILabel);
			this.m_sprCoin = (base.transform.Find("Bg/btm/Refresh/P").GetComponent("XUISprite") as IXUISprite);
			this.m_lblCost = (base.transform.Find("Bg/btm/Refresh/P/T1").GetComponent("XUILabel") as IXUILabel);
			this.m_btnRefesh = (base.transform.Find("Bg/btm/Refresh").GetComponent("XUIButton") as IXUIButton);
			this.m_btnBattle = (base.transform.Find("Bg/btm/Go").GetComponent("XUIButton") as IXUIButton);
			this.m_lblBattle = (base.transform.Find("Bg/btm/Go/T1").GetComponent("XUILabel") as IXUILabel);
			this.m_sprBg = (base.transform.Find("Bg").GetComponent("XUISprite") as IXUISprite);
			this.m_objFx = base.transform.Find("Bg/effect").gameObject;
			this.m_objFx.SetActive(false);
			this.m_attpool.SetupPool(this.m_objAtt.transform.parent.gameObject, this.m_objAtt, 2U, true);
			this.m_defpool.SetupPool(this.m_objDef.transform.parent.gameObject, this.m_objDef, 2U, true);
			this.m_lifepool.SetupPool(this.m_objLife.transform.parent.gameObject, this.m_objLife, 2U, true);
			this.m_rwdpool.SetupPool(this.m_objRwd.transform.parent.gameObject, this.m_objRwd, 2U, true);
			this.m_BossSnapshot = (base.transform.Find("Bg/Boss").GetComponent("UIDummy") as IUIDummy);
			this.m_SweepButton = (base.transform.Find("Bg/btm/SweepButton").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x0601003D RID: 65597 RVA: 0x003CD8F4 File Offset: 0x003CBAF4
		public void LoadBossAndStart()
		{
			base.StartCoroutine(DlgBase<BossRushDlg, BossRushBehavior>.singleton.LoadBossAssets());
		}

		// Token: 0x0601003E RID: 65598 RVA: 0x003CD908 File Offset: 0x003CBB08
		public void ResetPool()
		{
			this.m_attpool.ReturnAll(false);
			this.m_defpool.ReturnAll(false);
			this.m_lifepool.ReturnAll(false);
			this.m_rwdpool.ReturnAll(false);
		}

		// Token: 0x040071BD RID: 29117
		public IXUISprite m_sprBg;

		// Token: 0x040071BE RID: 29118
		public IXUILabel m_lblLayer;

		// Token: 0x040071BF RID: 29119
		public IXUILabel m_lblProgress;

		// Token: 0x040071C0 RID: 29120
		public IXUILabel m_lblTitle;

		// Token: 0x040071C1 RID: 29121
		public IXUILabel m_lblDiff;

		// Token: 0x040071C2 RID: 29122
		public GameObject m_objAtt;

		// Token: 0x040071C3 RID: 29123
		public GameObject m_objDef;

		// Token: 0x040071C4 RID: 29124
		public GameObject m_objLife;

		// Token: 0x040071C5 RID: 29125
		public IXUILabel m_lblDesc;

		// Token: 0x040071C6 RID: 29126
		public IXUILabel m_lblLeft;

		// Token: 0x040071C7 RID: 29127
		public IXUIButton m_btnClose;

		// Token: 0x040071C8 RID: 29128
		public IXUIButton m_Help;

		// Token: 0x040071C9 RID: 29129
		public IXUISprite m_sprVip;

		// Token: 0x040071CA RID: 29130
		public IXUISprite m_sprPrivilegeBg;

		// Token: 0x040071CB RID: 29131
		public IXUILabel m_lblPrivilege;

		// Token: 0x040071CC RID: 29132
		public IXUITexture m_txtBoss;

		// Token: 0x040071CD RID: 29133
		public XUIPool m_attpool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040071CE RID: 29134
		public XUIPool m_defpool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040071CF RID: 29135
		public XUIPool m_lifepool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040071D0 RID: 29136
		public GameObject m_objRwd;

		// Token: 0x040071D1 RID: 29137
		public IXUISprite m_sprBuff1;

		// Token: 0x040071D2 RID: 29138
		public IXUISprite m_sprBuff2;

		// Token: 0x040071D3 RID: 29139
		public IXUILabel m_lblBuff1;

		// Token: 0x040071D4 RID: 29140
		public IXUILabel m_lblBuff2;

		// Token: 0x040071D5 RID: 29141
		public XUIPool m_rwdpool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040071D6 RID: 29142
		public IXUILabel m_lblRefresh;

		// Token: 0x040071D7 RID: 29143
		public IXUILabel m_lblFree;

		// Token: 0x040071D8 RID: 29144
		public IXUISprite m_sprCoin;

		// Token: 0x040071D9 RID: 29145
		public IXUILabel m_lblCost;

		// Token: 0x040071DA RID: 29146
		public IXUIButton m_btnRefesh;

		// Token: 0x040071DB RID: 29147
		public IXUIButton m_btnBattle;

		// Token: 0x040071DC RID: 29148
		public IXUILabel m_lblBattle;

		// Token: 0x040071DD RID: 29149
		public GameObject m_objFx;

		// Token: 0x040071DE RID: 29150
		public IUIDummy m_BossSnapshot;

		// Token: 0x040071DF RID: 29151
		public IXUIButton m_SweepButton;
	}
}
