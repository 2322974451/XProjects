// Decompiled with JetBrains decompiler
// Type: XMainClient.XPlayerAttributes
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XPlayerAttributes : XRoleAttributes
    {
        public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Player_Attributes");
        public byte[] openedSystem = new byte[32];
        public bool AutoPlayOn = false;

        public override uint ID => XPlayerAttributes.uuID;

        public uint SkillPageIndex { set; get; }

        public XPlayerAttributes()
        {
            this._manualUnitBuff = true;
            this._security_Statistics = new XSecurityStatistics();
        }

        public override void InitAttribute(KKSG.Attribute attr) => base.InitAttribute(attr);

        public bool IsSystemOpened(uint sysID)
        {
            uint num1 = sysID / 8U;
            int num2 = 1 << (int)(sysID % 8U);
            if ((long)num1 < (long)this.openedSystem.Length)
                return ((uint)this.openedSystem[(int)num1] & (uint)num2) > 0U;
            XSingleton<XDebug>.singleton.AddErrorLog("sys id out of range: ", sysID.ToString());
            return false;
        }

        public void CacheOpenSystem(uint sysID)
        {
            if (!XSingleton<XTutorialMgr>.singleton.IsImmediatelyOpenSystem(sysID))
            {
                XSingleton<XTutorialHelper>.singleton.AddNewOpenSystem(sysID);
                XSingleton<XTutorialMgr>.singleton.SetExternalString("OpenSys" + (object)sysID);
            }
            else
            {
                this.ReallyOpenSystem(sysID);
                if (DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible())
                {
                    DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.OnSysChange((XSysDefine)sysID);
                    XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState((XSysDefine)sysID);
                }
            }
        }

        public void ReallyOpenSystem(uint sysID)
        {
            uint num1 = sysID / 8U;
            int num2 = 1 << (int)(sysID % 8U);
            if ((long)num1 >= (long)this.openedSystem.Length)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("open sys id out of range: ", sysID.ToString());
            }
            else
            {
                this.openedSystem[(int)num1] |= (byte)num2;
                XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState((XSysDefine)sysID);
                XDocuments.GetSpecificDocument<XMainInterfaceDocument>(XMainInterfaceDocument.uuID).OnSysOpen();
            }
        }

        public void CloseSystem(uint sysID)
        {
            uint num1 = sysID / 8U;
            int num2 = 1 << (int)(sysID % 8U);
            if ((long)num1 >= (long)this.openedSystem.Length)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("close sys id out of range: ", sysID.ToString());
            }
            else
            {
                this.openedSystem[(int)num1] &= (byte)~num2;
                XSingleton<XGameSysMgr>.singleton.SetSysRedPointState((XSysDefine)sysID, false);
                XDocuments.GetSpecificDocument<XMainInterfaceDocument>(XMainInterfaceDocument.uuID).OnSysChange();
            }
        }

        public void HPMPReset()
        {
            this.SetAttr(XAttributeDefine.XAttr_CurrentHP_Basic, this.GetAttr(XAttributeDefine.XAttr_MaxHP_Total));
            this.SetAttr(XAttributeDefine.XAttr_CurrentMP_Basic, this.GetAttr(XAttributeDefine.XAttr_MaxMP_Total));
        }

        public long GetLevelUpExp(int level)
        {
            PlayerLevelTable.RowData byLevel = XSingleton<XEntityMgr>.singleton.LevelTable.GetByLevel(level);
            return byLevel != null ? byLevel.Exp : 0L;
        }
    }
}
