using System;
using System.Collections;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017E6 RID: 6118
	internal class LuckyTurntableFrameHandler : DlgHandlerBase
	{
		// Token: 0x170038BA RID: 14522
		// (get) Token: 0x0600FD9A RID: 64922 RVA: 0x003B7B28 File Offset: 0x003B5D28
		protected override string FileName
		{
			get
			{
				return "OperatingActivity/LuckyTurntableFrame";
			}
		}

		// Token: 0x0600FD9B RID: 64923 RVA: 0x003B7B40 File Offset: 0x003B5D40
		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XOperatingActivityDocument>(XOperatingActivityDocument.uuID);
			this.doc_item = XDocuments.GetSpecificDocument<XCharacterItemDocument>(XCharacterItemDocument.uuID);
			this.m_btnRecord = (base.PanelObject.transform.Find("Main/EnterBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_btnBuy = (base.PanelObject.transform.Find("Main/BuyBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_btnUse = (base.PanelObject.transform.Find("Main/BeginBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_btnUseFxControl = (this.m_btnUse.gameObject.transform.Find("FxUse").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_btnInvalid = (base.PanelObject.transform.Find("Main/EndBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_btnHelp = (base.PanelObject.transform.Find("Main/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_CostRoot = base.PanelObject.transform.Find("Main/Tip2");
			this.m_CostImg = (this.m_CostRoot.Find("p").GetComponent("XUISprite") as IXUISprite);
			this.m_CostLabel = (this.m_CostRoot.Find("Tip2").GetComponent("XUILabel") as IXUILabel);
			this.m_TipTime = (base.PanelObject.transform.Find("Main/TipTime").GetComponent("XUILabel") as IXUILabel);
			this.m_TipDesc = (base.PanelObject.transform.Find("Main/TipDesc").GetComponent("XUILabel") as IXUILabel);
			this.m_LabelDataRange1 = (base.PanelObject.transform.Find("Main/DataRange1").GetComponent("XUILabel") as IXUILabel);
			this.m_LabelDataNum2 = (base.PanelObject.transform.Find("Main/DataNum2").GetComponent("XUILabel") as IXUILabel);
			this.m_LabelDataRange3 = (base.PanelObject.transform.Find("Main/DataRange3").GetComponent("XUILabel") as IXUILabel);
			this.m_LabelDataRange1.gameObject.SetActive(false);
			this.m_LabelDataNum2.gameObject.SetActive(false);
			this.m_LabelDataRange3.gameObject.SetActive(false);
			this.m_TipTime.SetText(XStringDefineProxy.GetString("LuckyTurnTable_Tip_Time"));
			this.m_TipDesc.SetText(XStringDefineProxy.GetString("LuckyTurnTable_Tip_Desc"));
			this.m_AwardRoot = base.PanelObject.transform.Find("Main/Items");
			GameObject gameObject = base.PanelObject.transform.Find("Main/Items/ItemTpl").gameObject;
			this.m_ItemPool.SetupPool(this.m_AwardRoot.gameObject, gameObject, 8U, false);
			for (int i = 0; i < 8; i++)
			{
				Transform transform = this.m_AwardRoot.Find("Item" + i);
				this.m_positions[i] = transform.localPosition;
			}
			this.m_SelectFxRoot = base.PanelObject.transform.Find("Main/Items/Selected");
			this.m_SelectFxControl = (this.m_SelectFxRoot.GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_SelectFxRoot.gameObject.SetActive(false);
		}

		// Token: 0x0600FD9C RID: 64924 RVA: 0x003B7EE8 File Offset: 0x003B60E8
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_btnRecord.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickRecordBtn));
			this.m_btnBuy.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickBuyBtn));
			this.m_btnUse.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickUseBtn));
			this.m_btnInvalid.RegisterClickEventHandler((IXUIButton btn) => true);
			this.m_btnHelp.RegisterClickEventHandler(delegate(IXUIButton btn)
			{
				DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XStringDefineProxy.GetString("LuckyTurnTable_HelpTitle"), XStringDefineProxy.GetString("LuckyTurnTable_HelpMessage"));
				return true;
			});
		}

		// Token: 0x0600FD9D RID: 64925 RVA: 0x003B7F9C File Offset: 0x003B619C
		private bool OnClickRecordBtn(IXUIButton btn)
		{
			XOperatingActivityDocument.LuckyTurntableInfo luckyTurntableData = this.doc.m_LuckyTurntableData;
			List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>();
			foreach (XOperatingActivityDocument.LuckyTurntableItem luckyTurntableItem in luckyTurntableData.Items)
			{
				bool hasReceived = luckyTurntableItem.HasReceived;
				if (hasReceived)
				{
					list.Add(new KeyValuePair<int, int>(luckyTurntableItem.ItemID, luckyTurntableItem.ItemCount));
				}
			}
			DlgBase<LuckyTurntableRecordView, LuckyTurntableRecordBehaviour>.singleton.ShowList(list);
			return true;
		}

		// Token: 0x0600FD9E RID: 64926 RVA: 0x003B8038 File Offset: 0x003B6238
		private bool OnClickBuyBtn(IXUIButton btn)
		{
			bool flag = this._fx_coroutine != null;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				XOperatingActivityDocument.LuckyTurntableInfo luckyTurntableData = this.doc.m_LuckyTurntableData;
				bool flag2 = !luckyTurntableData.IsPay && luckyTurntableData.CanBuy;
				if (flag2)
				{
					int currencyType = luckyTurntableData.CurrencyType;
					int price = (int)luckyTurntableData.Price;
					ulong itemCount = XBagDocument.BagDoc.GetItemCount(currencyType);
					bool flag3 = itemCount < (ulong)((long)price);
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_ITEM_NOT_ENOUGH, "fece00");
						return true;
					}
					this.doc.RequestBuyLuckyTurntable();
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemNoticeTip("Can not buy");
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600FD9F RID: 64927 RVA: 0x003B80E8 File Offset: 0x003B62E8
		private bool OnClickUseBtn(IXUIButton btn)
		{
			bool flag = this._fx_coroutine != null;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				XOperatingActivityDocument.LuckyTurntableInfo luckyTurntableData = this.doc.m_LuckyTurntableData;
				bool isPay = luckyTurntableData.IsPay;
				if (isPay)
				{
					this.doc_item.ToggleBlock(true);
					this.doc.RequestUseLuckyTurntable();
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemNoticeTip("Can not use");
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600FDA0 RID: 64928 RVA: 0x003B8154 File Offset: 0x003B6354
		private void PlayFxAt(int index, bool first = false)
		{
			this.m_SelectFxRoot.localPosition = this.m_positions[index];
			bool flag = !first;
			if (flag)
			{
				int num = (8 + index - 1) % 8;
				IXUITweenTool ixuitweenTool = this.m_tail_fxes[num];
				bool flag2 = ixuitweenTool != null;
				if (flag2)
				{
					ixuitweenTool.gameObject.SetActive(true);
					ixuitweenTool.ResetTween(true);
					ixuitweenTool.PlayTween(true, -1f);
				}
			}
		}

		// Token: 0x0600FDA1 RID: 64929 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void MoveFxTo(int index, double left_time, double total_time)
		{
		}

		// Token: 0x0600FDA2 RID: 64930 RVA: 0x003B81C4 File Offset: 0x003B63C4
		private void GetDataFromLabel()
		{
			string[] array = this.m_LabelDataRange1.GetText().Split(new char[]
			{
				','
			});
			this.m_DataRange1 = new double[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				this.m_DataRange1[i] = double.Parse(array[i].Trim());
			}
			this.m_DateRange2 = this.m_DataRange1[this.m_DataRange1.Length - 1];
			string text = this.m_LabelDataNum2.GetText();
			this.m_DataNum2 = int.Parse(text.Trim());
			string[] array2 = this.m_LabelDataRange3.GetText().Split(new char[]
			{
				','
			});
			this.m_DataRange3 = new double[array2.Length];
			for (int j = 0; j < array2.Length; j++)
			{
				this.m_DataRange3[j] = double.Parse(array2[j].Trim());
			}
		}

		// Token: 0x0600FDA3 RID: 64931 RVA: 0x003B82BE File Offset: 0x003B64BE
		private IEnumerator PlayFx(int index)
		{
			this.m_SelectFxRoot.gameObject.SetActive(true);
			this.m_SelectFxControl.SetTweenGroup(0);
			this.m_SelectFxControl.PlayTween(true, -1f);
			this.m_btnUseFxControl.gameObject.SetActive(true);
			this.m_btnUseFxControl.StopTween();
			this.m_btnUseFxControl.SetTweenGroup(0);
			this.m_btnUseFxControl.PlayTween(true, -1f);
			try
			{
				this.GetDataFromLabel();
			}
			catch
			{
				this.doc_item.ToggleBlock(false);
				this.RefeshInfo();
				yield break;
			}
			double wait_time = 0.0;
			int idx = new System.Random(Time.frameCount).Next(0, 7);
			int num2 = 32;
			double[] ts = this.m_DataRange1;
			double ts2 = this.m_DateRange2;
			num2 = this.m_DataNum2 * 8;
			double[] ts3 = this.m_DataRange3;
			bool first = true;
			int num3;
			for (int i = 0; i < ts.Length; i = num3 + 1)
			{
				idx = (idx + 1) % 8;
				this.PlayFxAt(idx, first);
				first = false;
				for (wait_time = ts[i]; wait_time > 0.0; wait_time -= (double)Time.deltaTime)
				{
					this.MoveFxTo(idx, wait_time, ts[i]);
					yield return null;
				}
				num3 = i;
			}
			int mid_num = (index - ts3.Length - idx + 160) % 8 + num2;
			for (int j = 0; j < mid_num; j = num3 + 1)
			{
				idx = (idx + 1) % 8;
				this.PlayFxAt(idx, false);
				for (wait_time = ts2; wait_time > 0.0; wait_time -= (double)Time.deltaTime)
				{
					this.MoveFxTo(idx, wait_time, ts2);
					yield return null;
				}
				num3 = j;
			}
			for (int k = 0; k < ts3.Length; k = num3 + 1)
			{
				idx = (idx + 1) % 8;
				this.PlayFxAt(idx, false);
				for (wait_time = ts3[k]; wait_time > 0.0; wait_time -= (double)Time.deltaTime)
				{
					this.MoveFxTo(idx, wait_time, ts3[k]);
					yield return null;
				}
				num3 = k;
			}
			this.doc_item.ToggleBlock(false);
			this.m_btnUseFxControl.SetTweenGroup(1);
			this.m_btnUseFxControl.PlayTween(true, -1f);
			this.m_SelectFxControl.StopTween();
			this.m_SelectFxControl.SetTweenGroup(1);
			this.m_SelectFxControl.PlayTween(true, -1f);
			for (wait_time = 1.0; wait_time > 0.0; wait_time -= (double)Time.deltaTime)
			{
				yield return null;
			}
			this.RefeshInfo();
			yield break;
		}

		// Token: 0x0600FDA4 RID: 64932 RVA: 0x003B82D4 File Offset: 0x003B64D4
		protected override void OnHide()
		{
			base.OnHide();
			this._fx_coroutine = null;
			this.doc_item.ToggleBlock(false);
		}

		// Token: 0x0600FDA5 RID: 64933 RVA: 0x003B82F2 File Offset: 0x003B64F2
		public override void OnUnload()
		{
			this.ClearEffectList(false);
			base.OnUnload();
			this._fx_coroutine = null;
			this.doc_item.ToggleBlock(false);
		}

		// Token: 0x0600FDA6 RID: 64934 RVA: 0x003B8318 File Offset: 0x003B6518
		public override void OnUpdate()
		{
			bool flag = this._fx_coroutine != null;
			if (flag)
			{
				bool flag2 = !this._fx_coroutine.MoveNext();
				if (flag2)
				{
					this._fx_coroutine = null;
				}
			}
		}

		// Token: 0x0600FDA7 RID: 64935 RVA: 0x003B8350 File Offset: 0x003B6550
		protected override void OnShow()
		{
			base.OnShow();
			XSingleton<XGameSysMgr>.singleton.SetSysRedState(XSysDefine.XSys_LuckyTurntable, false);
			this.doc.RefreshRedPoints();
			this.doc.RequestGetLuckyTurntableData();
			this._fx_coroutine = null;
		}

		// Token: 0x0600FDA8 RID: 64936 RVA: 0x003B838C File Offset: 0x003B658C
		public void RefeshInfo()
		{
			XOperatingActivityDocument.LuckyTurntableInfo luckyTurntableData = this.doc.m_LuckyTurntableData;
			this.m_btnBuy.gameObject.SetActive(false);
			this.m_btnInvalid.gameObject.SetActive(false);
			this.m_btnUse.gameObject.SetActive(false);
			this.m_CostRoot.gameObject.SetActive(false);
			bool isPay = luckyTurntableData.IsPay;
			if (isPay)
			{
				this.m_btnUse.gameObject.SetActive(true);
				this.m_btnUseFxControl.gameObject.SetActive(false);
			}
			else
			{
				bool canBuy = luckyTurntableData.CanBuy;
				if (canBuy)
				{
					this.m_btnBuy.gameObject.SetActive(true);
					Transform transform = this.m_btnBuy.gameObject.transform.Find("Label");
					bool flag = luckyTurntableData.Price > 0U;
					if (flag)
					{
						this.m_CostRoot.gameObject.SetActive(true);
						this.m_CostLabel.SetText(luckyTurntableData.Price.ToString());
						string strSprite;
						string strAtlas;
						XBagDocument.GetItemSmallIconAndAtlas(luckyTurntableData.CurrencyType, out strSprite, out strAtlas, 0U);
						this.m_CostImg.SetSprite(strSprite, strAtlas, false);
						bool flag2 = transform != null;
						if (flag2)
						{
							transform.gameObject.SetActive(false);
						}
					}
					else
					{
						bool flag3 = transform != null;
						if (flag3)
						{
							transform.gameObject.SetActive(true);
						}
					}
				}
				else
				{
					this.m_btnInvalid.gameObject.SetActive(true);
				}
			}
			this.RefreashList();
		}

		// Token: 0x0600FDA9 RID: 64937 RVA: 0x003B8510 File Offset: 0x003B6710
		public void OnGetIndex(int index)
		{
			this._fx_coroutine = this.PlayFx(index);
		}

		// Token: 0x0600FDAA RID: 64938 RVA: 0x003B8520 File Offset: 0x003B6720
		public void OnBuy()
		{
			this.RefeshInfo();
			this.OnClickUseBtn(null);
		}

		// Token: 0x0600FDAB RID: 64939 RVA: 0x003B8534 File Offset: 0x003B6734
		private void RefreashList()
		{
			this._fx_coroutine = null;
			this.m_SelectFxRoot.gameObject.SetActive(false);
			this.ClearEffectList(true);
			XOperatingActivityDocument.LuckyTurntableInfo luckyTurntableData = this.doc.m_LuckyTurntableData;
			this.m_ItemPool.ReturnAll(false);
			int num = Math.Min(8, luckyTurntableData.Items.Count);
			for (int i = 0; i < num; i++)
			{
				XOperatingActivityDocument.LuckyTurntableItem luckyTurntableItem = luckyTurntableData.Items[i];
				GameObject gameObject = this.m_ItemPool.FetchGameObject(false);
				gameObject.name = i.ToString() + "-" + luckyTurntableItem.ItemID.ToString();
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.localPosition = this.m_positions[i];
				IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				IXUISprite ixuisprite2 = gameObject.transform.FindChild("Quality").GetComponent("XUISprite") as IXUISprite;
				IXUITweenTool ixuitweenTool = gameObject.transform.FindChild("tail_fx").GetComponent("XUIPlayTween") as IXUITweenTool;
				ixuitweenTool.gameObject.SetActive(false);
				this.m_tail_fxes[i] = ixuitweenTool;
				ixuisprite.ID = (ulong)((long)luckyTurntableItem.ItemID);
				bool flag = !luckyTurntableItem.HasReceived;
				if (flag)
				{
					ItemList.RowData itemConf = XBagDocument.GetItemConf(luckyTurntableItem.ItemID);
					this.SetItemEffect(ixuisprite2.gameObject, itemConf.ItemEffect);
				}
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, luckyTurntableItem.ItemID, luckyTurntableItem.ItemCount, false);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
				ixuisprite.SetGrey(!luckyTurntableItem.HasReceived);
				ixuisprite2.SetGrey(!luckyTurntableItem.HasReceived);
			}
		}

		// Token: 0x0600FDAC RID: 64940 RVA: 0x003B8734 File Offset: 0x003B6934
		private void ClearEffectList(bool immediate)
		{
			bool flag = this.m_ItemEffectList != null;
			if (flag)
			{
				int i = 0;
				int count = this.m_ItemEffectList.Count;
				while (i < count)
				{
					XSingleton<XFxMgr>.singleton.DestroyFx(this.m_ItemEffectList[i], immediate);
					i++;
				}
				this.m_ItemEffectList.Clear();
			}
		}

		// Token: 0x0600FDAD RID: 64941 RVA: 0x003B8794 File Offset: 0x003B6994
		private void SetItemEffect(GameObject parent, string effectName)
		{
			bool flag = string.IsNullOrEmpty(effectName);
			if (!flag)
			{
				XFx xfx = XSingleton<XFxMgr>.singleton.CreateUIFx(effectName, parent.transform, false);
				bool flag2 = xfx != null;
				if (flag2)
				{
					this.m_ItemEffectList.Add(xfx);
				}
			}
		}

		// Token: 0x04006FDC RID: 28636
		private XOperatingActivityDocument doc;

		// Token: 0x04006FDD RID: 28637
		private XCharacterItemDocument doc_item;

		// Token: 0x04006FDE RID: 28638
		private IXUIButton m_btnBuy;

		// Token: 0x04006FDF RID: 28639
		private IXUIButton m_btnUse;

		// Token: 0x04006FE0 RID: 28640
		private IXUITweenTool m_btnUseFxControl;

		// Token: 0x04006FE1 RID: 28641
		private IXUIButton m_btnInvalid;

		// Token: 0x04006FE2 RID: 28642
		private IXUIButton m_btnRecord;

		// Token: 0x04006FE3 RID: 28643
		private IXUIButton m_btnHelp;

		// Token: 0x04006FE4 RID: 28644
		private Transform m_AwardRoot;

		// Token: 0x04006FE5 RID: 28645
		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006FE6 RID: 28646
		private Transform m_CostRoot;

		// Token: 0x04006FE7 RID: 28647
		private IXUISprite m_CostImg;

		// Token: 0x04006FE8 RID: 28648
		private IXUILabel m_CostLabel;

		// Token: 0x04006FE9 RID: 28649
		private IXUILabel m_TipTime;

		// Token: 0x04006FEA RID: 28650
		private IXUILabel m_TipDesc;

		// Token: 0x04006FEB RID: 28651
		private Vector3[] m_positions = new Vector3[8];

		// Token: 0x04006FEC RID: 28652
		private IXUITweenTool[] m_tail_fxes = new IXUITweenTool[8];

		// Token: 0x04006FED RID: 28653
		private IXUILabel m_LabelDataRange1;

		// Token: 0x04006FEE RID: 28654
		private IXUILabel m_LabelDataNum2;

		// Token: 0x04006FEF RID: 28655
		private IXUILabel m_LabelDataRange3;

		// Token: 0x04006FF0 RID: 28656
		private double[] m_DataRange1;

		// Token: 0x04006FF1 RID: 28657
		private double m_DateRange2;

		// Token: 0x04006FF2 RID: 28658
		private int m_DataNum2;

		// Token: 0x04006FF3 RID: 28659
		private double[] m_DataRange3;

		// Token: 0x04006FF4 RID: 28660
		private Transform m_SelectFxRoot;

		// Token: 0x04006FF5 RID: 28661
		private IXUITweenTool m_SelectFxControl;

		// Token: 0x04006FF6 RID: 28662
		private IEnumerator _fx_coroutine;

		// Token: 0x04006FF7 RID: 28663
		private List<XFx> m_ItemEffectList = new List<XFx>();
	}
}
