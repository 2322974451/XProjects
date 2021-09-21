// Decompiled with JetBrains decompiler
// Type: XMainClient.XHUDComponent
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XHUDComponent : XComponent
    {
        public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("CombatInfoInScene");
        private GameObject _hudObject = (GameObject)null;
        private List<XHudEntry> _List = new List<XHudEntry>();
        private List<XHudEntry> _Unused = new List<XHudEntry>();
        private Camera gameCamera = (Camera)null;
        private Camera uiCamera = (Camera)null;
        private XBattleDocument _BattleDoc;
        public static bool processHud = true;
        private static int currentCount = 0;
        public static int _Max_UI_UpdateCount_PreFrame = 4;

        public override uint ID => XHUDComponent.uuID;

        public static void ResetCurrentCount() => XHUDComponent.currentCount = 0;

        public override void OnAttachToHost(XObject host)
        {
            base.OnAttachToHost(host);
            this._hudObject = XSingleton<XEngineCommandMgr>.singleton.GetGameObject();
            this._hudObject.layer = LayerMask.NameToLayer("UI");
            this._hudObject.name = this._entity.EngineObject.Name + "_hud";
            this.gameCamera = XSingleton<XScene>.singleton.GameCamera.UnityCamera;
            this.uiCamera = XSingleton<XGameUI>.singleton.UICamera;
            XSingleton<UiUtility>.singleton.AddChild(XSingleton<XGameUI>.singleton.UIRoot, this._hudObject.transform);
            this._BattleDoc = XDocuments.GetSpecificDocument<XBattleDocument>(XBattleDocument.uuID);
        }

        public override void OnDetachFromHost()
        {
            base.OnDetachFromHost();
            int count = this._List.Count;
            while (count > 0)
                this.DestroyEntityHudGameObject(this._List[--count]);
            XSingleton<XEngineCommandMgr>.singleton.ReturnGameObject(this._hudObject);
            this._hudObject = (GameObject)null;
        }

        protected override void EventSubscribe()
        {
            this.RegisterEvent(XEventDefine.XEvent_HUDAdd, new XComponent.XEventHandler(this.AddHud));
            this.RegisterEvent(XEventDefine.XEvent_HUDDoodad, new XComponent.XEventHandler(this.AddDoodadHUD));
        }

        private XHudEntry CreateHUD()
        {
            if (this._Unused.Count > 0)
            {
                XHudEntry xhudEntry = this._Unused[this._Unused.Count - 1];
                this._Unused.RemoveAt(this._Unused.Count - 1);
                xhudEntry.time = Time.realtimeSinceStartup;
                xhudEntry.offset = 0.0f;
                this._List.Add(xhudEntry);
                return xhudEntry;
            }
            XHudEntry xhudEntry1 = new XHudEntry();
            this._List.Add(xhudEntry1);
            return xhudEntry1;
        }

        public bool AddDoodadHUD(XEventArgs e)
        {
            XHUDDoodadArgs xhudDoodadArgs = e as XHUDDoodadArgs;
            GameObject fromPrefab = XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab("UI/Billboard/HUDDoodad", Vector3.zero, Quaternion.identity);
            fromPrefab.layer = LayerMask.NameToLayer("UI");
            XSingleton<UiUtility>.singleton.AddChild(this._hudObject, fromPrefab);
            XHudEntry hud = this.CreateHUD();
            hud.time = Time.realtimeSinceStartup;
            hud.stay = 0.1f;
            hud.offset = 0.0f;
            hud.val = 0.0f;
            hud.label = fromPrefab.transform.GetComponent("XUILabel") as IXUILabel;
            hud.label.SetRootAsUIPanel(true);
            hud.isDigital = true;
            IXUILabelSymbol component1 = fromPrefab.transform.GetComponent("XUILabelSymbol") as IXUILabelSymbol;
            ItemList.RowData itemConf1 = XBagDocument.GetItemConf(xhudDoodadArgs.itemid);
            if (itemConf1 != null)
            {
                if (itemConf1.ItemType == (byte)3)
                {
                    string str = XLabelSymbolHelper.FormatCostWithIcon("+{1} {0}", xhudDoodadArgs.count, (ItemEnum)xhudDoodadArgs.itemid);
                    component1.InputText = str;
                }
                else
                {
                    ItemList.RowData itemConf2 = XBagDocument.GetItemConf(xhudDoodadArgs.itemid);
                    string itemQualityColorStr = XSingleton<UiUtility>.singleton.GetItemQualityColorStr((int)itemConf2.ItemQuality);
                    component1.InputText = string.Format("[{0}]{1}[-] x{2}", (object)itemQualityColorStr, (object)XSingleton<UiUtility>.singleton.ChooseProfString(itemConf2.ItemName), (object)xhudDoodadArgs.count);
                }
            }
            this.UIFollowTarget();
            IXHUDDescription component2 = fromPrefab.transform.GetComponent("HUDDescription") as IXHUDDescription;
            hud.offsetCurve = component2.GetPosCurve();
            hud.scaleCurve = component2.GetScaleCurve();
            hud.alphaCurve = component2.GetAlphaCurve();
            return true;
        }

        public bool AddHud(XEventArgs e)
        {
            if (!XHUDComponent.processHud || XHUDComponent.currentCount > XHUDComponent._Max_UI_UpdateCount_PreFrame)
            {
                e.Recycle();
                return true;
            }
            if (!XHUDComponent.processHud)
                return true;
            if (XHUDComponent.currentCount >= XHUDComponent._Max_UI_UpdateCount_PreFrame && this._List.Count > 0)
                this.DeleteHUD(this._List[0]);
            XHUDAddEventArgs xhudAddEventArgs = e as XHUDAddEventArgs;
            if (!this._entity.IsPlayer && (!XSingleton<XScene>.singleton.bSpectator || XSingleton<XEntityMgr>.singleton.Player.WatchTo == null || (long)XSingleton<XEntityMgr>.singleton.Player.WatchTo.ID != (long)this._entity.ID))
            {
                ulong num = 0;
                bool flag1 = false;
                if (xhudAddEventArgs.caster == null || xhudAddEventArgs.caster.Attributes == null || xhudAddEventArgs.caster.Attributes.HostID == 0UL)
                {
                    if (!this._BattleDoc.ShowTeamMemberDamageHUD)
                        num = xhudAddEventArgs.damageResult.Caster;
                    else
                        flag1 = true;
                }
                else
                {
                    if (!this._BattleDoc.ShowMobDamageHUD)
                        return true;
                    num = xhudAddEventArgs.caster.Attributes.HostID;
                }
                if (!flag1)
                {
                    if (num <= 0UL)
                        return true;
                    bool flag2 = XSingleton<XEntityMgr>.singleton.Player.WatchTo != null && (long)XSingleton<XEntityMgr>.singleton.Player.WatchTo.ID == (long)num;
                    if ((long)num != (long)XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID && !flag2)
                        return true;
                }
            }
            GameObject templateByDamageResult = XSingleton<XCombatHUDMgr>.singleton.GetHUDTemplateByDamageResult(xhudAddEventArgs.damageResult, this._entity.IsPlayer);
            ++XHUDComponent.currentCount;
            templateByDamageResult.layer = LayerMask.NameToLayer("UI");
            XHudEntry hud = this.CreateHUD();
            hud.time = Time.realtimeSinceStartup;
            hud.stay = 0.1f;
            hud.offset = 0.0f;
            hud.val = (float)xhudAddEventArgs.damageResult.Value;
            if (!hud.init)
            {
                hud.label = templateByDamageResult.transform.GetComponent("XUILabel") as IXUILabel;
                hud.label.SetRootAsUIPanel(true);
            }
            XSingleton<UiUtility>.singleton.AddChildNoMark(this._hudObject, templateByDamageResult);
            hud.isDigital = true;
            string strText = XSingleton<XCombatHUDMgr>.singleton.GetHUDText(xhudAddEventArgs.damageResult, hud.isDigital);
            if (this._entity.IsMainViewEntity)
                strText = (xhudAddEventArgs.damageResult.Value >= 0.0 ? "-" : "+") + strText;
            if (xhudAddEventArgs.damageResult.Result != ProjectResultType.PJRES_IMMORTAL && xhudAddEventArgs.damageResult.Result != ProjectResultType.PJRES_MISS)
                hud.label.SetText(strText);
            if (this._entity.IsEnemy && xhudAddEventArgs.damageResult.Value > 0.0)
                XSingleton<XLevelStatistics>.singleton.ls._total_damage += (float)xhudAddEventArgs.damageResult.Value;
            else if (this._entity.IsPlayer)
            {
                if (xhudAddEventArgs.damageResult.Value > 0.0)
                    XSingleton<XLevelStatistics>.singleton.ls._total_hurt += (float)xhudAddEventArgs.damageResult.Value;
                else
                    XSingleton<XLevelStatistics>.singleton.ls._total_heal += (float)-xhudAddEventArgs.damageResult.Value;
            }
            if (!xhudAddEventArgs.damageResult.IsCritical() && !this._entity.IsMainViewEntity)
            {
                bool applyGradient = false;
                Color white1 = Color.white;
                Color white2 = Color.white;
                XSingleton<XCombatHUDMgr>.singleton.GetElementColor(xhudAddEventArgs.damageResult.ElementType, ref applyGradient, ref white1, ref white2);
                hud.label.SetGradient(applyGradient, white1, white2);
                hud.label.SetColor(white1);
            }
            if (!xhudAddEventArgs.damageResult.IsCritical() && xhudAddEventArgs.damageResult.Result != ProjectResultType.PJRES_IMMORTAL && this._entity.IsMainViewEntity)
            {
                hud.label.SetGradient(false, Color.white, Color.white);
                hud.label.SetColor((Color)new Color32(byte.MaxValue, (byte)32, (byte)73, byte.MaxValue));
            }
            if (xhudAddEventArgs.damageResult.Value < 0.0)
            {
                Color green1 = Color.green;
                Color green2 = Color.green;
                hud.label.SetGradient(true, green1, green2);
                hud.label.SetColor(green1);
            }
            this.UIFollowTarget();
            if (!hud.init)
            {
                IXHUDDescription component = templateByDamageResult.transform.GetComponent("HUDDescription") as IXHUDDescription;
                hud.offsetCurve = component.GetPosCurve();
                hud.alphaCurve = component.GetAlphaCurve();
                hud.scaleCurve = component.GetScaleCurve();
            }
            return true;
        }

        private void DeleteHUD(XHudEntry ent)
        {
            this._List.Remove(ent);
            this._Unused.Add(ent);
            this.DestroyEntityHudGameObject(ent);
            --XHUDComponent.currentCount;
        }

        protected void HideEntityHudGameObject(XHudEntry ent)
        {
            ent.label.gameObject.transform.localPosition = XResourceLoaderMgr.Far_Far_Away;
            XSingleton<XResourceLoaderMgr>.singleton.UnSafeDestroy((Object)ent.label.gameObject);
        }

        protected void DestroyEntityHudGameObject(XHudEntry ent)
        {
            ent.label.gameObject.transform.localPosition = XResourceLoaderMgr.Far_Far_Away;
            XSingleton<XResourceLoaderMgr>.singleton.UnSafeDestroy((Object)ent.label.gameObject);
        }

        private void UIFollowTarget()
        {
            if ((Object)this.gameCamera == (Object)null)
                this.gameCamera = XSingleton<XScene>.singleton.GameCamera.UnityCamera;
            float height = this._entity.Height;
            Vector3 radiusCenter = this._entity.RadiusCenter;
            Vector3 viewportPoint = this.gameCamera.WorldToViewportPoint(new Vector3(radiusCenter.x, radiusCenter.y + height, radiusCenter.z));
            bool flag = (double)viewportPoint.z > 0.0 && (double)viewportPoint.x > 0.0 && (double)viewportPoint.x < 1.0 && (double)viewportPoint.y > 0.0 && (double)viewportPoint.y < 1.0;
            this._hudObject.transform.position = this.uiCamera.ViewportToWorldPoint(viewportPoint);
            Vector3 localPosition = this._hudObject.transform.localPosition;
            localPosition.x = (float)Mathf.FloorToInt(localPosition.x);
            localPosition.y = (float)Mathf.FloorToInt(localPosition.y);
            if ((double)localPosition.y > (double)(XSingleton<XGameUI>.singleton.Base_UI_Height / 2) * 0.5)
                localPosition.y = (float)(XSingleton<XGameUI>.singleton.Base_UI_Height / 2) * 0.5f;
            localPosition.z = 0.0f;
            this._hudObject.transform.localPosition = localPosition;
        }

        private void UpdateHUDs()
        {
            float realtimeSinceStartup = Time.realtimeSinceStartup;
            int count1 = this._List.Count;
            while (count1 > 0)
            {
                XHudEntry ent = this._List[--count1];
                float time1 = ent.offsetCurve[ent.offsetCurve.length - 1].time;
                float time2 = ent.scaleCurve[ent.scaleCurve.length - 1].time;
                float time3 = ent.alphaCurve[ent.alphaCurve.length - 1].time;
                float num1 = Mathf.Max(Mathf.Max(time2, time1), time3);
                float time4 = realtimeSinceStartup - ent.movementStart;
                ent.offset = ent.offsetCurve.Evaluate(time4);
                float num2 = ent.scaleCurve.Evaluate(realtimeSinceStartup - ent.time);
                if ((double)num2 < 1.0 / 1000.0)
                    num2 = 1f / 1000f;
                ent.label.gameObject.transform.localScale = Vector3.one * num2;
                float a = ent.alphaCurve.Evaluate(realtimeSinceStartup - ent.time);
                Color color = ent.label.GetColor();
                Color c = new Color(color.r, color.g, color.b, a);
                ent.label.SetColor(c);
                if ((double)time4 > (double)num1)
                    this.DeleteHUD(ent);
            }
            float a1 = -200f;
            int count2 = this._List.Count;
            while (count2 > 0)
            {
                XHudEntry xhudEntry = this._List[--count2];
                float y = Mathf.Max(a1, xhudEntry.offset);
                xhudEntry.label.gameObject.transform.localPosition = new Vector3(0.0f, y, 0.0f);
                a1 = y + Mathf.Round(xhudEntry.label.gameObject.transform.localScale.y * 20f);
            }
        }

        public override void PostUpdate(float fDeltaT) => this.UpdateHUDs();
    }
}
