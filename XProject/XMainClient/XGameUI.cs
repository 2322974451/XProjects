using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.Battle;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FE7 RID: 4071
	public class XGameUI : XSingleton<XGameUI>, IXGameUI, IXInterface
	{
		// Token: 0x170036F6 RID: 14070
		// (get) Token: 0x0600D3C4 RID: 54212 RVA: 0x0031CA27 File Offset: 0x0031AC27
		// (set) Token: 0x0600D3C5 RID: 54213 RVA: 0x0031CA2F File Offset: 0x0031AC2F
		public int Base_UI_Width { get; set; }

		// Token: 0x170036F7 RID: 14071
		// (get) Token: 0x0600D3C6 RID: 54214 RVA: 0x0031CA38 File Offset: 0x0031AC38
		// (set) Token: 0x0600D3C7 RID: 54215 RVA: 0x0031CA40 File Offset: 0x0031AC40
		public int Base_UI_Height { get; set; }

		// Token: 0x170036F8 RID: 14072
		// (get) Token: 0x0600D3C8 RID: 54216 RVA: 0x0031CA49 File Offset: 0x0031AC49
		// (set) Token: 0x0600D3C9 RID: 54217 RVA: 0x0031CA51 File Offset: 0x0031AC51
		public bool Deprecated { get; set; }

		// Token: 0x170036F9 RID: 14073
		// (get) Token: 0x0600D3CA RID: 54218 RVA: 0x0031CA5C File Offset: 0x0031AC5C
		public GameObject DlgControllerTpl
		{
			get
			{
				return this._dlgControllerTpl;
			}
		}

		// Token: 0x170036FA RID: 14074
		// (get) Token: 0x0600D3CB RID: 54219 RVA: 0x0031CA74 File Offset: 0x0031AC74
		public GameObject[] buttonTpl
		{
			get
			{
				return this._buttonTpl;
			}
		}

		// Token: 0x170036FB RID: 14075
		// (get) Token: 0x0600D3CC RID: 54220 RVA: 0x0031CA8C File Offset: 0x0031AC8C
		public GameObject[] spriteTpl
		{
			get
			{
				return this._spriteTpl;
			}
		}

		// Token: 0x170036FC RID: 14076
		// (get) Token: 0x0600D3CD RID: 54221 RVA: 0x0031CAA4 File Offset: 0x0031ACA4
		// (set) Token: 0x0600D3CE RID: 54222 RVA: 0x0031CABC File Offset: 0x0031ACBC
		public IXUIPanel HpbarRoot
		{
			get
			{
				return this.m_objHpbarRoot;
			}
			set
			{
				this.m_objHpbarRoot = value;
			}
		}

		// Token: 0x170036FD RID: 14077
		// (get) Token: 0x0600D3CF RID: 54223 RVA: 0x0031CAC8 File Offset: 0x0031ACC8
		// (set) Token: 0x0600D3D0 RID: 54224 RVA: 0x0031CAE0 File Offset: 0x0031ACE0
		public IXUIPanel NpcHpbarRoot
		{
			get
			{
				return this.m_objNpcHpbarRoot;
			}
			set
			{
				this.m_objNpcHpbarRoot = value;
			}
		}

		// Token: 0x170036FE RID: 14078
		// (get) Token: 0x0600D3D1 RID: 54225 RVA: 0x0031CAEC File Offset: 0x0031ACEC
		public GameObject UIAudio
		{
			get
			{
				return this.m_uiAudio;
			}
		}

		// Token: 0x170036FF RID: 14079
		// (get) Token: 0x0600D3D2 RID: 54226 RVA: 0x0031CB04 File Offset: 0x0031AD04
		// (set) Token: 0x0600D3D3 RID: 54227 RVA: 0x0031CB1C File Offset: 0x0031AD1C
		public Transform UIRoot
		{
			get
			{
				return this.m_objUIRoot;
			}
			set
			{
				this.m_objUIRoot = value;
				this.m_uiTool = (this.m_objUIRoot.GetComponent("XUITool") as IXUITool);
				GameObject gameObject = this.m_objUIRoot.FindChild("GenericEventHandle").gameObject;
				this.m_uiAudio = this.m_objUIRoot.FindChild("uiplayaudio").gameObject;
				XSingleton<XAudioMgr>.singleton.StoreAudioSource(this.m_uiAudio);
				this.m_uiTool.SetUIGenericEventHandle(gameObject);
				XSingleton<UIManager>.singleton.UIRoot = this.m_objUIRoot;
			}
		}

		// Token: 0x0600D3D4 RID: 54228 RVA: 0x0031CBAC File Offset: 0x0031ADAC
		public override bool Init()
		{
			XSingleton<XDebug>.singleton.AddLog("XMainClient.XGameUI.Init --------------------------------", null, null, null, null, null, XDebugColor.XDebug_None);
			XSingleton<XInterfaceMgr>.singleton.AttachInterface<IXGameUI>(XSingleton<XCommon>.singleton.XHash("XGameUI"), this);
			XSingleton<XInterfaceMgr>.singleton.AttachInterface<IModalDlg>(XSingleton<XCommon>.singleton.XHash("IModalDlg"), DlgBase<ModalDlg, ModalDlgBehaviour>.singleton);
			XSingleton<XInterfaceMgr>.singleton.AttachInterface<IXNormalItemDrawer>(XSingleton<XCommon>.singleton.XHash("IXNormalItemDrawer"), XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer);
			XSingleton<XInterfaceMgr>.singleton.AttachInterface<IGameSysMgr>(XSingleton<XCommon>.singleton.XHash("IGameSysMgr"), XSingleton<XGameSysMgr>.singleton);
			XSingleton<XInterfaceMgr>.singleton.AttachInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"), XSingleton<UiUtility>.singleton);
			XSingleton<XInterfaceMgr>.singleton.AttachInterface<ITssSdkSend>(XSingleton<XCommon>.singleton.XHash("ITssSdkSend"), XSingleton<XTssSdk>.singleton);
			XSingleton<XInterfaceMgr>.singleton.AttachInterface<IX3DAvatarMgr>(XSingleton<XCommon>.singleton.XHash("IX3DAvatarMgr"), XSingleton<X3DAvatarMgr>.singleton);
			XSingleton<XInterfaceMgr>.singleton.AttachInterface<ILuaExtion>(XSingleton<XCommon>.singleton.XHash("ILuaExtion"), XSingleton<XLuaExtion>.singleton);
			bool flag = this.UIRoot == null;
			if (flag)
			{
				this.UIRoot = (XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab("UI/Common/work/UIRoot", false, true) as GameObject).transform;
				Object.DontDestroyOnLoad(this.UIRoot);
			}
			bool flag2 = this.HpbarRoot == null;
			if (flag2)
			{
				GameObject gameObject = XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab("UI/Common/work/HpbarRoot", false, true) as GameObject;
				bool flag3 = gameObject != null;
				if (flag3)
				{
					this.HpbarRoot = (gameObject.GetComponent("XUIPanel") as IXUIPanel);
					Object.DontDestroyOnLoad(gameObject);
				}
			}
			bool flag4 = this.NpcHpbarRoot == null;
			if (flag4)
			{
				GameObject gameObject2 = XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab("UI/Common/work/HpbarRoot", false, true) as GameObject;
				bool flag5 = gameObject2 != null;
				if (flag5)
				{
					gameObject2.name = "NpcHpbarRoot";
					this.NpcHpbarRoot = (gameObject2.GetComponent("XUIPanel") as IXUIPanel);
					Object.DontDestroyOnLoad(gameObject2);
				}
			}
			for (int i = 0; i < 3; i++)
			{
				this._buttonTpl[i] = (XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab("UI/Common/work/XButton" + (i + 1), false, true) as GameObject);
				this._buttonTpl[i].SetActive(false);
				Object.DontDestroyOnLoad(this._buttonTpl[i]);
			}
			for (int j = 0; j < 1; j++)
			{
				this._spriteTpl[j] = (XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab("UI/Common/work/XSprite" + (j + 1), false, true) as GameObject);
				this._spriteTpl[j].SetActive(false);
				Object.DontDestroyOnLoad(this._spriteTpl[j]);
			}
			this._dlgControllerTpl = (XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab("UI/Common/work/DlgAnimation", false, true) as GameObject);
			this._dlgControllerTpl.SetActive(false);
			Object.DontDestroyOnLoad(this._dlgControllerTpl);
			return true;
		}

		// Token: 0x0600D3D5 RID: 54229 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void Uninit()
		{
		}

		// Token: 0x0600D3D6 RID: 54230 RVA: 0x0031CEC4 File Offset: 0x0031B0C4
		public void GetOverlay()
		{
			bool flag = this.m_overlay == null;
			if (flag)
			{
				this.m_overlay = (this.m_objUIRoot.FindChild("fade_panel/fade_canvas").GetComponent("XUISprite") as IXUISprite);
				this.m_overlay.gameObject.SetActive(false);
			}
		}

		// Token: 0x0600D3D7 RID: 54231 RVA: 0x0031CF18 File Offset: 0x0031B118
		public float GetOverlayAlpha()
		{
			this.GetOverlay();
			return this.m_overlay.gameObject.activeSelf ? this.m_overlay.GetAlpha() : 0f;
		}

		// Token: 0x0600D3D8 RID: 54232 RVA: 0x0031CF58 File Offset: 0x0031B158
		public void SetOverlayAlpha(float alpha)
		{
			this.GetOverlay();
			bool flag = alpha > 0f;
			if (flag)
			{
				bool flag2 = !this.m_overlay.gameObject.activeSelf;
				if (flag2)
				{
					this.m_overlay.gameObject.SetActive(true);
				}
				this.m_overlay.SetAlpha(alpha);
			}
			else
			{
				this.m_overlay.gameObject.SetActive(false);
			}
		}

		// Token: 0x0600D3D9 RID: 54233 RVA: 0x0031CFC8 File Offset: 0x0031B1C8
		private void ShowConnecting(bool bVisible)
		{
			bool flag = this.m_connect == null;
			if (flag)
			{
				this.m_connect = this.m_objUIRoot.FindChild("fade_panel/connecting").gameObject;
			}
			if (bVisible)
			{
				bool flag2 = !this.m_connect.activeSelf;
				if (flag2)
				{
					this.m_connect.SetActive(bVisible);
				}
			}
			else
			{
				bool activeSelf = this.m_connect.activeSelf;
				if (activeSelf)
				{
					this.m_connect.SetActive(bVisible);
				}
			}
		}

		// Token: 0x0600D3DA RID: 54234 RVA: 0x0031D04C File Offset: 0x0031B24C
		public void ShowBlock(bool bVisible)
		{
			bool flag = this.m_block == null;
			if (flag)
			{
				this.m_block = this.m_objUIRoot.FindChild("block").gameObject;
			}
			if (bVisible)
			{
				bool flag2 = !this.m_block.activeSelf;
				if (flag2)
				{
					this.m_block.SetActive(bVisible);
				}
			}
			else
			{
				bool activeSelf = this.m_block.activeSelf;
				if (activeSelf)
				{
					this.m_block.SetActive(bVisible);
				}
			}
		}

		// Token: 0x17003700 RID: 14080
		// (get) Token: 0x0600D3DB RID: 54235 RVA: 0x0031D0D0 File Offset: 0x0031B2D0
		// (set) Token: 0x0600D3DC RID: 54236 RVA: 0x0031D0E8 File Offset: 0x0031B2E8
		public Camera UICamera
		{
			get
			{
				return this.m_uiCamera;
			}
			set
			{
				this.m_uiCamera = value;
			}
		}

		// Token: 0x0600D3DD RID: 54237 RVA: 0x0031D0F4 File Offset: 0x0031B2F4
		public void OnGenericClick()
		{
			bool flag = XSingleton<XGame>.singleton.CurrentStage != null;
			if (flag)
			{
				bool flag2 = !XSingleton<XTutorialMgr>.singleton.Exculsive;
				if (flag2)
				{
					bool flag3 = DlgBase<EquipTooltipDlg, EquipTooltipDlgBehaviour>.singleton.IsLoaded();
					if (flag3)
					{
						DlgBase<EquipTooltipDlg, EquipTooltipDlgBehaviour>.singleton.HideToolTip(false);
					}
					bool flag4 = DlgBase<ItemTooltipDlg, ItemTooltipDlgBehaviour>.singleton.IsLoaded();
					if (flag4)
					{
						DlgBase<ItemTooltipDlg, ItemTooltipDlgBehaviour>.singleton.HideToolTip(false);
					}
					bool flag5 = DlgBase<EmblemTooltipDlg, EmblemTooltipDlgBehaviour>.singleton.IsLoaded();
					if (flag5)
					{
						DlgBase<EmblemTooltipDlg, EmblemTooltipDlgBehaviour>.singleton.HideToolTip(false);
					}
					bool flag6 = DlgBase<JadeTooltipDlg, TooltipDlgBehaviour>.singleton.IsLoaded();
					if (flag6)
					{
						DlgBase<JadeTooltipDlg, TooltipDlgBehaviour>.singleton.HideToolTip(false);
					}
					bool flag7 = DlgBase<FashionTooltipDlg, FashionTooltipDlgBehaviour>.singleton.IsLoaded();
					if (flag7)
					{
						DlgBase<FashionTooltipDlg, FashionTooltipDlgBehaviour>.singleton.HideToolTip(false);
					}
					bool flag8 = DlgBase<ArtifactToolTipDlg, ArtifactTooltipDlgBehaviour>.singleton.IsLoaded();
					if (flag8)
					{
						DlgBase<ArtifactToolTipDlg, ArtifactTooltipDlgBehaviour>.singleton.HideToolTip(false);
					}
					bool flag9 = DlgBase<FashionHairToolTipDlg, FashionHairToolTipBehaviour>.singleton.IsLoaded();
					if (flag9)
					{
						DlgBase<FashionHairToolTipDlg, FashionHairToolTipBehaviour>.singleton.HideToolTip(false);
					}
					bool flag10 = DlgBase<FashionStorageFashionToolTipDlg, FashionTooltipDlgBehaviour>.singleton.IsLoaded();
					if (flag10)
					{
						DlgBase<FashionStorageFashionToolTipDlg, FashionTooltipDlgBehaviour>.singleton.HideToolTip(false);
					}
					bool flag11 = DlgBase<FashionStorageEquipToolTipDlg, ItemTooltipDlgBehaviour>.singleton.IsLoaded();
					if (flag11)
					{
						DlgBase<FashionStorageEquipToolTipDlg, ItemTooltipDlgBehaviour>.singleton.HideToolTip(false);
					}
					bool flag12 = DlgBase<FashionStorageFashionHairToolTipDlg, FashionHairToolTipBehaviour>.singleton.IsLoaded();
					if (flag12)
					{
						DlgBase<FashionStorageFashionHairToolTipDlg, FashionHairToolTipBehaviour>.singleton.HideToolTip(false);
					}
				}
				bool flag13 = XSingleton<XTutorialMgr>.singleton.Exculsive && XSingleton<XTutorialMgr>.singleton.ExculsiveOnGeneric;
				if (flag13)
				{
					bool flag14 = DlgBase<EquipTooltipDlg, EquipTooltipDlgBehaviour>.singleton.IsLoaded();
					if (flag14)
					{
						DlgBase<EquipTooltipDlg, EquipTooltipDlgBehaviour>.singleton.HideToolTip(false);
					}
					bool flag15 = DlgBase<ItemTooltipDlg, ItemTooltipDlgBehaviour>.singleton.IsLoaded();
					if (flag15)
					{
						DlgBase<ItemTooltipDlg, ItemTooltipDlgBehaviour>.singleton.HideToolTip(false);
					}
					bool flag16 = DlgBase<EmblemTooltipDlg, EmblemTooltipDlgBehaviour>.singleton.IsLoaded();
					if (flag16)
					{
						DlgBase<EmblemTooltipDlg, EmblemTooltipDlgBehaviour>.singleton.HideToolTip(false);
					}
					bool flag17 = DlgBase<JadeTooltipDlg, TooltipDlgBehaviour>.singleton.IsLoaded();
					if (flag17)
					{
						DlgBase<JadeTooltipDlg, TooltipDlgBehaviour>.singleton.HideToolTip(false);
					}
					bool flag18 = DlgBase<FashionTooltipDlg, FashionTooltipDlgBehaviour>.singleton.IsLoaded();
					if (flag18)
					{
						DlgBase<FashionTooltipDlg, FashionTooltipDlgBehaviour>.singleton.HideToolTip(false);
					}
					bool flag19 = DlgBase<ArtifactToolTipDlg, ArtifactTooltipDlgBehaviour>.singleton.IsLoaded();
					if (flag19)
					{
						DlgBase<ArtifactToolTipDlg, ArtifactTooltipDlgBehaviour>.singleton.HideToolTip(false);
					}
					bool flag20 = DlgBase<FashionHairToolTipDlg, FashionHairToolTipBehaviour>.singleton.IsLoaded();
					if (flag20)
					{
						DlgBase<FashionHairToolTipDlg, FashionHairToolTipBehaviour>.singleton.HideToolTip(false);
					}
					bool flag21 = DlgBase<FashionStorageFashionToolTipDlg, FashionTooltipDlgBehaviour>.singleton.IsLoaded();
					if (flag21)
					{
						DlgBase<FashionStorageFashionToolTipDlg, FashionTooltipDlgBehaviour>.singleton.HideToolTip(false);
					}
					bool flag22 = DlgBase<FashionStorageEquipToolTipDlg, ItemTooltipDlgBehaviour>.singleton.IsLoaded();
					if (flag22)
					{
						DlgBase<FashionStorageEquipToolTipDlg, ItemTooltipDlgBehaviour>.singleton.HideToolTip(false);
					}
					bool flag23 = DlgBase<FashionStorageFashionHairToolTipDlg, FashionHairToolTipBehaviour>.singleton.IsLoaded();
					if (flag23)
					{
						DlgBase<FashionStorageFashionHairToolTipDlg, FashionHairToolTipBehaviour>.singleton.HideToolTip(false);
					}
					XSingleton<XTutorialMgr>.singleton.OnTutorialClicked();
				}
			}
		}

		// Token: 0x0600D3DE RID: 54238 RVA: 0x0031D389 File Offset: 0x0031B589
		public void ShowCutSceneUI()
		{
			DlgBase<CutSceneUI, CutSceneUIBehaviour>.singleton.Load();
			DlgBase<CutSceneUI, CutSceneUIBehaviour>.singleton.SetVisible(true, true);
		}

		// Token: 0x0600D3DF RID: 54239 RVA: 0x0031D3A4 File Offset: 0x0031B5A4
		public void UpdateNetUI()
		{
			this.ShowConnecting(XSingleton<XLoginDocument>.singleton.FetchTokenDelay || XSingleton<XLoginDocument>.singleton.LoginDelay || XSingleton<XClientNetwork>.singleton.XConnect.OnConnectDelay || XSingleton<XClientNetwork>.singleton.XConnect.OnRpcDelay || XSingleton<XClientNetwork>.singleton.XConnect.OnReconnect);
		}

		// Token: 0x0600D3E0 RID: 54240 RVA: 0x0031D405 File Offset: 0x0031B605
		internal void LoadLoginUI(EXStage eStage)
		{
			DlgBase<XLoginView, LoginWindowBehaviour>.singleton.Load();
			DlgBase<XLoginView, LoginWindowBehaviour>.singleton.SetVisible(true, true);
		}

		// Token: 0x0600D3E1 RID: 54241 RVA: 0x0031D420 File Offset: 0x0031B620
		internal void UnloadLoginUI()
		{
			DlgBase<XLoginView, LoginWindowBehaviour>.singleton.UnLoad(false);
			DlgBase<CutSceneUI, CutSceneUIBehaviour>.singleton.UnLoad(false);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.UnLoad(false);
		}

		// Token: 0x0600D3E2 RID: 54242 RVA: 0x0031D447 File Offset: 0x0031B647
		internal void LoadSelectCharUI(EXStage eStage)
		{
			DlgBase<XSelectCharView, SelectCharWindowBehaviour>.singleton.Load();
			DlgBase<XSelectCharView, SelectCharWindowBehaviour>.singleton.SetVisible(true, true);
		}

		// Token: 0x0600D3E3 RID: 54243 RVA: 0x0031D462 File Offset: 0x0031B662
		internal void UnLoadSelectCharUI()
		{
			DlgBase<XSelectCharView, SelectCharWindowBehaviour>.singleton.UnLoad(false);
			DlgBase<XAnnouncementView, XAnnouncementBehaviour>.singleton.UnLoad(false);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.UnLoad(false);
		}

		// Token: 0x0600D3E4 RID: 54244 RVA: 0x0031D48C File Offset: 0x0031B68C
		internal void LoadWorldUI(EXStage eStage)
		{
			bool bSpectator = XSingleton<XScene>.singleton.bSpectator;
			if (bSpectator)
			{
				DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.Load();
			}
			else
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.Load();
			}
			DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.Load();
			DlgBase<CutSceneUI, CutSceneUIBehaviour>.singleton.Load();
			DlgBase<ReviveDlg, ReviveDlgBehaviour>.singleton.Load();
		}

		// Token: 0x0600D3E5 RID: 54245 RVA: 0x0031D4E4 File Offset: 0x0031B6E4
		internal void UnloadWorldUI()
		{
			DlgBase<BattleMain, BattleMainBehaviour>.singleton.UnLoad(false);
			DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.UnLoad(false);
			DlgBase<ChallengeDlg, ChallengeDlgBehaviour>.singleton.UnLoad(false);
			DlgBase<BattleQTEDlg, BattleQTEDlgBehaviour>.singleton.UnLoad(false);
			DlgBase<BattleDramaDlg, BattleDramaDlgBehaviour>.singleton.UnLoad(false);
			DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.UnLoad(false);
			DlgBase<CutSceneUI, CutSceneUIBehaviour>.singleton.UnLoad(false);
			DlgBase<ReviveDlg, ReviveDlgBehaviour>.singleton.UnLoad(false);
			DlgBase<XPkLoadingView, XPkLoadingBehaviour>.singleton.UnLoad(false);
			DlgBase<XMultiPkLoadingView, XMultiPkLoadingBehaviour>.singleton.UnLoad(false);
			DlgBase<XTeamLeagueLoadingView, XTeamLeagueLoadingBehaviour>.singleton.UnLoad(false);
			DlgBase<NpcPopSpeekView, DlgBehaviourBase>.singleton.UnLoad(false);
			DlgBase<RollDlg, RollDlgBehaviour>.singleton.UnLoad(false);
		}

		// Token: 0x0600D3E6 RID: 54246 RVA: 0x0031D58E File Offset: 0x0031B78E
		internal void LoadHallUI(EXStage eStage)
		{
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.Load();
		}

		// Token: 0x0600D3E7 RID: 54247 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		internal void LoadConcreteUI(EXStage eStage)
		{
		}

		// Token: 0x0600D3E8 RID: 54248 RVA: 0x0031D59C File Offset: 0x0031B79C
		public void SetUIOptOption(bool globalMerge, bool selectMerge, bool lowDeviceMerge, bool refreshUI = true)
		{
			bool flag = this.m_uiTool != null;
			if (flag)
			{
				this.m_uiTool.SetUIOptOption(globalMerge, selectMerge, lowDeviceMerge);
			}
			if (refreshUI)
			{
				bool flag2 = this.m_objUIRoot != null;
				if (flag2)
				{
					this.m_objUIRoot.gameObject.SetActive(false);
					this.m_objUIRoot.gameObject.SetActive(true);
				}
				bool flag3 = this.m_objHpbarRoot != null;
				if (flag3)
				{
					this.m_objHpbarRoot.gameObject.SetActive(false);
					this.m_objHpbarRoot.gameObject.SetActive(true);
				}
				bool flag4 = this.m_objNpcHpbarRoot != null;
				if (flag4)
				{
					this.m_objNpcHpbarRoot.gameObject.SetActive(false);
					this.m_objNpcHpbarRoot.gameObject.SetActive(true);
				}
			}
		}

		// Token: 0x04006047 RID: 24647
		private Transform m_objUIRoot = null;

		// Token: 0x04006048 RID: 24648
		private IXUIPanel m_objHpbarRoot = null;

		// Token: 0x04006049 RID: 24649
		private IXUIPanel m_objNpcHpbarRoot = null;

		// Token: 0x0400604A RID: 24650
		private Camera m_uiCamera = null;

		// Token: 0x0400604B RID: 24651
		public IXUITool m_uiTool = null;

		// Token: 0x0400604C RID: 24652
		private IXUISprite m_overlay = null;

		// Token: 0x0400604D RID: 24653
		private GameObject m_connect = null;

		// Token: 0x0400604E RID: 24654
		private GameObject m_block = null;

		// Token: 0x0400604F RID: 24655
		private GameObject m_uiAudio = null;

		// Token: 0x04006050 RID: 24656
		public static int _far_far_away = 1000;

		// Token: 0x04006051 RID: 24657
		public static Vector3 Far_Far_Away = new Vector3(10000f, 10000f, 0f);

		// Token: 0x04006052 RID: 24658
		private GameObject[] _buttonTpl = new GameObject[3];

		// Token: 0x04006053 RID: 24659
		private GameObject[] _spriteTpl = new GameObject[1];

		// Token: 0x04006054 RID: 24660
		private GameObject _dlgControllerTpl = null;
	}
}
