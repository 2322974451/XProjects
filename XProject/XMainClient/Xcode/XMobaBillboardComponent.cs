

using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
    internal sealed class XMobaBillboardComponent : XComponent
    {
        public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Moba_Billboard");
        private XMobaBattleDocument _mobaDoc;
        private Transform _billboard = (Transform)null;
        private IUIDummy _uiDummy = (IUIDummy)null;
        private IUIBloodGrid _bloodGrid = (IUIBloodGrid)null;
        private IXUIProgress _bloodBar;
        private IXUIProgress _indureBar;
        public IXUILabelSymbol _name;
        public IXUILabel _level;
        public IXUISprite _exp;
        public string NameStr = "";
        private XBuffMonitorHandler _buffMonitor;
        private bool InitByMaster = false;
        private float _heroHeight = 10f;
        private static float k = 0.007f;
        private float _viewDistance = 10f;
        private int _alwaysHide = 0;
        public static string HPBAR_TEMPLATE = "UI/Billboard/MobaBillboard";
        private static readonly string MILITARY_ATLAS = "common/Billboard";
        public static readonly string billboardString_red = "[e8280c]";
        public static readonly string billboardString_green = "[53d103]";
        public static readonly string billboardString_blue = "[0aabd0]";
        public static readonly Color billboard_red = (Color)new Color32((byte)232, (byte)40, (byte)12, byte.MaxValue);
        public static readonly Color billboard_green = (Color)new Color32((byte)83, (byte)209, (byte)3, byte.MaxValue);
        public static readonly Color billboard_blue = (Color)new Color32((byte)10, (byte)171, (byte)208, byte.MaxValue);
        private BillboardUsage _secondbar_usage = BillboardUsage.MP;

        public override uint ID => XMobaBillboardComponent.uuID;

        public override void OnAttachToHost(XObject host)
        {
            base.OnAttachToHost(host);
            this._mobaDoc = XDocuments.GetSpecificDocument<XMobaBattleDocument>(XMobaBattleDocument.uuID);
            GameObject fromPrefab = XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab(XMobaBillboardComponent.HPBAR_TEMPLATE, this._entity.EngineObject.Position, this._entity.EngineObject.Rotation);
            if ((Object)fromPrefab != (Object)null)
                this._billboard = fromPrefab.transform;
            this._uiDummy = this._billboard.GetComponent("UIDummy") as IUIDummy;
            XSingleton<UiUtility>.singleton.AddChild(XSingleton<XGameUI>.singleton.HpbarRoot.UIComponent as IUIRect, fromPrefab, XSingleton<XGameUI>.singleton.HpbarRoot);
        }

        protected override void EventSubscribe()
        {
            this.RegisterEvent(XEventDefine.XEvent_BillboardShowCtrl, new XComponent.XEventHandler(this.OnShowCtrl));
            this.RegisterEvent(XEventDefine.XEvent_BuffChange, new XComponent.XEventHandler(this.OnBuffChange));
        }

        public override void Attached()
        {
            base.Attached();
            this._bloodBar = this._billboard.FindChild("Hpbar").GetComponent("XUIProgress") as IXUIProgress;
            this._bloodGrid = this._billboard.FindChild("Hpbar/BloodGrid").GetComponent("UIBloodGrid") as IUIBloodGrid;
            this._bloodGrid.SetMAXHP((int)this._entity.Attributes.GetAttr(XAttributeDefine.XAttr_MaxHP_Total));
            this._indureBar = this._billboard.FindChild("Indure").GetComponent("XUIProgress") as IXUIProgress;
            this._name = this._billboard.FindChild("Name").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
            this._level = this._billboard.FindChild("Level").GetComponent("XUILabel") as IXUILabel;
            this._exp = this._level.gameObject.transform.FindChild("frame").GetComponent("XUISprite") as IXUISprite;
            DlgHandlerBase.EnsureCreate<XBuffMonitorHandler>(ref this._buffMonitor, this._billboard.transform.FindChild("BuffFrame").gameObject);
            if (this._entity.IsPlayer)
                this._bloodBar.SetForegroundColor(XMobaBillboardComponent.billboard_green);
            else if (XSingleton<XEntityMgr>.singleton.IsOpponent(this._entity))
                this._bloodBar.SetForegroundColor(XMobaBillboardComponent.billboard_red);
            else
                this._bloodBar.SetForegroundColor(XMobaBillboardComponent.billboard_blue);
            if (this._entity.IsRole)
            {
                uint key = this._entity.IsPlayer ? XSingleton<XAttributeMgr>.singleton.XPlayerData.MilitaryRank : (this._entity.Attributes as XRoleAttributes).MilitaryRank;
                if (key == 0U)
                {
                    this.SetNameStr(this._entity.Attributes.Name);
                }
                else
                {
                    MilitaryRankByExploit.RowData byMilitaryRank = XMilitaryRankDocument._militaryReader.GetByMilitaryRank(key);
                    this.SetNameStr(XLabelSymbolHelper.FormatImage(XMobaBillboardComponent.MILITARY_ATLAS, byMilitaryRank.Icon) + this._entity.Attributes.Name);
                }
            }
            else
                this._name.SetVisible(false);
            if (this._buffMonitor != null)
                this._buffMonitor.InitMonitor(XSingleton<XGlobalConfig>.singleton.BuffMaxDisplayCountTeam, bShowTime: false);
            this._heroHeight = this._entity.Height;
            this._billboard.transform.localScale = Vector3.one * XMobaBillboardComponent.k;
            this._uiDummy.alpha = 0.0f;
        }

        private void SetNameStr(string str)
        {
            this.NameStr = str;
            this._name.InputText = str;
        }

        private void DestroyGameObjects()
        {
            if (!((Object)this._billboard != (Object)null))
                return;
            XSingleton<XResourceLoaderMgr>.singleton.UnSafeDestroy((Object)this._billboard.gameObject);
            this._billboard = (Transform)null;
        }

        public override void OnDetachFromHost()
        {
            this._alwaysHide = 0;
            this.DestroyGameObjects();
            base.OnDetachFromHost();
        }

        private bool OnShowCtrl(XEventArgs e)
        {
            XBillboardShowCtrlEventArgs showCtrlEventArgs = e as XBillboardShowCtrlEventArgs;
            if (showCtrlEventArgs.type == BillBoardHideType.Invalid)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("undefine billboard hide type. check code or contect pyc.");
                return false;
            }
            if (showCtrlEventArgs.show)
                this._alwaysHide &= ~(1 << XFastEnumIntEqualityComparer<BillBoardHideType>.ToInt(showCtrlEventArgs.type));
            else
                this._alwaysHide |= 1 << XFastEnumIntEqualityComparer<BillBoardHideType>.ToInt(showCtrlEventArgs.type);
            return true;
        }

        private bool OnBuffChange(XEventArgs args)
        {
            XBuffChangeEventArgs xbuffChangeEventArgs = args as XBuffChangeEventArgs;
            if (xbuffChangeEventArgs.entity.IsRole)
            {
                XBuffComponent buffs = xbuffChangeEventArgs.entity.Buffs;
                if (buffs != null)
                    this._buffMonitor.OnBuffChanged(buffs.GetUIBuffList());
            }
            return true;
        }

        private void SetBillBoardSameByMaster()
        {
            if (!XEntity.ValideEntity(this._entity.MobbedBy))
                return;
            XMobaBillboardComponent xcomponent = this._entity.MobbedBy.GetXComponent(XMobaBillboardComponent.uuID) as XMobaBillboardComponent;
            this._name.SetVisible(true);
            this._name.InputText = xcomponent.NameStr;
            this._level.SetText(xcomponent._level.GetText());
        }

        public override void PostUpdate(float fDeltaT)
        {
            if (!(this._host is XEntity host))
                return;
            if (!this.InitByMaster && this._entity.MobbedBy != null)
            {
                this.InitByMaster = true;
                if ((this._entity.Attributes as XOthersAttributes).SameBillBoardByMaster)
                    this.SetBillBoardSameByMaster();
            }
            if (!XEntity.ValideEntity(host))
                this._uiDummy.alpha = 0.0f;
            else if ((uint)this._alwaysHide > 0U)
            {
                this._uiDummy.alpha = 0.0f;
            }
            else
            {
                XPlayer player = XSingleton<XEntityMgr>.singleton.Player;
                if (player == null || player.EngineObject == null)
                    this.DestroyGameObjects();
                else if ((double)Vector3.Distance(host.EngineObject.Position, player.EngineObject.Position) > (double)this._viewDistance && (Object)this._billboard != (Object)null)
                {
                    this._uiDummy.alpha = 0.0f;
                }
                else
                {
                    if (!((Object)this._billboard != (Object)null))
                        return;
                    this.UpdateHpBar();
                }
            }
        }

        private void UpdateHpBar()
        {
            if ((double)this._uiDummy.alpha == 0.0)
                this._uiDummy.alpha = 1f;
            float num1 = 0.2f;
            if (!this._bloodBar.gameObject.activeSelf)
                num1 -= 0.05f;
            if (!this._indureBar.gameObject.activeSelf)
                num1 -= 0.05f;
            Vector3 position = this._entity.EngineObject.Position;
            this._billboard.position = new Vector3(position.x, position.y + this._heroHeight + num1, position.z);
            this._billboard.rotation = XSingleton<XScene>.singleton.GameCamera.Rotaton;
            if (XSingleton<XEntityMgr>.singleton.Player != null)
            {
                float num2 = 6.27f;
                float num3 = Vector3.Distance(XSingleton<XScene>.singleton.GameCamera.UnityCamera.transform.position, this._billboard.position);
                float num4 = XMobaBillboardComponent.k * num3 / num2;
                this._billboard.localScale = new Vector3(num4, num4, num4);
            }
            if (this._entity.IsRole)
            {
                int level;
                float exp;
                this._mobaDoc.GetRoleLevelAndExp(this._entity.ID, out level, out exp);
                this._level.SetText(level.ToString());
                this._exp.SetFillAmount(exp);
            }
            double attr1 = this._entity.Attributes.GetAttr(XAttributeDefine.XAttr_MaxHP_Total);
            if (this._bloodGrid.MAXHP != (int)attr1)
                this._bloodGrid.SetMAXHP((int)attr1);
            double num5 = this._entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentHP_Basic);
            if (num5 < 0.0)
                num5 = 0.0;
            this._bloodBar.value = (float)(num5 / attr1);
            if (!this._indureBar.gameObject.activeInHierarchy || this._secondbar_usage != BillboardUsage.MP)
                return;
            double attr2 = this._entity.Attributes.GetAttr(XAttributeDefine.XAttr_MaxMP_Total);
            double attr3 = this._entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentMP_Basic);
            this._indureBar.value = attr3 >= attr2 ? 1f : (float)(attr3 / attr2);
        }
    }
}
