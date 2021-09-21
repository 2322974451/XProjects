using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001819 RID: 6169
	internal class SuperRiskOpenboxHandler : DlgHandlerBase
	{
		// Token: 0x06010017 RID: 65559 RVA: 0x003CB930 File Offset: 0x003C9B30
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

		// Token: 0x06010018 RID: 65560 RVA: 0x003CBAD8 File Offset: 0x003C9CD8
		public override void RegisterEvent()
		{
			this.m_CloseBg.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClick));
			this.m_SpeedButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSpeedClick));
			this.m_StartButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnStartClick));
			base.RegisterEvent();
		}

		// Token: 0x06010019 RID: 65561 RVA: 0x001A6C1F File Offset: 0x001A4E1F
		protected void OnCloseClick(IXUISprite sp)
		{
			base.SetVisible(false);
		}

		// Token: 0x0601001A RID: 65562 RVA: 0x003CBB35 File Offset: 0x003C9D35
		protected override void OnHide()
		{
			this.m_CurrentSlot = -1;
			base.OnHide();
		}

		// Token: 0x0601001B RID: 65563 RVA: 0x003CBB46 File Offset: 0x003C9D46
		public void ClearCatchTex()
		{
			this.m_TopBox.SetTexturePath("");
		}

		// Token: 0x0601001C RID: 65564 RVA: 0x003CBB5C File Offset: 0x003C9D5C
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

		// Token: 0x0601001D RID: 65565 RVA: 0x003CBE88 File Offset: 0x003CA088
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

		// Token: 0x0601001E RID: 65566 RVA: 0x003CBFF8 File Offset: 0x003CA1F8
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

		// Token: 0x0601001F RID: 65567 RVA: 0x003CC064 File Offset: 0x003CA264
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

		// Token: 0x06010020 RID: 65568 RVA: 0x003CC188 File Offset: 0x003CA388
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

		// Token: 0x06010021 RID: 65569 RVA: 0x003CC244 File Offset: 0x003CA444
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

		// Token: 0x06010022 RID: 65570 RVA: 0x003CC2CC File Offset: 0x003CA4CC
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

		// Token: 0x06010023 RID: 65571 RVA: 0x003CC304 File Offset: 0x003CA504
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

		// Token: 0x04007194 RID: 29076
		private IXUITexture m_TopBox;

		// Token: 0x04007195 RID: 29077
		private XUIPool BoxPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007196 RID: 29078
		private GameObject m_SpeedFrame;

		// Token: 0x04007197 RID: 29079
		private IXUILabel m_SpeedTime;

		// Token: 0x04007198 RID: 29080
		private IXUIButton m_SpeedButton;

		// Token: 0x04007199 RID: 29081
		private IXUILabelSymbol m_SpeedCost;

		// Token: 0x0400719A RID: 29082
		private IXUIButton m_StartButton;

		// Token: 0x0400719B RID: 29083
		private IXUILabel m_StartTime;

		// Token: 0x0400719C RID: 29084
		private IXUISprite m_CloseBg;

		// Token: 0x0400719D RID: 29085
		private XSuperRiskDocument _doc;

		// Token: 0x0400719E RID: 29086
		private int m_CurrentSlot = -1;

		// Token: 0x0400719F RID: 29087
		private float m_fCoolTime = 1f;

		// Token: 0x040071A0 RID: 29088
		private float m_fLastClickBtnTime = 0f;

		// Token: 0x040071A1 RID: 29089
		private float m_fLastClickBtnTime1 = 0f;
	}
}
