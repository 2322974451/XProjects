using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class SuperRiskOpenboxHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			this._doc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XSuperRiskDocument.uuID) as XSuperRiskDocument);
			this.m_CloseBg = (base.PanelObject.transform.Find("Close").GetComponent("XUISprite") as IXUISprite);
			this.m_TopBox = (base.PanelObject.transform.Find("Box").GetComponent("XUITexture") as IXUITexture);
			Transform transform = base.PanelObject.transform.Find("List/Item");
			this.BoxPool.SetupPool(transform.parent.gameObject, transform.gameObject, 3U, false);
			this.m_SpeedFrame = base.PanelObject.transform.Find("SpeedFrame").gameObject;
			this.m_SpeedTime = (base.PanelObject.transform.Find("SpeedFrame/Time").GetComponent("XUILabel") as IXUILabel);
			this.m_SpeedButton = (base.PanelObject.transform.Find("SpeedFrame/SpeedBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_SpeedCost = (base.PanelObject.transform.Find("SpeedFrame/SpeedBtn/Cost").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_StartButton = (base.PanelObject.transform.Find("OpenBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_StartTime = (base.PanelObject.transform.Find("OpenBtn/Time").GetComponent("XUILabel") as IXUILabel);
		}

		public override void RegisterEvent()
		{
			this.m_CloseBg.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClick));
			this.m_SpeedButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSpeedClick));
			this.m_StartButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnStartClick));
			base.RegisterEvent();
		}

		protected void OnCloseClick(IXUISprite sp)
		{
			base.SetVisible(false);
		}

		protected override void OnHide()
		{
			this.m_CurrentSlot = -1;
			base.OnHide();
		}

		public void ClearCatchTex()
		{
			this.m_TopBox.SetTexturePath("");
		}

		public void ShowBox(int slot)
		{
			base.SetVisible(true);
			ClientBoxInfo clientBoxInfo = this._doc.SlotBoxInfo[slot];
			bool flag = clientBoxInfo != null;
			if (flag)
			{
				this.m_CurrentSlot = slot;
				int num = -1;
				ItemList.RowData itemConf = XBagDocument.GetItemConf((int)clientBoxInfo.itemID);
				bool flag2 = itemConf != null;
				if (flag2)
				{
					num = (int)itemConf.ItemQuality;
				}
				this.m_TopBox.SetTexturePath(this.GetBoxPicByState(clientBoxInfo.itemID, RiskBoxState.RISK_BOX_LOCKED));
				this.BoxPool.ReturnAll(false);
				int num2 = 0;
				RiskMapFile.RowData currentMapData = this._doc.GetCurrentMapData();
				for (int i = 0; i < currentMapData.BoxPreview.Count; i++)
				{
					bool flag3 = currentMapData.BoxPreview[i, 0] == num;
					if (flag3)
					{
						num2++;
					}
				}
				int num3 = -(num2 - 1) * this.BoxPool.TplWidth / 2;
				int num4 = 0;
				for (int j = 0; j < currentMapData.BoxPreview.Count; j++)
				{
					bool flag4 = currentMapData.BoxPreview[j, 0] == num;
					if (flag4)
					{
						GameObject gameObject = this.BoxPool.FetchGameObject(false);
						gameObject.transform.localPosition = new Vector3((float)(num3 + num4 * this.BoxPool.TplWidth), 0f, 0f);
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, currentMapData.BoxPreview[j, 1], currentMapData.BoxPreview[j, 2], false);
						IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
						ixuisprite.ID = (ulong)((long)currentMapData.BoxPreview[j, 1]);
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
						num4++;
					}
				}
				bool flag5 = clientBoxInfo.state == RiskBoxState.RISK_BOX_LOCKED;
				if (flag5)
				{
					this.m_StartButton.gameObject.SetActive(true);
					this.m_SpeedFrame.SetActive(false);
					this.m_StartTime.SetText(XSingleton<UiUtility>.singleton.TimeFormatString((int)clientBoxInfo.leftTime, 2, 3, 4, false, true));
				}
				bool flag6 = clientBoxInfo.state == RiskBoxState.RISK_BOX_UNLOCKED;
				if (flag6)
				{
					this.m_StartButton.gameObject.SetActive(false);
					this.m_SpeedFrame.SetActive(true);
					SuperRiskSpeedCost speedCost = this._doc.GetSpeedCost(num);
					bool flag7 = (int)clientBoxInfo.leftTime % speedCost.time == 0;
					int cost;
					if (flag7)
					{
						cost = (int)clientBoxInfo.leftTime / speedCost.time * speedCost.itemCount;
					}
					else
					{
						cost = ((int)clientBoxInfo.leftTime / speedCost.time + 1) * speedCost.itemCount;
					}
					this.m_SpeedCost.InputText = XLabelSymbolHelper.FormatCostWithIcon(cost, (ItemEnum)speedCost.itemID);
				}
				bool flag8 = clientBoxInfo.state == RiskBoxState.RISK_BOX_CANGETREWARD || clientBoxInfo.state == RiskBoxState.RISK_BOX_GETREWARD;
				if (flag8)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Wrong super risk state!", null, null, null, null, null);
				}
			}
		}

		public void BoxStateChange(int slot)
		{
			bool flag = slot != this.m_CurrentSlot;
			if (!flag)
			{
				bool flag2 = this._doc.SlotBoxInfo.ContainsKey(slot);
				if (flag2)
				{
					ClientBoxInfo clientBoxInfo = this._doc.SlotBoxInfo[slot];
					bool flag3 = clientBoxInfo != null && clientBoxInfo.state == RiskBoxState.RISK_BOX_UNLOCKED;
					if (flag3)
					{
						this.m_StartButton.gameObject.SetActive(false);
						this.m_SpeedFrame.SetActive(true);
						this.m_SpeedTime.SetText(XSingleton<UiUtility>.singleton.TimeFormatString((int)clientBoxInfo.leftTime, 0, 3, 4, false, true));
						int quality = 1;
						ItemList.RowData itemConf = XBagDocument.GetItemConf((int)clientBoxInfo.itemID);
						bool flag4 = itemConf != null;
						if (flag4)
						{
							quality = (int)itemConf.ItemQuality;
						}
						SuperRiskSpeedCost speedCost = this._doc.GetSpeedCost(quality);
						bool flag5 = (int)clientBoxInfo.leftTime % speedCost.time == 0;
						int cost;
						if (flag5)
						{
							cost = (int)clientBoxInfo.leftTime / speedCost.time * speedCost.itemCount;
						}
						else
						{
							cost = ((int)clientBoxInfo.leftTime / speedCost.time + 1) * speedCost.itemCount;
						}
						this.m_SpeedCost.InputText = XLabelSymbolHelper.FormatCostWithIcon(cost, (ItemEnum)speedCost.itemID);
					}
					bool flag6 = clientBoxInfo.state == RiskBoxState.RISK_BOX_CANGETREWARD;
					if (flag6)
					{
						base.SetVisible(false);
					}
				}
				else
				{
					base.SetVisible(false);
				}
			}
		}

		private string GetBoxPicByState(uint itemID, RiskBoxState state)
		{
			ItemList.RowData itemConf = XBagDocument.GetItemConf((int)itemID);
			bool flag = itemConf != null;
			string result;
			if (flag)
			{
				string text = XSingleton<XCommon>.singleton.StringCombine("atlas/UI/GameSystem/SuperRisk/bx", ((int)(itemConf.ItemQuality - 1)).ToString());
				bool flag2 = state == RiskBoxState.RISK_BOX_UNLOCKED;
				if (flag2)
				{
					text = XSingleton<XCommon>.singleton.StringCombine(text, "_1");
				}
				result = text;
			}
			else
			{
				result = "";
			}
			return result;
		}

		public bool OnSpeedClick(IXUIButton button)
		{
			bool flag = this.SetButtonCool(this.m_fCoolTime);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				ClientBoxInfo clientBoxInfo = this._doc.SlotBoxInfo[this.m_CurrentSlot];
				bool flag2 = clientBoxInfo == null;
				if (flag2)
				{
					result = true;
				}
				else
				{
					ItemList.RowData itemConf = XBagDocument.GetItemConf((int)clientBoxInfo.itemID);
					bool flag3 = itemConf == null;
					if (flag3)
					{
						result = true;
					}
					else
					{
						int itemQuality = (int)itemConf.ItemQuality;
						SuperRiskSpeedCost speedCost = this._doc.GetSpeedCost(itemQuality);
						ulong itemCount = XBagDocument.BagDoc.GetItemCount(speedCost.itemID);
						bool flag4 = (int)clientBoxInfo.leftTime % speedCost.time == 0;
						int num;
						if (flag4)
						{
							num = (int)clientBoxInfo.leftTime / speedCost.time * speedCost.itemCount;
						}
						else
						{
							num = ((int)clientBoxInfo.leftTime / speedCost.time + 1) * speedCost.itemCount;
						}
						bool flag5 = (long)num > (long)itemCount;
						if (flag5)
						{
							XSingleton<UiUtility>.singleton.ShowItemAccess(speedCost.itemID, null);
							result = true;
						}
						else
						{
							this._doc.ChangeBoxState(this.m_CurrentSlot, RiskBoxState.RISK_BOX_CANGETREWARD);
							result = true;
						}
					}
				}
			}
			return result;
		}

		public bool OnStartClick(IXUIButton button)
		{
			bool flag = this.SetButtonCool1(this.m_fCoolTime);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				foreach (KeyValuePair<int, ClientBoxInfo> keyValuePair in this._doc.SlotBoxInfo)
				{
					bool flag2 = keyValuePair.Value.state == RiskBoxState.RISK_BOX_UNLOCKED;
					if (flag2)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CannotUnLockAnyBox"), "fece00");
						return true;
					}
				}
				this._doc.ChangeBoxState(this.m_CurrentSlot, RiskBoxState.RISK_BOX_UNLOCKED);
				result = true;
			}
			return result;
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = this.m_CurrentSlot == -1;
			if (!flag)
			{
				bool flag2 = this._doc.SlotBoxInfo.ContainsKey(this.m_CurrentSlot);
				if (flag2)
				{
					ClientBoxInfo clientBoxInfo = this._doc.SlotBoxInfo[this.m_CurrentSlot];
					bool flag3 = clientBoxInfo.state == RiskBoxState.RISK_BOX_UNLOCKED;
					if (flag3)
					{
						this.m_SpeedTime.SetText(XSingleton<UiUtility>.singleton.TimeFormatString((int)clientBoxInfo.leftTime, 2, 3, 4, false, true));
					}
				}
			}
		}

		private bool SetButtonCool(float time)
		{
			float num = Time.realtimeSinceStartup - this.m_fLastClickBtnTime;
			bool flag = num < time;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this.m_fLastClickBtnTime = Time.realtimeSinceStartup;
				result = false;
			}
			return result;
		}

		private bool SetButtonCool1(float time)
		{
			float num = Time.realtimeSinceStartup - this.m_fLastClickBtnTime1;
			bool flag = num < time;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this.m_fLastClickBtnTime1 = Time.realtimeSinceStartup;
				result = false;
			}
			return result;
		}

		private IXUITexture m_TopBox;

		private XUIPool BoxPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private GameObject m_SpeedFrame;

		private IXUILabel m_SpeedTime;

		private IXUIButton m_SpeedButton;

		private IXUILabelSymbol m_SpeedCost;

		private IXUIButton m_StartButton;

		private IXUILabel m_StartTime;

		private IXUISprite m_CloseBg;

		private XSuperRiskDocument _doc;

		private int m_CurrentSlot = -1;

		private float m_fCoolTime = 1f;

		private float m_fLastClickBtnTime = 0f;

		private float m_fLastClickBtnTime1 = 0f;
	}
}
