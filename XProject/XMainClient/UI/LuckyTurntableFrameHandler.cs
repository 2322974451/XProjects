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

	internal class LuckyTurntableFrameHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "OperatingActivity/LuckyTurntableFrame";
			}
		}

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

		private void MoveFxTo(int index, double left_time, double total_time)
		{
		}

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

		protected override void OnHide()
		{
			base.OnHide();
			this._fx_coroutine = null;
			this.doc_item.ToggleBlock(false);
		}

		public override void OnUnload()
		{
			this.ClearEffectList(false);
			base.OnUnload();
			this._fx_coroutine = null;
			this.doc_item.ToggleBlock(false);
		}

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

		protected override void OnShow()
		{
			base.OnShow();
			XSingleton<XGameSysMgr>.singleton.SetSysRedState(XSysDefine.XSys_LuckyTurntable, false);
			this.doc.RefreshRedPoints();
			this.doc.RequestGetLuckyTurntableData();
			this._fx_coroutine = null;
		}

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

		public void OnGetIndex(int index)
		{
			this._fx_coroutine = this.PlayFx(index);
		}

		public void OnBuy()
		{
			this.RefeshInfo();
			this.OnClickUseBtn(null);
		}

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

		private XOperatingActivityDocument doc;

		private XCharacterItemDocument doc_item;

		private IXUIButton m_btnBuy;

		private IXUIButton m_btnUse;

		private IXUITweenTool m_btnUseFxControl;

		private IXUIButton m_btnInvalid;

		private IXUIButton m_btnRecord;

		private IXUIButton m_btnHelp;

		private Transform m_AwardRoot;

		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private Transform m_CostRoot;

		private IXUISprite m_CostImg;

		private IXUILabel m_CostLabel;

		private IXUILabel m_TipTime;

		private IXUILabel m_TipDesc;

		private Vector3[] m_positions = new Vector3[8];

		private IXUITweenTool[] m_tail_fxes = new IXUITweenTool[8];

		private IXUILabel m_LabelDataRange1;

		private IXUILabel m_LabelDataNum2;

		private IXUILabel m_LabelDataRange3;

		private double[] m_DataRange1;

		private double m_DateRange2;

		private int m_DataNum2;

		private double[] m_DataRange3;

		private Transform m_SelectFxRoot;

		private IXUITweenTool m_SelectFxControl;

		private IEnumerator _fx_coroutine;

		private List<XFx> m_ItemEffectList = new List<XFx>();
	}
}
