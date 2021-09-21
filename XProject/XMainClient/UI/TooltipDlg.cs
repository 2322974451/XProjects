using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200191B RID: 6427
	internal abstract class TooltipDlg<TDlgClass, TUIBehaviour> : DlgBase<TDlgClass, TUIBehaviour>, ITooltipDlg where TDlgClass : IXUIDlg, new() where TUIBehaviour : TooltipDlgBehaviour
	{
		// Token: 0x17003AE7 RID: 15079
		// (get) Token: 0x06010CDF RID: 68831 RVA: 0x00439094 File Offset: 0x00437294
		public XItemSelector ItemSelector
		{
			get
			{
				return this._ItemSelector;
			}
		}

		// Token: 0x17003AE8 RID: 15080
		// (get) Token: 0x06010CE0 RID: 68832 RVA: 0x004390AC File Offset: 0x004372AC
		// (set) Token: 0x06010CE1 RID: 68833 RVA: 0x004390C4 File Offset: 0x004372C4
		public uint profession
		{
			get
			{
				return this._profession;
			}
			set
			{
				this._profession = value;
				bool flag = this._profession == 0U;
				if (flag)
				{
					this._profession = XItemDrawerParam.DefaultProfession;
				}
			}
		}

		// Token: 0x17003AE9 RID: 15081
		// (get) Token: 0x06010CE2 RID: 68834 RVA: 0x004390F4 File Offset: 0x004372F4
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003AEA RID: 15082
		// (get) Token: 0x06010CE3 RID: 68835 RVA: 0x00439108 File Offset: 0x00437308
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003AEB RID: 15083
		// (get) Token: 0x06010CE4 RID: 68836 RVA: 0x0043911C File Offset: 0x0043731C
		protected virtual int compareWindowDistance
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x17003AEC RID: 15084
		// (get) Token: 0x06010CE5 RID: 68837 RVA: 0x00439130 File Offset: 0x00437330
		protected virtual int funcFrameWidth
		{
			get
			{
				return 150;
			}
		}

		// Token: 0x17003AED RID: 15085
		// (get) Token: 0x06010CE6 RID: 68838 RVA: 0x00439148 File Offset: 0x00437348
		public ulong MainItemUID
		{
			get
			{
				return this.mainItemUID;
			}
		}

		// Token: 0x06010CE7 RID: 68839 RVA: 0x00439160 File Offset: 0x00437360
		protected override void Init()
		{
			base.Init();
			this._bgTopOffset = (float)((XSingleton<XGameUI>.singleton.Base_UI_Height - base.uiBehaviour.m_PanelPool.TplHeight) / 2);
		}

		// Token: 0x06010CE8 RID: 68840 RVA: 0x00439193 File Offset: 0x00437393
		protected override void OnUnload()
		{
			this._ItemSelector.Unload();
			base.OnUnload();
		}

		// Token: 0x06010CE9 RID: 68841 RVA: 0x004391AC File Offset: 0x004373AC
		public virtual bool HideToolTip(bool forceHide = false)
		{
			bool flag = !forceHide;
			if (flag)
			{
				bool bShowedThisFrame = this._bShowedThisFrame;
				if (bShowedThisFrame)
				{
					return false;
				}
				bool bButtonClickedThisFrame = this._bButtonClickedThisFrame;
				if (bButtonClickedThisFrame)
				{
					return false;
				}
			}
			this.SetVisible(false, true);
			this._ItemSelector.Hide();
			this.profession = 0U;
			this.mainItemUID = 0UL;
			this.compareItemUID = 0UL;
			base.uiBehaviour.m_AttrPool.ReturnAll(false);
			base.uiBehaviour.m_PanelPool.ReturnAll(false);
			base.uiBehaviour.m_AttrFramePool.ReturnAll(false);
			return true;
		}

		// Token: 0x06010CEA RID: 68842 RVA: 0x0043925C File Offset: 0x0043745C
		public override void OnUpdate()
		{
			bool flag = this.blockTime == null;
			if (!flag)
			{
				int num = -1;
				bool flag2 = this.mainItemUID > 0UL && XSingleton<XGame>.singleton.Doc.XBagDoc.ItemBag.FindItem(this.mainItemUID, out num) && num > -1;
				if (flag2)
				{
					XItem xitem = XSingleton<XGame>.singleton.Doc.XBagDoc.ItemBag[num];
					bool flag3 = xitem != null && !xitem.bBinding && xitem.blocking > 0.0;
					if (flag3)
					{
						bool flag4 = this.blockTime != null;
						if (flag4)
						{
							this.blockTime.SetText(XStringDefineProxy.GetString("AUCTION_BLOCKING", new object[]
							{
								XSingleton<UiUtility>.singleton.TimeDuarationFormatSizeString((int)xitem.blocking, 2, 1)
							}));
						}
					}
				}
				bool flag5 = this.compareItemUID > 0UL && XSingleton<XGame>.singleton.Doc.XBagDoc.ItemBag.FindItem(this.compareItemUID, out num) && num > -1;
				if (flag5)
				{
					XItem xitem2 = XSingleton<XGame>.singleton.Doc.XBagDoc.ItemBag[num];
					bool flag6 = xitem2 != null && !xitem2.bBinding && xitem2.blocking > 0.0;
					if (flag6)
					{
						bool flag7 = this.compareBlockTime != null;
						if (flag7)
						{
							this.compareBlockTime.SetText(XStringDefineProxy.GetString("AUCTION_BLOCKING", new object[]
							{
								XSingleton<UiUtility>.singleton.TimeDuarationFormatSizeString((int)xitem2.blocking, 2, 1)
							}));
						}
					}
				}
			}
		}

		// Token: 0x06010CEB RID: 68843 RVA: 0x00439405 File Offset: 0x00437605
		public override void OnPostUpdate()
		{
			this._bShowedThisFrame = false;
			this._bButtonClickedThisFrame = false;
		}

		// Token: 0x06010CEC RID: 68844 RVA: 0x00439418 File Offset: 0x00437618
		public void SetPosition(IXUISprite clickIcon)
		{
			int num = base.uiBehaviour.m_TotalFrame.spriteHeight / 2;
			Vector3 localPosition = base.uiBehaviour.m_TotalFrame.gameObject.transform.localPosition;
			base.uiBehaviour.m_TotalFrame.gameObject.transform.localPosition = new Vector3(localPosition.x, (float)num, localPosition.z);
			base.uiBehaviour.DelayShow(this);
		}

		// Token: 0x06010CED RID: 68845 RVA: 0x004394A4 File Offset: 0x004376A4
		public virtual IXUISprite ShowToolTip(XItem mainItem, XItem compareItem, bool _bShowButtons, uint prof = 0U)
		{
			this.bShowButtons = _bShowButtons;
			this.HideToolTip(true);
			this.mainItemUID = ((mainItem == null || mainItem.itemID == 0) ? 0UL : mainItem.uid);
			this.compareItemUID = ((compareItem == null || compareItem.itemID == 0) ? 0UL : compareItem.uid);
			this.SetVisible(true, true);
			GameObject gameObject = base.uiBehaviour.m_PanelPool.FetchGameObject(false);
			gameObject.name = "main";
			this.profession = prof % 10U;
			this.SetupToolTip(gameObject, mainItem, compareItem, true);
			GameObject gameObject2 = null;
			bool flag = compareItem != null && compareItem.itemID != 0;
			if (flag)
			{
				gameObject2 = base.uiBehaviour.m_PanelPool.FetchGameObject(false);
				gameObject2.name = "compare";
				this.profession = prof % 10U;
				this.SetupToolTip(gameObject2, compareItem, mainItem, false);
			}
			IXUISprite ixuisprite = null;
			bool flag2 = compareItem == null || compareItem.itemID == 0;
			IXUISprite ixuisprite2;
			if (flag2)
			{
				ixuisprite2 = (gameObject.GetComponent("XUISprite") as IXUISprite);
				base.uiBehaviour.m_TotalFrame.spriteWidth = ixuisprite2.spriteWidth;
				base.uiBehaviour.m_TotalFrame.spriteHeight = ixuisprite2.spriteHeight;
			}
			else
			{
				int num = 0;
				int num2 = 0;
				ixuisprite2 = (gameObject.GetComponent("XUISprite") as IXUISprite);
				num += ixuisprite2.spriteWidth;
				bool flag3 = ixuisprite2.spriteHeight > num2;
				if (flag3)
				{
					num2 = ixuisprite2.spriteHeight;
				}
				ixuisprite = (gameObject2.GetComponent("XUISprite") as IXUISprite);
				num += ixuisprite.spriteWidth;
				bool flag4 = ixuisprite.spriteHeight > num2;
				if (flag4)
				{
					num2 = ixuisprite.spriteHeight;
				}
				base.uiBehaviour.m_TotalFrame.spriteWidth = num + this.compareWindowDistance;
				base.uiBehaviour.m_TotalFrame.spriteHeight = num2;
			}
			if (_bShowButtons)
			{
				base.uiBehaviour.m_TotalFrame.spriteWidth += this.funcFrameWidth * 2;
			}
			bool flag5 = compareItem == null || compareItem.itemID == 0;
			if (flag5)
			{
				gameObject.transform.localPosition = Vector3.zero;
			}
			else
			{
				gameObject.transform.localPosition = new Vector3((float)(ixuisprite2.spriteWidth / 2 + this.compareWindowDistance / 2), 0f);
				gameObject2.transform.localPosition = new Vector3((float)(-(float)ixuisprite.spriteWidth / 2 - this.compareWindowDistance / 2), 0f);
			}
			this._bShowedThisFrame = true;
			this._bNeedReposition = true;
			return base.uiBehaviour.m_TotalFrame;
		}

		// Token: 0x06010CEE RID: 68846 RVA: 0x0043976C File Offset: 0x0043796C
		public IXUISprite ShowToolTip(int itemid, uint prof = 0U)
		{
			this.HideToolTip(true);
			this.SetVisible(true, true);
			this.profession = prof % 10U;
			this.mainItemUID = 0UL;
			this.compareItemUID = 0UL;
			GameObject gameObject = base.uiBehaviour.m_PanelPool.FetchGameObject(false);
			gameObject.name = "main";
			gameObject.transform.localPosition = base.uiBehaviour.m_PanelPool._tpl.transform.localPosition;
			this.SetupToolTip(gameObject, itemid);
			this._bShowedThisFrame = true;
			this._bNeedReposition = true;
			gameObject.transform.localPosition = Vector3.zero;
			IXUISprite ixuisprite = gameObject.GetComponent("XUISprite") as IXUISprite;
			base.uiBehaviour.m_TotalFrame.spriteWidth = ixuisprite.spriteWidth;
			base.uiBehaviour.m_TotalFrame.spriteHeight = ixuisprite.spriteHeight;
			return base.uiBehaviour.m_TotalFrame;
		}

		// Token: 0x06010CEF RID: 68847 RVA: 0x0043987C File Offset: 0x00437A7C
		protected void SetupToolTip(GameObject goToolTip, int itemid)
		{
			ItemList.RowData itemConf = XBagDocument.GetItemConf(itemid);
			this.totalFrameHeight = base.uiBehaviour.m_TooltipBorder;
			bool flag = itemConf != null;
			if (flag)
			{
				this.SetupTopFrame(goToolTip, itemConf, true, null, null);
			}
			this.bHadJade = false;
			this.SetupOtherFrame(goToolTip, itemConf);
			IXUISprite ixuisprite = goToolTip.GetComponent("XUISprite") as IXUISprite;
			bool flag2 = !this.bHadJade;
			if (flag2)
			{
				ixuisprite.spriteHeight = (int)(Math.Min(this.totalFrameHeight, base.uiBehaviour.m_MaxTooltipHeight) + base.uiBehaviour.m_TooltipBorder);
			}
			else
			{
				ixuisprite.spriteHeight = (int)(Math.Min(this.totalFrameHeight, base.uiBehaviour.m_MaxTooltipHeightWithJade) + base.uiBehaviour.m_TooltipBorder);
			}
			Transform transform = goToolTip.transform.FindChild("FuncFrame");
			transform.gameObject.SetActive(false);
		}

		// Token: 0x06010CF0 RID: 68848 RVA: 0x00439978 File Offset: 0x00437B78
		protected void SetupToolTip(GameObject goToolTip, XItem item, XItem compareItem, bool bMain)
		{
			bool flag = item == null;
			if (!flag)
			{
				this.totalFrameHeight = base.uiBehaviour.m_TooltipBorder;
				ItemList.RowData itemConf = XBagDocument.GetItemConf(item.itemID);
				bool flag2 = itemConf != null;
				if (flag2)
				{
					this.SetupTopFrame(goToolTip, itemConf, bMain, item, compareItem);
				}
				this.SetAllAttrFrames(goToolTip, item as XAttrItem, compareItem as XAttrItem, bMain);
				this.bHadJade = false;
				this.SetupOtherFrame(goToolTip, item, compareItem, bMain);
				this.SetupToolTipButtons(goToolTip, item, bMain);
				IXUIScrollView ixuiscrollView = goToolTip.transform.FindChild("ScrollPanel").GetComponent("XUIScrollView") as IXUIScrollView;
				ixuiscrollView.ResetPosition();
				IXUISprite ixuisprite = goToolTip.GetComponent("XUISprite") as IXUISprite;
				bool flag3 = bMain && !XSingleton<TooltipParam>.singleton.bEquiped;
				if (flag3)
				{
					ixuisprite.SetSprite("kuang_09");
				}
				else
				{
					ixuisprite.SetSprite("kuang_02");
				}
				bool flag4 = !this.bHadJade;
				if (flag4)
				{
					ixuisprite.spriteHeight = (int)(Math.Min(this.totalFrameHeight, base.uiBehaviour.m_MaxTooltipHeight) + base.uiBehaviour.m_TooltipBorder);
				}
				else
				{
					ixuisprite.spriteHeight = (int)(Math.Min(this.totalFrameHeight, base.uiBehaviour.m_MaxTooltipHeightWithJade) + base.uiBehaviour.m_TooltipBorder);
				}
				Transform transform = goToolTip.transform.FindChild("FuncFrame");
				Vector3 localPosition = transform.localPosition;
				transform.localPosition = new Vector3(localPosition.x, (float)(-(float)ixuisprite.spriteHeight), localPosition.z);
				float x = goToolTip.transform.localPosition.x;
			}
		}

		// Token: 0x06010CF1 RID: 68849 RVA: 0x00439B38 File Offset: 0x00437D38
		protected virtual void SetupTopFrame(GameObject goToolTip, ItemList.RowData data, bool bMain, XItem instanceData = null, XItem compareData = null)
		{
			bool flag = data == null;
			if (!flag)
			{
				bool flag2 = data.Profession > 0;
				if (flag2)
				{
					this.profession = (uint)data.Profession;
				}
				this._SetupName(goToolTip, data, instanceData);
				this._SetupQuality(goToolTip, data, bMain);
				this._SetupBinding(goToolTip, data, bMain, instanceData);
				this._SetupIcon(goToolTip, data, instanceData);
				this.totalFrameHeight += (float)base.uiBehaviour.m_TopFrameHeight;
				this.totalFrameHeight += base.uiBehaviour.m_ScrollPanelSoftnessOffset;
				this._SetupPPTFrame(goToolTip, data, bMain, instanceData, compareData);
			}
		}

		// Token: 0x06010CF2 RID: 68850 RVA: 0x00439BE4 File Offset: 0x00437DE4
		protected virtual void _SetupPPTFrame(GameObject goToolTip, ItemList.RowData data, bool bMain, XItem instanceData = null, XItem compareData = null)
		{
			Transform transform = goToolTip.transform.Find("TopFrame/PPTFrame");
			bool flag = transform == null;
			if (!flag)
			{
				bool flag2 = instanceData == null;
				if (flag2)
				{
					transform.gameObject.SetActive(false);
				}
				else
				{
					transform.gameObject.SetActive(true);
					Transform transform2 = transform.Find("Good");
					Transform transform3 = transform.Find("Bad");
					Transform transform4 = transform.Find("Normal");
					transform2.gameObject.SetActive(false);
					transform3.gameObject.SetActive(false);
					transform4.gameObject.SetActive(false);
					string empty = string.Empty;
					string empty2 = string.Empty;
					int num = this._GetPPT(instanceData, true, ref empty);
					int num2 = this._GetPPT(compareData, false, ref empty2);
					bool flag3 = num < 0 || num2 < 0 || num == num2;
					Transform transform5;
					if (flag3)
					{
						transform5 = transform4;
					}
					else
					{
						bool flag4 = num > num2;
						if (flag4)
						{
							transform5 = transform2;
						}
						else
						{
							transform5 = transform3;
						}
					}
					transform5.gameObject.SetActive(true);
					IXUILabel ixuilabel = transform5.Find("Value").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(empty);
					IXUILabel ixuilabel2 = transform5.Find("Title").GetComponent("XUILabel") as IXUILabel;
					XAttributes xattributes = bMain ? XSingleton<TooltipParam>.singleton.mainAttributes : XSingleton<TooltipParam>.singleton.compareAttributes;
					bool flag5 = xattributes == null;
					if (flag5)
					{
						xattributes = XSingleton<XAttributeMgr>.singleton.XPlayerData;
					}
					ProfessionTable.RowData byProfID = XSingleton<XEntityMgr>.singleton.RoleInfo.GetByProfID(xattributes.TypeID);
					string text = (byProfID == null) ? string.Empty : XStringDefineProxy.GetString("ZizhiType" + byProfID.AttackType);
					bool flag6 = text != null;
					if (flag6)
					{
						ixuilabel2.SetText(text);
					}
				}
			}
		}

		// Token: 0x06010CF3 RID: 68851 RVA: 0x00439DC4 File Offset: 0x00437FC4
		protected virtual int _GetPPT(XItem item, bool bMain, ref string valueText)
		{
			return -1;
		}

		// Token: 0x17003AEE RID: 15086
		// (get) Token: 0x06010CF4 RID: 68852 RVA: 0x00439DD8 File Offset: 0x00437FD8
		protected virtual string _PPTTitle
		{
			get
			{
				return null;
			}
		}

		// Token: 0x06010CF5 RID: 68853 RVA: 0x00439DEC File Offset: 0x00437FEC
		protected XItemChangeAttr FindCorrespondingAttr(IEnumerable<XItemChangeAttr> attrs, uint attrID)
		{
			foreach (XItemChangeAttr xitemChangeAttr in attrs)
			{
				bool flag = xitemChangeAttr.AttrID == attrID;
				if (flag)
				{
					return xitemChangeAttr;
				}
			}
			return default(XItemChangeAttr);
		}

		// Token: 0x06010CF6 RID: 68854 RVA: 0x00439E54 File Offset: 0x00438054
		protected virtual void SetAllAttrFrames(GameObject goToolTip, XAttrItem item, XAttrItem compareItem, bool bMain)
		{
			bool flag = item == null || item.changeAttr.Count == 0;
			if (!flag)
			{
				GameObject gameObject = goToolTip.transform.FindChild("ScrollPanel").gameObject;
				this.SetBasicAttrFrame(gameObject, item, compareItem, bMain);
			}
		}

		// Token: 0x06010CF7 RID: 68855 RVA: 0x00439EA0 File Offset: 0x004380A0
		protected void SetBasicAttrFrame(GameObject scrollPanel, XAttrItem item, XAttrItem compareItem, bool bMain)
		{
			GameObject gameObject = base.uiBehaviour.m_AttrFramePool.FetchGameObject(false);
			gameObject.transform.parent = scrollPanel.transform;
			AttrFrameParam attrFrameParam = new AttrFrameParam();
			attrFrameParam.Title = XStringDefineProxy.GetString("TOOLTIP_BASIC_ATTR");
			for (int i = 0; i < item.changeAttr.Count; i++)
			{
				AttrParam item2 = default(AttrParam);
				AttrParam.ResetSb();
				AttrParam.Append(item.changeAttr[i], "", "");
				item2.SetTextFromSb();
				item2.SetValueFromSb();
				attrFrameParam.AttrList.Add(item2);
			}
			this.AppendFrame(gameObject, (float)this.SetupAttrFrame(gameObject, attrFrameParam, bMain), new Vector3?(base.uiBehaviour.m_AttrFramePool.TplPos));
			this.SetAttrOther(scrollPanel.transform, attrFrameParam);
			XSingleton<XGameUI>.singleton.m_uiTool.MarkParentAsChanged(gameObject);
		}

		// Token: 0x06010CF8 RID: 68856 RVA: 0x00439FA0 File Offset: 0x004381A0
		public void AppendFrame(GameObject go, float frameHeight, Vector3? tplPos = null)
		{
			Vector3 vector = tplPos ?? go.transform.localPosition;
			go.transform.localPosition = new Vector3(vector.x, -this.totalFrameHeight, vector.z);
			this.totalFrameHeight += frameHeight;
		}

		// Token: 0x06010CF9 RID: 68857 RVA: 0x0043A000 File Offset: 0x00438200
		protected virtual int SetupAttrFrame(GameObject attrFrame, AttrFrameParam param, bool bMain)
		{
			int num = 0;
			IXUILabel ixuilabel = attrFrame.transform.FindChild("Title").GetComponent("XUILabel") as IXUILabel;
			bool flag = !string.IsNullOrEmpty(param.Title);
			int num2;
			if (flag)
			{
				ixuilabel.SetText(param.Title);
				ixuilabel.SetVisible(true);
				num2 = (int)ixuilabel.gameObject.transform.localPosition.y - ixuilabel.spriteHeight;
			}
			else
			{
				ixuilabel.SetVisible(false);
				num2 = (int)ixuilabel.gameObject.transform.localPosition.y;
			}
			Transform transform = attrFrame.transform.FindChild("EquipRz");
			bool flag2 = transform != null;
			if (flag2)
			{
				transform.gameObject.SetActive(false);
			}
			transform = attrFrame.transform.FindChild("RzLabel");
			bool flag3 = transform != null;
			if (flag3)
			{
				transform.gameObject.SetActive(false);
			}
			for (int i = 0; i < param.AttrList.Count; i++)
			{
				GameObject gameObject = base.uiBehaviour.m_AttrPool.FetchGameObject(false);
				gameObject.transform.parent = attrFrame.transform;
				XSingleton<XGameUI>.singleton.m_uiTool.MarkParentAsChanged(gameObject);
				gameObject.transform.localPosition = new Vector3(base.uiBehaviour.m_AttrPool.TplPos.x, (float)(num2 + num), base.uiBehaviour.m_AttrPool.TplPos.z);
				gameObject.transform.localScale = Vector3.one;
				Transform transform2 = gameObject.transform.FindChild("Icon");
				bool flag4 = transform2 != null;
				if (flag4)
				{
					bool isShowTipsIcon = param.AttrList[i].IsShowTipsIcon;
					if (isShowTipsIcon)
					{
						transform2.gameObject.SetActive(true);
						IXUISprite ixuisprite = transform2.GetComponent("XUISprite") as IXUISprite;
						ixuisprite.SetSprite(param.AttrList[i].IconName);
					}
					else
					{
						transform2.gameObject.SetActive(false);
					}
				}
				IXUILabel ixuilabel2 = gameObject.transform.FindChild("Text").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = gameObject.transform.FindChild("Value").GetComponent("XUILabel") as IXUILabel;
				ixuilabel2.SetText(param.AttrList[i].strText);
				ixuilabel3.SetText(param.AttrList[i].strValue);
				ixuilabel3.SetVisible(false);
				ixuilabel3.SetVisible(true);
				num -= base.uiBehaviour.m_AttrPool.TplHeight;
			}
			IXUISprite ixuisprite2 = attrFrame.GetComponent("XUISprite") as IXUISprite;
			ixuisprite2.spriteHeight = -num - num2;
			return ixuisprite2.spriteHeight;
		}

		// Token: 0x06010CFA RID: 68858 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void SetAttrOther(Transform ParentTra, AttrFrameParam param)
		{
		}

		// Token: 0x06010CFB RID: 68859 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void SetupOtherFrame(GameObject goToolTip, XItem item, XItem compareItem, bool bMain)
		{
		}

		// Token: 0x06010CFC RID: 68860 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void SetupOtherFrame(GameObject goToolTip, ItemList.RowData data)
		{
		}

		// Token: 0x06010CFD RID: 68861 RVA: 0x0043A308 File Offset: 0x00438508
		protected virtual void SetupToolTipButtons(GameObject goToolTip, XItem item, bool bMain)
		{
			for (int i = 0; i < base.uiBehaviour.m_ButtonsVisible.Length; i++)
			{
				base.uiBehaviour.m_ButtonsVisible[i] = false;
			}
			bool flag = this.bShowButtons && bMain;
			if (flag)
			{
				goToolTip.transform.FindChild("FuncFrame").gameObject.SetActive(true);
				Transform transform = goToolTip.transform.FindChild("FuncFrame/Button1");
				bool flag2 = transform != null;
				if (flag2)
				{
					IXUIButton ixuibutton = transform.GetComponent("XUIButton") as IXUIButton;
					ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnButton1Clicked));
				}
				transform = goToolTip.transform.FindChild("FuncFrame/Button2");
				bool flag3 = transform != null;
				if (flag3)
				{
					IXUIButton ixuibutton2 = transform.GetComponent("XUIButton") as IXUIButton;
					ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnButton2Clicked));
				}
				transform = goToolTip.transform.FindChild("FuncFrame/Button3");
				bool flag4 = transform != null;
				if (flag4)
				{
					IXUIButton ixuibutton3 = transform.GetComponent("XUIButton") as IXUIButton;
					ixuibutton3.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnButton3Clicked));
				}
				transform = goToolTip.transform.FindChild("FuncFrame/Button4");
				bool flag5 = transform != null;
				if (flag5)
				{
					IXUIButton ixuibutton4 = transform.GetComponent("XUIButton") as IXUIButton;
					ixuibutton4.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnButton4Clicked));
				}
				transform = goToolTip.transform.FindChild("FuncFrame/Button5");
				bool flag6 = transform != null;
				if (flag6)
				{
					IXUIButton ixuibutton5 = transform.GetComponent("XUIButton") as IXUIButton;
					ixuibutton5.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnButton5Clicked));
				}
				transform = goToolTip.transform.FindChild("FuncFrame/Button6");
				bool flag7 = transform != null;
				if (flag7)
				{
					IXUIButton ixuibutton6 = transform.GetComponent("XUIButton") as IXUIButton;
					ixuibutton6.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnButton6Clicked));
				}
				transform = goToolTip.transform.FindChild("FuncFrame/Button7");
				bool flag8 = transform != null;
				if (flag8)
				{
					IXUIButton ixuibutton7 = transform.GetComponent("XUIButton") as IXUIButton;
					ixuibutton7.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnButton7Clicked));
				}
			}
			else
			{
				goToolTip.transform.FindChild("FuncFrame").gameObject.SetActive(false);
			}
		}

		// Token: 0x06010CFE RID: 68862 RVA: 0x0043A58C File Offset: 0x0043878C
		protected Vector3 _GetNextButtonPos()
		{
			Vector3[] buttonsOriginPos = base.uiBehaviour.m_ButtonsOriginPos;
			int activeButtonCount = this._ActiveButtonCount;
			this._ActiveButtonCount = activeButtonCount + 1;
			return buttonsOriginPos[activeButtonCount];
		}

		// Token: 0x06010CFF RID: 68863 RVA: 0x0043A5C4 File Offset: 0x004387C4
		public void SetupButtons(GameObject goToolTip, int group, bool bMain, int selectedIndex = -1, List<int> redPointIndex = null)
		{
			this._ActiveButtonCount = 0;
			bool flag = group >= TooltipDlgBehaviour.MAX_GROUP_COUNT;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Group id out of range: ", group.ToString(), null, null, null, null);
			}
			else
			{
				int num = bMain ? 1 : -1;
				for (int i = 0; i < TooltipDlgBehaviour.MAX_BUTTON_COUNT; i++)
				{
					Transform transform = goToolTip.transform.FindChild("FuncFrame/Button" + (i + 1));
					bool flag2 = transform != null;
					if (flag2)
					{
						bool flag3 = base.uiBehaviour.m_ButtonsVisible[i];
						if (flag3)
						{
							transform.gameObject.SetActive(true);
							IXUILabel ixuilabel = transform.FindChild("Label").GetComponent("XUILabel") as IXUILabel;
							ixuilabel.SetText(base.uiBehaviour.m_ButtonsText[group, i]);
							IXUIButton ixuibutton = transform.GetComponent("XUIButton") as IXUIButton;
							ixuibutton.ID = (ulong)((long)group);
							Vector3 vector = this._GetNextButtonPos();
							transform.localPosition = new Vector3(Mathf.Abs(vector.x) * (float)num, vector.y, vector.z);
							IXUISprite ixuisprite = transform.GetComponent("XUISprite") as IXUISprite;
							bool flag4 = ixuisprite != null;
							if (flag4)
							{
								bool flag5 = redPointIndex != null && redPointIndex.Count != 0 && redPointIndex.Contains(i);
								if (flag5)
								{
									ixuisprite.gameObject.transform.FindChild("RedPoint").gameObject.SetActive(true);
								}
								else
								{
									ixuisprite.gameObject.transform.FindChild("RedPoint").gameObject.SetActive(false);
								}
							}
						}
						else
						{
							transform.gameObject.SetActive(false);
						}
					}
				}
			}
		}

		// Token: 0x06010D00 RID: 68864 RVA: 0x0043A7A8 File Offset: 0x004389A8
		protected void _SetupButtonVisiability(GameObject goToolTip, int group, XItem item)
		{
			this.m_TempList.Clear();
			for (int i = 0; i < TooltipDlgBehaviour.MAX_BUTTON_COUNT; i++)
			{
				TooltipButtonOperateBase tooltipButtonOperateBase = this.m_OperateList[group, i];
				bool flag = tooltipButtonOperateBase != null;
				if (flag)
				{
					this.m_uiBehaviour.m_ButtonsVisible[i] = tooltipButtonOperateBase.IsButtonVisible(item);
					this.m_uiBehaviour.m_ButtonsText[group, i] = tooltipButtonOperateBase.GetButtonText();
					bool flag2 = tooltipButtonOperateBase.HasRedPoint(item);
					if (flag2)
					{
						this.m_TempList.Add(i);
					}
				}
			}
			this.SetupButtons(goToolTip, group, true, -1, this.m_TempList);
		}

		// Token: 0x06010D01 RID: 68865 RVA: 0x0043A854 File Offset: 0x00438A54
		protected virtual bool OnButton7Clicked(IXUIButton button)
		{
			this._bButtonClickedThisFrame = true;
			bool flag = this.m_OperateList[(int)button.ID, 6] != null;
			if (flag)
			{
				this.m_OperateList[(int)button.ID, 6].OnButtonClick(this.mainItemUID, this.compareItemUID);
			}
			this.HideToolTip(true);
			return true;
		}

		// Token: 0x06010D02 RID: 68866 RVA: 0x0043A8B8 File Offset: 0x00438AB8
		protected virtual bool OnButton6Clicked(IXUIButton button)
		{
			this._bButtonClickedThisFrame = true;
			bool flag = this.m_OperateList[(int)button.ID, 5] != null;
			if (flag)
			{
				this.m_OperateList[(int)button.ID, 5].OnButtonClick(this.mainItemUID, this.compareItemUID);
			}
			this.HideToolTip(true);
			return true;
		}

		// Token: 0x06010D03 RID: 68867 RVA: 0x0043A91C File Offset: 0x00438B1C
		protected virtual bool OnButton5Clicked(IXUIButton button)
		{
			this._bButtonClickedThisFrame = true;
			bool flag = this.m_OperateList[(int)button.ID, 4] != null;
			if (flag)
			{
				this.m_OperateList[(int)button.ID, 4].OnButtonClick(this.mainItemUID, this.compareItemUID);
			}
			this.HideToolTip(true);
			return true;
		}

		// Token: 0x06010D04 RID: 68868 RVA: 0x0043A980 File Offset: 0x00438B80
		protected virtual bool OnButton4Clicked(IXUIButton button)
		{
			this._bButtonClickedThisFrame = true;
			bool flag = this.m_OperateList[(int)button.ID, 3] != null;
			if (flag)
			{
				this.m_OperateList[(int)button.ID, 3].OnButtonClick(this.mainItemUID, this.compareItemUID);
			}
			this.HideToolTip(true);
			return true;
		}

		// Token: 0x06010D05 RID: 68869 RVA: 0x0043A9E4 File Offset: 0x00438BE4
		protected virtual bool OnButton3Clicked(IXUIButton button)
		{
			this._bButtonClickedThisFrame = true;
			bool flag = this.m_OperateList[(int)button.ID, 2] != null;
			if (flag)
			{
				this.m_OperateList[(int)button.ID, 2].OnButtonClick(this.mainItemUID, this.compareItemUID);
			}
			this.HideToolTip(true);
			return true;
		}

		// Token: 0x06010D06 RID: 68870 RVA: 0x0043AA48 File Offset: 0x00438C48
		protected virtual bool OnButton2Clicked(IXUIButton button)
		{
			this._bButtonClickedThisFrame = true;
			bool flag = this.m_OperateList[(int)button.ID, 1] != null;
			if (flag)
			{
				this.m_OperateList[(int)button.ID, 1].OnButtonClick(this.mainItemUID, this.compareItemUID);
			}
			this.HideToolTip(true);
			return true;
		}

		// Token: 0x06010D07 RID: 68871 RVA: 0x0043AAAC File Offset: 0x00438CAC
		protected virtual bool OnButton1Clicked(IXUIButton button)
		{
			this._bButtonClickedThisFrame = true;
			bool flag = this.m_OperateList[(int)button.ID, 0] != null;
			if (flag)
			{
				this.m_OperateList[(int)button.ID, 0].OnButtonClick(this.mainItemUID, this.compareItemUID);
			}
			this.HideToolTip(true);
			return true;
		}

		// Token: 0x06010D08 RID: 68872 RVA: 0x0043AB10 File Offset: 0x00438D10
		protected void _SetTopFrameLabel(GameObject goToolTip, int index, string key, string value)
		{
			IXUILabel ixuilabel = goToolTip.transform.FindChild("TopFrame/Text" + index.ToString()).GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = ixuilabel.gameObject.transform.Find("T").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(value);
			ixuilabel2.SetText(key);
		}

		// Token: 0x06010D09 RID: 68873 RVA: 0x0043AB80 File Offset: 0x00438D80
		protected void _SetupQuality(GameObject goToolTip, ItemList.RowData data, bool bMain)
		{
			GameObject gameObject = goToolTip.transform.Find("TopFrame/Quality/MainFrame").gameObject;
			GameObject gameObject2 = goToolTip.transform.Find("TopFrame/Quality/CompareFrame").gameObject;
			bool flag = bMain && !XSingleton<TooltipParam>.singleton.bEquiped;
			gameObject.SetActive(flag);
			gameObject2.SetActive(!flag);
			IXUISprite ixuisprite = goToolTip.transform.FindChild("TopFrame/Quality").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.spriteName = XSingleton<UiUtility>.singleton.GetItemQualityIcon((int)data.ItemQuality);
		}

		// Token: 0x06010D0A RID: 68874 RVA: 0x0043AC18 File Offset: 0x00438E18
		protected void _SetupBinding(GameObject goToolTip, ItemList.RowData data, bool bMain, XItem instanceData = null)
		{
			Transform transform = goToolTip.transform.Find("TopFrame/Binding/Yes");
			Transform transform2 = goToolTip.transform.Find("TopFrame/Binding/No");
			Transform transform3 = goToolTip.transform.FindChild("TopFrame/Binding/Blocking");
			bool flag = transform3 != null;
			if (flag)
			{
				if (bMain)
				{
					this.blockTime = (transform3.GetComponent("XUILabel") as IXUILabel);
				}
				else
				{
					this.compareBlockTime = (transform3.GetComponent("XUILabel") as IXUILabel);
				}
			}
			bool flag2 = XSingleton<TooltipParam>.singleton.bBinded;
			double num = 0.0;
			bool flag3 = instanceData != null;
			if (flag3)
			{
				num = instanceData.blocking;
				flag2 = instanceData.bBinding;
			}
			bool flag4 = this.blockTime != null && bMain;
			if (flag4)
			{
				this.blockTime.SetText((!flag2 && num > 0.0) ? XStringDefineProxy.GetString("AUCTION_BLOCKING", new object[]
				{
					XSingleton<UiUtility>.singleton.TimeDuarationFormatString((int)instanceData.blocking, 4)
				}) : string.Empty);
			}
			bool flag5 = this.compareBlockTime != null && !bMain;
			if (flag5)
			{
				this.compareBlockTime.SetText((!flag2 && num > 0.0) ? XStringDefineProxy.GetString("AUCTION_BLOCKING", new object[]
				{
					XSingleton<UiUtility>.singleton.TimeDuarationFormatString((int)instanceData.blocking, 4)
				}) : string.Empty);
			}
			bool flag6 = transform != null;
			if (flag6)
			{
				transform.gameObject.SetActive(flag2);
			}
			bool flag7 = transform2 != null;
			if (flag7)
			{
				transform2.gameObject.SetActive(!flag2);
			}
		}

		// Token: 0x06010D0B RID: 68875 RVA: 0x0043ADC0 File Offset: 0x00438FC0
		protected void _SetupIcon(GameObject goToolTip, ItemList.RowData data, XItem instanceData)
		{
			XItemDrawerMgr.Param.Profession = this.profession;
			bool flag = instanceData == null;
			if (flag)
			{
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(goToolTip.transform.Find("TopFrame/ItemTpl").gameObject, data, 0, false);
			}
			else
			{
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(goToolTip.transform.Find("TopFrame/ItemTpl").gameObject, instanceData);
			}
		}

		// Token: 0x06010D0C RID: 68876 RVA: 0x0043AE34 File Offset: 0x00439034
		protected void _SetupLevel(GameObject goToolTip, ItemList.RowData data, int index)
		{
			this._SetTopFrameLabel(goToolTip, index, XStringDefineProxy.GetString("ToolTipText_Level"), ((long)data.ReqLevel > (long)((ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level)) ? ("[ff0000]" + data.ReqLevel.ToString()) : data.ReqLevel.ToString());
		}

		// Token: 0x06010D0D RID: 68877 RVA: 0x0043AE90 File Offset: 0x00439090
		protected void _SetupProf(GameObject goToolTip, ItemList.RowData data, bool bMain, XItem instanceData, int index)
		{
			this._SetTopFrameLabel(goToolTip, index, XStringDefineProxy.GetString("ToolTipText_Prof"), this._GetProf(data, bMain, instanceData));
		}

		// Token: 0x06010D0E RID: 68878 RVA: 0x0043AEB1 File Offset: 0x004390B1
		protected void _SetupType(GameObject goToolTip, ItemList.RowData data, int index)
		{
			this._SetTopFrameLabel(goToolTip, index, XStringDefineProxy.GetString("ToolTipText_Type"), XSingleton<UiUtility>.singleton.GetItemTypeStr((int)data.ItemType));
		}

		// Token: 0x06010D0F RID: 68879 RVA: 0x0043AED8 File Offset: 0x004390D8
		protected void _SetupName(GameObject goToolTip, ItemList.RowData data, XItem instanceData = null)
		{
			IXUILabel ixuilabel = goToolTip.transform.Find("TopFrame/Name").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(XSingleton<UiUtility>.singleton.GetEquipName(data, instanceData, this.profession));
			ixuilabel.SetColor(XSingleton<UiUtility>.singleton.GetItemQualityColor((int)data.ItemQuality));
		}

		// Token: 0x06010D10 RID: 68880 RVA: 0x0043AF38 File Offset: 0x00439138
		protected string _GetProf(ItemList.RowData data, bool bMain, XItem instanceData)
		{
			bool flag = XBagDocument.IsProfMatched((uint)data.Profession);
			string result;
			if (flag)
			{
				result = XSingleton<XProfessionSkillMgr>.singleton.GetProfName((int)data.Profession);
			}
			else
			{
				result = "[ff0000]" + XSingleton<XProfessionSkillMgr>.singleton.GetProfName((int)data.Profession);
			}
			return result;
		}

		// Token: 0x06010D11 RID: 68881 RVA: 0x0043AF88 File Offset: 0x00439188
		public static Rect GetValidPos(int width, int height)
		{
			Rect result = default(Rect);
			result.Set((float)(-(float)(XSingleton<XGameUI>.singleton.Base_UI_Width - width) / 2), (float)(-(float)XSingleton<XGameUI>.singleton.Base_UI_Height / 2 + height), (float)(XSingleton<XGameUI>.singleton.Base_UI_Width - width), (float)(XSingleton<XGameUI>.singleton.Base_UI_Height - height));
			return result;
		}

		// Token: 0x04007B4C RID: 31564
		public ulong mainItemUID = 0UL;

		// Token: 0x04007B4D RID: 31565
		public ulong compareItemUID = 0UL;

		// Token: 0x04007B4E RID: 31566
		protected bool _bShowedThisFrame = false;

		// Token: 0x04007B4F RID: 31567
		protected bool _bButtonClickedThisFrame = false;

		// Token: 0x04007B50 RID: 31568
		protected float _bgTopOffset;

		// Token: 0x04007B51 RID: 31569
		protected bool _bNeedReposition;

		// Token: 0x04007B52 RID: 31570
		public float totalFrameHeight;

		// Token: 0x04007B53 RID: 31571
		public bool bShowButtons = true;

		// Token: 0x04007B54 RID: 31572
		protected bool bHadJade = false;

		// Token: 0x04007B55 RID: 31573
		protected TooltipButtonOperateBase[,] m_OperateList = new TooltipButtonOperateBase[TooltipDlgBehaviour.MAX_GROUP_COUNT, TooltipDlgBehaviour.MAX_BUTTON_COUNT];

		// Token: 0x04007B56 RID: 31574
		private IXUILabel blockTime = null;

		// Token: 0x04007B57 RID: 31575
		private IXUILabel compareBlockTime = null;

		// Token: 0x04007B58 RID: 31576
		private XItemSelector _ItemSelector = new XItemSelector(XSingleton<XGlobalConfig>.singleton.DefaultIconWidth);

		// Token: 0x04007B59 RID: 31577
		private int _ActiveButtonCount = 0;

		// Token: 0x04007B5A RID: 31578
		protected uint _profession = 0U;

		// Token: 0x04007B5B RID: 31579
		private List<int> m_TempList = new List<int>();
	}
}
