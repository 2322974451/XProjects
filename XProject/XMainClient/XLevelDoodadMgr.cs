// Decompiled with JetBrains decompiler
// Type: XMainClient.XLevelDoodadMgr
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

using KKSG;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XLevelDoodadMgr : XSingleton<XLevelDoodadMgr>
    {
        private List<XLevelDoodad> _doodads = new List<XLevelDoodad>();
        private GameObject _HpbarRoot = (GameObject)null;
        private List<GameObject> _DropedDoodads = new List<GameObject>();
        private List<uint> _TimerToken = new List<uint>();
        private Dictionary<uint, XSyncDoodadInfo> _NoticeDictionary = new Dictionary<uint, XSyncDoodadInfo>();
        private XTimerMgr.ElapsedEventHandler _showRollOverNoticeCb = (XTimerMgr.ElapsedEventHandler)null;
        private XTimerMgr.ElapsedEventHandler _delayGenerateDoodadCb = (XTimerMgr.ElapsedEventHandler)null;
        private float _DoodadPickCD = 0.0f;

        public XLevelDoodadMgr()
        {
            this._showRollOverNoticeCb = new XTimerMgr.ElapsedEventHandler(this.ShowRollOverNotice);
            this._delayGenerateDoodadCb = new XTimerMgr.ElapsedEventHandler(this.DelayGenerateDoodad);
        }

        public override bool Init()
        {
            this._HpbarRoot = XSingleton<XGameUI>.singleton.HpbarRoot.gameObject;
            this._DoodadPickCD = (float)XSingleton<XGlobalConfig>.singleton.GetInt("DoodadPickCD") / 100f;
            return true;
        }

        public override void Uninit()
        {
            this._doodads.Clear();
            this._DropedDoodads.Clear();
            this._NoticeDictionary.Clear();
            this._HpbarRoot = (GameObject)null;
        }

        public void CacheDoodad(List<DoodadInfo> doodads)
        {
            if (this._doodads.Count > 0)
                this.OnClearDoodad();
            this._doodads.Clear();
            for (int index = 0; index < doodads.Count; ++index)
            {
                DoodadInfo doodad = doodads[index];
                this._doodads.Add(new XLevelDoodad()
                {
                    index = (uint)index,
                    wave = doodad.waveid,
                    type = (XDoodadType)doodad.type,
                    id = doodad.id,
                    count = doodad.count,
                    dropped = false,
                    picked = false,
                    lastPickTime = 0.0f
                });
            }
        }

        public void OnMonsterDie(XEntity entity)
        {
            XLevelDoodad wave = this.FindWave(entity.Wave);
            if (wave == null || wave.dropped)
                return;
            XLevelDynamicInfo waveDynamicInfo = XSingleton<XLevelSpawnMgr>.singleton.CurrentSpawner.GetWaveDynamicInfo(entity.Wave);
            float num = 1f / (float)(waveDynamicInfo._TotalCount - waveDynamicInfo._dieCount + 1);
            if ((double)XSingleton<XCommon>.singleton.RandomFloat(0.0f, 1f) > (double)num)
                return;
            wave.dropped = true;
            wave.pos = entity.EngineObject.Position;
            wave.templateid = entity.Attributes.TypeID;
            if (entity.IsBoss && wave.id == 1U)
                this._doodads.Remove(wave);
            this.DelayGenerateClientDoodad((object)wave);
        }

        public void ReportServerList(List<uint> l)
        {
            l.Clear();
            for (int index = 0; index < this._doodads.Count; ++index)
            {
                if (this._doodads[index].picked)
                    l.Add((uint)this._doodads[index].wave);
            }
        }

        public void OnLeaveScene()
        {
            for (int index = 0; index < this._doodads.Count; ++index)
            {
                if (this._doodads[index].dropped && !this._doodads[index].picked)
                {
                    if ((Object)this._doodads[index].doodad != (Object)null)
                        XResourceLoaderMgr.SafeDestroy(ref this._doodads[index].doodad);
                    if ((Object)this._doodads[index].billboard != (Object)null)
                        XResourceLoaderMgr.SafeDestroy(ref this._doodads[index].billboard);
                }
            }
            this._doodads.Clear();
            this._NoticeDictionary.Clear();
        }

        public void OnClearDoodad()
        {
            for (int index = 0; index < this._TimerToken.Count; ++index)
                XSingleton<XTimerMgr>.singleton.KillTimer(this._TimerToken[index]);
            this._TimerToken.Clear();
            for (int index = 0; index < this._doodads.Count; ++index)
            {
                if (this._doodads[index].dropped && !this._doodads[index].picked)
                {
                    if ((Object)this._doodads[index].doodad != (Object)null)
                        XResourceLoaderMgr.SafeDestroy(ref this._doodads[index].doodad);
                    if ((Object)this._doodads[index].billboard != (Object)null)
                        XResourceLoaderMgr.SafeDestroy(ref this._doodads[index].billboard);
                }
            }
            this._doodads.Clear();
        }

        protected XLevelDoodad FindWave(int wave)
        {
            for (int index = 0; index < this._doodads.Count; ++index)
            {
                if (this._doodads[index].wave == wave)
                    return this._doodads[index];
            }
            return (XLevelDoodad)null;
        }

        protected XLevelDoodad FindWaveByIndex(uint index)
        {
            for (int index1 = 0; index1 < this._doodads.Count; ++index1)
            {
                if ((int)this._doodads[index1].index == (int)index)
                    return this._doodads[index1];
            }
            return (XLevelDoodad)null;
        }

        private bool GenerateDoodadFx(XLevelDoodad doo, Vector3 pos)
        {
            XEntityStatistics.RowData byId = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(doo.templateid);
            if (byId != null && byId.Type == (byte)1)
            {
                XEntityPresentation.RowData byPresentId = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(byId.PresentID);
                Vector3 vector3 = XSingleton<XScene>.singleton.GameCamera.UnityCamera.transform.position - pos;
                vector3.y = 0.0f;
                vector3.Normalize();
                float num = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("DoodadDist"));
                if (byPresentId != null)
                {
                    doo.pos += vector3 * (num + byPresentId.BoundRadius);
                    pos += vector3 * (num + byPresentId.BoundRadius);
                }
                else
                {
                    doo.pos += vector3 * num;
                    pos += vector3 * num;
                }
            }
            ItemList.RowData itemConf = XBagDocument.GetItemConf((int)doo.id);
            if (itemConf != null)
            {
                string[] strArray = itemConf.DoodadFx.Split(XGlobalConfig.ListSeparator);
                if (strArray.Length > 1)
                {
                    if (int.Parse(strArray[0]) == 0)
                    {
                        XSingleton<XFxMgr>.singleton.CreateFx(strArray[2]).Play(pos, Quaternion.identity, Vector3.one);
                        if (doo.id == 1U)
                            XSingleton<XAudioMgr>.singleton.PlaySoundAt(pos, "Audio/common/Coins");
                        if (!XSingleton<XGame>.singleton.SyncMode && !XSingleton<XLevelFinishMgr>.singleton.IsCurrentLevelFinished)
                        {
                            uint num = (double)strArray.Length < 3.0 ? XSingleton<XTimerMgr>.singleton.SetTimer(1.5f, this._delayGenerateDoodadCb, (object)doo) : XSingleton<XTimerMgr>.singleton.SetTimer(float.Parse(strArray[3]), this._delayGenerateDoodadCb, (object)doo);
                            doo.token = num;
                            this._TimerToken.Add(num);
                        }
                        return true;
                    }
                    XSingleton<XAudioMgr>.singleton.PlaySoundAt(pos, "Audio/common/Item_Gem");
                    return false;
                }
            }
            return false;
        }

        private bool GetDoodadInfo(
          XLevelDoodad doo,
          ref string location,
          ref string name,
          ref Vector3 offset,
          ref int quality,
          ref bool isequip)
        {
            if (doo == null)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("Doo is null!");
                return false;
            }
            if (doo.type == XDoodadType.Item)
            {
                FashionList.RowData fashionConf = XBagDocument.GetFashionConf((int)doo.id);
                if (fashionConf != null)
                {
                    string dir = "";
                    string equipPrefabModel = XEquipDocument.GetEquipPrefabModel(fashionConf, XSingleton<XEntityMgr>.singleton.Player.BasicTypeID, out dir);
                    if (equipPrefabModel != "")
                    {
                        location = "Equipments/" + equipPrefabModel;
                        offset = this.GetDoodadOffset(XSingleton<XEntityMgr>.singleton.Player.BasicTypeID, (FashionPosition)fashionConf.EquipPos);
                        ItemList.RowData itemConf = XBagDocument.GetItemConf((int)doo.id);
                        if (itemConf == null)
                        {
                            XSingleton<XDebug>.singleton.AddErrorLog("ItemID not exist:" + (object)doo.id);
                            return false;
                        }
                        name = XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemName);
                        quality = (int)itemConf.ItemQuality;
                    }
                }
                else
                {
                    EquipList.RowData equipConf = XBagDocument.GetEquipConf((int)doo.id);
                    if (equipConf != null)
                    {
                        string defaultEquipModel;
                        if (equipConf.EquipPos == (byte)0)
                            defaultEquipModel = XSingleton<XGlobalConfig>.singleton.GetValue("DoodadPrefabHead");
                        else if (equipConf.EquipPos == (byte)7)
                            defaultEquipModel = XSingleton<XGlobalConfig>.singleton.GetValue("DoodadPrefabNecklace");
                        else if (equipConf.EquipPos == (byte)8)
                            defaultEquipModel = XSingleton<XGlobalConfig>.singleton.GetValue("DoodadPrefabEarring");
                        else if (equipConf.EquipPos == (byte)9)
                        {
                            defaultEquipModel = XSingleton<XGlobalConfig>.singleton.GetValue("DoodadPrefabRing");
                        }
                        else
                        {
                            string dir = "";
                            defaultEquipModel = XEquipDocument.GetDefaultEquipModel(XSingleton<XEntityMgr>.singleton.Player.BasicTypeID, (FashionPosition)equipConf.EquipPos, out dir);
                        }
                        if (defaultEquipModel != "")
                        {
                            location = "Equipments/" + defaultEquipModel;
                            offset = this.GetDoodadOffsetEquip(XSingleton<XEntityMgr>.singleton.Player.BasicTypeID, (EquipPosition)equipConf.EquipPos);
                            ItemList.RowData itemConf = XBagDocument.GetItemConf((int)doo.id);
                            if (itemConf == null)
                            {
                                XSingleton<XDebug>.singleton.AddErrorLog("ItemID not exist:" + (object)doo.id);
                                return false;
                            }
                            name = XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemName);
                            quality = (int)itemConf.ItemQuality;
                            isequip = true;
                        }
                    }
                    else
                    {
                        ItemList.RowData itemConf = XBagDocument.GetItemConf((int)doo.id);
                        if (itemConf == null)
                        {
                            XSingleton<XDebug>.singleton.AddErrorLog("ItemID not exist:" + (object)doo.id);
                            return false;
                        }
                        string[] strArray = itemConf.DoodadFx.Split(XGlobalConfig.ListSeparator);
                        if (strArray.Length < 3)
                        {
                            location = strArray.Length > 1 ? strArray[1] : strArray[0];
                            name = XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemName);
                            quality = (int)itemConf.ItemQuality;
                        }
                    }
                }
            }
            else if (doo.type == XDoodadType.Buff || doo.type == XDoodadType.BuffHorse || doo.type == XDoodadType.BuffSkill || doo.type == XDoodadType.BigMeleeItem)
            {
                BuffTable.RowData buffData = XSingleton<XBuffTemplateManager>.singleton.GetBuffData((int)doo.id, 1);
                if (buffData == null)
                {
                    XSingleton<XDebug>.singleton.AddErrorLog("BuffID not exist:" + (object)doo.id);
                    return false;
                }
                location = buffData.BuffDoodadFx;
                name = buffData.BuffName;
                quality = -1;
            }
            return true;
        }

        private GameObject GenerateDoodadGO(
          XLevelDoodad doo,
          Vector3 pos,
          string location,
          bool isequip,
          int quality,
          Vector3 offset)
        {
            if (doo == null)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("Doo is null!");
                return (GameObject)null;
            }
            GameObject gameObject = (GameObject)null;
            if (doo.type == XDoodadType.Buff || doo.type == XDoodadType.BuffHorse || doo.type == XDoodadType.BuffSkill || doo.type == XDoodadType.BigMeleeItem)
            {
                gameObject = XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab(location) as GameObject;
            }
            else
            {
                GameObject fromPrefab = XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab(location) as GameObject;
                if ((Object)fromPrefab == (Object)null)
                {
                    XSingleton<XDebug>.singleton.AddErrorLog("Equip == null");
                    return (GameObject)null;
                }
                if (isequip)
                {
                    string str;
                    switch (quality)
                    {
                        case 3:
                            str = "Szcs_glow";
                            break;
                        case 4:
                            str = "Szbz_glow";
                            break;
                        case 5:
                            str = "Szbh_glow";
                            break;
                        default:
                            str = "Szty_glow";
                            break;
                    }
                    gameObject = XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab("Prefabs/Effects/Default/" + str) as GameObject;
                    if ((Object)gameObject == (Object)null)
                        return (GameObject)null;
                    Transform childRecursively = XSingleton<XCommon>.singleton.FindChildRecursively(gameObject.transform, "zhuangbei");
                    if ((Object)fromPrefab.transform == (Object)null || (Object)childRecursively == (Object)null)
                    {
                        XSingleton<XDebug>.singleton.AddErrorLog("Equip or t = null");
                        return (GameObject)null;
                    }
                    XSingleton<UiUtility>.singleton.AddChild(childRecursively, fromPrefab.transform);
                    fromPrefab.transform.localRotation = Quaternion.Euler(-90f, 0.0f, 0.0f);
                    fromPrefab.transform.localPosition += offset;
                }
                else
                {
                    ItemList.RowData itemConf = XBagDocument.GetItemConf((int)doo.id);
                    if (itemConf == null)
                    {
                        XSingleton<XDebug>.singleton.AddErrorLog("Doo.Id not exists : " + (object)(int)doo.id);
                        return (GameObject)null;
                    }
                    string[] strArray = itemConf.DoodadFx.Split(XGlobalConfig.ListSeparator);
                    if (strArray.Length > 1)
                    {
                        switch (int.Parse(strArray[0]))
                        {
                            case 0:
                                gameObject = fromPrefab;
                                fromPrefab.transform.localPosition = pos;
                                break;
                            case 1:
                                gameObject = XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab(strArray[2]) as GameObject;
                                if ((Object)gameObject == (Object)null)
                                    return (GameObject)null;
                                Transform childRecursively = XSingleton<XCommon>.singleton.FindChildRecursively(gameObject.transform, "Point_drop01");
                                fromPrefab.transform.localRotation = Quaternion.Euler(-90f, 0.0f, 0.0f);
                                if ((Object)fromPrefab.transform == (Object)null || (Object)childRecursively == (Object)null)
                                {
                                    XSingleton<XDebug>.singleton.AddErrorLog("Equip or t = null");
                                    return (GameObject)null;
                                }
                                XSingleton<UiUtility>.singleton.AddChild(childRecursively, fromPrefab.transform);
                                break;
                        }
                    }
                    else
                    {
                        gameObject = fromPrefab;
                        fromPrefab.transform.localPosition = pos;
                    }
                }
            }
            if ((Object)gameObject == (Object)null)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("Go = null!");
                return (GameObject)null;
            }
            float num = XSingleton<XScene>.singleton.TerrainY(pos);
            gameObject.transform.position = new Vector3(pos.x, num + 0.5f, pos.z);
            return gameObject;
        }

        private bool AttachDoodadBillboard(XLevelDoodad doo, string name, int quality)
        {
            if (doo == null)
                return false;
            GameObject fromPrefab = XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab("UI/Billboard/DoodadBillboard") as GameObject;
            if ((Object)fromPrefab == (Object)null)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("Billboard create failed");
                return false;
            }
            XSingleton<UiUtility>.singleton.AddChild(this._HpbarRoot, fromPrefab);
            fromPrefab.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
            doo.billboard = fromPrefab;
            IXUILabel component1 = fromPrefab.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
            IXUILabelSymbol component2 = fromPrefab.transform.FindChild("Name").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
            if (component1 != null)
            {
                switch (XSingleton<XScene>.singleton.SceneType)
                {
                    case SceneType.SCENE_HORSE_RACE:
                    case SceneType.SCENE_WEEKEND4V4_HORSERACING:
                        component1.SetText(XStringDefineProxy.GetString("RACE_DOODAD_NAME"));
                        break;
                    default:
                        component2.InputText = doo.count <= 1U ? name : name + doo.count.ToString();
                        component1.SetColor(XSingleton<UiUtility>.singleton.GetItemQualityColor(quality));
                        break;
                }
            }
            if (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_BATTLEFIELD_FIGHT)
            {
                string str = XBattleFieldBattleDocument.Doc.userIdToRole[doo.roleid];
                if (str != null)
                    component2.InputText = str + "\n" + component1.GetText();
            }
            return true;
        }

        private GameObject GenerateDoodadObject(XLevelDoodad doo, Vector3 pos)
        {
            string location = "";
            string name = "";
            Vector3 zero = Vector3.zero;
            int quality = 0;
            bool isequip = false;
            if (!this.GetDoodadInfo(doo, ref location, ref name, ref zero, ref quality, ref isequip))
            {
                XSingleton<XDebug>.singleton.AddErrorLog("doodad info get error");
                return (GameObject)null;
            }
            if (location == "")
                return (GameObject)null;
            GameObject doodadGo = this.GenerateDoodadGO(doo, pos, location, isequip, quality, zero);
            if ((Object)doodadGo == (Object)null)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("Doodad gameobject create failed");
                return (GameObject)null;
            }
            doo.doodad = doodadGo;
            doo.pos = pos;
            if (!this.AttachDoodadBillboard(doo, name, quality))
            {
                XSingleton<XDebug>.singleton.AddErrorLog("Doodad billboard create failed");
                return (GameObject)null;
            }
            XDoodadCreateArgs xdoodadCreateArgs = XEventPool<XDoodadCreateArgs>.GetEvent();
            xdoodadCreateArgs.doo = doo;
            xdoodadCreateArgs.Firer = (XObject)XSingleton<XGame>.singleton.Doc;
            XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xdoodadCreateArgs);
            return doodadGo;
        }

        private void DelayGenerateClientDoodad(object obj)
        {
            XLevelDoodad doo = (XLevelDoodad)obj;
            this.GenerateDoodad(doo, doo.pos);
        }

        protected GameObject GenerateDoodad(XLevelDoodad doo, Vector3 pos) => this.GenerateDoodadFx(doo, pos) ? doo.doodad : this.GenerateDoodadObject(doo, pos);

        protected Vector3 GetDoodadOffset(uint typeid, FashionPosition pos)
        {
            string str;
            switch (pos)
            {
                case FashionPosition.FASHION_START:
                    str = XSingleton<XGlobalConfig>.singleton.GetValue("DoodadOffsetHead");
                    break;
                case FashionPosition.FashionUpperBody:
                    str = XSingleton<XGlobalConfig>.singleton.GetValue("DoodadOffsetUpperBody");
                    break;
                case FashionPosition.FashionLowerBody:
                    str = XSingleton<XGlobalConfig>.singleton.GetValue("DoodadOffsetLowerBody");
                    break;
                case FashionPosition.FashionGloves:
                    str = XSingleton<XGlobalConfig>.singleton.GetValue("DoodadOffsetGloves");
                    break;
                case FashionPosition.FashionBoots:
                    str = XSingleton<XGlobalConfig>.singleton.GetValue("DoodadOffsetBoots");
                    break;
                case FashionPosition.FashionMainWeapon:
                    str = XSingleton<XGlobalConfig>.singleton.GetValue("DoodadOffsetMainWeapon");
                    break;
                case FashionPosition.FashionSecondaryWeapon:
                    str = XSingleton<XGlobalConfig>.singleton.GetValue("DoodadOffsetSecWeapon");
                    break;
                case FashionPosition.FashionWings:
                    str = XSingleton<XGlobalConfig>.singleton.GetValue("DoodadOffsetWing");
                    break;
                case FashionPosition.FashionTail:
                    str = XSingleton<XGlobalConfig>.singleton.GetValue("DoodadOffsetTail");
                    break;
                case FashionPosition.FashionDecal:
                    str = XSingleton<XGlobalConfig>.singleton.GetValue("DoodadOffsetDecal");
                    break;
                default:
                    str = XSingleton<XGlobalConfig>.singleton.GetValue("DoodadOffsetNormal");
                    break;
            }
            string[] strArray = str.Split(XGlobalConfig.AllSeparators);
            return new Vector3(float.Parse(strArray[((int)typeid - 1) * 2]), float.Parse(strArray[((int)typeid - 1) * 2 + 1]), 0.0f);
        }

        protected Vector3 GetDoodadOffsetEquip(uint typeid, EquipPosition pos)
        {
            string str;
            switch (pos)
            {
                case EquipPosition.EQUIP_START:
                    str = XSingleton<XGlobalConfig>.singleton.GetValue("DoodadOffsetHead");
                    break;
                case EquipPosition.Upperbody:
                    str = XSingleton<XGlobalConfig>.singleton.GetValue("DoodadOffsetUpperBody");
                    break;
                case EquipPosition.Lowerbody:
                    str = XSingleton<XGlobalConfig>.singleton.GetValue("DoodadOffsetLowerBody");
                    break;
                case EquipPosition.Gloves:
                    str = XSingleton<XGlobalConfig>.singleton.GetValue("DoodadOffsetGloves");
                    break;
                case EquipPosition.Boots:
                    str = XSingleton<XGlobalConfig>.singleton.GetValue("DoodadOffsetBoots");
                    break;
                case EquipPosition.Mainweapon:
                    str = XSingleton<XGlobalConfig>.singleton.GetValue("DoodadOffsetMainWeapon");
                    break;
                case EquipPosition.Secondaryweapon:
                    str = XSingleton<XGlobalConfig>.singleton.GetValue("DoodadOffsetSecWeapon");
                    break;
                case EquipPosition.Necklace:
                    str = XSingleton<XGlobalConfig>.singleton.GetValue("DoodadOffsetNormal");
                    break;
                case EquipPosition.Earrings:
                    str = XSingleton<XGlobalConfig>.singleton.GetValue("DoodadOffsetNormal");
                    break;
                case EquipPosition.Rings:
                    str = XSingleton<XGlobalConfig>.singleton.GetValue("DoodadOffsetNormal");
                    break;
                default:
                    str = XSingleton<XGlobalConfig>.singleton.GetValue("DoodadOffsetNormal");
                    break;
            }
            string[] strArray = str.Split(XGlobalConfig.AllSeparators);
            return new Vector3(float.Parse(strArray[((int)typeid - 1) * 2]), float.Parse(strArray[((int)typeid - 1) * 2 + 1]), 0.0f);
        }

        public void OnDoodadPicked(int wave, uint index)
        {
            if (!XSingleton<XGame>.singleton.SyncMode)
                this.OnDoodadPickedSolo(wave, index);
            else
                this.OnDoodadPickedSync(wave, index);
        }

        protected void OnDoodadPickedSolo(int wave, uint index)
        {
            XLevelDoodad waveByIndex = this.FindWaveByIndex(index);
            if (waveByIndex == null)
            {
                XSingleton<XDebug>.singleton.AddLog("Pick up some doodad not exists??");
            }
            else
            {
                if (waveByIndex.type == XDoodadType.Buff)
                {
                    XBuffAddEventArgs xbuffAddEventArgs = XEventPool<XBuffAddEventArgs>.GetEvent();
                    xbuffAddEventArgs.xBuffDesc.BuffID = (int)waveByIndex.id;
                    xbuffAddEventArgs.xBuffDesc.BuffLevel = (int)waveByIndex.count;
                    xbuffAddEventArgs.Firer = (XObject)XSingleton<XEntityMgr>.singleton.Player;
                    xbuffAddEventArgs.xBuffDesc.CasterID = XSingleton<XEntityMgr>.singleton.Player.ID;
                    XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xbuffAddEventArgs);
                }
                if (waveByIndex.type == XDoodadType.Item)
                {
                    XHUDDoodadArgs xhudDoodadArgs = XEventPool<XHUDDoodadArgs>.GetEvent();
                    xhudDoodadArgs.itemid = (int)waveByIndex.id;
                    xhudDoodadArgs.count = (int)waveByIndex.count;
                    xhudDoodadArgs.Firer = (XObject)XSingleton<XEntityMgr>.singleton.Player;
                    XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xhudDoodadArgs);
                }
                this._OnDoodadPickedSucc(waveByIndex, (XEntity)XSingleton<XEntityMgr>.singleton.Player);
            }
        }

        protected void _OnDoodadPickedSucc(XLevelDoodad doo, XEntity p)
        {
            if ((Object)doo.doodad == (Object)null)
                return;
            XDoodadDeleteArgs xdoodadDeleteArgs = XEventPool<XDoodadDeleteArgs>.GetEvent();
            xdoodadDeleteArgs.doo = doo;
            xdoodadDeleteArgs.Firer = (XObject)XSingleton<XGame>.singleton.Doc;
            XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xdoodadDeleteArgs);
            doo.picked = true;
            if (doo.type == XDoodadType.Item)
            {
                Transform childRecursively = XSingleton<XCommon>.singleton.FindChildRecursively(doo.doodad.transform, "zhuangbei");
                if ((Object)childRecursively != (Object)null && childRecursively.childCount > 0)
                    XSingleton<XResourceLoaderMgr>.singleton.UnSafeDestroy((Object)childRecursively.GetChild(0).gameObject);
            }
            XResourceLoaderMgr.SafeDestroy(ref doo.doodad);
            XResourceLoaderMgr.SafeDestroy(ref doo.billboard);
            if (p == null)
                return;
            XSingleton<XFxMgr>.singleton.CreateAndPlay("Effects/FX_Particle/Roles/Lzg_Ty/Ty_buff_xishou", p.EngineObject, Vector3.zero, Vector3.one, follow: true, duration: 5f);
        }

        protected void OnDoodadPickedSync(int wave, uint index)
        {
            XLevelDoodad waveByIndex = this.FindWaveByIndex(index);
            if (waveByIndex == null || (double)Time.time - (double)waveByIndex.lastPickTime < (double)this._DoodadPickCD)
                return;
            waveByIndex.lastPickTime = Time.time;
            RpcC2G_FetchEnemyDoodadReq fetchEnemyDoodadReq = new RpcC2G_FetchEnemyDoodadReq()
            {
                oArg = {
          waveid = waveByIndex.wave,
          pos = new Vec3()
        }
            };
            fetchEnemyDoodadReq.oArg.pos.x = waveByIndex.pos.x;
            fetchEnemyDoodadReq.oArg.pos.y = waveByIndex.pos.y;
            fetchEnemyDoodadReq.oArg.pos.z = waveByIndex.pos.z;
            fetchEnemyDoodadReq.oArg.id = waveByIndex.id;
            fetchEnemyDoodadReq.oArg.type = (int)waveByIndex.type;
            fetchEnemyDoodadReq.oArg.count = waveByIndex.count;
            fetchEnemyDoodadReq.oArg.index = waveByIndex.index;
            XSingleton<XClientNetwork>.singleton.Send((Rpc)fetchEnemyDoodadReq);
        }

        public void OnDoodadPickedSyncSucc(
          uint index,
          int wave,
          Vector3 posid,
          XEntity p,
          uint maxroll,
          uint playerroll)
        {
            XLevelDoodad waveByIndex = this.FindWaveByIndex(index);
            if (waveByIndex == null)
                return;
            this._OnDoodadPickedSucc(waveByIndex, p);
            if (waveByIndex.type != XDoodadType.Item)
                return;
            this.ShowGetItemNotice(waveByIndex, p);
        }

        private void ShowGetItemNotice(XLevelDoodad doo, XEntity p)
        {
            if (doo.type != XDoodadType.Item)
                return;
            XHUDDoodadArgs xhudDoodadArgs = XEventPool<XHUDDoodadArgs>.GetEvent();
            xhudDoodadArgs.itemid = (int)doo.id;
            xhudDoodadArgs.count = (int)doo.count;
            xhudDoodadArgs.Firer = (XObject)p;
            XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xhudDoodadArgs);
        }

        protected void ShowStartRollNotice(XLevelDoodad doo, XEntity p, uint maxroll, uint playerroll)
        {
            string format = XStringDefineProxy.GetString("DOODAD_DEPENDING");
            ItemList.RowData itemConf = XBagDocument.GetItemConf((int)doo.id);
            string str = string.Format("[{0}]{1}[-]", (object)XSingleton<UiUtility>.singleton.GetItemQualityRGB((int)itemConf.ItemQuality), (object)XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemName));
            uint key = XSingleton<UiUtility>.singleton.ShowSystemNoticeTip(string.Format(format, (object)str));
            int num = (int)XSingleton<XTimerMgr>.singleton.SetTimer(1f, this._showRollOverNoticeCb, (object)key);
            this._NoticeDictionary.Add(key, new XSyncDoodadInfo()
            {
                doo = doo,
                owner = p,
                maxroll = maxroll,
                playerroll = playerroll
            });
        }

        protected void ShowRollOverNotice(object o)
        {
            uint num = (uint)o;
            XSyncDoodadInfo notice = this._NoticeDictionary[num];
            ItemList.RowData itemConf = XBagDocument.GetItemConf((int)notice.doo.id);
            string str = string.Format("[{0}]{1}[-]", (object)XSingleton<UiUtility>.singleton.GetItemQualityRGB((int)itemConf.ItemQuality), (object)XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemName));
            if ((int)notice.maxroll == (int)notice.playerroll)
                XSingleton<UiUtility>.singleton.EditSystemNoticeTip(string.Format(XStringDefineProxy.GetString("DOODAD_RESULT_PLAYER"), (object)str, (object)notice.maxroll), num);
            else
                XSingleton<UiUtility>.singleton.EditSystemNoticeTip(string.Format(XStringDefineProxy.GetString("DOODAD_RESULT"), (object)str, (object)notice.owner.Name, (object)notice.maxroll, (object)notice.playerroll), num);
            if (notice.doo.type != XDoodadType.Item)
                return;
            XHUDDoodadArgs xhudDoodadArgs = XEventPool<XHUDDoodadArgs>.GetEvent();
            xhudDoodadArgs.itemid = (int)notice.doo.id;
            xhudDoodadArgs.count = (int)notice.doo.count;
            xhudDoodadArgs.Firer = (XObject)notice.owner;
            XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xhudDoodadArgs);
        }

        public void Update()
        {
            XPlayer player = XSingleton<XEntityMgr>.singleton.Player;
            if (!XEntity.ValideEntity((XEntity)player))
                return;
            for (int index = 0; index < this._doodads.Count; ++index)
            {
                if ((Object)this._doodads[index].doodad != (Object)null)
                {
                    if ((Object)this._doodads[index].billboard != (Object)null)
                    {
                        Vector3 vector3 = new Vector3(this._doodads[index].doodad.transform.position.x, this._doodads[index].doodad.transform.position.y + 0.2f, this._doodads[index].doodad.transform.position.z);
                        this._doodads[index].billboard.transform.position = vector3;
                        this._doodads[index].billboard.transform.rotation = XSingleton<XScene>.singleton.GameCamera.Rotaton;
                    }
                    if (player != null && this._doodads[index].dropped && !this._doodads[index].picked && (double)Vector3.Magnitude(player.EngineObject.Position - this._doodads[index].doodad.transform.position) < 1.0)
                        this.OnDoodadPicked(this._doodads[index].wave, this._doodads[index].index);
                }
            }
        }

        public void ReceiveDoodadServerInfo(EnemyDoodadInfo info)
        {
            XEntityStatistics.RowData byId = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(info.dropperTemplateID);
            if (byId != null)
            {
                if (byId.Type == (byte)1)
                {
                    int num = (int)XSingleton<XTimerMgr>.singleton.SetTimer(0.05f, new XTimerMgr.ElapsedEventHandler(this.GenerateDoodadFromServer), (object)info);
                }
                else
                    this.GenerateDoodadFromServer((object)info);
            }
            else
                this.GenerateDoodadFromServer((object)info);
        }

        public void GenerateDoodadFromServer(object obj)
        {
            EnemyDoodadInfo enemyDoodadInfo = (EnemyDoodadInfo)obj;
            XLevelDoodad doo = new XLevelDoodad();
            doo.wave = enemyDoodadInfo.waveid;
            Vector3 pos = new Vector3(enemyDoodadInfo.pos.x, enemyDoodadInfo.pos.y, enemyDoodadInfo.pos.z);
            doo.pos = pos;
            doo.type = (XDoodadType)enemyDoodadInfo.type;
            doo.id = enemyDoodadInfo.id;
            doo.count = enemyDoodadInfo.count;
            doo.dropped = true;
            doo.picked = false;
            doo.lastPickTime = 0.0f;
            doo.index = enemyDoodadInfo.index;
            doo.token = 0U;
            doo.templateid = enemyDoodadInfo.dropperTemplateID;
            doo.roleid = enemyDoodadInfo.roleid;
            this._doodads.Add(doo);
            this.GenerateDoodad(doo, pos);
        }

        public void ExternalGenerateDoodad(
          int doodadid,
          int type,
          int waveid,
          Vector3 pos,
          uint templateid,
          uint index,
          uint count)
        {
            XLevelDoodad doo = new XLevelDoodad();
            doo.wave = waveid;
            doo.pos = pos;
            doo.type = (XDoodadType)type;
            doo.id = (uint)doodadid;
            doo.count = count;
            doo.dropped = true;
            doo.picked = false;
            doo.lastPickTime = 0.0f;
            doo.index = index;
            doo.token = 0U;
            doo.templateid = templateid;
            this._doodads.Add(doo);
            this.GenerateDoodad(doo, pos);
        }

        public void DelayGenerateDoodad(object obj)
        {
            if (XSingleton<XLevelFinishMgr>.singleton.IsCurrentLevelFinished)
                return;
            XLevelDoodad doo = (XLevelDoodad)obj;
            if (doo.token > 0U)
            {
                this._TimerToken.Contains(doo.token);
                this._TimerToken.Remove(doo.token);
            }
            this.GenerateDoodadObject(doo, doo.pos);
        }

        public List<GameObject> GetDoodadsInScene(XDoodadType type)
        {
            this._DropedDoodads.Clear();
            for (int index = 0; index < this._doodads.Count; ++index)
            {
                if (this._doodads[index].type == type && this._doodads[index].dropped && !this._doodads[index].picked)
                    this._DropedDoodads.Add(this._doodads[index].doodad);
            }
            return this._DropedDoodads;
        }

        public void PickAllDoodad()
        {
            for (int index = 0; index < this._doodads.Count; ++index)
            {
                if (this._doodads[index].dropped && !this._doodads[index].picked)
                    this.OnDoodadPicked(this._doodads[index].wave, this._doodads[index].index);
            }
        }

        public void OnReconnect() => this.OnClearDoodad();
    }
}
