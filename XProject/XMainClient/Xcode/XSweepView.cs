using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XSweepView : DlgBase<XSweepView, XSweepBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/SweepDlg";
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
			this._doc = XDocuments.GetSpecificDocument<XSweepDocument>(XSweepDocument.uuID);
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		protected override void OnShow()
		{
			base.uiBehaviour.m_RewardPool.ReturnAll(false);
			base.uiBehaviour.m_DropPool.ReturnAll(false);
			this._preSweepReward = base.uiBehaviour.m_RewardPool._tpl;
			base.uiBehaviour.m_SweepTip.SetVisible(false);
			base.uiBehaviour.m_Exp.SetVisible(!this._doc.IsSeal);
			base.uiBehaviour.m_SealTip.gameObject.SetActive(this._doc.IsSeal);
		}

		protected bool OnCloseClicked(IXUIButton button)
		{
			bool flag = this._doc.Count > 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._sweepTime);
				XSingleton<XTimerMgr>.singleton.KillTimer(this._setPosition);
				this.SetVisibleWithAnimation(false, null);
				result = true;
			}
			return result;
		}

		public void SetReward()
		{
			this.ShowReward(null);
			this.SetExpBar();
		}

		private void ShowReward(object o = null)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				GameObject gameObject = base.uiBehaviour.m_RewardPool.FetchGameObject(false);
				IXUILabel ixuilabel = gameObject.transform.FindChild("RewardLabel").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(XStringDefineProxy.GetString("SWEEP_COUNT", new object[]
				{
					this._doc.GetCount() + 1
				}));
				base.uiBehaviour.m_dragBox.enabled = false;
				int num = 0;
				for (int i = 0; i < 10; i++)
				{
					ItemBrief item = this._doc.GetItem(this._doc.GetCount(), i);
					bool flag2 = item == null;
					if (flag2)
					{
						break;
					}
					GameObject gameObject2 = base.uiBehaviour.m_DropPool.FetchGameObject(false);
					gameObject2.transform.parent = gameObject.transform.FindChild("Parent");
					gameObject2.transform.localPosition = new Vector3((float)(i % this.m_showNum * base.uiBehaviour.m_DropPool.TplWidth), (float)(-(float)(i / this.m_showNum) * base.uiBehaviour.m_DropPool.TplHeight), 0f);
					XItemDrawerMgr.Param.bBinding = item.isbind;
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject2, (int)item.itemID, (int)item.itemCount, true);
					num++;
					IXUISprite ixuisprite = gameObject2.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = (ulong)item.itemID;
					bool flag3 = !item.isbind;
					if (flag3)
					{
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
					}
					else
					{
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnBindItemClick));
					}
				}
				IXUISprite ixuisprite2 = gameObject.transform.FindChild("P").GetComponent("XUISprite") as IXUISprite;
				ixuisprite2.spriteHeight += (num - 1) / this.m_showNum * base.uiBehaviour.m_DropPool.TplHeight;
				gameObject.transform.localPosition = new Vector3(base.uiBehaviour.m_RewardPool.TplPos.x, this._preSweepReward.transform.localPosition.y + (float)(ixuisprite2.spriteHeight + 5), 0f);
				this._preSweepReward = gameObject;
				this._doc.Count = this._doc.Count - 1;
				bool flag4 = this._doc.Count > 0;
				if (flag4)
				{
					XSingleton<XTimerMgr>.singleton.KillTimer(this._sweepTime);
					this._sweepTime = XSingleton<XTimerMgr>.singleton.SetTimer(0.4f, new XTimerMgr.ElapsedEventHandler(this.ShowReward), null);
				}
				else
				{
					base.uiBehaviour.m_SweepTip.SetVisible(this._doc.ShowTip);
					base.uiBehaviour.m_SweepTip.gameObject.transform.localPosition = new Vector3(0f, this._preSweepReward.transform.localPosition.y + 125f);
					bool showTip = this._doc.ShowTip;
					if (showTip)
					{
						XSweepDocument xsweepDocument = XSingleton<XGame>.singleton.Doc.GetXComponent(XSweepDocument.uuID) as XSweepDocument;
						int slectDiffect = xsweepDocument.SlectDiffect;
						bool flag5 = slectDiffect == 1 && XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemCount(87) <= 0UL;
						if (flag5)
						{
							base.uiBehaviour.m_SweepTip.SetText(XStringDefineProxy.GetString("NOT_TICKET_FATIGUE", new object[]
							{
								this._doc.GetCount()
							}));
						}
						else
						{
							bool notHaveFatigue = this._doc.NotHaveFatigue;
							if (notHaveFatigue)
							{
								base.uiBehaviour.m_SweepTip.SetText(XStringDefineProxy.GetString("NOT_HAVE_FATIGUE", new object[]
								{
									this._doc.GetCount()
								}));
							}
							else
							{
								base.uiBehaviour.m_SweepTip.SetText(XStringDefineProxy.GetString("NOT_HAVE_COUNT", new object[]
								{
									this._doc.GetCount()
								}));
							}
						}
					}
					base.uiBehaviour.m_dragBox.enabled = true;
				}
				XSingleton<XTimerMgr>.singleton.KillTimer(this._setPosition);
				this._setPosition = XSingleton<XTimerMgr>.singleton.SetTimer(0.1f, new XTimerMgr.ElapsedEventHandler(this.SetPos), null);
			}
		}

		public void SetPos(object o = null)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				base.uiBehaviour.m_ScrollView.ResetPosition();
			}
		}

		public override void OnUpdate()
		{
			bool flag = this._doc.GainExp > 0f;
			if (flag)
			{
				this.SetExpBar();
			}
		}

		private void SetExpBar()
		{
			bool flag = XSingleton<XEntityMgr>.singleton.Player == null;
			if (!flag)
			{
				XPlayerAttributes xplayerAttributes = XSingleton<XEntityMgr>.singleton.Player.Attributes as XPlayerAttributes;
				this._doc.GainExp -= this._doc.ExpDelta;
				this._doc.CurExp += this._doc.ExpDelta;
				int num = (int)xplayerAttributes.GetLevelUpExp((int)(this._doc.ProcessLevel + 1U));
				num = ((num <= 0) ? 1 : num);
				while (this._doc.CurExp >= (float)num)
				{
					this._doc.CurExp -= (float)num;
					XSweepDocument doc = this._doc;
					uint processLevel = doc.ProcessLevel + 1U;
					doc.ProcessLevel = processLevel;
					num = (int)xplayerAttributes.GetLevelUpExp((int)(this._doc.ProcessLevel + 1U));
				}
				bool flag2 = num == 0;
				if (flag2)
				{
					base.uiBehaviour.m_ExpText.SetText("+0.00%");
					base.uiBehaviour.m_Exp.value = 1f;
				}
				else
				{
					float num2 = this._doc.CurExp / (float)num;
					base.uiBehaviour.m_ExpText.SetText(string.Format("+{0:F2}%", num2 * 100f));
					base.uiBehaviour.m_Exp.value = num2;
				}
			}
		}

		private uint _sweepTime;

		private uint _setPosition;

		private XSweepDocument _doc = null;

		private GameObject _preSweepReward = null;

		private readonly int m_showNum = 6;
	}
}
