using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XLevelUpStatusView : DlgBase<XLevelUpStatusView, XLevelUpStatusBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/LevelUpStatusDlg";
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
			base.uiBehaviour.m_iPlayTween.SetTargetGameObject(base.uiBehaviour.m_iPlayTween.gameObject);
			base.uiBehaviour.m_iPlayTween.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnPlayTweenFinish));
			this._doc = XDocuments.GetSpecificDocument<XLevelUpStatusDocument>(XLevelUpStatusDocument.uuID);
			base.uiBehaviour.m_AttrFrame.SetActive(false);
			base.uiBehaviour.m_FishFrame.SetActive(false);
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
		}

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

		public void OnPlayTweenFinish(IXUITweenTool iPlayTween)
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				this.SetVisible(false, true);
			}
		}

		public bool OnCloseClick(IXUIButton button)
		{
			bool flag = this.canClose;
			if (flag)
			{
				this.SetVisible(false, true);
			}
			return true;
		}

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

		public void ShowLevelUpStatus()
		{
			base.uiBehaviour.m_Close.gameObject.GetComponent<Collider>().enabled = true;
			this.canClose = false;
			this.Handler(null);
			base.uiBehaviour.m_tweenLevel.ResetTween(true);
			base.uiBehaviour.m_tweenLevel.PlayTween(true, -1f);
		}

		private void Handler(object arg)
		{
			this.timetoken = XSingleton<XTimerMgr>.singleton.SetTimer(2f, new XTimerMgr.ElapsedEventHandler(this.EnableCollider), null);
			base.uiBehaviour.m_objWing.SetActive(false);
			base.uiBehaviour.m_iPlayTween.gameObject.SetActive(true);
			this.ShowLevelUp();
		}

		private void EnableCollider(object o)
		{
			this.canClose = true;
			this._doc.PreLevel = 0U;
			this._doc.CurLevel = 0U;
		}

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

		private XLevelUpStatusDocument _doc;

		private uint timetoken = 0U;

		private bool canClose = false;

		private XAttributeDefine[] AttrInfos = new XAttributeDefine[]
		{
			XAttributeDefine.XAttr_Strength_Total,
			XAttributeDefine.XAttr_Agility_Total,
			XAttributeDefine.XAttr_Intelligence_Total,
			XAttributeDefine.XAttr_Vitality_Total
		};
	}
}
