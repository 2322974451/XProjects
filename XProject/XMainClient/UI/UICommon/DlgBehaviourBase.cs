

using System.Runtime.CompilerServices;
using UILib;
using UnityEngine;

namespace XMainClient.UI.UICommon
{
    public class DlgBehaviourBase : MonoBehaviour, IXUIBehaviour, IXUIObject
    {
        private IXUIDlg m_uiDlgInterface = (IXUIDlg)null;
        private IXUIObject[] m_uiChilds = (IXUIObject[])null;
        private ulong m_id;
        private bool m_bExculsive = false;

        public IXUIObject parent
        {
            get => (IXUIObject)null;
            set
            {
            }
        }

        public ulong ID
        {
            get => this.m_id;
            set => this.m_id = value;
        }

        public bool Exculsive
        {
            get => this.m_bExculsive;
            set => this.m_bExculsive = value;
        }

        public bool IsVisible() => this.gameObject.activeInHierarchy;

        public void SetVisible(bool bVisible) => this.gameObject.SetActive(bVisible);

        public IXUIDlg uiDlgInterface
        {
            get => this.m_uiDlgInterface;
            set => this.m_uiDlgInterface = value;
        }

        public IXUIObject[] uiChilds => this.m_uiChilds;

        public IXUIObject GetUIObject(string strName)
        {
            Transform child = this.transform.FindChild(strName);
            return (Object)null != (Object)child ? (IXUIObject)child.GetComponent<XUIObjectBase>() : (IXUIObject)null;
        }

        public void OnPress() => this.OnFocus();

        public void OnFocus()
        {
        }

        public virtual void Init()
        {
            this.m_uiChilds = (IXUIObject[])this.GetComponentsInChildren<XUIObjectBase>();
            for (int index = 0; index < this.m_uiChilds.Length; ++index)
                (this.m_uiChilds[index] as XUIObjectBase).Init();
        }

        public virtual void Highlight(bool bTrue)
        {
        }

    }
}
