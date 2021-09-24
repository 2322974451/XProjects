

using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XSpriteIllustrationHandler : DlgHandlerBase
    {
        private IXUIButton m_Close;
        private XUIPool m_SpritePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
        private IXUIScrollView m_ScrollView;
        private IXUITable m_Table;
        private IXUILabel m_Title;
        private IXUILabelSymbol m_Tip;
        private IXUILabel m_LTypeName;
        private IXUILabel m_STypeName;
        private IXUILabel m_ATypeName;
        private IXUILabel m_BTypeName;
        private IXUILabel m_CTypeName;
        private List<IXUIList> m_TypeList = new List<IXUIList>();
        private List<List<uint>> m_SpriteID = new List<List<uint>>();
        private List<Transform> m_TypeTitle = new List<Transform>();

        protected override string FileName => "GameSystem/SpriteSystem/SpriteIllustrationWindow";

        protected override void Init()
        {
            this.m_TypeList.Clear();
            this.m_TypeTitle.Clear();
            this.m_LTypeName = this.PanelObject.transform.Find("Bg/ScrollView/Table/L/TypeL/Name").GetComponent("XUILabel") as IXUILabel;
            this.m_STypeName = this.PanelObject.transform.Find("Bg/ScrollView/Table/S/TypeL/Name").GetComponent("XUILabel") as IXUILabel;
            this.m_ATypeName = this.PanelObject.transform.Find("Bg/ScrollView/Table/A/TypeL/Name").GetComponent("XUILabel") as IXUILabel;
            this.m_BTypeName = this.PanelObject.transform.Find("Bg/ScrollView/Table/B/TypeL/Name").GetComponent("XUILabel") as IXUILabel;
            this.m_CTypeName = this.PanelObject.transform.Find("Bg/ScrollView/Table/C/TypeL/Name").GetComponent("XUILabel") as IXUILabel;
            this.m_Close = this.PanelObject.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton;
            for (int index = 1; index < XFastEnumIntEqualityComparer<SpriteQuality>.ToInt(SpriteQuality.MAX); ++index)
            {
                string s1 = ((SpriteQuality)index).ToString();
                this.m_TypeTitle.Add(this.PanelObject.transform.Find(XSingleton<XCommon>.singleton.StringCombine("Bg/ScrollView/Table/", s1)));
                IXUIList component = this.PanelObject.transform.Find(XSingleton<XCommon>.singleton.StringCombine("Bg/ScrollView/Table/", s1, "/Grid")).GetComponent("XUIList") as IXUIList;
                component.RegisterRepositionHandle(new OnAfterRepostion(this.OnListRefreshFinished));
                this.m_TypeList.Add(component);
            }
            Transform transform = this.PanelObject.transform.Find("Bg/ScrollView/ItemTpl");
            this.m_SpritePool.SetupPool(transform.parent.gameObject, transform.gameObject, 10U, false);
            this.m_ScrollView = this.PanelObject.transform.Find("Bg/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView;
            this.m_Table = this.PanelObject.transform.Find("Bg/ScrollView/Table").GetComponent("XUITable") as IXUITable;
            this.m_Title = this.PanelObject.transform.Find("Bg/Tittle").GetComponent("XUILabel") as IXUILabel;
            this.m_Tip = this.PanelObject.transform.Find("Tip").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
        }

        private void OnListRefreshFinished()
        {
            this.m_Table.Reposition();
            this.m_ScrollView.ResetPosition();
        }

        public override void RegisterEvent() => this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));

        private void ClassifySpritesByQuality(List<uint> itemList, bool isItem)
        {
            XSpriteSystemDocument specificDocument = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
            this.m_SpriteID.Clear();
            List<uint> uintList1 = new List<uint>();
            List<uint> uintList2 = new List<uint>();
            List<uint> uintList3 = new List<uint>();
            List<uint> uintList4 = new List<uint>();
            List<uint> uintList5 = new List<uint>();
            for (int index = 0; index < itemList.Count; ++index)
            {
                SpriteQuality spriteQuality;
                uint num;
                if (isItem)
                {
                    SpritePreviewTable.RowData byItemId = specificDocument._SpritePreviewTable.GetByItemID(itemList[index]);
                    if (byItemId != null)
                    {
                        spriteQuality = (SpriteQuality)byItemId.ItemQuality;
                        num = byItemId.ItemID;
                    }
                    else
                        continue;
                }
                else
                {
                    SpriteTable.RowData bySpriteId = specificDocument._SpriteTable.GetBySpriteID(itemList[index]);
                    if (bySpriteId != null)
                    {
                        spriteQuality = (SpriteQuality)bySpriteId.SpriteQuality;
                        num = bySpriteId.SpriteID;
                    }
                    else
                        continue;
                }
                switch (spriteQuality)
                {
                    case SpriteQuality.C:
                        uintList5.Add(num);
                        break;
                    case SpriteQuality.B:
                        uintList4.Add(num);
                        break;
                    case SpriteQuality.A:
                        uintList3.Add(num);
                        break;
                    case SpriteQuality.S:
                        uintList2.Add(num);
                        break;
                    case SpriteQuality.L:
                        uintList1.Add(num);
                        break;
                }
            }
            this.m_SpriteID.Add(uintList5);
            this.m_SpriteID.Add(uintList4);
            this.m_SpriteID.Add(uintList3);
            this.m_SpriteID.Add(uintList2);
            this.m_SpriteID.Add(uintList1);
        }

        private void ShowIllustration(List<uint> itemList, bool isItem, bool showTip)
        {
            this.m_Title.SetText(isItem ? XStringDefineProxy.GetString("SpriteAwardPreview") : XStringDefineProxy.GetString("SpriteIllustrationName"));
            this.SetIllustrationType(isItem ? XStringDefineProxy.GetString("SpriteIllustrationType1") : XStringDefineProxy.GetString("SpriteIllustrationType2"));
            this.m_Tip.InputText = XStringDefineProxy.GetString("SpriteLotterySafeTip", (object)XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID).SpecialSafeCount);
            this.m_Tip.SetVisible(showTip);
            this.m_ScrollView.ResetPosition();
            this.ClassifySpritesByQuality(itemList, isItem);
            this.m_SpritePool.FakeReturnAll();
            this.CreateIcon(SpriteQuality.L, isItem);
            this.CreateIcon(SpriteQuality.S, isItem);
            this.CreateIcon(SpriteQuality.A, isItem);
            this.CreateIcon(SpriteQuality.B, isItem);
            this.CreateIcon(SpriteQuality.C, isItem);
            this.m_SpritePool.ActualReturnAll(true);
        }

        private void SetIllustrationType(string name)
        {
            this.m_LTypeName.SetText(name);
            this.m_STypeName.SetText(name);
            this.m_ATypeName.SetText(name);
            this.m_BTypeName.SetText(name);
            this.m_CTypeName.SetText(name);
        }

        public void ShowSpriteEggIllustration(SpriteEggLotteryType type)
        {
            List<uint> itemList;
            if (!XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID)._SpriteEggPreviewDict.TryGetValue(XFastEnumIntEqualityComparer<SpriteEggLotteryType>.ToInt(type), out itemList) || itemList.Count <= 0)
                return;
            this.ShowIllustration(itemList, true, type == SpriteEggLotteryType.Special);
        }

        public void ShowSpriteAllIllustration()
        {
            XSpriteSystemDocument specificDocument = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
            if (specificDocument.SpriteShowInIllustration.Count <= 0)
                return;
            this.ShowIllustration(specificDocument.SpriteShowInIllustration, false, false);
        }

        private void CreateIcon(SpriteQuality quality, bool isItem)
        {
            int index1 = XFastEnumIntEqualityComparer<SpriteQuality>.ToInt(quality) - 1;
            IXUIList type = this.m_TypeList[index1];
            List<uint> uintList = this.m_SpriteID[index1];
            this.m_TypeTitle[index1].gameObject.SetActive(uintList.Count > 0);
            for (int index2 = 0; index2 < uintList.Count; ++index2)
            {
                GameObject go = this.m_SpritePool.FetchGameObject();
                go.transform.parent = type.gameObject.transform;
                if (isItem)
                    this.SetItemInfo(go, uintList[index2]);
                else
                    this.SetSpriteInfo(go, uintList[index2]);
                XSingleton<XGameUI>.singleton.m_uiTool.ChangePanel(go, type.GetParentUIRect(), type.GetParentPanel());
            }
            type.Refresh();
        }

        private void SetItemInfo(GameObject obj, uint itemID)
        {
            IXUISprite component = obj.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
            component.ID = (ulong)itemID;
            XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(obj, (int)itemID);
            component.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
        }

        private void SetSpriteInfo(GameObject obj, uint spriteID)
        {
            XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(obj, (int)spriteID);
            IXUISprite component = obj.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
            component.ID = (ulong)spriteID;
            component.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSpriteIconClicked));
        }

        private void OnSpriteIconClicked(IXUISprite spr)
        {
            uint id = (uint)spr.ID;
            XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
            DlgBase<XSpriteDetailView, XSpriteDetailBehaviour>.singleton.ShowDetail(id);
        }

        private bool OnCloseClicked(IXUIButton sp)
        {
            this.SetVisible(false);
            return true;
        }
    }
}
