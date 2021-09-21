using System;
using UILib;
using UnityEngine;
using XMainClient.UI.Battle;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001725 RID: 5925
	internal class BattleQTEDlg : DlgBase<BattleQTEDlg, BattleQTEDlgBehaviour>
	{
		// Token: 0x170037AD RID: 14253
		// (get) Token: 0x0600F4A5 RID: 62629 RVA: 0x0036FA60 File Offset: 0x0036DC60
		public override string fileName
		{
			get
			{
				return "Battle/BattleQTEDlg";
			}
		}

		// Token: 0x170037AE RID: 14254
		// (get) Token: 0x0600F4A6 RID: 62630 RVA: 0x0036FA78 File Offset: 0x0036DC78
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170037AF RID: 14255
		// (get) Token: 0x0600F4A7 RID: 62631 RVA: 0x0036FA8C File Offset: 0x0036DC8C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600F4A8 RID: 62632 RVA: 0x0036FA9F File Offset: 0x0036DC9F
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XBattleDocument>(XBattleDocument.uuID);
		}

		// Token: 0x0600F4A9 RID: 62633 RVA: 0x0036FAB9 File Offset: 0x0036DCB9
		public void SetStatus(QteUIType type, bool status)
		{
			this._type = type;
			this.SetVisible(status, true);
		}

		// Token: 0x0600F4AA RID: 62634 RVA: 0x0036FACC File Offset: 0x0036DCCC
		public void SetChargeValue(float value)
		{
			this._charge_value = value;
			base.uiBehaviour.m_ChargeBar.Value = this._charge_value;
		}

		// Token: 0x0600F4AB RID: 62635 RVA: 0x0036FAED File Offset: 0x0036DCED
		public void SetAbnormalValue(float value)
		{
			this._abnormal_delta = value;
		}

		// Token: 0x0600F4AC RID: 62636 RVA: 0x0036FAF8 File Offset: 0x0036DCF8
		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_Bind.gameObject.SetActive(this._type == QteUIType.Bind);
			base.uiBehaviour.m_Abnormal.gameObject.SetActive(this._type == QteUIType.Abnormal);
			base.uiBehaviour.m_Charge.gameObject.SetActive(this._type == QteUIType.Charge);
			base.uiBehaviour.m_Block.gameObject.SetActive(this._type != QteUIType.Charge);
			switch (this._type)
			{
			case QteUIType.Bind:
			{
				base.uiBehaviour.m_BindLeftButton.SetVisible(true);
				base.uiBehaviour.m_BindRightButton.SetVisible(false);
				base.uiBehaviour.m_BindArrow.localPosition = new Vector3(base.uiBehaviour.m_BindLeftButton.parent.gameObject.transform.localPosition.x, 0f);
				bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() && DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler != null;
				if (flag)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.SetVisible(false);
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.ResetPressState();
				}
				break;
			}
			case QteUIType.Abnormal:
			{
				this._abnormal_flag = true;
				this._abnormal_wait = 0;
				this._abnormal_send_wait = 0;
				base.uiBehaviour.m_AbnormalBar.Value = 0f;
				base.uiBehaviour.m_AbnormalSuccessTween.gameObject.SetActive(false);
				base.uiBehaviour.m_AbnormalFailTween.gameObject.SetActive(false);
				base.uiBehaviour.m_AbnormalHitTween.gameObject.SetActive(false);
				base.uiBehaviour.m_AbnormalBeginTween.PlayTween(true, -1f);
				bool flag2 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() && DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler != null;
				if (flag2)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.SetVisible(false);
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.ResetPressState();
				}
				break;
			}
			case QteUIType.Charge:
				base.uiBehaviour.m_ChargeBar.Value = this._charge_value;
				break;
			}
		}

		// Token: 0x0600F4AD RID: 62637 RVA: 0x0036FD40 File Offset: 0x0036DF40
		protected override void OnHide()
		{
			base.OnHide();
			QteUIType type = this._type;
			if (type > QteUIType.Abnormal)
			{
				if (type != QteUIType.Charge)
				{
				}
			}
			else
			{
				bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() && DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler != null;
				if (flag)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.SetVisible(true);
				}
			}
		}

		// Token: 0x0600F4AE RID: 62638 RVA: 0x0036FDA4 File Offset: 0x0036DFA4
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_BindLeftButton.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnBindLeftButtonClick));
			base.uiBehaviour.m_BindRightButton.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnBindRightButtonClick));
			base.uiBehaviour.m_AbnormalClickSpace.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnAbnormalClicked));
		}

		// Token: 0x0600F4AF RID: 62639 RVA: 0x0036FE10 File Offset: 0x0036E010
		private void OnBindLeftButtonClick(IXUISprite sp)
		{
			base.uiBehaviour.m_BindLeftButton.SetVisible(false);
			base.uiBehaviour.m_BindRightButton.SetVisible(true);
			base.uiBehaviour.m_BindArrow.localPosition = new Vector3(base.uiBehaviour.m_BindRightButton.parent.gameObject.transform.localPosition.x, 0f);
			this.SendBindOperation();
		}

		// Token: 0x0600F4B0 RID: 62640 RVA: 0x0036FE88 File Offset: 0x0036E088
		private void OnBindRightButtonClick(IXUISprite sp)
		{
			base.uiBehaviour.m_BindLeftButton.SetVisible(true);
			base.uiBehaviour.m_BindRightButton.SetVisible(false);
			base.uiBehaviour.m_BindArrow.localPosition = new Vector3(base.uiBehaviour.m_BindLeftButton.parent.gameObject.transform.localPosition.x, 0f);
			this.SendBindOperation();
		}

		// Token: 0x0600F4B1 RID: 62641 RVA: 0x0036FF00 File Offset: 0x0036E100
		private void OnAbnormalClicked(IXUISprite sp)
		{
			bool flag = !this._abnormal_flag;
			if (!flag)
			{
				this._abnormal_flag = false;
				bool flag2 = base.uiBehaviour.m_AbnormalLeftTarget.localPosition.x <= base.uiBehaviour.m_AbnormalThumb.localPosition.x && base.uiBehaviour.m_AbnormalRightTarget.localPosition.x >= base.uiBehaviour.m_AbnormalThumb.localPosition.x;
				if (flag2)
				{
					base.uiBehaviour.m_AbnormalSuccessTween.PlayTween(true, -1f);
					base.uiBehaviour.m_AbnormalHitTween.PlayTween(true, -1f);
					this._abnormal_send_wait = 30;
				}
				else
				{
					base.uiBehaviour.m_AbnormalFailTween.PlayTween(true, -1f);
					this._abnormal_wait = 30;
				}
			}
		}

		// Token: 0x0600F4B2 RID: 62642 RVA: 0x0036FFE4 File Offset: 0x0036E1E4
		private void SendCheckAbnormalOperation()
		{
			PtcC2G_QTEOperation ptcC2G_QTEOperation = new PtcC2G_QTEOperation();
			ptcC2G_QTEOperation.Data.type = 2U;
			ptcC2G_QTEOperation.Data.monsterid = (ulong)((long)this._doc.AbnormalBuffID);
			XSingleton<XClientNetwork>.singleton.Send(ptcC2G_QTEOperation);
		}

		// Token: 0x0600F4B3 RID: 62643 RVA: 0x0037002C File Offset: 0x0036E22C
		private void SendBindOperation()
		{
			bool syncMode = XSingleton<XGame>.singleton.SyncMode;
			if (syncMode)
			{
				PtcC2G_QTEOperation ptcC2G_QTEOperation = new PtcC2G_QTEOperation();
				ptcC2G_QTEOperation.Data.type = 2U;
				ptcC2G_QTEOperation.Data.monsterid = (ulong)((long)this._doc.BindBuffID);
				XSingleton<XClientNetwork>.singleton.Send(ptcC2G_QTEOperation);
			}
			else
			{
				XBuff xbuff = null;
				bool flag = XSingleton<XEntityMgr>.singleton.Player != null;
				if (flag)
				{
					xbuff = XSingleton<XEntityMgr>.singleton.Player.Buffs.GetBuffByID(this._doc.BindBuffID);
				}
				bool flag2 = xbuff != null;
				if (flag2)
				{
					bool flag3 = XSingleton<XEntityMgr>.singleton.Player.Attributes.GetAttr(XAttributeDefine.XAttr_PhysicalAtkMod_Total) > XSingleton<XEntityMgr>.singleton.Player.Attributes.GetAttr(XAttributeDefine.XAttr_MagicAtkMod_Total);
					double attr;
					if (flag3)
					{
						attr = XSingleton<XEntityMgr>.singleton.Player.Attributes.GetAttr(XAttributeDefine.XAttr_PhysicalAtkMod_Total);
					}
					else
					{
						attr = XSingleton<XEntityMgr>.singleton.Player.Attributes.GetAttr(XAttributeDefine.XAttr_MagicAtkMod_Total);
					}
					xbuff.ChangeBuffHP((double)((float)(-(float)attr)));
				}
			}
		}

		// Token: 0x0600F4B4 RID: 62644 RVA: 0x00370158 File Offset: 0x0036E358
		public override void OnUpdate()
		{
			base.OnUpdate();
			QteUIType type = this._type;
			if (type == QteUIType.Abnormal)
			{
				bool flag = this._abnormal_wait != 0;
				if (flag)
				{
					this._abnormal_wait--;
					bool flag2 = this._abnormal_wait == 0;
					if (flag2)
					{
						this._abnormal_flag = true;
					}
				}
				bool flag3 = this._abnormal_send_wait != 0;
				if (flag3)
				{
					this._abnormal_send_wait--;
					bool flag4 = this._abnormal_send_wait == 0;
					if (flag4)
					{
						this.SendCheckAbnormalOperation();
					}
				}
				bool abnormal_flag = this._abnormal_flag;
				if (abnormal_flag)
				{
					base.uiBehaviour.m_AbnormalBar.Value += this._abnormal_delta;
					bool flag5 = base.uiBehaviour.m_AbnormalBar.Value == 1f || base.uiBehaviour.m_AbnormalBar.Value == 0f;
					if (flag5)
					{
						this._abnormal_delta = -this._abnormal_delta;
					}
				}
			}
		}

		// Token: 0x0400698C RID: 27020
		private XBattleDocument _doc = null;

		// Token: 0x0400698D RID: 27021
		private QteUIType _type = QteUIType.Bind;

		// Token: 0x0400698E RID: 27022
		private float _abnormal_delta = 0.01f;

		// Token: 0x0400698F RID: 27023
		private bool _abnormal_flag = false;

		// Token: 0x04006990 RID: 27024
		private int _abnormal_wait = 0;

		// Token: 0x04006991 RID: 27025
		private int _abnormal_send_wait = 0;

		// Token: 0x04006992 RID: 27026
		private float _charge_value = 0f;
	}
}
