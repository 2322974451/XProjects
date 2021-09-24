using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.Battle;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	public class XGameUI : XSingleton<XGameUI>, IXGameUI, IXInterface
	{

		public int Base_UI_Width { get; set; }

		public int Base_UI_Height { get; set; }

		public bool Deprecated { get; set; }

		public GameObject DlgControllerTpl
		{
			get
			{
				return this._dlgControllerTpl;
			}
		}

		public GameObject[] buttonTpl
		{
			get
			{
				return this._buttonTpl;
			}
		}

		public GameObject[] spriteTpl
		{
			get
			{
				return this._spriteTpl;
			}
		}

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

		public GameObject UIAudio
		{
			get
			{
				return this.m_uiAudio;
			}
		}

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

		public override void Uninit()
		{
		}

		public void GetOverlay()
		{
			bool flag = this.m_overlay == null;
			if (flag)
			{
				this.m_overlay = (this.m_objUIRoot.FindChild("fade_panel/fade_canvas").GetComponent("XUISprite") as IXUISprite);
				this.m_overlay.gameObject.SetActive(false);
			}
		}

		public float GetOverlayAlpha()
		{
			this.GetOverlay();
			return this.m_overlay.gameObject.activeSelf ? this.m_overlay.GetAlpha() : 0f;
		}

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

		public void ShowCutSceneUI()
		{
			DlgBase<CutSceneUI, CutSceneUIBehaviour>.singleton.Load();
			DlgBase<CutSceneUI, CutSceneUIBehaviour>.singleton.SetVisible(true, true);
		}

		public void UpdateNetUI()
		{
			this.ShowConnecting(XSingleton<XLoginDocument>.singleton.FetchTokenDelay || XSingleton<XLoginDocument>.singleton.LoginDelay || XSingleton<XClientNetwork>.singleton.XConnect.OnConnectDelay || XSingleton<XClientNetwork>.singleton.XConnect.OnRpcDelay || XSingleton<XClientNetwork>.singleton.XConnect.OnReconnect);
		}

		internal void LoadLoginUI(EXStage eStage)
		{
			DlgBase<XLoginView, LoginWindowBehaviour>.singleton.Load();
			DlgBase<XLoginView, LoginWindowBehaviour>.singleton.SetVisible(true, true);
		}

		internal void UnloadLoginUI()
		{
			DlgBase<XLoginView, LoginWindowBehaviour>.singleton.UnLoad(false);
			DlgBase<CutSceneUI, CutSceneUIBehaviour>.singleton.UnLoad(false);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.UnLoad(false);
		}

		internal void LoadSelectCharUI(EXStage eStage)
		{
			DlgBase<XSelectCharView, SelectCharWindowBehaviour>.singleton.Load();
			DlgBase<XSelectCharView, SelectCharWindowBehaviour>.singleton.SetVisible(true, true);
		}

		internal void UnLoadSelectCharUI()
		{
			DlgBase<XSelectCharView, SelectCharWindowBehaviour>.singleton.UnLoad(false);
			DlgBase<XAnnouncementView, XAnnouncementBehaviour>.singleton.UnLoad(false);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.UnLoad(false);
		}

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

		internal void LoadHallUI(EXStage eStage)
		{
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.Load();
		}

		internal void LoadConcreteUI(EXStage eStage)
		{
		}

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

		private Transform m_objUIRoot = null;

		private IXUIPanel m_objHpbarRoot = null;

		private IXUIPanel m_objNpcHpbarRoot = null;

		private Camera m_uiCamera = null;

		public IXUITool m_uiTool = null;

		private IXUISprite m_overlay = null;

		private GameObject m_connect = null;

		private GameObject m_block = null;

		private GameObject m_uiAudio = null;

		public static int _far_far_away = 1000;

		public static Vector3 Far_Far_Away = new Vector3(10000f, 10000f, 0f);

		private GameObject[] _buttonTpl = new GameObject[3];

		private GameObject[] _spriteTpl = new GameObject[1];

		private GameObject _dlgControllerTpl = null;
	}
}
