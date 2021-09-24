

using KKSG;
using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
    internal class BattleIndicateHandler : DlgHandlerBase
    {
        public XUIPool m_TeamIndicatePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
        public Transform m_Direction;
        private Vector3 m_DirectPos;
        private Transform m_CachedDirectionTarget;
        private List<BattleIndicator> m_IndicatesList = new List<BattleIndicator>();
        private Dictionary<ulong, BattleIndicator> m_EntityIndicates = new Dictionary<ulong, BattleIndicator>();
        private float _Half_H_Fov;
        private float _tan_half_H_fov;
        private float _Half_V_Fov;
        private float _tan_half_V_fov;
        private float _sqr_tan_half_V_fov;
        private Transform m_MiniMapRotation;
        private IXUITexture m_MiniMap;
        private Transform m_MiniMapCamera;
        private XUIPool m_MiniMapElementPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
        private Dictionary<ulong, MiniMapElement> m_MiniMapElements = new Dictionary<ulong, MiniMapElement>();
        private List<MiniMapElement> m_MiniMapDoor = new List<MiniMapElement>();
        private List<MiniMapElement> m_MiniMapBuff = new List<MiniMapElement>();
        private Dictionary<ulong, MiniMapElement> m_MiniMapDoodadDic = new Dictionary<ulong, MiniMapElement>();
        private List<MiniMapElement> m_MiniMapFx = new List<MiniMapElement>();
        private Dictionary<ulong, MiniMapElement> m_MiniMapFxDic = new Dictionary<ulong, MiniMapElement>();
        private List<MiniMapElement> m_MiniMapPic = new List<MiniMapElement>();
        private Dictionary<ulong, MiniMapElement> m_MiniMapPicDic = new Dictionary<ulong, MiniMapElement>();
        private uint m_MiniMapFxToken = 0;
        private uint m_MiniMapPicToken = 0;
        private float MiniMapScale;
        private bool _staticMap;
        private Vector3 _referencePos;
        private Vector2 _outSize = Vector2.one;
        private int _heroBattleDepth_O;
        private int _heroBattleDepth_A;
        private static bool _hide_minimap_opponent;
        private XEntity _campEntity;
        private List<ulong> _unInitEntityList = new List<ulong>();
        private Vector2 MiniMapSize;
        private readonly float BASESIZE = 65f;
        private Vector2 MapSizeInTable;
        private int MaxDisplayNum = 0;
        private List<int> m_ShouldShowEnemyIndex = new List<int>();
        private HashSet<ulong> m_ValidSet = new HashSet<ulong>();

        protected override void Init()
        {
            base.Init();
            this._campEntity = (XEntity)XSingleton<XEntityMgr>.singleton.Player;
            if (DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded())
                this.InitTeamIndicate();
            this.MiniMapSize = new Vector2(this.BASESIZE, this.BASESIZE);
            this._staticMap = XSingleton<XSceneMgr>.singleton.GetSceneStaticMiniMapCenter(XSingleton<XScene>.singleton.SceneID, out this._referencePos);
            this._outSize = Vector2.one;
            this.SetMiniMapSize(XSingleton<XSceneMgr>.singleton.GetSceneMiniMapOutSize(XSingleton<XScene>.singleton.SceneID));
            this.InitMiniMap();
            this._heroBattleDepth_O = 200;
            this._heroBattleDepth_A = 100;
            this.MaxDisplayNum = XSingleton<XGlobalConfig>.singleton.GetInt("MaxEnmeyIndicatorDisplayNum");
        }

        public void SetMiniMapSize(Vector2 size, float scale = 0.0f)
        {
            if (size != this._outSize)
            {
                this.SetMiniMapOutSize(Vector2.one);
                this.SetMiniMapOutSize(size);
            }
            if ((double)scale <= 0.0)
                return;
            this.MiniMapScale = scale;
        }

        private void SetMiniMapOutSize(Vector2 size)
        {
            Vector2 outSize = this._outSize;
            this._outSize = size;
            this.MiniMapSize = new Vector2(this.BASESIZE * this._outSize.x, this.BASESIZE * this._outSize.y);
            IXUISprite component1 = this.PanelObject.transform.FindChild("Bg/MapBg").GetComponent("XUISprite") as IXUISprite;
            component1.spriteWidth = (int)((double)component1.spriteWidth / (double)outSize.x * (double)this._outSize.x);
            component1.spriteHeight = (int)((double)component1.spriteHeight / (double)outSize.y * (double)this._outSize.y);
            IXUIPanel component2 = this.PanelObject.transform.FindChild("MiniMap").GetComponent("XUIPanel") as IXUIPanel;
            Vector4 clipRange = component2.ClipRange;
            float z = clipRange.z;
            clipRange.z = clipRange.z / outSize.x * this._outSize.x;
            clipRange.x = (float)(-((double)clipRange.z - (double)z) / 2.0);
            float w = clipRange.w;
            clipRange.w = clipRange.w / outSize.y * this._outSize.y;
            clipRange.y = (float)(-((double)clipRange.w - (double)w) / 2.0);
            component2.ClipRange = clipRange;
            IXUISprite component3 = this.PanelObject.transform.FindChild("MiniMap/Bg").GetComponent("XUISprite") as IXUISprite;
            Vector3 localPosition1 = component3.transform.localPosition;
            float spriteWidth1 = (float)component3.spriteWidth;
            component3.spriteWidth = (int)((double)component3.spriteWidth / (double)outSize.x * (double)this._outSize.x);
            localPosition1.x = (float)(-((double)component3.spriteWidth - (double)spriteWidth1) / 2.0);
            float spriteHeight = (float)component3.spriteHeight;
            component3.spriteHeight = (int)((double)component3.spriteHeight / (double)outSize.y * (double)this._outSize.y);
            localPosition1.y = (float)(-((double)component3.spriteHeight - (double)spriteHeight) / 2.0);
            component3.transform.localPosition = localPosition1;
            IXUISprite component4 = this.PanelObject.transform.FindChild("Bg/NameBg").GetComponent("XUISprite") as IXUISprite;
            float spriteWidth2 = (float)component4.spriteWidth;
            component4.spriteWidth = (int)((double)component4.spriteWidth / (double)outSize.x * (double)this._outSize.x);
            Vector3 localPosition2 = component4.transform.localPosition;
            component4.transform.localPosition = new Vector3((float)(-((double)component4.spriteWidth - (double)spriteWidth2) / 2.0), localPosition2.y);
            IXUILabel component5 = this.PanelObject.transform.FindChild("Bg/Name").GetComponent("XUILabel") as IXUILabel;
            float spriteWidth3 = (float)component5.spriteWidth;
            component5.spriteWidth = (int)((double)component5.spriteWidth / (double)outSize.x * (double)this._outSize.x);
            Vector3 localPosition3 = component5.gameObject.transform.localPosition;
            component5.gameObject.transform.localPosition = new Vector3((float)(-((double)component5.spriteWidth - (double)spriteWidth3) / 2.0), localPosition3.y);
        }

        public override void OnUnload()
        {
            foreach (MiniMapElement miniMapElement in this.m_MiniMapElements.Values)
                this.DestroyFx(miniMapElement.notice);
            foreach (MiniMapElement miniMapElement in this.m_MiniMapDoodadDic.Values)
                this.DestroyFx(miniMapElement.notice);
            foreach (MiniMapElement miniMapElement in this.m_MiniMapFxDic.Values)
                this.DestroyFx(miniMapElement.notice);
            foreach (MiniMapElement miniMapElement in this.m_MiniMapPicDic.Values)
                this.DestroyFx(miniMapElement.notice);
            this.m_MiniMapDoor.Clear();
            this.m_MiniMapElements.Clear();
            this.m_MiniMapBuff.Clear();
            this.m_MiniMapDoodadDic.Clear();
            this.m_MiniMapFx.Clear();
            this.m_MiniMapPic.Clear();
            this.m_MiniMapFxDic.Clear();
            this.m_MiniMapPicDic.Clear();
            this.m_MiniMapElementPool.ReturnAll();
            this.m_MiniMap.SetTexturePath("");
            base.OnUnload();
        }

        private void InitTeamIndicate()
        {
            this._Half_V_Fov = (float)(Math.PI / 180.0 * ((double)XSingleton<XScene>.singleton.GameCamera.UnityCamera.fieldOfView * 0.5));
            float num = (float)XSingleton<XGameUI>.singleton.Base_UI_Width / (float)XSingleton<XGameUI>.singleton.Base_UI_Height;
            this._Half_H_Fov = (float)Math.Atan(Math.Tan((double)this._Half_V_Fov) * (double)num) * 0.95f;
            this._tan_half_H_fov = (float)Math.Tan((double)this._Half_H_Fov);
            this._tan_half_V_fov = (float)Math.Tan((double)this._Half_V_Fov);
            this._sqr_tan_half_V_fov = this._tan_half_V_fov * this._tan_half_V_fov;
            Transform child = this.PanelObject.transform.FindChild("EnemyIndicate");
            this.m_TeamIndicatePool.SetupPool(child.parent.gameObject, child.gameObject, 10U);
            this.m_Direction = this.PanelObject.transform.FindChild("Direction");
            this.m_DirectPos = this.m_Direction.localPosition;
            this.m_Direction.gameObject.transform.localPosition = XGameUI.Far_Far_Away;
            this.m_EntityIndicates.Clear();
            this.m_IndicatesList.Clear();
            this.m_TeamIndicatePool.ReturnAll();
        }

        private void InitMiniMap()
        {
            this.m_MiniMapCamera = this.PanelObject.transform.Find("MiniMap/Bg/Rotation/Camera");
            this.m_MiniMapCamera.gameObject.SetActive(!this._staticMap);
            Transform child = this.PanelObject.transform.FindChild("MiniMap/Bg/Rotation/Element");
            this.m_MiniMapElementPool.SetupPool(child.parent.gameObject, child.gameObject, 20U);
            this.m_MiniMapRotation = this.PanelObject.transform.FindChild("MiniMap/Bg/Rotation");
            this.m_MiniMap = this.PanelObject.transform.FindChild("MiniMap/Bg/Rotation/Map").GetComponent("XUITexture") as IXUITexture;
            this.MiniMapScale = (float)XSingleton<XGlobalConfig>.singleton.GetInt("MiniMapScale") / 10f;
            this.MiniMapInit();
        }

        private void MiniMapInit()
        {
            this.m_MiniMapDoor.Clear();
            this.m_MiniMapElements.Clear();
            this.m_MiniMapBuff.Clear();
            this.m_MiniMapDoodadDic.Clear();
            this.m_MiniMapFx.Clear();
            this.m_MiniMapPic.Clear();
            this.m_MiniMapFxDic.Clear();
            this.m_MiniMapPicDic.Clear();
            this.m_MiniMapElementPool.ReturnAll();
            this.MiniMapAdd((XEntity)XSingleton<XEntityMgr>.singleton.Player);
            uint sceneId = XSingleton<XScene>.singleton.SceneID;
            string sceneMiniMap = XSingleton<XSceneMgr>.singleton.GetSceneMiniMap(sceneId);
            if (!string.IsNullOrEmpty(sceneMiniMap))
                this.m_MiniMap.SetTexturePath("atlas/UI/Battle/minimap/" + sceneMiniMap);
            short[] sceneMiniMapSize = XSingleton<XSceneMgr>.singleton.GetSceneMiniMapSize(sceneId);
            if (sceneMiniMapSize != null)
            {
                if (sceneMiniMapSize.Length > 2)
                    this.MiniMapScale = (float)sceneMiniMapSize[2] / 10f;
                this.MapSizeInTable = new Vector2((float)sceneMiniMapSize[0], (float)sceneMiniMapSize[1]);
                this.m_MiniMap.spriteWidth = (int)((double)this.MapSizeInTable.x * (double)this.MiniMapScale);
                this.m_MiniMap.spriteHeight = (int)((double)this.MapSizeInTable.y * (double)this.MiniMapScale);
            }
            this.m_MiniMapRotation.transform.eulerAngles = new Vector3(0.0f, 0.0f, (float)XSingleton<XSceneMgr>.singleton.GetSceneMiniMapRotation(sceneId));
            BattleIndicateHandler._hide_minimap_opponent = false;
        }

        public void SetMiniMapRotation(float rotation)
        {
            if (XSingleton<XSceneMgr>.singleton.GetSceneMiniMapRotation(XSingleton<XScene>.singleton.SceneID) >= 0 || !((UnityEngine.Object)this.m_MiniMapRotation != (UnityEngine.Object)null))
                return;
            this.m_MiniMapRotation.transform.eulerAngles = new Vector3(0.0f, 0.0f, rotation);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            if (XSingleton<XEntityMgr>.singleton.Player == null)
                return;
            if (!this._staticMap)
                this._referencePos = XSingleton<XEntityMgr>.singleton.Player.EngineObject.Position;
            if (DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded())
            {
                this.m_ValidSet.Clear();
                this.UpdateTeamIndicate();
                this.UpdateEnemyIndicate();
                this.UpdateDirection();
                if (this.m_IndicatesList.Count != this.m_ValidSet.Count)
                {
                    for (int index = this.m_IndicatesList.Count - 1; index >= 0; --index)
                    {
                        if (!this.m_ValidSet.Contains(this.m_IndicatesList[index].id))
                        {
                            BattleIndicator indicates = this.m_IndicatesList[index];
                            this.m_TeamIndicatePool.ReturnInstance(indicates.sp.gameObject);
                            this.m_EntityIndicates.Remove(indicates.id);
                            this.m_IndicatesList.RemoveAt(index);
                        }
                    }
                }
            }
            this.UpdateMiniMap();
        }

        private void UpdateMiniMap()
        {
            if (this._campEntity == null)
                return;
            this.m_MiniMap.spriteWidth = (int)((double)this.MapSizeInTable.x * (double)this.MiniMapScale);
            this.m_MiniMap.spriteHeight = (int)((double)this.MapSizeInTable.y * (double)this.MiniMapScale);
            MiniMapElement element;
            if (this.m_MiniMapElements.TryGetValue(this._campEntity.ID, out element))
            {
                this.SetupMiniMapElement(this._campEntity, element);
                this.m_MiniMap.gameObject.transform.localPosition = new Vector3(-this._referencePos.x, -this._referencePos.z) * this.MiniMapScale;
            }
            if (!this._staticMap && (UnityEngine.Object)this.m_MiniMapCamera != (UnityEngine.Object)null && (UnityEngine.Object)XSingleton<XScene>.singleton.GameCamera.UnityCamera != (UnityEngine.Object)null)
                this.m_MiniMapCamera.localEulerAngles = new Vector3(0.0f, 0.0f, -XSingleton<XScene>.singleton.GameCamera.UnityCamera.transform.eulerAngles.y);
            List<XEntity> opponent = XSingleton<XEntityMgr>.singleton.GetOpponent(this._campEntity);
            for (int index = 0; index < opponent.Count; ++index)
            {
                if (this.m_MiniMapElements.TryGetValue(opponent[index].ID, out element))
                    this.SetupMiniMapElement(opponent[index], element, BattleIndicateHandler._hide_minimap_opponent || !opponent[index].IsVisible);
            }
            List<XEntity> ally = XSingleton<XEntityMgr>.singleton.GetAlly(this._campEntity);
            for (int index = 0; index < ally.Count; ++index)
            {
                if (this.m_MiniMapElements.TryGetValue(ally[index].ID, out element))
                    this.SetupMiniMapElement(ally[index], element);
            }
            for (int index = 0; index < this.m_MiniMapDoor.Count; ++index)
                this.SetupMiniMapStatic(this.m_MiniMapDoor[index]);
            for (int index = 0; index < this.m_MiniMapBuff.Count; ++index)
                this.SetupMiniMapStatic(this.m_MiniMapBuff[index]);
            for (int index = 0; index < this.m_MiniMapFx.Count; ++index)
                this.SetupMiniMapFxStatic(this.m_MiniMapFx[index]);
            for (int index = 0; index < this.m_MiniMapPic.Count; ++index)
                this.SetupMiniMapFxStatic(this.m_MiniMapPic[index]);
        }

        private void SetupMiniMapElement(XEntity entity, MiniMapElement element, bool hide = false)
        {
            if (entity.Deprecated)
            {
                this.m_MiniMapElements.Remove(entity.ID);
                this.DestroyFx(element.notice);
                element.notice = (XFx)null;
                this.m_MiniMapElementPool.ReturnInstance(element.sp.gameObject);
            }
            else
            {
                Vector3 position = entity.EngineObject.Position;
                float x1 = position.x - this._referencePos.x;
                float y1 = position.z - this._referencePos.z;
                element.transform.localPosition = new Vector3(x1, y1) * this.MiniMapScale;
                element.transform.parent = element.transform.parent.parent;
                float x2 = (double)element.transform.localPosition.x <= (double)this.MiniMapSize.x ? ((double)element.transform.localPosition.x >= -(double)this.MiniMapSize.x ? element.transform.localPosition.x : -this.MiniMapSize.x) : this.MiniMapSize.x;
                float y2 = (double)element.transform.localPosition.y <= (double)this.MiniMapSize.y ? ((double)element.transform.localPosition.y >= -(double)this.MiniMapSize.y ? element.transform.localPosition.y : -this.MiniMapSize.y) : this.MiniMapSize.y;
                element.transform.localPosition = new Vector3(x2, y2);
                element.transform.parent = this.m_MiniMapRotation;
                element.sp.transform.localEulerAngles = -this.m_MiniMapRotation.transform.eulerAngles;
                float alpha = 1f;
                if (!entity.IsPlayer && entity.IsDead)
                    alpha = 0.0f;
                if (hide)
                    alpha = 0.0f;
                element.sp.SetAlpha(alpha);
            }
        }

        private void SetupMiniMapStatic(MiniMapElement element)
        {
            element.sp.transform.localPosition = new Vector3(element.transform.position.x - this._referencePos.x, element.transform.position.z - this._referencePos.z) * this.MiniMapScale;
            element.sp.transform.localEulerAngles = -this.m_MiniMapRotation.transform.eulerAngles;
        }

        private void SetupMiniMapFxStatic(MiniMapElement element) => element.sp.transform.localPosition = new Vector3(element.pos.x - this._referencePos.x, element.pos.z - this._referencePos.z) * this.MiniMapScale;

        private void SetupMiniMapPicStatic(MiniMapElement element) => element.sp.transform.localPosition = new Vector3(element.pos.x - this._referencePos.x, element.pos.z - this._referencePos.z) * this.MiniMapScale;

        public void DelTeamIndicate(ulong uid)
        {
            BattleIndicator battleIndicator;
            if (!this.m_EntityIndicates.TryGetValue(uid, out battleIndicator))
                return;
            this.m_TeamIndicatePool.ReturnInstance(battleIndicator.sp.gameObject);
            this.m_EntityIndicates.Remove(uid);
            this.m_IndicatesList.Remove(battleIndicator);
        }

        protected void UpdateTeamIndicate()
        {
            if (XSingleton<XScene>.singleton.SceneData == null || XSingleton<XScene>.singleton.SceneData.HideTeamIndicate)
                return;
            List<XEntity> ally = XSingleton<XEntityMgr>.singleton.GetAlly(this._campEntity);
            for (int index = 0; index < ally.Count; ++index)
            {
                if (ally[index] != XSingleton<XEntityMgr>.singleton.Player && ally[index].IsRole)
                {
                    BattleIndicator bi;
                    if (!this.m_EntityIndicates.TryGetValue(ally[index].ID, out bi))
                        this.CreateEntityIndicate(out bi, ally[index], true);
                    if (XEntity.ValideEntity(ally[index]))
                    {
                        this.m_ValidSet.Add(ally[index].ID);
                        this.ShowIndicatePosition(bi, ally[index], true);
                    }
                }
            }
        }

        protected void UpdateEnemyIndicate()
        {
            List<XEntity> opponent = XSingleton<XEntityMgr>.singleton.GetOpponent(this._campEntity);
            this.m_ShouldShowEnemyIndex.Clear();
            for (int index = 0; index < opponent.Count; ++index)
            {
                if (opponent[index].IsEnemy && !opponent[index].IsPuppet && (!XSingleton<XGame>.singleton.SyncMode || opponent[index].IsServerFighting) && (XSingleton<XGame>.singleton.SyncMode || opponent[index].IsFighting))
                    this.m_ShouldShowEnemyIndex.Add(index);
            }
            if (this.m_ShouldShowEnemyIndex.Count > this.MaxDisplayNum)
            {
                for (int index = 0; index < this.m_ShouldShowEnemyIndex.Count; ++index)
                {
                    BattleIndicator battleIndicator;
                    if (this.m_EntityIndicates.TryGetValue(opponent[this.m_ShouldShowEnemyIndex[index]].ID, out battleIndicator))
                    {
                        this.m_TeamIndicatePool.ReturnInstance(battleIndicator.sp.gameObject);
                        this.m_EntityIndicates.Remove(opponent[this.m_ShouldShowEnemyIndex[index]].ID);
                    }
                }
            }
            else
            {
                for (int index1 = 0; index1 < this.m_ShouldShowEnemyIndex.Count; ++index1)
                {
                    int index2 = this.m_ShouldShowEnemyIndex[index1];
                    bool flag1 = XEntity.ValideEntity(opponent[index2]);
                    bool flag2 = !flag1;
                    BattleIndicator bi;
                    if (!this.m_EntityIndicates.TryGetValue(opponent[index2].ID, out bi))
                    {
                        if (!flag2)
                            this.CreateEntityIndicate(out bi, opponent[index2], false);
                        else
                            flag2 = false;
                    }
                    if (!flag2 && flag1)
                    {
                        this.ShowIndicatePosition(bi, opponent[index2], false);
                        this.m_ValidSet.Add(opponent[index2].ID);
                    }
                }
            }
        }

        protected void CreateEntityIndicate(out BattleIndicator bi, XEntity e, bool IsTeamMember)
        {
            GameObject gameObject = this.m_TeamIndicatePool.FetchGameObject();
            IXUISprite component = gameObject.GetComponent("XUISprite") as IXUISprite;
            bi = new BattleIndicator();
            bi.id = e.ID;
            bi.go = gameObject;
            bi.sp = component;
            bi.arrow = bi.go.transform.FindChild("arrow");
            bi.leader = bi.go.transform.FindChild("leader").GetComponent("XUISprite") as IXUISprite;
            bi.xGameObject = e.EngineObject;
            this.m_EntityIndicates.Add(e.ID, bi);
            this.m_IndicatesList.Add(bi);
            if (IsTeamMember)
            {
                string teamIndicateAvatar = XSingleton<XProfessionSkillMgr>.singleton.GetTeamIndicateAvatar(e.TypeID % 10U);
                component.SetSprite(teamIndicateAvatar);
            }
            else
                component.SetSprite("monster_00");
            if (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_PVP)
            {
                XBattleCaptainPVPDocument specificDocument = XDocuments.GetSpecificDocument<XBattleCaptainPVPDocument>(XBattleCaptainPVPDocument.uuID);
                bool flag = (long)e.ID == (long)specificDocument.MyPosition(false);
                bi.leader.SetAlpha(flag ? 1f : 0.0f);
            }
            else
                bi.leader.SetAlpha(0.0f);
        }

        protected void ShowIndicatePosition(BattleIndicator bi, XEntity e, bool IsTeamMember)
        {
            if (bi.xGameObject == null || XSingleton<XCutScene>.singleton.IsPlaying)
            {
                bi.sp.gameObject.transform.localPosition = Vector3.one * (float)XGameUI._far_far_away;
            }
            else
            {
                Vector3 position1 = e.EngineObject.Position;
                Camera unityCamera = XSingleton<XScene>.singleton.GameCamera.UnityCamera;
                Vector3 vector3_1 = XSingleton<XEntityMgr>.singleton.Player.EngineObject.Position - position1;
                if (bi.xGameObject.IsVisible)
                {
                    if (IsTeamMember)
                    {
                        float num1 = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("TeamIndicateDistance"));
                        if ((double)vector3_1.sqrMagnitude < (double)num1 * (double)num1)
                        {
                            bi.sp.gameObject.transform.localPosition = Vector3.one * (float)XGameUI._far_far_away;
                        }
                        else
                        {
                            float num2 = e.Height + 0.6f;
                            Vector3 position2 = new Vector3(position1.x, position1.y + num2, position1.z);
                            Vector3 viewportPoint = unityCamera.WorldToViewportPoint(position2);
                            bi.sp.SetAlpha(1f);
                            bi.sp.gameObject.transform.position = XSingleton<XGameUI>.singleton.UICamera.ViewportToWorldPoint(viewportPoint);
                            Vector3 localPosition = bi.sp.gameObject.transform.localPosition;
                            localPosition.x = (float)Mathf.FloorToInt(localPosition.x);
                            localPosition.y = (float)Mathf.FloorToInt(localPosition.y);
                            localPosition.z = 0.0f;
                            bi.sp.gameObject.transform.localPosition = localPosition;
                        }
                    }
                    else
                        bi.sp.SetAlpha(0.0f);
                }
                else
                {
                    int num3 = XSingleton<XGameUI>.singleton.Base_UI_Width / 2;
                    int num4 = XSingleton<XGameUI>.singleton.Base_UI_Height / 2;
                    Vector3 normalized1 = unityCamera.transform.forward.normalized;
                    Vector3 normalized2 = unityCamera.transform.right.normalized;
                    Vector3 rhs1 = position1 - unityCamera.transform.position;
                    Vector3 rhs2 = position1 - normalized2 * Vector3.Dot(normalized2, rhs1) - unityCamera.transform.position;
                    Vector3 vector3_2 = normalized1 * Vector3.Dot(normalized1, rhs2);
                    Vector3 lhs = rhs2 - vector3_2;
                    float num5 = lhs.sqrMagnitude / vector3_2.sqrMagnitude;
                    if ((double)Vector3.Dot(lhs, unityCamera.transform.up) > 0.0 || (double)num5 < (double)this._sqr_tan_half_V_fov)
                    {
                        vector3_1.Set(vector3_1.x, 0.0f, vector3_1.z);
                        Vector3 vector3_3 = new Vector3(unityCamera.transform.forward.x, 0.0f, unityCamera.transform.forward.z);
                        float num6 = (float)Math.PI / 180f * Vector3.Angle(vector3_1, vector3_3);
                        if (!XSingleton<XCommon>.singleton.Clockwise(vector3_1, vector3_3))
                            num6 = -num6;
                        float num7 = (float)(Math.Tan((double)num6) / (double)this._tan_half_H_fov * (double)XSingleton<XGameUI>.singleton.Base_UI_Width * 0.5);
                        if ((double)num6 >= (double)this._Half_H_Fov)
                        {
                            float num8 = Mathf.Clamp((num7 - (float)num3) * (float)num4 / num7, 0.0f, (float)XSingleton<XGameUI>.singleton.Base_UI_Height);
                            bi.go.transform.localPosition = new Vector3((float)(num3 - this.m_TeamIndicatePool.TplWidth / 2), (float)-num4 + num8, 0.0f);
                            bi.arrow.transform.localRotation = Quaternion.identity;
                            bi.arrow.transform.Rotate(0.0f, 0.0f, 90f);
                            if ((double)num8 < 260.0)
                                bi.sp.SetAlpha(0.5f);
                            else
                                bi.sp.SetAlpha(1f);
                        }
                        else
                        {
                            float num9 = Mathf.Clamp((float)((double)(-num7 - (float)num3) * (double)num4 / -(double)num7), (float)(this.m_TeamIndicatePool.TplHeight / 2), (float)(XSingleton<XGameUI>.singleton.Base_UI_Height - this.m_TeamIndicatePool.TplHeight / 2));
                            bi.go.transform.localPosition = new Vector3((float)(-num3 + this.m_TeamIndicatePool.TplWidth / 2), (float)-num4 + num9, 0.0f);
                            bi.arrow.transform.localRotation = Quaternion.identity;
                            bi.arrow.transform.Rotate(0.0f, 0.0f, -90f);
                            bi.sp.SetAlpha(1f);
                        }
                    }
                    else
                    {
                        vector3_1.Set(vector3_1.x, 0.0f, vector3_1.z);
                        Vector3 vector3_4 = new Vector3(unityCamera.transform.forward.x, 0.0f, unityCamera.transform.forward.z);
                        float num10 = (float)Math.PI / 180f * Vector3.Angle(vector3_1, vector3_4);
                        if (!XSingleton<XCommon>.singleton.Clockwise(vector3_1, vector3_4))
                            num10 = -num10;
                        float num11 = (float)(Math.Tan((double)num10) / (double)this._tan_half_H_fov * (double)XSingleton<XGameUI>.singleton.Base_UI_Width * 0.5);
                        if ((double)num10 <= (double)this._Half_H_Fov && (double)num10 >= -(double)this._Half_H_Fov)
                        {
                            float x = Mathf.Clamp(num11, (float)(-num3 + this.m_TeamIndicatePool.TplWidth / 2), (float)(num3 - this.m_TeamIndicatePool.TplWidth / 2));
                            bi.go.transform.localPosition = new Vector3(x, (float)(-num4 + this.m_TeamIndicatePool.TplHeight / 2), 0.0f);
                            bi.arrow.transform.localRotation = Quaternion.identity;
                            if ((double)x > 165.0)
                                bi.sp.SetAlpha(0.5f);
                            else
                                bi.sp.SetAlpha(1f);
                        }
                        else if ((double)num10 > (double)this._Half_H_Fov)
                        {
                            float num12 = Mathf.Clamp((num11 - (float)num3) * (float)num4 / num11, 0.0f, (float)XSingleton<XGameUI>.singleton.Base_UI_Height);
                            bi.go.transform.localPosition = new Vector3((float)(num3 - this.m_TeamIndicatePool.TplWidth / 2), (float)-num4 + num12, 0.0f);
                            bi.arrow.transform.localRotation = Quaternion.identity;
                            bi.arrow.transform.Rotate(0.0f, 0.0f, 90f);
                            if ((double)num12 < 260.0)
                                bi.sp.SetAlpha(0.5f);
                            else
                                bi.sp.SetAlpha(1f);
                        }
                        else if ((double)num10 < (double)this._Half_H_Fov)
                        {
                            float num13 = Mathf.Clamp((float)((double)(-num11 - (float)num3) * (double)num4 / -(double)num11), (float)(this.m_TeamIndicatePool.TplHeight / 2), (float)(XSingleton<XGameUI>.singleton.Base_UI_Height - this.m_TeamIndicatePool.TplHeight / 2));
                            bi.go.transform.localPosition = new Vector3((float)(-num3 + this.m_TeamIndicatePool.TplWidth / 2), (float)-num4 + num13, 0.0f);
                            bi.arrow.transform.localRotation = Quaternion.identity;
                            bi.arrow.transform.Rotate(0.0f, 0.0f, -90f);
                            bi.sp.SetAlpha(1f);
                        }
                    }
                }
            }
        }

        private bool DealWithSpectatorWatchToNull(XEntity e)
        {
            if (!XSingleton<XScene>.singleton.bSpectator)
                return false;
            if (XSingleton<XEntityMgr>.singleton.Player.WatchTo == null)
            {
                this._unInitEntityList.Add(e.ID);
                return true;
            }
            if ((long)e.ID == (long)XSingleton<XEntityMgr>.singleton.Player.WatchTo.ID && (uint)this._unInitEntityList.Count > 0U)
            {
                this._campEntity = (XEntity)XSingleton<XEntityMgr>.singleton.Player.WatchTo;
                for (int index = 0; index < this._unInitEntityList.Count; ++index)
                {
                    if ((long)this._unInitEntityList[index] != (long)XSingleton<XEntityMgr>.singleton.Player.WatchTo.ID)
                    {
                        XEntity entityConsiderDeath = XSingleton<XEntityMgr>.singleton.GetEntityConsiderDeath(this._unInitEntityList[index]);
                        if (entityConsiderDeath != null)
                            this.MiniMapAdd(entityConsiderDeath);
                    }
                }
                this._unInitEntityList.Clear();
            }
            return false;
        }

        public void MiniMapAdd(XEntity e)
        {
            if (e == null || e.Attributes == null)
                return;
            XEntityStatistics.RowData byId = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(e.Attributes.TypeID);
            if (byId != null && byId.HideInMiniMap || this.DealWithSpectatorWatchToNull(e) || XSingleton<XEntityMgr>.singleton.IsNeutral(e) || e.IsPuppet || e.IsSubstance)
                return;
            if (!this.m_MiniMapElements.ContainsKey(e.ID))
            {
                GameObject gameObject1 = this.m_MiniMapElementPool.FetchGameObject();
                GameObject gameObject2 = gameObject1.transform.Find("Circle").gameObject;
                if ((UnityEngine.Object)gameObject2 != (UnityEngine.Object)null)
                    gameObject2.SetActive(false);
                IXUISprite component = gameObject1.GetComponent("XUISprite") as IXUISprite;
                MiniMapElement element = new MiniMapElement();
                element.notice = (XFx)null;
                element.sp = component;
                component.SetAlpha(1f);
                if (e.IsPlayer)
                {
                    element.sp.SetSprite("smap_1");
                    element.sp.MakePixelPerfect();
                    element.sp.spriteDepth = 35;
                    gameObject1.name = "Player";
                }
                else if (this.SpecialIsOpponent(this._campEntity, e))
                {
                    if (e.IsBoss)
                    {
                        element.sp.SetSprite("smap_2");
                        element.sp.MakePixelPerfect();
                        element.sp.spriteDepth = 32;
                        gameObject1.name = "Boss";
                    }
                    else if (e.IsElite)
                    {
                        element.sp.SetSprite("smap_3");
                        element.sp.MakePixelPerfect();
                        element.sp.spriteDepth = 31;
                        gameObject1.name = "Elite";
                    }
                    else
                    {
                        element.sp.SetSprite("smap_6");
                        element.sp.MakePixelPerfect();
                        element.sp.spriteDepth = 30;
                        gameObject1.name = "Enemy";
                    }
                }
                else if (this.SpecialIsAlly(this._campEntity, e))
                {
                    if (e.IsNpc)
                    {
                        element.sp.SetSprite("smap_5");
                        element.sp.MakePixelPerfect();
                        element.sp.spriteDepth = 33;
                        gameObject1.name = "Npc";
                    }
                    else
                    {
                        element.sp.SetSprite("smap_4");
                        element.sp.MakePixelPerfect();
                        element.sp.spriteDepth = 34;
                        gameObject1.name = "Ally";
                    }
                }
                else
                {
                    element.sp.SetSprite("none");
                    element.sp.SetAlpha(0.0f);
                }
                element.transform = gameObject1.transform;
                this.m_MiniMapElements.Add(e.ID, element);
                this.SetupMiniMapElement(e, element);
            }
            this.RefreshOnMoba(e);
            this.RefreshOnHero(e);
        }

        public bool SetMiniMapElement(ulong id, string spriteName, int width = -1, int height = -1)
        {
            MiniMapElement miniMapElement;
            if (!this.m_MiniMapElements.TryGetValue(id, out miniMapElement))
                return false;
            miniMapElement.sp.SetSprite(spriteName);
            if (width == -1 && height == -1)
            {
                miniMapElement.sp.MakePixelPerfect();
            }
            else
            {
                miniMapElement.sp.spriteWidth = width;
                miniMapElement.sp.spriteHeight = height;
            }
            return true;
        }

        public void RefreshOnMoba(XEntity e)
        {
            if (XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_MOBA || e.Attributes == null || XSingleton<XAttributeMgr>.singleton.XPlayerData == null || !e.IsRole)
                return;
            XMobaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XMobaBattleDocument>(XMobaBattleDocument.uuID);
            MobaMemberData mobaMemberData;
            if (specificDocument.MyData == null || !specificDocument.MobaData.TryGetValue(e.ID, out mobaMemberData) || mobaMemberData.heroID == 0U)
                return;
            this.SetHeroMiniMapElement(e.ID, mobaMemberData.heroID, (int)specificDocument.MyData.teamID == (int)mobaMemberData.teamID, true);
        }

        public void RefreshOnHero(XEntity e)
        {
            if (XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_HEROBATTLE || e.Attributes == null || XSingleton<XAttributeMgr>.singleton.XPlayerData == null || !e.IsRole)
                return;
            XHeroBattleDocument specificDocument = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
            uint heroID = 0;
            if (!specificDocument.heroIDIndex.TryGetValue(e.ID, out heroID) || heroID == 0U)
                return;
            this.SetHeroMiniMapElement(e.ID, heroID, XSingleton<XEntityMgr>.singleton.IsAlly(e), true);
        }

        public void SetHeroMiniMapElement(ulong id, uint heroID, bool isMyTeam, bool force = false)
        {
            MiniMapElement miniMapElement;
            if (heroID == 0U || !this.m_MiniMapElements.TryGetValue(id, out miniMapElement) || !force && (int)miniMapElement.heroID == (int)heroID)
                return;
            XSingleton<XDebug>.singleton.AddGreenLog("SetMiniMap hero ele, uid = ", id.ToString(), ", heroID = ", heroID.ToString());
            miniMapElement.heroID = heroID;
            OverWatchTable.RowData byHeroId = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID).OverWatchReader.GetByHeroID(heroID);
            miniMapElement.sp.SetSprite(byHeroId.MiniMapIcon, "Battle/battledlg2");
            miniMapElement.sp.MakePixelPerfect();
            miniMapElement.sp.spriteDepth = !isMyTeam ? this._heroBattleDepth_O++ : this._heroBattleDepth_A++;
            if ((long)id == (long)XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID)
                miniMapElement.sp.spriteDepth = 300;
            Transform transform = miniMapElement.sp.gameObject.transform.Find("Circle");
            if ((UnityEngine.Object)transform != (UnityEngine.Object)null && transform.GetComponent("XUISprite") is IXUISprite component)
            {
                component.SetVisible(true);
                component.SetSprite(isMyTeam ? "smhead_o" : "smhead_e");
                component.spriteDepth = !isMyTeam ? this._heroBattleDepth_O++ : this._heroBattleDepth_A++;
                if ((long)id == (long)XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID)
                    component.spriteDepth = 301;
            }
        }

        public void ResetMiniMapAllElement()
        {
            List<XEntity> all = XSingleton<XEntityMgr>.singleton.GetAll();
            for (int index = 0; index < all.Count; ++index)
                this.ResetMiniMapElement(all[index].ID);
        }

        public bool ResetMiniMapElement(ulong id)
        {
            MiniMapElement miniMapElement;
            if (!this.m_MiniMapElements.TryGetValue(id, out miniMapElement))
                return false;
            XEntity entityConsiderDeath = XSingleton<XEntityMgr>.singleton.GetEntityConsiderDeath(id);
            if (entityConsiderDeath == null)
                return false;
            miniMapElement.sp.SetAlpha(1f);
            if (entityConsiderDeath.IsPlayer)
            {
                miniMapElement.sp.SetSprite("smap_1");
                miniMapElement.sp.MakePixelPerfect();
                miniMapElement.sp.spriteDepth = 35;
            }
            else if (this.SpecialIsOpponent(this._campEntity, entityConsiderDeath))
            {
                if (entityConsiderDeath.IsBoss)
                {
                    miniMapElement.sp.SetSprite("smap_2");
                    miniMapElement.sp.MakePixelPerfect();
                    miniMapElement.sp.spriteDepth = 32;
                }
                else if (entityConsiderDeath.IsElite)
                {
                    miniMapElement.sp.SetSprite("smap_3");
                    miniMapElement.sp.MakePixelPerfect();
                    miniMapElement.sp.spriteDepth = 31;
                }
                else
                {
                    miniMapElement.sp.SetSprite("smap_6");
                    miniMapElement.sp.MakePixelPerfect();
                    miniMapElement.sp.spriteDepth = 30;
                }
            }
            else if (this.SpecialIsAlly(this._campEntity, entityConsiderDeath))
            {
                if (entityConsiderDeath.IsNpc)
                {
                    miniMapElement.sp.SetSprite("smap_5");
                    miniMapElement.sp.MakePixelPerfect();
                    miniMapElement.sp.spriteDepth = 33;
                }
                else
                {
                    miniMapElement.sp.SetSprite("smap_4");
                    miniMapElement.sp.MakePixelPerfect();
                    miniMapElement.sp.spriteDepth = 34;
                }
            }
            else
            {
                XSingleton<XDebug>.singleton.AddGreenLog("null");
                miniMapElement.sp.SetAlpha(0.0f);
            }
            this.RefreshOnMoba(entityConsiderDeath);
            this.RefreshOnHero(entityConsiderDeath);
            return true;
        }

        private bool SpecialIsOpponent(XEntity e1, XEntity e2)
        {
            if (!XSingleton<XScene>.singleton.bSpectator || !XSingleton<XSceneMgr>.singleton.IsPVPScene() || !e2.IsRole)
                return XSingleton<XEntityMgr>.singleton.IsOpponent(e1, e2);
            bool isBlueTeam;
            return XDocuments.GetSpecificDocument<XSpectateSceneDocument>(XSpectateSceneDocument.uuID).TryGetEntityIsBlueTeam(e2, out isBlueTeam) && !isBlueTeam;
        }

        private bool SpecialIsAlly(XEntity e1, XEntity e2)
        {
            if (!XSingleton<XScene>.singleton.bSpectator || !XSingleton<XSceneMgr>.singleton.IsPVPScene() || !e2.IsRole)
                return XSingleton<XEntityMgr>.singleton.IsAlly(e1, e2);
            bool isBlueTeam;
            return XDocuments.GetSpecificDocument<XSpectateSceneDocument>(XSpectateSceneDocument.uuID).TryGetEntityIsBlueTeam(e2, out isBlueTeam) && isBlueTeam;
        }

        public static void SetMiniMapOpponentStatus(bool hide) => BattleIndicateHandler._hide_minimap_opponent = hide;

        public void MiniMapAddDoor(Transform go)
        {
            if (!((UnityEngine.Object)go.FindChild("Target") != (UnityEngine.Object)null))
                return;
            GameObject gameObject1 = this.m_MiniMapElementPool.FetchGameObject();
            GameObject gameObject2 = gameObject1.transform.Find("Circle").gameObject;
            if ((UnityEngine.Object)gameObject2 != (UnityEngine.Object)null)
                gameObject2.SetActive(false);
            IXUISprite component = gameObject1.GetComponent("XUISprite") as IXUISprite;
            component.SetAlpha(1f);
            MiniMapElement element = new MiniMapElement();
            element.notice = (XFx)null;
            element.sp = component;
            element.sp.SetSprite("smap_7");
            element.sp.MakePixelPerfect();
            gameObject1.name = "Door";
            element.transform = go;
            this.m_MiniMapDoor.Add(element);
            this.SetupMiniMapStatic(element);
        }

        public void OnMonsterDie(XEntity e)
        {
        }

        public void MiniMapDel(ulong uid)
        {
            MiniMapElement miniMapElement;
            if (!this.m_MiniMapElements.TryGetValue(uid, out miniMapElement))
                return;
            this.m_MiniMapElements.Remove(uid);
            this.DestroyFx(miniMapElement.notice);
            miniMapElement.notice = (XFx)null;
            this.m_MiniMapElementPool.ReturnInstance(miniMapElement.sp.gameObject);
        }

        public void MiniMapDel(XEntity e)
        {
            MiniMapElement miniMapElement;
            if (XSingleton<XEntityMgr>.singleton.IsAlly(e) || !this.m_MiniMapElements.TryGetValue(e.ID, out miniMapElement))
                return;
            this.m_MiniMapElements.Remove(e.ID);
            this.DestroyFx(miniMapElement.notice);
            miniMapElement.notice = (XFx)null;
            this.m_MiniMapElementPool.ReturnInstance(miniMapElement.sp.gameObject);
        }

        public void MiniMapNoticeAdd(XEntity e)
        {
            MiniMapElement element;
            if (!this.m_MiniMapElements.TryGetValue(e.ID, out element))
                return;
            this.CreateAndPlayFxFxFirework(element);
        }

        public void MiniMapBuffAdd(XLevelDoodad doo)
        {
            BuffTable.RowData buffData = XSingleton<XBuffTemplateManager>.singleton.GetBuffData((int)doo.id, 1);
            if (buffData == null || string.IsNullOrEmpty(buffData.MiniMapIcon) || this.m_MiniMapDoodadDic.ContainsKey((ulong)doo.index))
                return;
            GameObject gameObject1 = this.m_MiniMapElementPool.FetchGameObject();
            GameObject gameObject2 = gameObject1.transform.Find("Circle").gameObject;
            if ((UnityEngine.Object)gameObject2 != (UnityEngine.Object)null)
                gameObject2.SetActive(false);
            IXUISprite component = gameObject1.GetComponent("XUISprite") as IXUISprite;
            MiniMapElement element = new MiniMapElement();
            element.notice = (XFx)null;
            element.sp = component;
            component.SetAlpha(1f);
            element.sp.SetSprite(buffData.MiniMapIcon);
            element.sp.MakePixelPerfect();
            element.sp.spriteDepth = 36;
            gameObject1.name = "Buff";
            element.transform = doo.doodad.transform;
            this.m_MiniMapBuff.Add(element);
            this.m_MiniMapDoodadDic.Add((ulong)doo.index, element);
            this.SetupMiniMapStatic(element);
        }

        public void MiniMapBuffDel(XLevelDoodad doo)
        {
            MiniMapElement miniMapElement;
            if (!this.m_MiniMapDoodadDic.TryGetValue((ulong)doo.index, out miniMapElement))
                return;
            this.m_MiniMapBuff.Remove(miniMapElement);
            this.m_MiniMapDoodadDic.Remove((ulong)doo.index);
            this.DestroyFx(miniMapElement.notice);
            miniMapElement.notice = (XFx)null;
            this.m_MiniMapElementPool.ReturnInstance(miniMapElement.sp.gameObject);
        }

        public uint MiniMapFxAdd(Vector3 pos, string fx)
        {
            GameObject gameObject1 = this.m_MiniMapElementPool.FetchGameObject();
            GameObject gameObject2 = gameObject1.transform.Find("Circle").gameObject;
            if ((UnityEngine.Object)gameObject2 != (UnityEngine.Object)null)
                gameObject2.SetActive(false);
            IXUISprite component = gameObject1.GetComponent("XUISprite") as IXUISprite;
            MiniMapElement element = new MiniMapElement();
            element.notice = XSingleton<XFxMgr>.singleton.CreateFx(fx);
            if (element.notice != null)
            {
                element.notice.Play(component.transform, Vector3.zero, Vector3.one, follow: true);
                XSingleton<XGameUI>.singleton.m_uiTool.MarkParentAsChanged(component.gameObject);
            }
            element.sp = component;
            component.SetAlpha(1f);
            element.pos = pos;
            element.sp.SetSprite("");
            gameObject1.name = "Fx";
            element.transform = (Transform)null;
            ++this.m_MiniMapFxToken;
            this.m_MiniMapFx.Add(element);
            this.m_MiniMapFxDic.Add((ulong)this.m_MiniMapFxToken, element);
            this.SetupMiniMapFxStatic(element);
            return this.m_MiniMapFxToken;
        }

        public void MiniMapFxDel(uint token)
        {
            MiniMapElement miniMapElement;
            if (!this.m_MiniMapFxDic.TryGetValue((ulong)token, out miniMapElement))
                return;
            this.m_MiniMapFx.Remove(miniMapElement);
            this.m_MiniMapFxDic.Remove((ulong)token);
            this.DestroyFx(miniMapElement.notice);
            miniMapElement.notice = (XFx)null;
            this.m_MiniMapElementPool.ReturnInstance(miniMapElement.sp.gameObject);
        }

        public uint MiniMapPicAdd(Vector3 pos, string pic)
        {
            GameObject gameObject1 = this.m_MiniMapElementPool.FetchGameObject();
            GameObject gameObject2 = gameObject1.transform.Find("Circle").gameObject;
            if ((UnityEngine.Object)gameObject2 != (UnityEngine.Object)null)
                gameObject2.SetActive(false);
            IXUISprite component = gameObject1.GetComponent("XUISprite") as IXUISprite;
            MiniMapElement element = new MiniMapElement();
            element.notice = (XFx)null;
            element.sp = component;
            component.SetAlpha(1f);
            element.pos = pos;
            element.sp.SetSprite(pic);
            element.sp.MakePixelPerfect();
            element.sp.transform.localEulerAngles = -this.m_MiniMapRotation.transform.eulerAngles;
            element.sp.spriteDepth = 36;
            gameObject1.name = "Pic";
            element.transform = (Transform)null;
            ++this.m_MiniMapPicToken;
            this.m_MiniMapPic.Add(element);
            this.m_MiniMapPicDic.Add((ulong)this.m_MiniMapPicToken, element);
            this.SetupMiniMapPicStatic(element);
            return this.m_MiniMapPicToken;
        }

        public void MiniMapPicDel(uint token)
        {
            MiniMapElement miniMapElement;
            if (!this.m_MiniMapPicDic.TryGetValue((ulong)token, out miniMapElement))
                return;
            this.m_MiniMapPic.Remove(miniMapElement);
            this.m_MiniMapPicDic.Remove((ulong)token);
            this.m_MiniMapElementPool.ReturnInstance(miniMapElement.sp.gameObject);
        }

        public void CreateAndPlayFxFxFirework(MiniMapElement element)
        {
            this.DestroyFx(element.notice);
            element.notice = (XFx)null;
            element.notice = XSingleton<XFxMgr>.singleton.CreateFx("Effects/FX_Particle/UIfx/UI_xdtts");
            element.notice.Play(element.sp.transform, Vector3.zero, Vector3.one, follow: true);
            XSingleton<XGameUI>.singleton.m_uiTool.MarkParentAsChanged(element.sp.gameObject);
        }

        private void DestroyFx(XFx fx)
        {
            if (fx == null)
                return;
            XSingleton<XFxMgr>.singleton.DestroyFx(fx);
        }

        public void MiniMapNoticeDel(XEntity e)
        {
            MiniMapElement miniMapElement;
            if (!this.m_MiniMapElements.TryGetValue(e.ID, out miniMapElement))
                return;
            this.DestroyFx(miniMapElement.notice);
            miniMapElement.notice = (XFx)null;
        }

        public void ShowDirection(Transform target)
        {
            this.m_CachedDirectionTarget = target;
            if (XSingleton<XScene>.singleton.bSpectator)
                return;
            this.m_Direction.localPosition = this.m_DirectPos;
        }

        public void UpdateDirection()
        {
            if (!((UnityEngine.Object)this.m_CachedDirectionTarget != (UnityEngine.Object)null))
                return;
            XPlayer player = XSingleton<XEntityMgr>.singleton.Player;
            Camera unityCamera = XSingleton<XScene>.singleton.GameCamera.UnityCamera;
            Vector3 position = player.EngineObject.Position;
            Vector3 vector3_1 = new Vector3(this.m_CachedDirectionTarget.transform.position.x, 0.0f, this.m_CachedDirectionTarget.transform.position.z) - new Vector3(position.x, 0.0f, position.z);
            Vector3 vector3_2 = new Vector3(unityCamera.transform.forward.x, 0.0f, unityCamera.transform.forward.z);
            float sqrMagnitude = vector3_1.sqrMagnitude;
            float angle = Vector3.Angle(vector3_2, vector3_1);
            if (XSingleton<XCommon>.singleton.Clockwise(vector3_2, vector3_1))
                this.m_Direction.transform.localRotation = Quaternion.AngleAxis(-angle, Vector3.forward);
            else
                this.m_Direction.transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            if ((double)sqrMagnitude < 50.0)
            {
                this.m_Direction.localPosition = XGameUI.Far_Far_Away;
                this.m_CachedDirectionTarget = (Transform)null;
            }
        }

        public void ClearTeamIndicate()
        {
            this.m_EntityIndicates.Clear();
            this.m_TeamIndicatePool.ReturnAll();
            this.m_IndicatesList.Clear();
        }

        public void ChangeWatchToEntity(XEntity e) => this._campEntity = e;
    }
}
