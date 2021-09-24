using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class FashionTooltipDlg : TooltipDlg<FashionTooltipDlg, FashionTooltipDlgBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/FashionToolTipDlg";
			}
		}

		protected override int compareWindowDistance
		{
			get
			{
				return 20;
			}
		}

		protected override void Init()
		{
			base.Init();
			this.m_OperateList[0, 0] = new TooltipButtonOperateFashionPutOn();
			this.m_OperateList[0, 1] = new TooltipButtonOperateFashionPutOnSuit();
			this.m_OperateList[0, 2] = new TooltipButtonOperateRecycle(XSysDefine.XSys_Fashion_Fashion);
			this.m_OperateList[0, 3] = new TooltipButtonOperateSell();
			this.m_OperateList[0, 4] = new TooltipButtonActivateFashion();
			this.m_OperateList[1, 0] = new TooltipButtonOperateFashionTakeOff();
			this.m_OperateList[1, 1] = new TooltipButtonOperateFashionTakeOffSuit();
			this._doc = XDocuments.GetSpecificDocument<XFashionDocument>(XFashionDocument.uuID);
		}

		public override bool HideToolTip(bool forceHide = false)
		{
			return base.HideToolTip(forceHide);
		}

		protected override void SetupTopFrame(GameObject goToolTip, ItemList.RowData data, bool bMain, XItem instanceData = null, XItem compareData = null)
		{
			base.SetupTopFrame(goToolTip, data, bMain, instanceData, compareData);
			base._SetupLevel(goToolTip, data, 0);
			base._SetupProf(goToolTip, data, bMain, instanceData, 1);
			FashionList.RowData fashionConf = XBagDocument.GetFashionConf(data.ItemID);
			base._SetTopFrameLabel(goToolTip, 2, XStringDefineProxy.GetString("ToolTipText_Part"), (fashionConf != null) ? XSingleton<UiUtility>.singleton.GetFashionPartName((FashionPosition)fashionConf.EquipPos, true) : string.Empty);
			Transform transform = goToolTip.transform;
			GameObject gameObject = transform.FindChild("TopFrame/State").gameObject;
			this.time = (transform.FindChild("TopFrame/Time/Left").GetComponent("XUILabel") as IXUILabel);
			bool flag = this.mainItemUID > 0UL;
			if (flag)
			{
				gameObject.SetActive(this._doc.IsFashionEquipOn(this.mainItemUID));
			}
			else
			{
				gameObject.SetActive(false);
			}
			ClientFashionData clientFashionData = this._doc.FindFashion(this.mainItemUID);
			ItemList.RowData itemConf = XBagDocument.GetItemConf(data.ItemID);
			bool flag2 = itemConf != null;
			if (flag2)
			{
				bool flag3 = itemConf.TimeLimit == 0U;
				if (flag3)
				{
					this.time.SetText(XStringDefineProxy.GetString("FASHION_LIMIT_ALWAYS"));
				}
				else
				{
					bool flag4 = clientFashionData == null;
					if (flag4)
					{
						this.time.SetText(XSingleton<UiUtility>.singleton.TimeDuarationFormatString((int)itemConf.TimeLimit, 5) + XStringDefineProxy.GetString("FASHION_LIMIT_UNWEAR"));
					}
					else
					{
						bool flag5 = clientFashionData.timeleft < 0.0;
						if (flag5)
						{
							this.time.SetText(XSingleton<UiUtility>.singleton.TimeDuarationFormatString((int)itemConf.TimeLimit, 5) + XStringDefineProxy.GetString("FASHION_LIMIT_UNWEAR"));
						}
						else
						{
							this.time.SetText(XSingleton<UiUtility>.singleton.TimeDuarationFormatString((int)itemConf.TimeLimit, 5));
						}
					}
				}
			}
		}

		protected override int _GetPPT(XItem item, bool bMain, ref string valueText)
		{
			bool flag = item == null;
			int result;
			if (flag)
			{
				result = -1;
			}
			else
			{
				uint ppt = item.GetPPT(bMain ? XSingleton<TooltipParam>.singleton.mainAttributes : XSingleton<TooltipParam>.singleton.compareAttributes);
				valueText = ppt.ToString();
				result = (int)ppt;
			}
			return result;
		}

		protected override void SetupOtherFrame(GameObject goToolTip, XItem mainItem, XItem compareItem, bool bMain)
		{
			this._SetupSuitFrame(goToolTip, mainItem, compareItem, bMain);
			base.SetupOtherFrame(goToolTip, mainItem, compareItem, bMain);
		}

		protected override void SetupToolTipButtons(GameObject goToolTip, XItem item, bool bMain)
		{
			base.SetupToolTipButtons(goToolTip, item, bMain);
			bool flag = !this.bShowButtons;
			if (!flag)
			{
				if (bMain)
				{
					bool flag2 = this._doc.IsFashionEquipOn(item.uid);
					if (flag2)
					{
						base._SetupButtonVisiability(goToolTip, 1, item);
					}
					else
					{
						base._SetupButtonVisiability(goToolTip, 0, item);
					}
				}
			}
		}

		private void _SetupSuitFrame(GameObject goToolTip, XItem mainItem, XItem compareItem, bool bMain)
		{
			IXUISprite ixuisprite = goToolTip.transform.FindChild("ScrollPanel/SuitFrame").GetComponent("XUISprite") as IXUISprite;
			bool flag = mainItem == null;
			if (flag)
			{
				ixuisprite.SetVisible(false);
			}
			else
			{
				ixuisprite.SetVisible(true);
				ItemList.RowData itemConf = XBagDocument.GetItemConf(mainItem.itemID);
				int itemQuality = (int)itemConf.ItemQuality;
				bool flag2 = this._doc.IsFashionThreeSpecial(mainItem.itemID);
				int fashionSuit = this._doc.GetFashionSuit(mainItem.itemID);
				bool flag3 = flag2 && fashionSuit == 0;
				if (flag3)
				{
					ixuisprite.SetVisible(false);
				}
				else
				{
					int num = 0;
					int num2 = (XSingleton<TooltipParam>.singleton.FashionOnBody == null) ? this._doc.GetQualityCountOnBody(itemQuality, flag2) : this.GetFashionCount(itemQuality, flag2);
					AttrFrameParam attrFrameParam = new AttrFrameParam();
					for (int i = 2; i <= 7; i++)
					{
						SeqListRef<uint> qualityEffect = this._doc.GetQualityEffect(itemQuality, i, flag2);
						bool flag4 = qualityEffect.Count == 0;
						if (!flag4)
						{
							for (int j = 0; j < qualityEffect.Count; j++)
							{
								bool flag5 = qualityEffect[j, 0] == 0U;
								if (!flag5)
								{
									bool flag6 = i <= num2;
									string text;
									string color;
									if (flag6)
									{
										text = "ffffff";
										color = XSingleton<UiUtility>.singleton.GetColorStr(new Color(0.99607843f, 0.80784315f, 0f));
									}
									else
									{
										text = XSingleton<UiUtility>.singleton.GetColorStr(new Color(0.5019608f, 0.5019608f, 0.5019608f));
										color = text;
									}
									AttrParam item = default(AttrParam);
									AttrParam.ResetSb();
									AttrParam.Append(AttrParam.TextSb, XStringDefineProxy.GetString("EQUIP_SUIT_EFFECT", new object[]
									{
										i
									}), color);
									string s = string.Format("{0}{1}", XStringDefineProxy.GetString((XAttributeDefine)qualityEffect[j, 0]), XAttributeCommon.GetAttrValueStr((int)qualityEffect[j, 0], (float)qualityEffect[j, 1]));
									AttrParam.Append(AttrParam.ValueSb, s, text);
									item.SetTextFromSb();
									item.SetValueFromSb();
									attrFrameParam.AttrList.Add(item);
									num++;
								}
							}
						}
					}
					bool flag7 = num > 0;
					if (flag7)
					{
						bool flag8 = !flag2;
						if (flag8)
						{
							string @string = XStringDefineProxy.GetString("EQUIP_SUIT_TITLE", new object[]
							{
								this._doc.GetQualityName(itemQuality)
							});
							string str = string.Format("({0}/{1})", num2, 7);
							attrFrameParam.Title = @string + str;
						}
						else
						{
							string string2 = XStringDefineProxy.GetString("EQUIP_SUIT_THREE_TITLE", new object[]
							{
								this._doc.GetQualityName(itemQuality)
							});
							string str2 = string.Format("({0}/{1})", num2, 3);
							attrFrameParam.Title = string2 + str2;
						}
						base.AppendFrame(ixuisprite.gameObject, (float)this.SetupAttrFrame(ixuisprite.gameObject, attrFrameParam, bMain), null);
						ixuisprite.SetVisible(false);
						ixuisprite.SetVisible(true);
					}
					else
					{
						ixuisprite.SetVisible(false);
					}
				}
			}
		}

		private int GetFashionCount(int quality, bool IsThreeSuit)
		{
			bool flag = XSingleton<TooltipParam>.singleton.FashionOnBody == null;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				int num = 0;
				int i = 0;
				int count = XSingleton<TooltipParam>.singleton.FashionOnBody.Count;
				while (i < count)
				{
					ItemList.RowData itemConf = XBagDocument.GetItemConf((int)XSingleton<TooltipParam>.singleton.FashionOnBody[i]);
					bool flag2 = itemConf == null;
					if (!flag2)
					{
						bool flag3 = IsThreeSuit ^ this._doc.IsFashionThreeSpecial((int)XSingleton<TooltipParam>.singleton.FashionOnBody[i]);
						if (!flag3)
						{
							bool flag4 = IsThreeSuit && this._doc.GetFashionSuit((int)XSingleton<TooltipParam>.singleton.FashionOnBody[i]) == 0;
							if (!flag4)
							{
								bool flag5 = (int)itemConf.ItemQuality == quality;
								if (flag5)
								{
									num++;
								}
							}
						}
					}
					i++;
				}
				result = num;
			}
			return result;
		}

		public override void OnUpdate()
		{
			ClientFashionData clientFashionData = this._doc.FindFashion(this.mainItemUID);
			bool flag = clientFashionData != null && clientFashionData.timeleft > 0.0;
			if (flag)
			{
				bool flag2 = this.time != null;
				if (flag2)
				{
					this.time.SetText(XSingleton<UiUtility>.singleton.TimeDuarationFormatString((int)clientFashionData.timeleft, 5));
				}
			}
		}

		private XFashionDocument _doc;

		private IXUILabel time = null;
	}
}
