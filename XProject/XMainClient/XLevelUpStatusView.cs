using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E49 RID: 3657
	internal class XLevelUpStatusView : DlgBase<XLevelUpStatusView, XLevelUpStatusBehaviour>
	{
		// Token: 0x17003460 RID: 13408
		// (get) Token: 0x0600C447 RID: 50247 RVA: 0x002ACF64 File Offset: 0x002AB164
		public override string fileName
		{
			get
			{
				return "GameSystem/LevelUpStatusDlg";
			}
		}

		// Token: 0x17003461 RID: 13409
		// (get) Token: 0x0600C448 RID: 50248 RVA: 0x002ACF7C File Offset: 0x002AB17C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600C449 RID: 50249 RVA: 0x002ACF90 File Offset: 0x002AB190
		protected override void Init()
		{
			base.Init();
			base.uiBehaviour.m_iPlayTween.SetTargetGameObject(base.uiBehaviour.m_iPlayTween.gameObject);
			base.uiBehaviour.m_iPlayTween.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnPlayTweenFinish));
			this._doc = XDocuments.GetSpecificDocument<XLevelUpStatusDocument>(XLevelUpStatusDocument.uuID);
			base.uiBehaviour.m_AttrFrame.SetActive(false);
			base.uiBehaviour.m_FishFrame.SetActive(false);
		}

		// Token: 0x0600C44A RID: 50250 RVA: 0x002AD017 File Offset: 0x002AB217
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
		}

		// Token: 0x0600C44B RID: 50251 RVA: 0x002AD038 File Offset: 0x002AB238
		protected override void OnHide()
		{
			base.OnHide();
			base.uiBehaviour.m_AttrFrame.SetActive(false);
			base.uiBehaviour.m_FishFrame.SetActive(false);
			bool flag = this.timetoken > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this.timetoken);
			}
		}

		// Token: 0x0600C44C RID: 50252 RVA: 0x002AD090 File Offset: 0x002AB290
		public void OnPlayTweenFinish(IXUITweenTool iPlayTween)
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				this.SetVisible(false, true);
			}
		}

		// Token: 0x0600C44D RID: 50253 RVA: 0x002AD0B4 File Offset: 0x002AB2B4
		public bool OnCloseClick(IXUIButton button)
		{
			bool flag = this.canClose;
			if (flag)
			{
				this.SetVisible(false, true);
			}
			return true;
		}

		// Token: 0x0600C44E RID: 50254 RVA: 0x002AD0DC File Offset: 0x002AB2DC
		private void PlayWingEff()
		{
			uint curLevel = this._doc.CurLevel;
			uint preLevel = this._doc.PreLevel;
			bool flag = curLevel > preLevel;
			if (flag)
			{
				base.uiBehaviour.m_iPlayTween.gameObject.SetActive(false);
				base.uiBehaviour.m_objWing.SetActive(true);
				base.uiBehaviour.m_lblLevel.SetText(curLevel.ToString());
				this.timetoken = XSingleton<XTimerMgr>.singleton.SetTimer(1.4f, new XTimerMgr.ElapsedEventHandler(this.Handler), null);
			}
			else
			{
				this.Handler(null);
			}
		}

		// Token: 0x0600C44F RID: 50255 RVA: 0x002AD17C File Offset: 0x002AB37C
		public void ShowLevelUpStatus()
		{
			base.uiBehaviour.m_Close.gameObject.GetComponent<Collider>().enabled = true;
			this.canClose = false;
			this.Handler(null);
			base.uiBehaviour.m_tweenLevel.ResetTween(true);
			base.uiBehaviour.m_tweenLevel.PlayTween(true, -1f);
		}

		// Token: 0x0600C450 RID: 50256 RVA: 0x002AD1E0 File Offset: 0x002AB3E0
		private void Handler(object arg)
		{
			this.timetoken = XSingleton<XTimerMgr>.singleton.SetTimer(2f, new XTimerMgr.ElapsedEventHandler(this.EnableCollider), null);
			base.uiBehaviour.m_objWing.SetActive(false);
			base.uiBehaviour.m_iPlayTween.gameObject.SetActive(true);
			this.ShowLevelUp();
		}

		// Token: 0x0600C451 RID: 50257 RVA: 0x002AD240 File Offset: 0x002AB440
		private void EnableCollider(object o)
		{
			this.canClose = true;
			this._doc.PreLevel = 0U;
			this._doc.CurLevel = 0U;
		}

		// Token: 0x0600C452 RID: 50258 RVA: 0x002AD264 File Offset: 0x002AB464
		public void ShowLevelUp()
		{
			base.uiBehaviour.m_AttrFrame.SetActive(true);
			base.uiBehaviour.m_AttrPool.ReturnAll(false);
			GameObject gameObject = base.uiBehaviour.m_AttrPool.FetchGameObject(false);
			IXUILabel ixuilabel = gameObject.transform.FindChild("AttrName").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(XStringDefineProxy.GetString("XAttr_Level"));
			IXUILabel ixuilabel2 = gameObject.transform.FindChild("PreValue").GetComponent("XUILabel") as IXUILabel;
			ixuilabel2.SetText(this._doc.PreLevel.ToString());
			IXUILabel ixuilabel3 = gameObject.transform.FindChild("CurValue").GetComponent("XUILabel") as IXUILabel;
			ixuilabel3.SetText(this._doc.CurLevel.ToString());
			gameObject.SetActive(false);
			this.m_uiBehaviour.m_lblSkillPoint.SetText("x" + this.SkillPoint(this._doc.CurLevel).ToString());
			this.m_uiBehaviour.m_lblCurrLevel.SetText(this._doc.CurLevel.ToString());
			for (int i = 0; i < this._doc.AttrID.Count; i++)
			{
				gameObject = base.uiBehaviour.m_AttrPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3(base.uiBehaviour.m_AttrPool.TplPos.x, base.uiBehaviour.m_AttrPool.TplPos.y - (float)(base.uiBehaviour.m_AttrPool.TplHeight * i), base.uiBehaviour.m_AttrPool.TplPos.z);
				ixuilabel = (gameObject.transform.FindChild("AttrName").GetComponent("XUILabel") as IXUILabel);
				ixuilabel.SetText(XStringDefineProxy.GetString(((XAttributeDefine)this._doc.AttrID[i]).ToString()));
				ixuilabel2 = (gameObject.transform.FindChild("PreValue").GetComponent("XUILabel") as IXUILabel);
				ixuilabel2.SetText(this._doc.AttrOldValue[i].ToString());
				ixuilabel3 = (gameObject.transform.FindChild("CurValue").GetComponent("XUILabel") as IXUILabel);
				ixuilabel3.SetText(this._doc.AttrNewValue[i].ToString());
			}
			bool flag = this._doc.NewSkillID.Count != 0;
			if (flag)
			{
				base.uiBehaviour.m_NewSkillFrame.gameObject.SetActive(true);
				base.uiBehaviour.m_sprSkillBg.spriteHeight = 550;
				base.uiBehaviour.m_SkillPool.ReturnAll(false);
				for (int j = 0; j < this._doc.NewSkillID.Count; j++)
				{
					gameObject = base.uiBehaviour.m_SkillPool.FetchGameObject(false);
					SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(this._doc.NewSkillID[j], 0U);
					IXUISprite ixuisprite = gameObject.GetComponent("XUISprite") as IXUISprite;
					IXUISprite ixuisprite2 = gameObject.transform.FindChild("Bg").GetComponent("XUISprite") as IXUISprite;
					bool flag2 = skillConfig.SkillType == 3;
					if (flag2)
					{
						ixuisprite2.SetSprite("JN_bd0");
					}
					else
					{
						bool flag3 = skillConfig.SkillType == 2;
						if (flag3)
						{
							ixuisprite2.SetSprite("JN_dk_0");
						}
						else
						{
							ixuisprite2.SetSprite("JN_dk");
						}
					}
					ixuisprite.SetSprite(skillConfig.Icon, skillConfig.Atlas, false);
					gameObject.transform.localPosition = new Vector3(base.uiBehaviour.m_SkillPool.TplPos.x - (float)(this._doc.NewSkillID.Count - 1 - j * 2) / 2f * (float)ixuisprite2.spriteWidth, base.uiBehaviour.m_SkillPool.TplPos.y);
				}
			}
			else
			{
				base.uiBehaviour.m_NewSkillFrame.gameObject.SetActive(false);
				base.uiBehaviour.m_sprSkillBg.spriteHeight = 400;
			}
			base.uiBehaviour.m_iPlayTween.PlayTween(true, -1f);
		}

		// Token: 0x0600C453 RID: 50259 RVA: 0x002AD728 File Offset: 0x002AB928
		public int SkillPoint(uint level)
		{
			PlayerLevelTable levelTable = XSingleton<XEntityMgr>.singleton.LevelTable;
			for (int i = 0; i < levelTable.Table.Length; i++)
			{
				bool flag = (long)levelTable.Table[i].Level == (long)((ulong)level);
				if (flag)
				{
					return levelTable.Table[i].AddSkillPoint;
				}
			}
			return 1;
		}

		// Token: 0x0400555C RID: 21852
		private XLevelUpStatusDocument _doc;

		// Token: 0x0400555D RID: 21853
		private uint timetoken = 0U;

		// Token: 0x0400555E RID: 21854
		private bool canClose = false;

		// Token: 0x0400555F RID: 21855
		private XAttributeDefine[] AttrInfos = new XAttributeDefine[]
		{
			XAttributeDefine.XAttr_Strength_Total,
			XAttributeDefine.XAttr_Agility_Total,
			XAttributeDefine.XAttr_Intelligence_Total,
			XAttributeDefine.XAttr_Vitality_Total
		};
	}
}
