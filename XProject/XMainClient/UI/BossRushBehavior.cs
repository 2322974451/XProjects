using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	public class BossRushBehavior : DlgBehaviourBase
	{

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

		public void LoadBossAndStart()
		{
			base.StartCoroutine(DlgBase<BossRushDlg, BossRushBehavior>.singleton.LoadBossAssets());
		}

		public void ResetPool()
		{
			this.m_attpool.ReturnAll(false);
			this.m_defpool.ReturnAll(false);
			this.m_lifepool.ReturnAll(false);
			this.m_rwdpool.ReturnAll(false);
		}

		public IXUISprite m_sprBg;

		public IXUILabel m_lblLayer;

		public IXUILabel m_lblProgress;

		public IXUILabel m_lblTitle;

		public IXUILabel m_lblDiff;

		public GameObject m_objAtt;

		public GameObject m_objDef;

		public GameObject m_objLife;

		public IXUILabel m_lblDesc;

		public IXUILabel m_lblLeft;

		public IXUIButton m_btnClose;

		public IXUIButton m_Help;

		public IXUISprite m_sprVip;

		public IXUISprite m_sprPrivilegeBg;

		public IXUILabel m_lblPrivilege;

		public IXUITexture m_txtBoss;

		public XUIPool m_attpool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_defpool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_lifepool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public GameObject m_objRwd;

		public IXUISprite m_sprBuff1;

		public IXUISprite m_sprBuff2;

		public IXUILabel m_lblBuff1;

		public IXUILabel m_lblBuff2;

		public XUIPool m_rwdpool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUILabel m_lblRefresh;

		public IXUILabel m_lblFree;

		public IXUISprite m_sprCoin;

		public IXUILabel m_lblCost;

		public IXUIButton m_btnRefesh;

		public IXUIButton m_btnBattle;

		public IXUILabel m_lblBattle;

		public GameObject m_objFx;

		public IUIDummy m_BossSnapshot;

		public IXUIButton m_SweepButton;
	}
}
