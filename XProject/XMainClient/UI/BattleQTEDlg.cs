using System;
using UILib;
using UnityEngine;
using XMainClient.UI.Battle;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class BattleQTEDlg : DlgBase<BattleQTEDlg, BattleQTEDlgBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Battle/BattleQTEDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
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
			this._doc = XDocuments.GetSpecificDocument<XBattleDocument>(XBattleDocument.uuID);
		}

		public void SetStatus(QteUIType type, bool status)
		{
			this._type = type;
			this.SetVisible(status, true);
		}

		public void SetChargeValue(float value)
		{
			this._charge_value = value;
			base.uiBehaviour.m_ChargeBar.Value = this._charge_value;
		}

		public void SetAbnormalValue(float value)
		{
			this._abnormal_delta = value;
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_BindLeftButton.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnBindLeftButtonClick));
			base.uiBehaviour.m_BindRightButton.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnBindRightButtonClick));
			base.uiBehaviour.m_AbnormalClickSpace.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnAbnormalClicked));
		}

		private void OnBindLeftButtonClick(IXUISprite sp)
		{
			base.uiBehaviour.m_BindLeftButton.SetVisible(false);
			base.uiBehaviour.m_BindRightButton.SetVisible(true);
			base.uiBehaviour.m_BindArrow.localPosition = new Vector3(base.uiBehaviour.m_BindRightButton.parent.gameObject.transform.localPosition.x, 0f);
			this.SendBindOperation();
		}

		private void OnBindRightButtonClick(IXUISprite sp)
		{
			base.uiBehaviour.m_BindLeftButton.SetVisible(true);
			base.uiBehaviour.m_BindRightButton.SetVisible(false);
			base.uiBehaviour.m_BindArrow.localPosition = new Vector3(base.uiBehaviour.m_BindLeftButton.parent.gameObject.transform.localPosition.x, 0f);
			this.SendBindOperation();
		}

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

		private void SendCheckAbnormalOperation()
		{
			PtcC2G_QTEOperation ptcC2G_QTEOperation = new PtcC2G_QTEOperation();
			ptcC2G_QTEOperation.Data.type = 2U;
			ptcC2G_QTEOperation.Data.monsterid = (ulong)((long)this._doc.AbnormalBuffID);
			XSingleton<XClientNetwork>.singleton.Send(ptcC2G_QTEOperation);
		}

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

		private XBattleDocument _doc = null;

		private QteUIType _type = QteUIType.Bind;

		private float _abnormal_delta = 0.01f;

		private bool _abnormal_flag = false;

		private int _abnormal_wait = 0;

		private int _abnormal_send_wait = 0;

		private float _charge_value = 0f;
	}
}
