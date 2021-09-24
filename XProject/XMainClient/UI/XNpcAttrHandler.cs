

using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
    internal class XNpcAttrHandler : DlgHandlerBase
    {
        private XNPCFavorDocument m_doc;
        private IXUIList m_BasicUIList;
        private XUIPool m_BasicAttrPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
        private IXUIList m_OtherUIList;
        private XUIPool m_OtherAttrPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

        protected override string FileName => "GameSystem/NPCBlessing/NpcAttrHandler";

        protected override void Init()
        {
            base.Init();
            this.m_doc = XDocuments.GetSpecificDocument<XNPCFavorDocument>(XNPCFavorDocument.uuID);
            this.m_BasicUIList = this.transform.FindChild("AttrGrid").GetComponent("XUIList") as IXUIList;
            Transform child1 = this.m_BasicUIList.gameObject.transform.FindChild("Tpl");
            this.m_BasicAttrPool.SetupPool(this.m_BasicUIList.gameObject, child1.gameObject, 10U, false);
            child1.gameObject.SetActive(false);
            this.m_OtherUIList = this.transform.FindChild("NoBasicAttrGrid").GetComponent("XUIList") as IXUIList;
            Transform child2 = this.m_OtherUIList.gameObject.transform.FindChild("Tpl");
            this.m_OtherAttrPool.SetupPool(this.m_OtherUIList.gameObject, child2.gameObject, 5U, false);
            child2.gameObject.SetActive(false);
        }

        protected override void OnShow() => this.RefreshData();

        public override void RefreshData() => this.RefreshAttr();

        private void RefreshAttr()
        {
            this.m_BasicAttrPool.FakeReturnAll();
            this.m_OtherAttrPool.FakeReturnAll();
            Dictionary<uint, uint>.Enumerator enumerator = this.m_doc.DictSumAttr.GetEnumerator();
            while (enumerator.MoveNext())
            {
                KeyValuePair<uint, uint> current = enumerator.Current;
                uint key = current.Key;
                current = enumerator.Current;
                uint attrValue = current.Value;
                GameObject gameObject;
                if (XAttributeCommon.IsBasicRange((int)key))
                {
                    gameObject = this.m_BasicAttrPool.FetchGameObject();
                    gameObject.transform.parent = this.m_BasicUIList.gameObject.transform;
                }
                else
                {
                    gameObject = this.m_OtherAttrPool.FetchGameObject();
                    gameObject.transform.parent = this.m_OtherUIList.gameObject.transform;
                }
                gameObject.transform.localScale = Vector3.one;
                this.DrawAttr(gameObject.transform, key, attrValue);
            }
            this.m_BasicAttrPool.ActualReturnAll();
            this.m_OtherAttrPool.ActualReturnAll();
            this.m_BasicUIList.Refresh();
            this.m_OtherUIList.Refresh();
        }

        public override void OnUnload()
        {
            this.m_doc = (XNPCFavorDocument)null;
            base.OnUnload();
        }

        private void DrawAttr(Transform item, uint attrId, uint attrValue)
        {
            IXUILabel component1 = item.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
            IXUILabel component2 = item.FindChild("Value").GetComponent("XUILabel") as IXUILabel;
            component1.SetText(XAttributeCommon.GetAttrStr((int)attrId));
            component2.SetText(XAttributeCommon.GetAttrValueStr(attrId, attrValue));
        }
    }
}
