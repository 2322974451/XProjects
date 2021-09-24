

using KKSG;
using MiniJSON;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient.UI
{
    public class UiUtility : XSingleton<UiUtility>, IUiUtility, IXInterface
    {
        private StringBuilder _Timebuilder = new StringBuilder();
        private int[] TimeDuaration = new int[5]
        {
      2592000,
      86400,
      3600,
      60,
      1
        };
        private string[] TimeDuarationName = new string[5]
        {
      "MONTH_DUARATION",
      "DAY_DUARATION",
      "HOUR_DUARATION",
      "MINUTE_DUARATION",
      "SECOND_DUARATION"
        };
        private string[] TimeName = new string[5]
        {
      "MONTH_DUARATION",
      "DAY_DUARATION",
      "HOUR_DUARATION",
      "MINUTE_TIME",
      "SECOND_DUARATION"
        };
        private string[] NumberSeparatorNames = (string[])null;
        private string wifiBtn;
        private uint wifi_green = 0;
        private uint wifi_yellow = 0;
        private bool wifi_forward = true;
        private float wifi_duration = 1f;
        private float wifi_cur = 0.0f;
        public List<string> ComSpriteStr = new List<string>();

        public bool Deprecated { get; set; }

        private bool FatalErrorButtonCallback(IXUIButton go)
        {
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
            XSingleton<XShell>.singleton.Pause = false;
            XSingleton<XClientNetwork>.singleton.OnFatalErrorCallback();
            return true;
        }

        public void OnFatalErrorClosed(ErrorCode code)
        {
            XSingleton<XTutorialMgr>.singleton.StopTutorial();
            XSingleton<XShell>.singleton.Pause = true;
            string label = XStringDefineProxy.GetString(code);
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.Load();
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetSingleButtonMode(true);
            this._ShowModalDialog(label, XStringDefineProxy.GetString(XStringDefine.COMMON_OK), "-", new ButtonClickEventHandler(this.FatalErrorButtonCallback), 300);
        }

        public void OnFatalErrorClosed(string text)
        {
            XSingleton<XTutorialMgr>.singleton.StopTutorial();
            XSingleton<XShell>.singleton.Pause = true;
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.Load();
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetSingleButtonMode(true);
            this._ShowModalDialog(text, XStringDefineProxy.GetString(XStringDefine.COMMON_OK), "-", new ButtonClickEventHandler(this.FatalErrorButtonCallback), 300);
        }

        public void ShowErrorCode(ErrorCode code) => this.ShowModalDialog(XStringDefineProxy.GetString(code), XStringDefineProxy.GetString(XStringDefine.COMMON_OK));

        internal string GetEquipName(ItemList.RowData data, XItem instanceData = null, uint profession = 0)
        {
            if (instanceData != null && instanceData.Type == ItemType.EQUIP)
            {
                XEquipItem xequipItem = instanceData as XEquipItem;
                if (xequipItem.enhanceInfo.EnhanceLevel > 0U)
                    return string.Format("{0}+{1}", (object)XSingleton<UiUtility>.singleton.ChooseProfString(data.ItemName, profession), (object)xequipItem.enhanceInfo.EnhanceLevel.ToString());
            }
            return XSingleton<UiUtility>.singleton.ChooseProfString(data.ItemName, profession);
        }

        internal void ShowTooltipDialogWithSearchingCompare(
          XItem mainItem,
          IXUISprite icon = null,
          bool bShowButtons = true,
          uint profession = 0)
        {
            if (mainItem == null)
                return;
            XItem compareItem = (XItem)null;
            if (mainItem.type == 1U)
            {
                EquipList.RowData equipConf = XBagDocument.GetEquipConf(mainItem.itemID);
                if (equipConf == null)
                {
                    XSingleton<XDebug>.singleton.AddErrorLog("Cannot find equip config for id: ", mainItem.itemID.ToString());
                    return;
                }
                compareItem = XSingleton<XGame>.singleton.Doc.XBagDoc.EquipBag[(int)equipConf.EquipPos];
            }
            else if (mainItem.type == 6U)
                compareItem = XEmblemDocument.CheckEquipedEmblemsAttrs(XSingleton<XGame>.singleton.Doc.XBagDoc.EmblemBag, mainItem);
            else if (mainItem.type == 31U)
            {
                ArtifactListTable.RowData artifactListRowData = ArtifactDocument.GetArtifactListRowData((uint)mainItem.itemID);
                if (artifactListRowData == null)
                {
                    XSingleton<XDebug>.singleton.AddErrorLog("Cannot find artifact config for id: ", mainItem.itemID.ToString());
                    return;
                }
                compareItem = XSingleton<XGame>.singleton.Doc.XBagDoc.ArtifactBag[(int)artifactListRowData.ArtifactPos];
            }
            this.ShowTooltipDialog(mainItem, compareItem, icon, bShowButtons, profession);
        }

        internal void ShowTooltipDialog(
          XItem mainItem,
          XItem compareItem,
          IXUISprite icon = null,
          bool bShowButtons = true,
          uint profession = 0)
        {
            if (mainItem == null)
                return;
            if (compareItem != null && compareItem.itemID != 0 && mainItem.Type != compareItem.Type)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("mainItem.Type != compareItem.Type");
            }
            else
            {
                XDocuments.GetSpecificDocument<XFashionDocument>(XFashionDocument.uuID);
                if (DlgBase<EquipTooltipDlg, EquipTooltipDlgBehaviour>.singleton.IsLoaded())
                    DlgBase<EquipTooltipDlg, EquipTooltipDlgBehaviour>.singleton.HideToolTip(true);
                if (DlgBase<ItemTooltipDlg, ItemTooltipDlgBehaviour>.singleton.IsLoaded())
                    DlgBase<ItemTooltipDlg, ItemTooltipDlgBehaviour>.singleton.HideToolTip(true);
                if (DlgBase<EmblemTooltipDlg, EmblemTooltipDlgBehaviour>.singleton.IsLoaded())
                    DlgBase<EmblemTooltipDlg, EmblemTooltipDlgBehaviour>.singleton.HideToolTip(true);
                if (DlgBase<JadeTooltipDlg, TooltipDlgBehaviour>.singleton.IsLoaded())
                    DlgBase<JadeTooltipDlg, TooltipDlgBehaviour>.singleton.HideToolTip(true);
                if (DlgBase<FashionTooltipDlg, FashionTooltipDlgBehaviour>.singleton.IsLoaded())
                    DlgBase<FashionTooltipDlg, FashionTooltipDlgBehaviour>.singleton.HideToolTip(true);
                if (DlgBase<ArtifactToolTipDlg, ArtifactTooltipDlgBehaviour>.singleton.IsLoaded())
                    DlgBase<ArtifactToolTipDlg, ArtifactTooltipDlgBehaviour>.singleton.HideToolTip(true);
                if (DlgBase<FashionHairToolTipDlg, FashionHairToolTipBehaviour>.singleton.IsLoaded())
                    DlgBase<FashionHairToolTipDlg, FashionHairToolTipBehaviour>.singleton.HideToolTip(true);
                ITooltipDlg tooltipDlg = mainItem.Description.TooltipDlg;
                tooltipDlg.ShowToolTip(mainItem, compareItem, bShowButtons, profession);
                tooltipDlg.ItemSelector.Select(icon);
                tooltipDlg.SetPosition(icon);
                XSingleton<TooltipParam>.singleton.Reset();
            }
        }

        public void PushBarrage(string nick, string content) => DlgBase<BroadcastDlg, BroadcastBehaviour>.singleton.Push(nick, content);

        public void StartBroadcast(bool start)
        {
            if (start)
            {
                DlgBase<BroadMiniDlg, BroadcastMiniBehaviour>.singleton.isBroadcast = true;
                DlgBase<BroadMiniDlg, BroadcastMiniBehaviour>.singleton.Show(true);
            }
            else
            {
                DlgBase<BroadMiniDlg, BroadcastMiniBehaviour>.singleton.isBroadcast = false;
                DlgBase<BroadMiniDlg, BroadcastMiniBehaviour>.singleton.Show(false);
            }
        }

        public void ShowDetailTooltip(int itemID, GameObject icon = null) => this.ShowTooltipDialog(XBagDocument.MakeXItem(itemID), (XItem)null, icon.GetComponent("XUISprite") as IXUISprite, false);

        public void ParseHeadIcon(List<uint> setid, IXUISprite spr)
        {
            if (setid == null)
            {
                spr.SetVisible(false);
            }
            else
            {
                string preContent = XPrerogativeDocument.ConvertTypeToPreContent(PrerogativeType.PreHeadPortrait, setid);
                string empty = string.Empty;
                if (!string.IsNullOrEmpty(preContent))
                {
                    string[] strArray = preContent.Split('=');
                    if (strArray.Length >= 2)
                        empty = strArray[1];
                }
                if (!string.IsNullOrEmpty(empty))
                {
                    spr.SetVisible(true);
                    spr.SetSprite(empty);
                }
                else
                    spr.SetVisible(false);
            }
        }

        public void ShowTooltipDialog(int itemID, GameObject icon = null)
        {
            ItemList.RowData itemConf = XBagDocument.GetItemConf(itemID);
            if (itemConf == null)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("rowData == null: ", itemID.ToString());
            }
            else
            {
                IXUISprite xuiSprite = (IXUISprite)null;
                if ((UnityEngine.Object)null != (UnityEngine.Object)icon)
                    xuiSprite = icon.GetComponent("XUISprite") as IXUISprite;
                if (itemConf.ItemType == (byte)5)
                {
                    XSingleton<UiUtility>.singleton.ShowTooltipDialog(XBagDocument.MakeXItem(itemID), (XItem)null, xuiSprite, false);
                }
                else
                {
                    itemID = XBagDocument.ConvertTemplate(itemConf);
                    DlgBase<ItemTooltipDlg, ItemTooltipDlgBehaviour>.singleton.ShowToolTip(itemID);
                    DlgBase<ItemTooltipDlg, ItemTooltipDlgBehaviour>.singleton.ItemSelector.Select(icon);
                    DlgBase<ItemTooltipDlg, ItemTooltipDlgBehaviour>.singleton.SetPosition(xuiSprite);
                    XSingleton<TooltipParam>.singleton.Reset();
                }
            }
        }

        internal void ShowOutLookDialog(XItem item, IXUISprite icon = null, uint proferssion = 0)
        {
            if (item == null)
                return;
            if (item.Type == ItemType.FASHION)
            {
                FashionList.RowData fashionConf = XBagDocument.GetFashionConf(item.itemID);
                if (fashionConf != null && (int)fashionConf.EquipPos == XFastEnumIntEqualityComparer<FashionPosition>.ToInt(FashionPosition.Hair))
                {
                    DlgBase<FashionStorageFashionHairToolTipDlg, FashionHairToolTipBehaviour>.singleton.ShowToolTip(item, (XItem)null, true, proferssion);
                    DlgBase<FashionStorageFashionHairToolTipDlg, FashionHairToolTipBehaviour>.singleton.ItemSelector.Select(icon);
                    DlgBase<FashionStorageFashionHairToolTipDlg, FashionHairToolTipBehaviour>.singleton.SetPosition(icon);
                }
                else
                {
                    DlgBase<FashionStorageFashionToolTipDlg, FashionTooltipDlgBehaviour>.singleton.ShowToolTip(item, (XItem)null, true, proferssion);
                    DlgBase<FashionStorageFashionToolTipDlg, FashionTooltipDlgBehaviour>.singleton.ItemSelector.Select(icon);
                    DlgBase<FashionStorageFashionToolTipDlg, FashionTooltipDlgBehaviour>.singleton.SetPosition(icon);
                }
                XSingleton<TooltipParam>.singleton.Reset();
            }
            else
            {
                if (item.Type != ItemType.EQUIP)
                    return;
                DlgBase<FashionStorageEquipToolTipDlg, ItemTooltipDlgBehaviour>.singleton.ShowToolTip(item, (XItem)null, true, proferssion);
                DlgBase<FashionStorageEquipToolTipDlg, ItemTooltipDlgBehaviour>.singleton.ItemSelector.Select(icon);
                DlgBase<FashionStorageEquipToolTipDlg, ItemTooltipDlgBehaviour>.singleton.SetPosition(icon);
                XSingleton<TooltipParam>.singleton.Reset();
            }
        }

        public void ShowTooltipDialog(int itemID, IXUISprite icon = null, uint profession = 0)
        {
            ItemList.RowData itemConf = XBagDocument.GetItemConf(itemID);
            if (itemConf == null)
                XSingleton<XDebug>.singleton.AddErrorLog("rowData == null: ", itemID.ToString());
            else if (itemConf.ItemType == (byte)5)
            {
                XSingleton<UiUtility>.singleton.ShowTooltipDialog(XBagDocument.MakeXItem(itemID), (XItem)null, icon, false);
            }
            else
            {
                itemID = XBagDocument.ConvertTemplate(itemConf);
                DlgBase<ItemTooltipDlg, ItemTooltipDlgBehaviour>.singleton.ShowToolTip(itemID, profession);
                DlgBase<ItemTooltipDlg, ItemTooltipDlgBehaviour>.singleton.ItemSelector.Select(icon);
                DlgBase<ItemTooltipDlg, ItemTooltipDlgBehaviour>.singleton.SetPosition(icon);
                XSingleton<TooltipParam>.singleton.Reset();
            }
        }

        public void ShowTooltipDialogByUID(string strUID, GameObject icon = null)
        {
            ulong result = 0;
            if (!ulong.TryParse(strUID, out result))
                return;
            XItem mainItem = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(result);
            if (mainItem == null)
            {
                XFashionDocument xcomponent = XSingleton<XGame>.singleton.Doc.GetXComponent(XFashionDocument.uuID) as XFashionDocument;
                ClientFashionData fashion = xcomponent.FindFashion(result);
                if (fashion != null)
                    mainItem = xcomponent.MakeXItem(fashion);
            }
            if (mainItem != null)
            {
                IXUISprite icon1 = (IXUISprite)null;
                if ((UnityEngine.Object)null != (UnityEngine.Object)icon)
                    icon1 = icon.GetComponent("XUISprite") as IXUISprite;
                this.ShowTooltipDialog(mainItem, (XItem)null, icon1, false);
            }
        }

        public void ShowSystemHelp(string main, string title, string label)
        {
            DlgBase<SystemHelpDlg, SystemHelpBehaviour>.singleton.Load();
            this._ShowSystemHelp(main, title, label);
        }

        public void ShowModalDialogWithTitle(
          string title,
          string label,
          string firstBtn,
          ButtonClickEventHandler handler = null,
          int depth = 50)
        {
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.Load();
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetSingleButtonMode(true);
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetCloseButtonVisible(false);
            this._ShowModalDialog(label, firstBtn, "-", handler, depth, title);
        }

        public void ShowModalDialog(string label, string firstBtn)
        {
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.Load();
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetSingleButtonMode(true);
            this._ShowModalDialog(label, firstBtn, "-");
        }

        public void ShowModalDialog(
          string label,
          string firstBtn,
          ButtonClickEventHandler handler = null,
          int depth = 50)
        {
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.Load();
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetSingleButtonMode(true);
            this._ShowModalDialog(label, firstBtn, "-", handler, depth);
        }

        public void ShowModalDialog(
          string label,
          string firstBtn,
          string secondBtn,
          ButtonClickEventHandler handler = null)
        {
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.Load();
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetSingleButtonMode(false);
            this._ShowModalDialog(label, firstBtn, secondBtn, handler);
        }

        public void ShowModalDialog(
          string label,
          string firstBtn,
          string secondBtn,
          ButtonClickEventHandler handler = null,
          int depth = 50)
        {
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.Load();
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetSingleButtonMode(false);
            this._ShowModalDialog(label, firstBtn, secondBtn, handler, depth);
        }

        public void ShowModalDialog(
          string label,
          string firstBtn,
          string secondBtn,
          ButtonClickEventHandler handler,
          ButtonClickEventHandler handler2,
          bool showCloseBtn = false,
          XTempTipDefine showNoTip = XTempTipDefine.OD_START,
          int depth = 50)
        {
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.StartTip = showNoTip;
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.Load();
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetSingleButtonMode(false);
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetCloseButtonVisible(showCloseBtn);
            this._ShowModalDialog(label, firstBtn, secondBtn, handler, handler2, depth);
        }

        public void ShowModalDialog(
          string title,
          string label,
          string firstBtn,
          string secondBtn,
          ButtonClickEventHandler handler,
          ButtonClickEventHandler handler2,
          bool showCloseBtn = false,
          XTempTipDefine showNoTip = XTempTipDefine.OD_START,
          int depth = 50)
        {
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.StartTip = showNoTip;
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.Load();
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetSingleButtonMode(false);
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetCloseButtonVisible(showCloseBtn);
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetTitle(title);
            this._ShowModalDialog(label, firstBtn, secondBtn, handler, handler2, depth);
        }

        public void ShowModalDialog(string message, ButtonClickEventHandler handler)
        {
            string firstBtn = XStringDefineProxy.GetString("COMMON_OK");
            string secondBtn = XStringDefineProxy.GetString("COMMON_CANCEL");
            this.ShowModalDialog(message, firstBtn, secondBtn, handler);
        }

        protected void _ShowModalDialog(
          string label,
          string firstBtn,
          string secondBtn,
          ButtonClickEventHandler handler,
          ButtonClickEventHandler handler2,
          int depth = 50)
        {
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetPanelDepth(depth);
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton._bHasGrey = false;
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetLabelsWithSymbols(label, firstBtn, secondBtn);
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetModalCallback(handler, handler2);
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetTweenTargetAndPlay(DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.uiBehaviour.gameObject);
        }

        protected void _ShowModalDialog(
          string label,
          string firstBtn,
          string secondBtn,
          ButtonClickEventHandler handler = null,
          int depth = 50,
          string title = "")
        {
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetPanelDepth(depth);
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton._bHasGrey = false;
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetTitle(title);
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetLabelsWithSymbols(label, firstBtn, secondBtn);
            if (handler == null)
                DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetModalCallback(new ButtonClickEventHandler(this.FrButtonCallback));
            else
                DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetModalCallback(handler);
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetTweenTargetAndPlay(DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.uiBehaviour.gameObject);
        }

        protected void _ShowSystemHelp(string main, string title, string label, int depth = 50)
        {
            DlgBase<SystemHelpDlg, SystemHelpBehaviour>.singleton.SetPanelDepth(depth);
            DlgBase<SystemHelpDlg, SystemHelpBehaviour>.singleton._bHasGrey = false;
            DlgBase<SystemHelpDlg, SystemHelpBehaviour>.singleton.SetVisible(false, true);
            DlgBase<SystemHelpDlg, SystemHelpBehaviour>.singleton.SetLabels(main, title, label);
            DlgBase<SystemHelpDlg, SystemHelpBehaviour>.singleton.SetTweenTargetAndPlay(DlgBase<SystemHelpDlg, SystemHelpBehaviour>.singleton.uiBehaviour.gameObject);
        }

        public void ShowLeaveTeamModalDialog(ButtonClickEventHandler handler, string tips = "") => XSingleton<UiUtility>.singleton.ShowModalDialog(!(tips == "") ? tips : XStringDefineProxy.GetString("TEAM_SHOULD_LEAVE_TEAM_CONFIRM"), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), handler);

        public void CloseHelp()
        {
            if (!DlgBase<SystemHelpDlg, SystemHelpBehaviour>.singleton.IsVisible())
                return;
            DlgBase<SystemHelpDlg, SystemHelpBehaviour>.singleton.SetVisible(false, true);
        }

        public void CloseModalDlg()
        {
            if (!DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.IsVisible())
                return;
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
        }

        private bool FrButtonCallback(IXUIButton go)
        {
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
            XSingleton<XShell>.singleton.Pause = false;
            return true;
        }

        public string RoleTypeToString(RoleType type) => "UnknownProf";

        private Vector3 GetScreenPointMin() => XSingleton<XGameUI>.singleton.UICamera.WorldToScreenPoint(XSingleton<XGameUI>.singleton.UIRoot.TransformPoint((Vector3)new Vector2((float)(-XSingleton<XGameUI>.singleton.Base_UI_Width / 2), (float)(XSingleton<XGameUI>.singleton.Base_UI_Height / 2))));

        private Vector3 GetScreenPointMax() => XSingleton<XGameUI>.singleton.UICamera.WorldToScreenPoint(XSingleton<XGameUI>.singleton.UIRoot.TransformPoint((Vector3)new Vector2((float)(XSingleton<XGameUI>.singleton.Base_UI_Width / 2), (float)(-XSingleton<XGameUI>.singleton.Base_UI_Height / 2))));

        public string GetColorStr(Color color) => string.Format("{0:X2}{1:X2}{2:X2}", (object)(uint)((double)color.r * (double)byte.MaxValue), (object)(uint)((double)color.g * (double)byte.MaxValue), (object)(uint)((double)color.b * (double)byte.MaxValue));

        public Color GetColor(float[] rgb)
        {
            if (rgb == null)
                return Color.white;
            if (rgb.Length > 3)
                return new Color(rgb[0] / (float)byte.MaxValue, rgb[1] / (float)byte.MaxValue, rgb[2] / (float)byte.MaxValue, rgb[3] / 100f);
            if (rgb.Length > 2)
                return new Color(rgb[0] / (float)byte.MaxValue, rgb[1] / (float)byte.MaxValue, rgb[2] / (float)byte.MaxValue);
            if (rgb.Length > 1)
                return new Color(rgb[0] / (float)byte.MaxValue, rgb[1] / (float)byte.MaxValue, 1f);
            return (uint)rgb.Length > 0U ? new Color(rgb[0] / (float)byte.MaxValue, 1f, 1f) : Color.white;
        }

        public string GetItemQualityFrame(int quality, int type)
        {
            switch (quality)
            {
                case 0:
                    return "kuang_dj_0";
                case 1:
                    return "kuang_dj_1";
                case 2:
                    return "kuang_dj_2";
                case 3:
                    return "kuang_dj_3";
                case 4:
                    return "kuang_dj_4";
                case 5:
                    return "kuang_dj_5";
                default:
                    return "kuang_dj_0";
            }
        }

        public string GetItemQualityRGB(int quality)
        {
            switch (quality)
            {
                case 0:
                    return XSingleton<XGlobalConfig>.singleton.GetValue("Quality0Color");
                case 1:
                    return XSingleton<XGlobalConfig>.singleton.GetValue("Quality1Color");
                case 2:
                    return XSingleton<XGlobalConfig>.singleton.GetValue("Quality2Color");
                case 3:
                    return XSingleton<XGlobalConfig>.singleton.GetValue("Quality3Color");
                case 4:
                    return XSingleton<XGlobalConfig>.singleton.GetValue("Quality4Color");
                case 5:
                    return XSingleton<XGlobalConfig>.singleton.GetValue("Quality5Color");
                default:
                    return XSingleton<XGlobalConfig>.singleton.GetValue("Quality0Color");
            }
        }

        public Color GetItemQualityColor(int quality)
        {
            string itemQualityColorStr = this.GetItemQualityColorStr(quality);
            return string.IsNullOrEmpty(itemQualityColorStr) ? Color.white : (Color)new Color32(Convert.ToByte(itemQualityColorStr.Substring(0, 2), 16), Convert.ToByte(itemQualityColorStr.Substring(2, 2), 16), Convert.ToByte(itemQualityColorStr.Substring(4, 2), 16), byte.MaxValue);
        }

        public Color ConvertRGBStringToColor(string c) => (Color)new Color32(Convert.ToByte(c.Substring(0, 2), 16), Convert.ToByte(c.Substring(2, 2), 16), Convert.ToByte(c.Substring(4, 2), 16), byte.MaxValue);

        public string GetItemQualityColorStr(int quality)
        {
            string str = "";
            switch (quality)
            {
                case 0:
                    str = XSingleton<XGlobalConfig>.singleton.GetValue("Quality0Color");
                    break;
                case 1:
                    str = XSingleton<XGlobalConfig>.singleton.GetValue("Quality1Color");
                    break;
                case 2:
                    str = XSingleton<XGlobalConfig>.singleton.GetValue("Quality2Color");
                    break;
                case 3:
                    str = XSingleton<XGlobalConfig>.singleton.GetValue("Quality3Color");
                    break;
                case 4:
                    str = XSingleton<XGlobalConfig>.singleton.GetValue("Quality4Color");
                    break;
                case 5:
                    str = XSingleton<XGlobalConfig>.singleton.GetValue("Quality5Color");
                    break;
            }
            return str;
        }

        public string GetItemQualityIcon(int quality)
        {
            switch (quality)
            {
                case 0:
                    return "icondjdj_0";
                case 1:
                    return "icondjdj_1";
                case 2:
                    return "icondjdj_2";
                case 3:
                    return "icondjdj_3";
                case 4:
                    return "icondjdj_4";
                case 5:
                    return "icondjdj_5";
                default:
                    return "null";
            }
        }

        public string GetItemQualityName(int quality)
        {
            switch (quality)
            {
                case 0:
                    return "D";
                case 1:
                    return "C";
                case 2:
                    return "B";
                case 3:
                    return "A";
                case 4:
                    return "S";
                case 5:
                    return "L";
                default:
                    return string.Empty;
            }
        }

        public string GetScorePic(int score)
        {
            switch (score)
            {
                case 1:
                    return "F-S";
                case 2:
                    return "F-SS";
                case 3:
                    return "F-SSS";
                default:
                    return "";
            }
        }

        public string GetEquipFusionIconName(int fusionLevel)
        {
            string empty = string.Empty;
            string str;
            switch (fusionLevel)
            {
                case 1:
                    str = "equip_0_00000";
                    break;
                case 2:
                    str = "equip_1_00000";
                    break;
                case 3:
                    str = "equip_2_00000";
                    break;
                case 4:
                    str = "equip_3_00000";
                    break;
                case 5:
                    str = "equip_4_00000";
                    break;
                default:
                    str = "equip_0_00000";
                    break;
            }
            return str;
        }

        internal string GetEquipPartName(EquipPosition part, bool bPrefix = true)
        {
            switch (part)
            {
                case EquipPosition.EQUIP_START:
                    return XStringDefineProxy.GetString(XStringDefine.ITEM_PART_HEAD);
                case EquipPosition.Upperbody:
                    return XStringDefineProxy.GetString(XStringDefine.ITEM_PART_UPPERBODY);
                case EquipPosition.Lowerbody:
                    return XStringDefineProxy.GetString(XStringDefine.ITEM_PART_LOWERBODY);
                case EquipPosition.Gloves:
                    return XStringDefineProxy.GetString(XStringDefine.ITEM_PART_GLOVES);
                case EquipPosition.Boots:
                    return XStringDefineProxy.GetString(XStringDefine.ITEM_PART_BOOTS);
                case EquipPosition.Mainweapon:
                    return XStringDefineProxy.GetString(XStringDefine.ITEM_PART_MAINWEAPON);
                case EquipPosition.Secondaryweapon:
                    return XStringDefineProxy.GetString(XStringDefine.ITEM_PART_SECWEAPON);
                case EquipPosition.Necklace:
                    return XStringDefineProxy.GetString(XStringDefine.ITEM_PART_NECKLACE);
                case EquipPosition.Earrings:
                    return XStringDefineProxy.GetString(XStringDefine.ITEM_PART_EARRING);
                case EquipPosition.Rings:
                    return XStringDefineProxy.GetString(XStringDefine.ITEM_PART_RING1);
                default:
                    return "";
            }
        }

        internal string GetFashionPartName(FashionPosition part, bool bPrefix = true)
        {
            switch (part)
            {
                case FashionPosition.FASHION_START:
                    return (bPrefix ? XStringDefineProxy.GetString(XStringDefine.FASHION_PREFIX) : "") + XStringDefineProxy.GetString(XStringDefine.FASHION_HEAD);
                case FashionPosition.FashionUpperBody:
                    return (bPrefix ? XStringDefineProxy.GetString(XStringDefine.FASHION_PREFIX) : "") + XStringDefineProxy.GetString(XStringDefine.FASHION_UPPERBODY);
                case FashionPosition.FashionLowerBody:
                    return (bPrefix ? XStringDefineProxy.GetString(XStringDefine.FASHION_PREFIX) : "") + XStringDefineProxy.GetString(XStringDefine.FASHION_LOWERBODY);
                case FashionPosition.FashionGloves:
                    return (bPrefix ? XStringDefineProxy.GetString(XStringDefine.FASHION_PREFIX) : "") + XStringDefineProxy.GetString(XStringDefine.FASHION_GLOVES);
                case FashionPosition.FashionBoots:
                    return (bPrefix ? XStringDefineProxy.GetString(XStringDefine.FASHION_PREFIX) : "") + XStringDefineProxy.GetString(XStringDefine.FASHION_BOOTS);
                case FashionPosition.FashionMainWeapon:
                    return (bPrefix ? XStringDefineProxy.GetString(XStringDefine.FASHION_PREFIX) : "") + XStringDefineProxy.GetString(XStringDefine.FASHION_MAINWEAPON);
                case FashionPosition.FashionSecondaryWeapon:
                    return (bPrefix ? XStringDefineProxy.GetString(XStringDefine.FASHION_PREFIX) : "") + XStringDefineProxy.GetString(XStringDefine.FASHION_SECWEAPON);
                case FashionPosition.FashionWings:
                    return (bPrefix ? XStringDefineProxy.GetString(XStringDefine.FASHION_PREFIX) : "") + XStringDefineProxy.GetString(XStringDefine.FASHION_WINGS);
                case FashionPosition.FashionTail:
                    return (bPrefix ? XStringDefineProxy.GetString(XStringDefine.FASHION_PREFIX) : "") + XStringDefineProxy.GetString(XStringDefine.FASHION_TAIL);
                case FashionPosition.FashionDecal:
                    return (bPrefix ? XStringDefineProxy.GetString(XStringDefine.FASHION_PREFIX) : "") + XStringDefineProxy.GetString(XStringDefine.FASHION_DECAL);
                case FashionPosition.Hair:
                    return (bPrefix ? XStringDefineProxy.GetString(XStringDefine.FASHION_PREFIX) : "") + XStringDefineProxy.GetString(XStringDefine.FASHION_HAIR);
                default:
                    return "";
            }
        }

        internal string GetArtifactPartName(ArtifactPosition part, bool bPrefix = true)
        {
            switch (part)
            {
                case ArtifactPosition.ARTIFACT_START:
                    return XStringDefineProxy.GetString(XStringDefine.ARTIFACT_ANSAB);
                case ArtifactPosition.Grail:
                    return XStringDefineProxy.GetString(XStringDefine.ARTIFACT_GRAIL);
                case ArtifactPosition.Battleheart:
                    return XStringDefineProxy.GetString(XStringDefine.ARTIFACT_BATTLEHEART);
                case ArtifactPosition.DragonHorn:
                    return XStringDefineProxy.GetString(XStringDefine.ARTIFACT_DRAGONHORN);
                default:
                    return "";
            }
        }

        public string ChooseProfString(List<string> ProfStringList, uint basicTypeId = 0)
        {
            if (ProfStringList.Count == 1)
                return ProfStringList[0];
            if (ProfStringList.Count == 0)
                return "";
            if (basicTypeId <= 0U)
                basicTypeId = XItemDrawerParam.DefaultProfession;
            int index = (int)basicTypeId - 1;
            return ProfStringList[index];
        }

        public string ChooseProfString(string[] ProfStringList, uint basicTypeId = 0)
        {
            if (ProfStringList == null || ProfStringList.Length == 0)
                return "";
            if (ProfStringList.Length == 1)
                return ProfStringList[0];
            if (basicTypeId <= 0U)
                basicTypeId = XItemDrawerParam.DefaultProfession;
            int index = (int)basicTypeId - 1;
            if (index >= 0 && index < ProfStringList.Length)
                return ProfStringList[index];
            XSingleton<XDebug>.singleton.AddErrorLog("There's no data for prof ", basicTypeId.ToString(), ", data: {", string.Join(", ", ProfStringList), "}");
            return string.Empty;
        }

        internal T ChooseProfData<T>(List<T> ProfDataList, uint basicTypeId = 0)
        {
            if (ProfDataList == null || ProfDataList.Count == 0)
                return default(T);
            if (ProfDataList.Count == 1)
                return ProfDataList[0];
            if (basicTypeId <= 0U)
                basicTypeId = XItemDrawerParam.DefaultProfession;
            int index1 = (int)basicTypeId - 1;
            if (index1 >= 0 && index1 < ProfDataList.Count)
                return ProfDataList[index1];
            XSingleton<XCommon>.singleton.shareSB.Length = 0;
            T obj;
            for (int index2 = 0; index2 < ProfDataList.Count; ++index2)
            {
                if ((uint)index2 > 0U)
                    XSingleton<XCommon>.singleton.shareSB.Append(", ");
                StringBuilder shareSb = XSingleton<XCommon>.singleton.shareSB;
                obj = ProfDataList[index2];
                string str = obj.ToString();
                shareSb.Append(str);
            }
            XSingleton<XDebug>.singleton.AddErrorLog("There's no data for prof ", basicTypeId.ToString(), ", data: {", XSingleton<XCommon>.singleton.shareSB.ToString(), "}");
            obj = default(T);
            return obj;
        }

        internal T ChooseProfData<T>(T[] ProfDataList, uint basicTypeId = 0)
        {
            if (ProfDataList == null || ProfDataList.Length == 0)
                return default(T);
            if (ProfDataList.Length == 1)
                return ProfDataList[0];
            if (basicTypeId == 0U)
                basicTypeId = XItemDrawerParam.DefaultProfession;
            int index1 = (int)basicTypeId - 1;
            if (index1 >= 0 && index1 < ProfDataList.Length)
                return ProfDataList[index1];
            XSingleton<XCommon>.singleton.shareSB.Length = 0;
            for (int index2 = 0; index2 < ProfDataList.Length; ++index2)
            {
                if ((uint)index2 > 0U)
                    XSingleton<XCommon>.singleton.shareSB.Append(", ");
                XSingleton<XCommon>.singleton.shareSB.Append(ProfDataList[index2].ToString());
            }
            XSingleton<XDebug>.singleton.AddErrorLog("There's no data for prof ", basicTypeId.ToString(), ", data: {", XSingleton<XCommon>.singleton.shareSB.ToString(), "}");
            return default(T);
        }

        internal T ChooseProfData<T>(ref SeqListRef<T> ProfDataList, uint basicTypeId = 0, int index = 0)
        {
            if (ProfDataList.Count == 0)
                return default(T);
            if (ProfDataList.Count == 1)
                return ProfDataList[0, index];
            if (basicTypeId == 0U)
                basicTypeId = XItemDrawerParam.DefaultProfession;
            int index1 = (int)basicTypeId - 1;
            if (index1 >= 0 && index1 < ProfDataList.Count)
                return ProfDataList[index1, index];
            XSingleton<XCommon>.singleton.shareSB.Length = 0;
            T obj;
            for (int index2 = 0; index2 < ProfDataList.Count; ++index2)
            {
                if ((uint)index2 > 0U)
                    XSingleton<XCommon>.singleton.shareSB.Append(", ");
                StringBuilder shareSb = XSingleton<XCommon>.singleton.shareSB;
                obj = ProfDataList[index2, index];
                string str = obj.ToString();
                shareSb.Append(str);
            }
            XSingleton<XDebug>.singleton.AddErrorLog("There's no data for prof ", basicTypeId.ToString(), ", data: {", XSingleton<XCommon>.singleton.shareSB.ToString(), "}");
            obj = default(T);
            return obj;
        }

        internal string ReplaceReturn(string s) => s.Replace("{n}", "\n");

        public void AddChild(Transform parent, Transform child)
        {
            child.parent = parent;
            child.localPosition = Vector3.zero;
            child.localRotation = Quaternion.identity;
            child.localScale = Vector3.one;
            XSingleton<XGameUI>.singleton.m_uiTool.MarkParentAsChanged(child.gameObject);
        }

        public void AddChild(GameObject parent, GameObject child)
        {
            child.transform.parent = parent.transform;
            child.transform.localPosition = Vector3.zero;
            child.transform.localRotation = Quaternion.identity;
            child.transform.localScale = Vector3.one;
            XSingleton<XGameUI>.singleton.m_uiTool.MarkParentAsChanged(child.gameObject);
        }

        public void AddChildNoMark(GameObject parent, GameObject child)
        {
            child.transform.parent = parent.transform;
            child.transform.localPosition = Vector3.zero;
            child.transform.localRotation = Quaternion.identity;
            child.transform.localScale = Vector3.one;
        }

        public void AddChild(IUIRect parent, GameObject child, IXUIPanel panel)
        {
            child.transform.parent = parent.transform;
            child.transform.localPosition = Vector3.zero;
            child.transform.localRotation = Quaternion.identity;
            child.transform.localScale = Vector3.one;
            if (XSingleton<XGameUI>.singleton.m_uiTool == null)
                return;
            XSingleton<XGameUI>.singleton.m_uiTool.ChangePanel(child, parent, panel);
        }

        public long GetTimeStamp()
        {
            DateTime dateTime = DateTime.Now;
            dateTime = dateTime.ToUniversalTime();
            return (dateTime.Ticks - 621355968000000000L) / 10000000L;
        }

        public string TimeFormatSince1970(int elapsedSeconds, string format, bool isCountTimeZone = false) => this.TimeNow((double)elapsedSeconds, isCountTimeZone).ToString(format);

        public DateTime TimeNow(double elapsedSeconds, bool isCountTimeZone = false)
        {
            int num = 0;
            if (isCountTimeZone)
                num = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).Hours;
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0);
            elapsedSeconds = Math.Max(0.0, elapsedSeconds);
            dateTime = dateTime.AddSeconds(elapsedSeconds + (double)(num * 3600));
            return dateTime;
        }

        public double TimeFormatLastTime(double elapsedSeconds, bool isCountTimeZone = false) => (this.TimeNow(elapsedSeconds, isCountTimeZone) - DateTime.Now).TotalSeconds;

        public string TimeFormatString(
          int totalSecond,
          int lowCount = 0,
          int upCount = 3,
          int minUnit = 4,
          bool isCarry = false,
          bool needPadLeft = true)
        {
            this._Timebuilder.Length = 0;
            upCount = Math.Min(3, upCount);
            int num1 = 2 + (3 - upCount);
            if (isCarry)
                totalSecond = (int)Math.Ceiling((double)totalSecond / (double)this.TimeDuaration[minUnit]) * this.TimeDuaration[minUnit];
            for (int index = num1; index < 5; ++index)
            {
                int num2 = totalSecond / this.TimeDuaration[index];
                totalSecond %= this.TimeDuaration[index];
                if (5 - index <= 4 - minUnit + lowCount || this._Timebuilder.Length != 0 || num2 != 0)
                {
                    if ((uint)this._Timebuilder.Length > 0U)
                        this._Timebuilder.Append(":");
                    if (index == 2 || !needPadLeft)
                        this._Timebuilder.Append(num2.ToString());
                    else
                        this._Timebuilder.Append(num2.ToString().PadLeft(2, '0'));
                    if (index == minUnit)
                        return this._Timebuilder.ToString();
                }
            }
            return this._Timebuilder.ToString();
        }

        public string TimeFormatString(
          float totalSecondFloat,
          int lowCount = 0,
          int upCount = 3,
          int minUnit = 4,
          bool isCarry = false)
        {
            this.TimeFormatString((int)totalSecondFloat, lowCount, upCount, minUnit, isCarry, true);
            totalSecondFloat %= 1f;
            totalSecondFloat *= 100f;
            this._Timebuilder.Append(string.Format(".{0}", (object)((int)totalSecondFloat).ToString().PadLeft(2, '0')));
            return this._Timebuilder.ToString();
        }

        public string TimeAgoFormatString(int totalSecond)
        {
            if (totalSecond < 0)
                return XStringDefineProxy.GetString("ONLINE");
            for (int index = 0; index < 5; ++index)
            {
                int num1 = this.TimeDuaration[index];
                int num2 = totalSecond / num1;
                if (num2 > 0)
                    return string.Format("{0}{1}{2}", (object)num2.ToString(), (object)XStringDefineProxy.GetString(this.TimeDuarationName[index]), (object)XStringDefineProxy.GetString("AGO"));
            }
            return XStringDefineProxy.GetString("JUSTNOW");
        }

        public string TimeOnOrOutFromString(int totalSecond) => totalSecond < 0 ? XStringDefineProxy.GetString("ONLINE") : XStringDefineProxy.GetString("OUTLINE");

        public string TimeAccFormatString(int totalSecond, int minTime, int maxTime = 0)
        {
            if (totalSecond < 0)
                return XStringDefineProxy.GetString("ONLINE");
            for (int index = maxTime; index < 5; ++index)
            {
                int num1 = this.TimeDuaration[index];
                int num2 = totalSecond / num1;
                if (num2 > 0 || index == minTime)
                    return string.Format("{0}{1}", (object)(num2 > 0 ? num2 : 1).ToString(), (object)XStringDefineProxy.GetString(this.TimeDuarationName[index]));
            }
            return XStringDefineProxy.GetString("JUSTNOW");
        }

        public string TimeDuarationFormatString(int totalSecond, int minTime = 5)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool flag = false;
            if (totalSecond <= 0)
            {
                stringBuilder.Append(0).Append(XStringDefineProxy.GetString("SECOND_DUARATION"));
            }
            else
            {
                for (int index = 0; index < minTime; ++index)
                {
                    int num1 = this.TimeDuaration[index];
                    int num2 = totalSecond / num1;
                    if (num2 > 0)
                        flag = true;
                    if (flag)
                        stringBuilder.Append(num2).Append(XStringDefineProxy.GetString(this.TimeName[index]));
                    totalSecond -= num2 * num1;
                    if (totalSecond == 0)
                        break;
                }
            }
            return stringBuilder.ToString();
        }

        public string TimeDuarationFormatSizeString(int totalSecond, int size = 5, int start = 0)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool flag = false;
            int num1 = 0;
            if (totalSecond <= 0)
            {
                stringBuilder.Append(0).Append(XStringDefineProxy.GetString("SECOND_DUARATION"));
            }
            else
            {
                for (int index = start; index < 5; ++index)
                {
                    int num2 = this.TimeDuaration[index];
                    int num3 = totalSecond / num2;
                    if (num3 > 0)
                        flag = true;
                    if (flag)
                    {
                        ++num1;
                        stringBuilder.Append(num3).Append(XStringDefineProxy.GetString(this.TimeName[index]));
                    }
                    totalSecond -= num3 * num2;
                    if (totalSecond == 0 || num1 >= size)
                        break;
                }
            }
            return stringBuilder.ToString();
        }

        public string TimeDurationBackFormatString(int totalSecond, int minTime = 5)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool flag = false;
            if (totalSecond <= 0)
            {
                stringBuilder.Append(0).Append(XStringDefineProxy.GetString("SECOND_DUARATION"));
            }
            else
            {
                for (int index = 0; index < minTime; ++index)
                {
                    int num1 = this.TimeDuaration[index];
                    int num2 = totalSecond / num1;
                    if (num2 > 0)
                        flag = true;
                    if (flag)
                        stringBuilder.Append(num2).Append(XStringDefineProxy.GetString(this.TimeName[index]));
                    totalSecond -= num2 * num1;
                    if (totalSecond == 0)
                        break;
                }
            }
            return stringBuilder.ToString();
        }

        public string NumberFormat(int number)
        {
            bool flag = number < 0;
            number = Math.Abs(number);
            string str;
            if (number < 10000)
            {
                str = number.ToString();
            }
            else
            {
                number /= 10000;
                str = number.ToString() + "W";
            }
            if (flag)
                str = "-" + str;
            return str;
        }

        public string NumberFormat(ulong number)
        {
            if (number < XSingleton<XGlobalConfig>.singleton.MinSeparateNum)
                return number.ToString();
            ulong[] numberSeparators = XSingleton<XGlobalConfig>.singleton.NumberSeparators;
            int index1 = -1;
            for (int index2 = 0; index2 < numberSeparators.Length && numberSeparators[index2] <= number; ++index2)
                index1 = index2;
            if (index1 == -1)
                return number.ToString();
            if (this.NumberSeparatorNames == null)
            {
                this.NumberSeparatorNames = new string[numberSeparators.Length];
                for (int index3 = 0; index3 < numberSeparators.Length; ++index3)
                    this.NumberSeparatorNames[index3] = "NumberSeparator" + index3.ToString();
            }
            return string.Format("{0}{1}", (object)(number / numberSeparators[index1]).ToString(), (object)XStringDefineProxy.GetString(this.NumberSeparatorNames[index1]));
        }

        public string NumberFormatBillion(ulong number)
        {
            double num = 100000000.0;
            return (double)number > num ? string.Format("{0}{1}", (object)((double)(ulong)((double)number / num * 100.0) / 100.0), (object)XStringDefineProxy.GetString("NumberSeparator1")) : this.NumberFormat(number);
        }

        public string GetBagExpandFullTips(BagType type)
        {
            switch (type)
            {
                case BagType.EquipBag:
                    return XSingleton<XStringTable>.singleton.GetString("ExpandEquipBagFull");
                case BagType.EmblemBag:
                    return XSingleton<XStringTable>.singleton.GetString("ExpandEmbleBagFull");
                case BagType.ArtifactBag:
                    return XSingleton<XStringTable>.singleton.GetString("ExpandArtifactBagFull");
                case BagType.ItemBag:
                    return XSingleton<XStringTable>.singleton.GetString("ExpandItemBagFull");
                default:
                    return string.Empty;
            }
        }

        public Transform FindChild(Transform dlg, string childName)
        {
            string name1 = childName;
            if (childName.Contains("?profession?"))
            {
                int num = XFastEnumIntEqualityComparer<RoleType>.ToInt(XSingleton<XAttributeMgr>.singleton.XPlayerData.Profession) % 10;
                childName = childName.Replace("?profession?", num.ToString());
                name1 = name1.Replace("?profession?", num.ToString());
            }
            if (childName.Contains("?profession1turn?"))
            {
                int num1 = XFastEnumIntEqualityComparer<RoleType>.ToInt(XSingleton<XAttributeMgr>.singleton.XPlayerData.Profession);
                if (num1 >= 10)
                {
                    int num2 = num1 % 100 / 10 + num1 % 10 * 2 - 2;
                    childName = childName.Replace("?profession1turn?", num2.ToString("d2"));
                    name1 = name1.Replace("?profession1turn?", num2.ToString("d2"));
                }
            }
            if (!childName.Contains("{"))
                return dlg.FindChild(name1);
            int num3 = childName.IndexOf("{");
            int num4 = childName.IndexOf("}");
            int num5 = int.Parse(childName.Substring(num3 + 1, num4 - num3 - 1)) - 1;
            string name2 = childName.Substring(0, num3 - 1);
            string str = childName.Substring(num4 + 1);
            Transform child = dlg.FindChild(name2);
            if ((UnityEngine.Object)child == (UnityEngine.Object)null || num5 >= child.childCount)
                return (Transform)null;
            Transform transform = (Transform)null;
            int num6 = -1;
            for (int index = 0; index < child.childCount; ++index)
            {
                transform = child.GetChild(index);
                if (transform.gameObject.activeSelf)
                    ++num6;
                if (num5 == num6)
                    break;
            }
            return str != "" ? transform.FindChild(str.Substring(1)) : transform;
        }

        public int GetItemCount(int itemID) => XSingleton<XGame>.singleton.Doc.XBagDoc.ItemBag.GetItemCount(itemID);

        public bool IsMaxBuyPowerCnt() => this.IsMaxBuyCnt(XMainClient.ItemEnum.FATIGUE);

        public bool IsMaxBuyCnt(XMainClient.ItemEnum type)
        {
            int level = (int)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
            int vipLevel = (int)XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID).VipLevel;
            XPurchaseInfo purchaseInfo = XDocuments.GetSpecificDocument<XPurchaseDocument>(XPurchaseDocument.uuID).GetPurchaseInfo(level, vipLevel, type);
            return purchaseInfo.totalBuyNum <= purchaseInfo.curBuyNum;
        }

        public bool CanEnterBattleScene(uint sceneID) => this.CanEnterBattleScene(sceneID, 1);

        public bool CanEnterBattleScene(uint sceneID, int cnt)
        {
            SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(sceneID);
            if (sceneData == null)
                return false;
            bool flag = true;
            for (int index1 = 0; index1 < sceneData.FatigueCost.Count; ++index1)
            {
                int num = 0;
                if (sceneData.FatigueCost[index1, 0] <= 50)
                {
                    num = (int)XSingleton<XGame>.singleton.Doc.XBagDoc.GetVirtualItemCount((XMainClient.ItemEnum)sceneData.FatigueCost[index1, 0]);
                }
                else
                {
                    int index2 = -1;
                    XSingleton<XGame>.singleton.Doc.XBagDoc.ItemBag.FindItem((ulong)sceneData.FatigueCost[index1, 0], out index2);
                    if (index2 >= 0)
                        num = XSingleton<XGame>.singleton.Doc.XBagDoc.ItemBag[index2].itemCount;
                }
                if (num < sceneData.FatigueCost[index1, 1])
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }

        public void ShowLoginTip(string text) => DlgBase<XLoginTipView, XLoginTipBehaviour>.singleton.ShowTips(text);

        public void StopLoginTip() => DlgBase<XLoginTipView, XLoginTipBehaviour>.singleton.StopTips();

        public void ShowSystemTip(string text, string rgb = "fece00") => XDocuments.GetSpecificDocument<XSystemTipDocument>(XSystemTipDocument.uuID)?.ShowTip(text, rgb);

        public void ShowSystemTip(int errcode, string rgb = "fece00") => XDocuments.GetSpecificDocument<XSystemTipDocument>(XSystemTipDocument.uuID)?.ShowTip(XStringDefineProxy.GetString((ErrorCode)errcode), rgb);

        public void ShowSystemTip(ErrorCode errcode, string rgb = "fece00") => XDocuments.GetSpecificDocument<XSystemTipDocument>(XSystemTipDocument.uuID)?.ShowTip(this.ReplaceReturn(XStringDefineProxy.GetString(errcode)), rgb);

        public void OnGetInvalidRequest(string name) => XSingleton<XDebug>.singleton.AddErrorLog("GetInvalidRequest:  ", name);

        public uint ShowSystemNoticeTip(string text) => XDocuments.GetSpecificDocument<XShowGetItemDocument>(XShowGetItemDocument.uuID).AddTip(text);

        public void EditSystemNoticeTip(string text, uint id) => XDocuments.GetSpecificDocument<XShowGetItemDocument>(XShowGetItemDocument.uuID).EditTip(text, id);

        public int GetRowCount(int count, int columnCount) => count <= 0 ? 0 : (count - 1) / columnCount + 1;

        public void SetVirtualItem(XNumberTween numTween, ulong num, bool bAnim = true, string postfix = "")
        {
            numTween.SetNumberWithTween(num, postfix, !bAnim);
            if (!bAnim)
                return;
            numTween.IconTween?.PlayTween(true);
        }

        public void ShowItemAccess(int itemid, AccessCallback callback = null)
        {
            ItemList.RowData itemConf = XBagDocument.GetItemConf(itemid);
            if (itemConf == null || itemConf.Access.Count <= 0)
                return;
            List<int> ids = new List<int>();
            List<int> intList = new List<int>();
            for (int index = 0; index < itemConf.Access.Count; ++index)
            {
                ids.Add(itemConf.Access[index, 0]);
                intList.Add(itemConf.Access[index, 1]);
            }
            DlgBase<ItemAccessDlg, ItemAccessDlgBehaviour>.singleton.ShowAccess(itemid, ids, intList, callback);
        }

        public void OnItemClick(IXUISprite sp) => this.ShowTooltipDialog((int)sp.ID, sp);

        public void OnBindItemClick(IXUISprite sp)
        {
            int id = (int)sp.ID;
            XSingleton<TooltipParam>.singleton.bBinded = true;
            this.ShowTooltipDialog(id, sp);
        }

        public void SetUIDepthDelta(GameObject go, int delta) => XSingleton<XGameUI>.singleton.m_uiTool.SetUIDepthDelta(go, delta);

        public void UpdateWifi(IXUIButton btn, IXUISprite spr)
        {
            if (this.wifi_green == 0U || this.wifi_yellow == 0U)
            {
                this.wifi_green = uint.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("WIFI_GREEN"));
                this.wifi_yellow = uint.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("WIFI_YELO"));
            }
            long delay = XSingleton<XServerTimeMgr>.singleton.GetDelay();
            if (delay <= (long)this.wifi_green)
            {
                this.wifiBtn = "xh_2";
                btn?.SetAlpha(1f);
                spr?.SetAlpha(1f);
            }
            else if (delay <= (long)this.wifi_yellow)
            {
                this.wifiBtn = "xh_1";
                btn?.SetAlpha(1f);
                spr?.SetAlpha(1f);
            }
            else
            {
                this.wifiBtn = "xh_0";
                btn?.SetAlpha(1f);
                spr?.SetAlpha(1f);
            }
            btn?.SetSprites(this.wifiBtn, this.wifiBtn, this.wifiBtn);
            spr?.SetSprite(this.wifiBtn);
            if (delay < XServerTimeMgr.SyncTimeOut)
                return;
            if ((double)this.wifi_cur >= 1.0 && this.wifi_forward)
                this.wifi_forward = false;
            if ((double)this.wifi_cur <= 0.0 && !this.wifi_forward)
                this.wifi_forward = true;
            this.wifi_cur = this.wifi_forward ? Time.time % this.wifi_duration / this.wifi_duration : (float)(1.0 - (double)Time.time % (double)this.wifi_duration / (double)this.wifi_duration);
            btn?.SetAlpha(this.wifi_cur);
            spr?.SetAlpha(this.wifi_cur);
        }

        public bool IsWeakNetwork()
        {
            uint num1 = uint.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("WIFI_GREEN"));
            uint num2 = uint.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("WIFI_YELO"));
            long delay = XSingleton<XServerTimeMgr>.singleton.GetDelay();
            return delay > (long)num1 && delay > (long)num2;
        }

        public void RefreshPing(IXUILabel _time, IXUISlider _slider, IXUILabel _free)
        {
            string batteryLevel = XSingleton<XUpdater.XUpdater>.singleton.XPlatform.GetBatteryLevel();
            string strText = DateTime.Now.ToString("HH:mm");
            _time?.SetText(strText);
            int result = 100;
            int.TryParse(batteryLevel, out result);
            if (_slider != null)
                _slider.Value = (float)result / 100f;
            if (_free == null)
                return;
            _free.Alpha = XSingleton<XLoginDocument>.singleton.freeflow ? 1f : 0.0f;
        }

        public bool IsSystemExpress(string txt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(txt);
            return bytes != null && bytes.Length > 1 && bytes[0] == (byte)240;
        }

        public string StripInvalidUnicodeCharacters(string str) => str;

        public void ShowAfterLoginAnnouncement(PlatNotice announcement)
        {
            if (announcement == null || !announcement.isopen)
                return;
            DlgBase<XAnnouncementView, XAnnouncementBehaviour>.singleton.ShowAnnouncement(announcement.content);
        }

        public void ShowPatface()
        {
            DlgBase<XPatfaceView, XPatfaceBehaviour>.singleton.bShow = true;
            RpcC2M_FetchPlatNotice mFetchPlatNotice = new RpcC2M_FetchPlatNotice();
            mFetchPlatNotice.oArg.type = XSingleton<XClientNetwork>.singleton.AccountType;
            switch (Application.platform)
            {
                case RuntimePlatform.IPhonePlayer:
                    mFetchPlatNotice.oArg.platid = PlatType.PLAT_IOS;
                    break;
                case RuntimePlatform.Android:
                    mFetchPlatNotice.oArg.platid = PlatType.PLAT_ANDROID;
                    break;
            }
            XSingleton<XClientNetwork>.singleton.Send((Rpc)mFetchPlatNotice);
        }

        public string GlobalConfigGetValue(string cfgName) => XSingleton<XGlobalConfig>.singleton.GetValue(cfgName);

        public Color StringToColor(string str)
        {
            if (string.IsNullOrEmpty(str))
                return Color.white;
            int num = int.Parse(str, NumberStyles.AllowHexSpecifier);
            return new Color((float)(num / 65536) / (float)byte.MaxValue, (float)(num / 256 % 256) / (float)byte.MaxValue, (float)(num % 256) / (float)byte.MaxValue);
        }

        public string GetChatDesignation(uint desID, string specDesi, string name = "")
        {
            DesignationTable.RowData byId = XDocuments.GetSpecificDocument<XDesignationDocument>(XDesignationDocument.uuID)._DesignationTable.GetByID((int)desID);
            if (byId == null || !byId.ShowInChat)
                return name;
            if (byId.Effect != "")
                return string.Format("{0}{1}", (object)XLabelSymbolHelper.FormatDesignation(byId.Atlas, byId.Effect), (object)name);
            if (name != "")
                name = string.Format(" {0}", (object)name);
            return byId.Special ? string.Format("{0}{1}[-]{2}", (object)byId.Color, (object)specDesi, (object)name) : string.Format("{0}{1}[-]{2}", (object)byId.Color, (object)byId.Designation, (object)name);
        }

        public string SetChatCoverDesignation(string name, uint desID, bool justPicDesc = false)
        {
            DesignationTable.RowData byId = XDocuments.GetSpecificDocument<XDesignationDocument>(XDesignationDocument.uuID)._DesignationTable.GetByID((int)desID);
            string str = string.Format("{0}{1}", (object)XSingleton<XGlobalConfig>.singleton.GetValue("XUILabelSymbolNameColor"), (object)name);
            if (byId == null || byId.Effect != "")
            {
                if (byId != null)
                    str = string.Format("{0}{1}", (object)XLabelSymbolHelper.FormatDesignation(byId.Atlas, byId.Effect), (object)str);
            }
            else if (!justPicDesc)
                str = string.Format("{0}{1} {2}", (object)XSingleton<XGlobalConfig>.singleton.GetValue("XUILabelSymbolDesignationColor"), (object)byId.Designation, (object)str);
            return str;
        }

        public Color ParseColor(string text, int offset)
        {
            int num1 = this.HexToDecimal(text[offset]) << 4 | this.HexToDecimal(text[offset + 1]);
            int num2 = this.HexToDecimal(text[offset + 2]) << 4 | this.HexToDecimal(text[offset + 3]);
            int num3 = this.HexToDecimal(text[offset + 4]) << 4 | this.HexToDecimal(text[offset + 5]);
            float num4 = 0.003921569f;
            return new Color(num4 * (float)num1, num4 * (float)num2, num4 * (float)num3);
        }

        public int HexToDecimal(char ch)
        {
            switch (ch)
            {
                case '0':
                    return 0;
                case '1':
                    return 1;
                case '2':
                    return 2;
                case '3':
                    return 3;
                case '4':
                    return 4;
                case '5':
                    return 5;
                case '6':
                    return 6;
                case '7':
                    return 7;
                case '8':
                    return 8;
                case '9':
                    return 9;
                case 'A':
                case 'a':
                    return 10;
                case 'B':
                case 'b':
                    return 11;
                case 'C':
                case 'c':
                    return 12;
                case 'D':
                case 'd':
                    return 13;
                case 'E':
                case 'e':
                    return 14;
                case 'F':
                case 'f':
                    return 15;
                default:
                    return 15;
            }
        }

        public void ShowFatigueSureDlg(ButtonClickEventHandler handler) => XSingleton<UiUtility>.singleton.ShowModalDialog(string.Format(XStringDefineProxy.GetString("FATIGUEOVERFLOWTIPS"), (object)XSingleton<XGlobalConfig>.singleton.GetValue("MaxFatigue")), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), handler, 100);

        public void ShowRank(IXUISprite sp, IXUILabel label, int rank)
        {
            if (1 <= rank && rank <= 3)
            {
                sp.gameObject.SetActive(true);
                label.gameObject.SetActive(false);
                if (rank == 1)
                    sp.SetSprite("N1");
                if (rank == 2)
                    sp.SetSprite("N2");
                if (rank != 3)
                    return;
                sp.SetSprite("N3");
            }
            else
            {
                sp.gameObject.SetActive(false);
                label.gameObject.SetActive(true);
                if (rank <= 0)
                    label.SetText(XStringDefineProxy.GetString("NoRank"));
                else
                    label.SetText(rank.ToString());
            }
        }

        public void DestroyTextureInActivePool(XUIPool pool, string path)
        {
            List<GameObject> gameObjectList = ListPool<GameObject>.Get();
            pool.GetActiveList(gameObjectList);
            for (int index = 0; index < gameObjectList.Count; ++index)
            {
                if (gameObjectList[index].transform.Find(nameof(path)).GetComponent("XUITexture") is IXUITexture component1)
                    component1.SetTexturePath("");
            }
            ListPool<GameObject>.Release(gameObjectList);
        }

        public void SetMiniMapOpponentStatus(bool hide) => BattleIndicateHandler.SetMiniMapOpponentStatus(hide);

        public string GetItemTypeStr(ItemType type) => this.GetItemTypeStr(XFastEnumIntEqualityComparer<ItemType>.ToInt(type));

        public string GetItemTypeStr(int type) => XStringDefineProxy.GetString(XSingleton<XCommon>.singleton.StringCombine("ItemType", type.ToString()));

        public void OnPayCallback(string msg) => XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID).OnPayCallback(msg);

        public void SDKPandoraBuyGoods(string json) => XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID).SDKPandoraBuyGoods(json);

        public void OnQQVipPayCallback(string msg) => XDocuments.GetSpecificDocument<XPlatformAbilityDocument>(XPlatformAbilityDocument.uuID).OnQQVipPayCallback(msg);

        public void OnGameCenterWakeUp(int type)
        {
            XSingleton<XDebug>.singleton.AddLog("[OnGameCenterWakeUp] StartUpType = " + (object)type);
            StartUpType startUpType = (StartUpType)type;
            if ((startUpType != StartUpType.StartUp_QQ || XSingleton<XLoginDocument>.singleton.Channel != XAuthorizationChannel.XAuthorization_QQ) && (startUpType != StartUpType.StartUp_WX || XSingleton<XLoginDocument>.singleton.Channel != XAuthorizationChannel.XAuthorization_WeChat))
                return;
            XSingleton<XDebug>.singleton.AddLog("[OnGameCenterWakeUp] PtcC2N_UpdateStartUpTypeNtf type = " + (object)type);
            XSingleton<XClientNetwork>.singleton.Send((Protocol)new PtcC2N_UpdateStartUpTypeNtf()
            {
                Data = {
          type = startUpType
        }
            });
            DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshGameCenterInfo();
        }

        public void OnGetPlatFriendsInfo()
        {
            XSingleton<XDebug>.singleton.AddLog("[UiUtility] OnGetPlatFriendsInfo");
            XFriendsDocument.Doc.SyncPlatFriendsInfo();
            XSingleton<XLoginDocument>.singleton.SetFriendServerIcon();
            XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendGameExData("QuerySelf", "");
            if (XSingleton<PDatabase>.singleton.playerInfo == null)
                return;
            XSingleton<XUICacheImage>.singleton.SetMainIcon(XSingleton<PDatabase>.singleton.playerInfo.data.pictureLarge);
        }

        public void SerialHandle3DTouch(string msg) => XSingleton<X3DTouchMgr>.singleton.OnProcess3DTouch(msg);

        public void SerialHandleScreenLock(string msg)
        {
        }

        public void OnPayMarketingInfo(List<PayMarketingInfo> listInfo) => XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID).OnGetPayMarketingInfo(listInfo);

        public void ShowSettingNumberDialog(
          uint itemID,
          string title,
          uint min,
          uint max,
          uint step,
          ModalSettingNumberDlg.GetInputNumber handler,
          int depth = 50)
        {
            DlgBase<ModalSettingNumberDlg, ModalSettingNumberDlgBehaviour>.singleton.Load();
            DlgBase<ModalSettingNumberDlg, ModalSettingNumberDlgBehaviour>.singleton.MaxNumber = max;
            DlgBase<ModalSettingNumberDlg, ModalSettingNumberDlgBehaviour>.singleton.MinNumber = min;
            DlgBase<ModalSettingNumberDlg, ModalSettingNumberDlgBehaviour>.singleton.Title = title;
            DlgBase<ModalSettingNumberDlg, ModalSettingNumberDlgBehaviour>.singleton.step = step;
            DlgBase<ModalSettingNumberDlg, ModalSettingNumberDlgBehaviour>.singleton.ItemID = itemID;
            DlgBase<ModalSettingNumberDlg, ModalSettingNumberDlgBehaviour>.singleton.SetModalInfo(handler);
            DlgBase<ModalSettingNumberDlg, ModalSettingNumberDlgBehaviour>.singleton.SetVisible(true, true);
        }

        public string GetPartitionId() => XSingleton<XClientNetwork>.singleton.ServerID.ToString();

        public string GetRoleId() => XSingleton<XEntityMgr>.singleton.Player != null ? XSingleton<XEntityMgr>.singleton.Player.Attributes.RoleID.ToString() : "0";

        public void OnReplayStart()
        {
            if (DlgBase<ReplaykitDlg, ReplayBehaviour>.singleton.IsVisible())
                return;
            DlgBase<ReplaykitDlg, ReplayBehaviour>.singleton.isPlaying = true;
            DlgBase<ReplaykitDlg, ReplayBehaviour>.singleton.Show(true);
        }

        public void OnSetBg(bool on) => XSingleton<XChatIFlyMgr>.singleton.SetBackMusicOn(on);

        public void OpenHtmlUrl(string key) => XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendExtDara("open_url", Json.Serialize((object)new Dictionary<string, string>()
        {
            ["url"] = XSingleton<XGlobalConfig>.singleton.GetValue(key),
            ["screendir"] = "SENSOR"
        }));

        public void CloseSysAndNoticeServer(uint sysID)
        {
            XSingleton<XClientNetwork>.singleton.Send((Protocol)new PtcC2G_CloseHintNtf()
            {
                Data = {
          systemid = sysID
        }
            });
            XSingleton<XGameSysMgr>.singleton.SetSysRedPointState((XSysDefine)sysID, false);
            XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState((XSysDefine)sysID);
        }

        public void OpenUrl(string url, bool landscape) => XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendExtDara("open_url", Json.Serialize((object)new Dictionary<string, string>()
        {
            [nameof(url)] = url,
            ["screendir"] = (landscape ? "LANDSCAPE" : "SENSOR")
        }));

        public void Shuffle<T>(ref List<T> list)
        {
            for (int index1 = list.Count - 1; index1 > 0; --index1)
            {
                int index2 = XSingleton<XCommon>.singleton.RandomInt(0, index1 + 1);
                if (index2 != index1)
                {
                    T obj = list[index1];
                    list[index1] = list[index2];
                    list[index2] = obj;
                }
            }
        }

        public void OnSetWebViewMenu(int menutype) => DlgBase<WebView, WebViewBehaviour>.singleton.OnSetWebViewMenu(menutype);

        public void OnWebViewBackGame(int backtype) => DlgBase<WebView, WebViewBehaviour>.singleton.OnWebViewBackGame(backtype);

        public void OnWebViewRefershRefPoint(string jsonstr) => DlgBase<WebView, WebViewBehaviour>.singleton.OnWebViewRefershRefPoint(jsonstr);

        public void OnWebViewSetheaderInfo(string jsonstr) => DlgBase<WebView, WebViewBehaviour>.singleton.OnWebViewSetheaderInfo(jsonstr);

        public void OnWebViewCloseLoading(int show) => DlgBase<WebView, WebViewBehaviour>.singleton.OnWebViewCloseLoading(show);

        public void OnWebViewShowReconnect(int show) => DlgBase<WebView, WebViewBehaviour>.singleton.OnWebViewShowReconnect(show);

        public void OnWebViewClose()
        {
            if (!DlgBase<WebView, WebViewBehaviour>.singleton.IsLoaded())
                return;
            DlgBase<WebView, WebViewBehaviour>.singleton.SetVisible(false, true);
        }

        public void OnWebViewLiveTab()
        {
            if (!DlgBase<WebView, WebViewBehaviour>.singleton.IsLoaded())
                return;
            DlgBase<WebView, WebViewBehaviour>.singleton.OnTabLive();
        }

        public void ShowPandoraPopView(bool bShow)
        {
            if (bShow && XSingleton<XScene>.singleton.GameCamera != null && (UnityEngine.Object)XSingleton<XScene>.singleton.GameCamera.UnityCamera != (UnityEngine.Object)null && !XSingleton<XScene>.singleton.GameCamera.UnityCamera.enabled)
                XSingleton<XScene>.singleton.GameCamera.UnityCamera.enabled = true;
            XSingleton<XDebug>.singleton.AddGreenLog("Pandora UiUtiliy ShowPandoraPopView bShow = " + bShow.ToString());
            DlgBase<XPandoraSDKPopView, XPandoraSDKPopViewBehaviour>.singleton.SetVisible(bShow, true);
        }

        public void OnWXGroupResult(string apiId, string result, int error, WXGroupCallBackType type)
        {
            switch (type)
            {
                case WXGroupCallBackType.DragonGuild:
                    XSingleton<PDatabase>.singleton.wxGroupCallbackType = WXGroupCallBackType.Guild;
                    XDragonGuildDocument.Doc.View.DragonGuildGroupResult(apiId, result, error);
                    break;
                case WXGroupCallBackType.Guild:
                    DlgBase<XGuildHallView, XGuildHallBehaviour>.singleton.GuildGroupResult(apiId, result, error);
                    break;
            }
        }

        public void RefreshWXGroupBtn(WXGroupCallBackType type)
        {
            switch (type)
            {
                case WXGroupCallBackType.DragonGuild:
                    XSingleton<PDatabase>.singleton.wxGroupCallbackType = WXGroupCallBackType.Guild;
                    XDragonGuildDocument.Doc.RefreshWXGroupBtn();
                    break;
                case WXGroupCallBackType.Guild:
                    DlgBase<XGuildHallView, XGuildHallBehaviour>.singleton.RefreshWXGroupBtn();
                    break;
            }
        }

        public void NoticeShareResult(string result, ShareCallBackType type)
        {
            XSingleton<XDebug>.singleton.AddLog("NoticeShareResult   " + result + ", type = " + type.ToString());
            if (type != ShareCallBackType.AddQQFriend)
                this.ShowSystemTip(result == "Success" ? XSingleton<XStringTable>.singleton.GetString("GUILD_GROUP_SHARE_SUC") : XSingleton<XStringTable>.singleton.GetString("GUILD_GROUP_SHARE_FAIL"), "fece00");
            else
                this.ShowSystemTip(result == "Success" ? XSingleton<XStringTable>.singleton.GetString("FRIEND_ADD_QQ_FRIEND_SEND_SUC") : XSingleton<XStringTable>.singleton.GetString("FRIEND_ADD_QQ_FRIEND_SEND_FAIL"), "fece00");
            switch (type)
            {
                case ShareCallBackType.Normal:
                    XSingleton<XPandoraSDKDocument>.singleton.NoticePandoraShareResult(result);
                    break;
                case ShareCallBackType.GloryPic:
                    XAchievementDocument specificDocument1 = XDocuments.GetSpecificDocument<XAchievementDocument>(XAchievementDocument.uuID);
                    if (!result.Contains("Success"))
                        break;
                    specificDocument1.SendWeekShareSuccess(0U);
                    break;
                case ShareCallBackType.DungeonShare:
                    XSingleton<XDebug>.singleton.AddLog("DungeonShare   " + result);
                    XAchievementDocument specificDocument2 = XDocuments.GetSpecificDocument<XAchievementDocument>(XAchievementDocument.uuID);
                    if (result.Contains("Success"))
                        specificDocument2.SendWeekShareSuccess(specificDocument2.FirstPassSceneID);
                    specificDocument2.FirstPassSceneID = 0U;
                    if (!DlgBase<DungeonShareView, DungeonShareBehavior>.singleton.IsVisible())
                        break;
                    DlgBase<DungeonShareView, DungeonShareBehavior>.singleton.SetVisibleWithAnimation(false, (DlgBase<DungeonShareView, DungeonShareBehavior>.OnAnimationOver)null);
                    break;
                case ShareCallBackType.WeekShare:
                    XAchievementDocument specificDocument3 = XDocuments.GetSpecificDocument<XAchievementDocument>(XAchievementDocument.uuID);
                    if (!result.Contains("Success"))
                        break;
                    specificDocument3.SendWeekShareSuccess(0U);
                    break;
            }
        }

        public bool CheckWXInstalled()
        {
            if (XSingleton<XUpdater.XUpdater>.singleton.XPlatform.CheckStatus("Weixin_Installed", ""))
                return true;
            XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("ERR_WECHAT_NOT_INSTALLED"), "fece00");
            return false;
        }

        public bool CheckQQInstalled()
        {
            if (XSingleton<XUpdater.XUpdater>.singleton.XPlatform.CheckStatus("QQ_Installed", ""))
                return true;
            XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("ERR_QQ_NOT_INSTALLED"), "fece00");
            return false;
        }

        public void UpdatePandoraSDKRedPoint(int pandoraSysID, bool showRedPoint, string module)
        {
            if (showRedPoint)
            {
                if (XSingleton<XPandoraSDKDocument>.singleton.IsActivityTabShow(pandoraSysID))
                    XSingleton<XGameSysMgr>.singleton.ForceUpdateSysRedPointImmediately(pandoraSysID, showRedPoint);
            }
            else
                XSingleton<XGameSysMgr>.singleton.ForceUpdateSysRedPointImmediately(pandoraSysID, showRedPoint);
            if (module == "action")
            {
                XDocuments.GetSpecificDocument<XOperatingActivityDocument>(XOperatingActivityDocument.uuID).RefreshRedPoints();
            }
            else
            {
                if (!(module == "callBack"))
                    return;
                XSingleton<XUpdater.XUpdater>.singleton.XLuaEngine.hotfixMgr.CallLuaFunc("LuaBackflowDocument", "RefreshPandoraTabRedpoint");
            }
        }

        public void AttachPandoraSDKRedPoint(int sysID, string module)
        {
            if (module == "action")
            {
                XDocuments.GetSpecificDocument<XOperatingActivityDocument>(XOperatingActivityDocument.uuID).AttachPandoraRedPoint(sysID);
            }
            else
            {
                if (!(module == "callBack"))
                    return;
                XDocuments.GetSpecificDocument<XBackFlowDocument>(XBackFlowDocument.uuID).AttachPandoraRedPoint(sysID);
            }
        }

        public void ResetAllPopPLParent() => XSingleton<XPandoraSDKDocument>.singleton.ResetAllPopPLParent();

        public void BillBoardCommonSetSpriteStr(params string[] strs)
        {
            this.ComSpriteStr.Clear();
            for (int index = 0; index < strs.Length; ++index)
                this.ComSpriteStr.Add(strs[index]);
        }

        public double GetMachineTime() => (double)(DateTime.Now.Ticks / 10000000L);

        public int GetMachineTimeFrom1970() => (int)((DateTime.Now - new DateTime(1970, 1, 1)).Ticks / 10000000L);

        public string Decrypt(string CipherText)
        {
            byte[] bytes1 = Encoding.BigEndianUnicode.GetBytes(CipherText);
            int length = bytes1.Length;
            byte[] bytes2 = new byte[length / 2];
            for (int index = 0; index < length; index += 4)
            {
                byte num1 = bytes1[index + 1];
                byte num2 = bytes1[index + 3];
                int num3 = ((int)num1 & 15) << 4;
                int num4 = (int)num1 & 240;
                int num5 = (int)num2 & 15;
                int num6 = ((int)num2 & 240) >> 4;
                bytes2[index / 2] = Convert.ToByte(num3 | num6);
                bytes2[index / 2 + 1] = Convert.ToByte(num4 | num5);
            }
            return Encoding.BigEndianUnicode.GetString(bytes2, 0, bytes2.Length);
        }

        public bool CheckPlatfomStatus() => (XSingleton<XLoginDocument>.singleton.Channel != XAuthorizationChannel.XAuthorization_QQ || this.CheckQQInstalled()) && (XSingleton<XLoginDocument>.singleton.Channel != XAuthorizationChannel.XAuthorization_WeChat || this.CheckWXInstalled());

        public bool IsOppositeSex(int one, int two)
        {
            one %= 10;
            two %= 10;
            List<int> intList1 = XSingleton<XGlobalConfig>.singleton.GetIntList("MaleTypeList");
            List<int> intList2 = XSingleton<XGlobalConfig>.singleton.GetIntList("FemaleTypeList");
            return intList1.Contains(one) && intList2.Contains(two) || intList1.Contains(two) && intList2.Contains(one);
        }

        public void ShareToWXFriendBackEnd(string openID, string title, string desc, string tag)
        {
            string str = Json.Serialize((object)new Dictionary<string, object>()
            {
                ["openId"] = (object)openID,
                [nameof(title)] = (object)title,
                ["description"] = (object)desc,
                ["thumbMediaId"] = (object)"",
                ["mediaTagName"] = (object)tag,
                ["messageExt"] = (object)"ShareWithWeixin"
            });
            XSingleton<XDebug>.singleton.AddLog("ShareToWXFriend paramStr = " + str);
            XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendExtDara("share_send_to_friend_wx", str);
        }

        public void ShareToQQFreindBackEnd(
          string openID,
          string title,
          string desc,
          string tag,
          string targetUrl,
          string imageUrl,
          string previewText)
        {
            string str = Json.Serialize((object)new Dictionary<string, object>()
            {
                ["act"] = (object)1,
                ["openId"] = (object)openID,
                [nameof(title)] = (object)title,
                ["summary"] = (object)desc,
                [nameof(targetUrl)] = (object)targetUrl,
                [nameof(imageUrl)] = (object)imageUrl,
                [nameof(previewText)] = (object)previewText,
                ["gameTag"] = (object)tag
            });
            XSingleton<XDebug>.singleton.AddLog("SharePkToQQFriend paramStr = " + str);
            XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendExtDara("share_send_to_friend_qq", str);
        }

        public void PandoraPicShare(string accountType, string scene, string objPath)
        {
            XSingleton<XDebug>.singleton.AddLog("UiUtility PandoraPicShare : accountType = " + accountType + ",scene = " + scene + ",objPath = " + objPath);
            GameObject gameObject = GameObject.Find(objPath);
            if (!((UnityEngine.Object)gameObject != (UnityEngine.Object)null))
                return;
            XSingleton<XDebug>.singleton.AddLog("UiUtility PandoraPicShare find obj");
            Bounds includesChildren = XSingleton<XUpdater.XUpdater>.singleton.XPandoraManager.GetBoundsIncludesChildren(gameObject.transform);
            Vector3 screenPoint1 = XSingleton<XGameUI>.singleton.UICamera.WorldToScreenPoint(includesChildren.min);
            Vector3 screenPoint2 = XSingleton<XGameUI>.singleton.UICamera.WorldToScreenPoint(includesChildren.max);
            XSingleton<XScreenShotMgr>.singleton.PartCaptureScreen(new Rect(screenPoint1.x, screenPoint1.y, screenPoint2.x - screenPoint1.x, screenPoint2.y - screenPoint1.y), accountType, scene);
        }

        public void OneKeyAddQQFriend(string openID, string friendName)
        {
            if (Application.platform == RuntimePlatform.IPhonePlayer)
                XSingleton<PDatabase>.singleton.shareCallbackType = ShareCallBackType.AddQQFriend;
            string name = XSingleton<XAttributeMgr>.singleton.XPlayerData.Name;
            string str1 = XStringDefineProxy.GetString("FRIEND_ADD_QQ_FRIEND_REMARK", (object)friendName);
            string str2 = XStringDefineProxy.GetString("FRIEND_ADD_QQ_FRIEND", (object)name);
            string str3 = Json.Serialize((object)new Dictionary<string, object>()
            {
                ["openId"] = (object)openID,
                ["desc"] = (object)str1,
                ["verifyMsg"] = (object)str2
            });
            XSingleton<XDebug>.singleton.AddLog("AddQQFriend paramStr = " + str3);
            XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendExtDara("add_game_qq_friend", str3);
        }

        public void ShowPressToolTips(bool pressed, string content, Vector3 pos, Vector3 offset) => DlgBase<PressTipsDlg, PressTipsBehaviour>.singleton.Setup(pressed, content, pos, offset);

        public bool ToDownLoadCorrectPackage(IXUIButton button)
        {
            switch (Application.platform)
            {
                case RuntimePlatform.IPhonePlayer:
                    string str1 = XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_VERSIONNOTMATCH_URL");
                    XSingleton<XDebug>.singleton.AddLog("AppStore Url: ", str1);
                    Application.OpenURL(str1);
                    break;
                case RuntimePlatform.Android:
                    string str2 = XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_VERSIONNOTMATCH_ANDROID_URL");
                    XSingleton<XDebug>.singleton.AddLog("AndroidAppStore Url: ", str2);
                    Application.OpenURL(str2);
                    break;
            }
            return true;
        }

        public bool ToDownLoadCorrectPackagePre(IXUIButton button)
        {
            switch (Application.platform)
            {
                case RuntimePlatform.IPhonePlayer:
                    string str1 = XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_VERSIONNOTMATCH_URL");
                    XSingleton<XDebug>.singleton.AddLog("AppStore Url: ", str1);
                    Application.OpenURL(str1);
                    break;
                case RuntimePlatform.Android:
                    string str2 = XSingleton<XStringTable>.singleton.GetString("XUPDATE_ERROR_VERSIONNOTMATCH_ANDROID_PRE_URL");
                    XSingleton<XDebug>.singleton.AddLog("AndroidAppStore Url: ", str2);
                    Application.OpenURL(str2);
                    break;
            }
            return true;
        }
    }
}
