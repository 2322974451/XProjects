using System;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XBattleEnemyInfo
	{

		public int SequenceNum
		{
			get
			{
				return this.m_CurSequence;
			}
			set
			{
				this.m_CurSequence = value;
			}
		}

		public XEntity Entity { get; set; }

		public float HitTime
		{
			get
			{
				return this.m_HitTime;
			}
		}

		public void SwapData(XBattleEnemyInfo other)
		{
			XEntity entity = this.Entity;
			this.Entity = other.Entity;
			other.Entity = entity;
			float hitTime = this.m_HitTime;
			this.m_HitTime = other.m_HitTime;
			other.m_HitTime = hitTime;
			bool bIsSuperArmorBroken = this.m_bIsSuperArmorBroken;
			this.m_bIsSuperArmorBroken = other.m_bIsSuperArmorBroken;
			other.m_bIsSuperArmorBroken = bIsSuperArmorBroken;
		}

		public XBattleEnemyInfo(int index, GameObject go, BattleEnemyType type)
		{
			this.m_CurSequence = index;
			this.m_PreSequence = index;
			this.m_Go = go;
			this.m_Type = type;
			this._InitUI();
		}

		public bool AttachUI(GameObject go)
		{
			bool flag = this.m_Go != null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.m_Go = go;
				this._InitUI();
				result = true;
			}
			return result;
		}

		private void _InitUI()
		{
			bool flag = this.m_Go == null;
			if (flag)
			{
				this.m_uiPanel = null;
				this.m_uiBg = null;
				this.m_uiAvatar = null;
				this.m_uiName = null;
				this.m_uiBeHitTween = null;
				this.m_uiPositionTween = null;
				this.m_uiProgressHp = null;
				this.m_uiSuperArmor = null;
				this.m_uiSuperArmorFx = null;
				this.m_uiSuperArmorSpeedFx = null;
				this.m_uiSpriteHp = null;
				this.m_uiLevel = null;
				this.m_uiHpLabel = null;
				this.m_uiMpLabel = null;
				this.m_BuffMonitor = null;
			}
			else
			{
				Transform transform = this.m_Go.transform;
				this.m_uiPanel = (transform.GetComponent("XUIPanel") as IXUIPanel);
				this.m_uiBg = transform.FindChild("Bg").gameObject;
				this.m_uiAvatar = (transform.FindChild("Bg/Avatar").GetComponent("XUISprite") as IXUISprite);
				this.m_uiName = (transform.FindChild("Bg/PlayerName").GetComponent("XUILabel") as IXUILabel);
				this.m_uiBeHitTween = (this.m_uiBg.GetComponent("XUIPlayTween") as IXUITweenTool);
				this.m_uiPositionTween = (transform.GetComponent("XUIPlayTween") as IXUITweenTool);
				this.m_uiPositionTween.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this._OnTweenPositionFinished));
				bool flag2 = this.m_Type == BattleEnemyType.BET_BOSS;
				if (flag2)
				{
					this.m_uiProgressHp = (transform.FindChild("Bg/HpBar").GetComponent("XUIProgress") as IXUIProgress);
					this.m_uiProgressHp.value = 0f;
					this.m_uiSuperArmor = (transform.FindChild("Bg/SuperArmor").GetComponent("XUIProgress") as IXUIProgress);
					this.m_uiSuperArmorFx = (transform.FindChild("Bg/SuperArmorFx").GetComponent("XUIPlayTween") as IXUITweenTool);
					this.m_uiSuperArmorFx.gameObject.SetActive(false);
					this.m_uiSuperArmorSpeedFx = (transform.FindChild("Bg/SpeedFx").GetComponent("XUISprite") as IXUISprite);
					this.m_uiSuperArmorSpeedFx.gameObject.SetActive(false);
				}
				else
				{
					bool flag3 = this.m_Type == BattleEnemyType.BET_ROLE;
					if (flag3)
					{
						this.m_uiSpriteHp = (transform.FindChild("Bg/HpBar/BackDrop").GetComponent("XUISprite") as IXUISprite);
						this.m_uiSpriteHp.SetFillAmount(0f);
						this.m_uiLevel = (transform.FindChild("Bg/Level").GetComponent("XUILabel") as IXUILabel);
						this.m_uiHpLabel = (transform.Find("Bg/HpText").GetComponent("XUILabel") as IXUILabel);
						this.m_uiMpLabel = (transform.Find("Bg/MpText").GetComponent("XUILabel") as IXUILabel);
						this.m_uiMp = (transform.FindChild("Bg/MpBar/BackDrop").GetComponent("XUISprite") as IXUISprite);
						this.m_uiHpBackDrop = (transform.FindChild("Bg/HpBar/BackDrop").GetComponent("XUISprite") as IXUISprite);
						this.m_uiMp.SetFillAmount(0f);
					}
				}
				DlgHandlerBase.EnsureCreate<XBuffMonitorHandler>(ref this.m_BuffMonitor, transform.Find("Bg/BuffFrame").gameObject, null, true);
				this.m_BuffMonitor.InitMonitor(XSingleton<XGlobalConfig>.singleton.BuffMaxDisplayCountBoss, false, true);
				this.m_Go.SetActive(false);
			}
		}

		public void SetSuperArmorState(bool bBroken)
		{
			this.m_bIsSuperArmorBroken = bBroken;
			bool flag = this.m_uiSuperArmorFx != null;
			if (flag)
			{
				this.m_uiSuperArmorFx.PlayTween(true, -1f);
			}
		}

		public void StopSuperArmorFx()
		{
			bool flag = this.m_uiSuperArmorFx != null;
			if (flag)
			{
				this.m_uiSuperArmorFx.StopTween();
				this.m_uiSuperArmorFx.gameObject.SetActive(false);
			}
		}

		private void _UpdateRole()
		{
			bool deprecated = this.Entity.Deprecated;
			if (!deprecated)
			{
				double attr = this.Entity.Attributes.GetAttr(XAttributeDefine.XAttr_MaxHP_Total);
				double num = this.Entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentHP_Basic);
				bool flag = num < 0.0;
				if (flag)
				{
					num = 0.0;
				}
				bool flag2 = num < attr && !XBattleEnemyInfo.bShow;
				if (flag2)
				{
					XBattleEnemyInfo.bShow = true;
				}
				bool flag3 = this.m_Go == null;
				if (!flag3)
				{
					double attr2 = this.Entity.Attributes.GetAttr(XAttributeDefine.XAttr_MaxMP_Total);
					double num2 = this.Entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentMP_Basic);
					bool flag4 = this.Entity is XRole;
					if (flag4)
					{
						int profID = XFastEnumIntEqualityComparer<RoleType>.ToInt((this.Entity.Attributes as XRoleAttributes).Profession);
						string profHeadIcon = XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon(profID);
						this.m_uiAvatar.spriteName = profHeadIcon;
					}
					else
					{
						this.m_uiAvatar.SetSprite(this.Entity.Present.PresentLib.Avatar, this.Entity.Present.PresentLib.Atlas, false);
					}
					this.m_uiName.SetText(this.Entity.Name);
					this.m_uiLevel.SetText(this.Entity.Attributes.Level.ToString());
					bool flag5 = attr == 0.0;
					if (flag5)
					{
						this.m_uiSpriteHp.SetVisible(false);
						this.m_uiHpLabel.SetVisible(false);
					}
					else
					{
						this.m_uiSpriteHp.SetVisible(true);
						this.m_uiHpLabel.SetVisible(true);
						this.m_uiSpriteHp.SetFillAmount((float)(num / attr));
						this.m_uiHpLabel.SetText(string.Format("{0}/{1}", ((int)num).ToString(), ((int)attr).ToString()));
					}
					bool flag6 = num2 < 0.0;
					if (flag6)
					{
						num2 = 0.0;
					}
					bool flag7 = attr2 == 0.0;
					if (flag7)
					{
						this.m_uiMp.SetVisible(false);
						this.m_uiMpLabel.SetVisible(false);
					}
					else
					{
						this.m_uiMp.SetVisible(true);
						this.m_uiMpLabel.SetVisible(true);
						this.m_uiMp.SetFillAmount((float)(num2 / attr2));
						this.m_uiMpLabel.SetText(string.Format("{0}/{1}", ((int)num2).ToString(), ((int)attr2).ToString()));
					}
				}
			}
		}

		private void _UpdateBoss()
		{
			bool deprecated = this.Entity.Deprecated;
			if (!deprecated)
			{
				double attr = this.Entity.Attributes.GetAttr(XAttributeDefine.XAttr_MaxHP_Total);
				double num = this.Entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentHP_Basic);
				bool flag = num < 0.0;
				if (flag)
				{
					num = 0.0;
				}
				bool flag2 = num < attr && !XBattleEnemyInfo.bShow;
				if (flag2)
				{
					XBattleEnemyInfo.bShow = true;
				}
				bool flag3 = this.m_Go == null;
				if (!flag3)
				{
					XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(this.Entity.TypeID);
					bool flag4 = byID.HpSection > 1U;
					if (flag4)
					{
						this.m_uiProgressHp.SetTotalSection(byID.HpSection);
					}
					else
					{
						this.m_uiProgressHp.SetTotalSection(1U);
					}
					double attr2 = this.Entity.Attributes.GetAttr(XAttributeDefine.XAttr_MaxSuperArmor_Total);
					double attr3 = this.Entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentSuperArmor_Total);
					this.m_uiAvatar.SetSprite(this.Entity.Present.PresentLib.Avatar, this.Entity.Present.PresentLib.Atlas, false);
					this.m_uiName.SetText(this.Entity.Name);
					bool flag5 = num == 0.0;
					if (flag5)
					{
						this.m_uiProgressHp.SetVisible(false);
						this.m_uiSuperArmor.SetVisible(false);
					}
					else
					{
						this.m_uiProgressHp.SetVisible(true);
						this.m_uiSuperArmor.SetVisible(true);
						this.m_uiProgressHp.value = (float)(num / attr);
						bool flag6 = attr2 > 0.0;
						if (flag6)
						{
							this.m_uiSuperArmor.gameObject.SetActive(true);
							bool flag7 = attr3 <= attr2;
							if (flag7)
							{
								this.m_uiSuperArmor.value = (float)(attr3 / attr2);
							}
							bool bIsSuperArmorBroken = this.m_bIsSuperArmorBroken;
							if (bIsSuperArmorBroken)
							{
								this.m_uiSuperArmor.SetForegroundColor(new Color32(140, 219, 0, byte.MaxValue));
							}
							else
							{
								this.m_uiSuperArmor.SetForegroundColor(Color.white);
							}
						}
						else
						{
							this.m_uiSuperArmor.value = 0f;
							this.m_uiSuperArmor.gameObject.SetActive(false);
						}
					}
				}
			}
		}

		public void Update()
		{
			bool flag = this.Entity == null;
			if (!flag)
			{
				bool flag2 = this.m_BuffMonitor != null;
				if (flag2)
				{
					this.m_BuffMonitor.OnUpdate();
				}
				bool flag3 = this.m_Type == BattleEnemyType.BET_BOSS;
				if (flag3)
				{
					this._UpdateBoss();
				}
				else
				{
					bool flag4 = this.m_Type == BattleEnemyType.BET_ROLE;
					if (flag4)
					{
						this._UpdateRole();
					}
				}
			}
		}

		public void SetVisible(bool bShow)
		{
			bool flag = this.m_Go != null;
			if (flag)
			{
				this.m_Go.SetActive(bShow);
			}
		}

		public bool bNotBeHitRecently
		{
			get
			{
				return Time.time - this.m_HitTime > XBattleEnemyInfo.fNotBeHitTime;
			}
		}

		public bool IsRecentlyHit(float fMainTargetHitTime)
		{
			return this.m_HitTime > fMainTargetHitTime + XBattleEnemyInfo.fNotBeHitTime;
		}

		public void SetPosition(bool bAnim)
		{
			bool flag = this.m_CurSequence == this.m_PreSequence;
			if (flag)
			{
				if (bAnim)
				{
					return;
				}
				bool flag2 = this.m_CurSequence == 0;
				if (flag2)
				{
					this.m_PreSequence = 1;
				}
				else
				{
					this.m_PreSequence = 0;
				}
			}
			else
			{
				bool flag3 = this.m_PreSequence * this.m_CurSequence != 0;
				if (flag3)
				{
					bool flag4 = !bAnim;
					if (flag4)
					{
						this.m_PreSequence = 0;
					}
				}
			}
			int num = this.m_PreSequence * 10 + this.m_CurSequence;
			bool flag5 = this.m_uiPanel != null;
			if (flag5)
			{
				if (bAnim)
				{
					this.m_uiPanel.SetDepth(30 - num);
					this.m_uiPositionTween.SetTweenGroup(num);
					this.m_uiPositionTween.PlayTween(true, -1f);
				}
				else
				{
					this.m_uiPanel.SetDepth(0);
					this.m_uiPositionTween.ResetTweenByGroup(false, num);
				}
			}
			this.m_PreSequence = this.m_CurSequence;
		}

		private void _OnTweenPositionFinished(IXUITweenTool tween)
		{
			bool flag = this.m_uiPanel != null;
			if (flag)
			{
				this.m_uiPanel.SetDepth(0);
			}
		}

		public void OnBeHit(ProjectDamageResult result)
		{
			bool flag = result.Value <= 0.0;
			if (!flag)
			{
				bool flag2 = this.m_uiBeHitTween != null;
				if (flag2)
				{
					this.m_uiBeHitTween.PlayTween(true, -1f);
				}
				this.m_HitTime = Time.time;
			}
		}

		public void RefreshBuff()
		{
			bool flag = this.Entity == null || this.Entity.Deprecated;
			if (!flag)
			{
				bool flag2 = this.Entity.Buffs != null && this.m_BuffMonitor != null;
				if (flag2)
				{
					this.m_BuffMonitor.OnBuffChanged(this.Entity.Buffs.GetUIBuffList());
				}
			}
		}

		public void Unload()
		{
			DlgHandlerBase.EnsureUnload<XBuffMonitorHandler>(ref this.m_BuffMonitor);
		}

		public static bool bShow;

		public static float fNotBeHitTime = 3f;

		private int m_CurSequence;

		private int m_PreSequence;

		public GameObject m_Go;

		private BattleEnemyType m_Type;

		private float m_HitTime = 0f;

		private bool m_bIsSuperArmorBroken = false;

		public GameObject m_uiBg = null;

		public IXUISprite m_uiAvatar = null;

		public IXUILabel m_uiName = null;

		public IXUIProgress m_uiProgressHp = null;

		public IXUISprite m_uiSpriteHp = null;

		public IXUISprite m_uiHpBackDrop = null;

		public IXUIProgress m_uiSuperArmor = null;

		public IXUISprite m_uiMp = null;

		public IXUITweenTool m_uiSuperArmorFx = null;

		public IXUISprite m_uiSuperArmorSpeedFx = null;

		public IXUITweenTool m_uiBeHitTween;

		public IXUITweenTool m_uiPositionTween;

		public IXUIPanel m_uiPanel;

		public IXUILabel m_uiLevel;

		public IXUILabel m_uiHpLabel;

		public IXUILabel m_uiMpLabel;

		public XBuffMonitorHandler m_BuffMonitor;
	}
}
