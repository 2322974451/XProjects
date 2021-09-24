using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class PandoraView : DlgBase<PandoraView, PandoraBehaviour>
	{

		private OutLook outLook
		{
			get
			{
				bool flag = this.m_outLook == null;
				if (flag)
				{
					this.m_outLook = new OutLook();
				}
				bool flag2 = this.m_outLook.display_fashion == null;
				if (flag2)
				{
					this.m_outLook.display_fashion = new OutLookDisplayFashion();
				}
				return this.m_outLook;
			}
		}

		public override string fileName
		{
			get
			{
				return "GameSystem/PandoraDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Pandora);
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<PandoraDocument>(PandoraDocument.uuID);
			this._showItemDoc = XDocuments.GetSpecificDocument<XShowGetItemDocument>(XShowGetItemDocument.uuID);
		}

		public override int[] GetTitanBarItems()
		{
			return new int[]
			{
				(int)this._doc.PandoraData.PandoraID,
				(int)this._doc.PandoraData.FireID
			};
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.Alloc3DAvatarPool("PandoraView");
			this._showItemDoc.bIgonre = true;
			this.m_DummyAngle[0] = new Vector3(this._doc.PandoraData.DisplayAngle0[0], this._doc.PandoraData.DisplayAngle0[1], this._doc.PandoraData.DisplayAngle0[2]);
			this.m_DummyAngle[1] = new Vector3(this._doc.PandoraData.DisplayAngle1[0], this._doc.PandoraData.DisplayAngle1[1], this._doc.PandoraData.DisplayAngle1[2]);
			this.m_DummyAngle[2] = new Vector3(this._doc.PandoraData.DisplayAngle2[0], this._doc.PandoraData.DisplayAngle2[1], this._doc.PandoraData.DisplayAngle2[2]);
			this.m_DummyScale[0] = new Vector3(this._doc.PandoraData.DisplayAngle0[3], this._doc.PandoraData.DisplayAngle0[4], this._doc.PandoraData.DisplayAngle0[5]);
			this.m_DummyScale[1] = new Vector3(this._doc.PandoraData.DisplayAngle1[3], this._doc.PandoraData.DisplayAngle1[4], this._doc.PandoraData.DisplayAngle1[5]);
			this.m_DummyScale[2] = new Vector3(this._doc.PandoraData.DisplayAngle2[3], this._doc.PandoraData.DisplayAngle2[4], this._doc.PandoraData.DisplayAngle2[5]);
			base.uiBehaviour.m_DisplayLabel[0].SetText(this._doc.PandoraData.DisplayName0);
			base.uiBehaviour.m_DisplayLabel[1].SetText(this._doc.PandoraData.DisplayName1);
			base.uiBehaviour.m_DisplayLabel[2].SetText(this._doc.PandoraData.DisplayName2);
			this.ShowDisplayFrame();
		}

		protected override void OnHide()
		{
			this._showItemDoc.bIgonre = false;
			this.ClearAllFx();
			this._doc.DestroyFx(this.m_OpenFx);
			this.m_OpenFx = null;
			base.Return3DAvatarPool();
			XSingleton<XTimerMgr>.singleton.KillTimer(this._fxTimeToken);
			base.OnHide();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			base.Alloc3DAvatarPool("PandoraView");
			this._showItemDoc.bIgonre = true;
		}

		public override void LeaveStackTop()
		{
			base.LeaveStackTop();
			this._showItemDoc.bIgonre = false;
		}

		protected override void OnUnload()
		{
			this.ClearAllFx();
			this._doc.DestroyFx(this.m_OpenFx);
			this.m_OpenFx = null;
			this.m_outLook = null;
			base.Return3DAvatarPool();
			XSingleton<XTimerMgr>.singleton.KillTimer(this._fxTimeToken);
			DlgHandlerBase.EnsureUnload<ItemListHandler>(ref this._itemListHandler);
			base.OnUnload();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_BackButton.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnBackClicked));
			base.uiBehaviour.m_OnceButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnOnceButtonClicked));
			base.uiBehaviour.m_TenButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnTenButtonClicked));
			base.uiBehaviour.m_OKButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnOKButtonClicked));
			base.uiBehaviour.m_ItemListButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnItemListButtonClicked));
			base.uiBehaviour.m_DisplayPoint[0].RegisterSpriteDragEventHandler(new SpriteDragEventHandler(this.OnAvatarDrag0));
			base.uiBehaviour.m_DisplayPoint[1].RegisterSpriteDragEventHandler(new SpriteDragEventHandler(this.OnAvatarDrag1));
			base.uiBehaviour.m_DisplayPoint[2].RegisterSpriteDragEventHandler(new SpriteDragEventHandler(this.OnAvatarDrag2));
		}

		private void OnBackClicked(IXUISprite sp)
		{
			this.SetVisible(false, true);
		}

		private bool OnOnceButtonClicked(IXUIButton button)
		{
			this._doc.SendPandoraLottery(true);
			return true;
		}

		private bool OnTenButtonClicked(IXUIButton button)
		{
			this._doc.SendPandoraLottery(false);
			return true;
		}

		private bool OnOKButtonClicked(IXUIButton button)
		{
			this.ShowDisplayFrame();
			XScreenShotShareDocument specificDocument = XDocuments.GetSpecificDocument<XScreenShotShareDocument>(XScreenShotShareDocument.uuID);
			bool flag = specificDocument.CurShareBgType == ShareBgType.LuckyPandora && specificDocument.SpriteID > 0U;
			if (flag)
			{
				XSingleton<PDatabase>.singleton.shareCallbackType = ShareCallBackType.GloryPic;
				DlgBase<DungeonShareView, DungeonShareBehavior>.singleton.SetVisibleWithAnimation(true, null);
			}
			return true;
		}

		private bool OnItemListButtonClicked(IXUIButton button)
		{
			DlgHandlerBase.EnsureCreate<ItemListHandler>(ref this._itemListHandler, base.uiBehaviour.transform, false, null);
			this._itemListHandler.ShowItemList(PandoraDocument.ItemList);
			return true;
		}

		private bool OnAvatarDrag0(Vector2 delta)
		{
			bool flag = this.m_Dummy[0] != null;
			if (flag)
			{
				this.m_Dummy[0].EngineObject.Rotate(Vector3.up, -delta.x / 2f);
				this.m_DummyAngle[0] = this.m_Dummy[0].EngineObject.LocalEulerAngles;
			}
			return true;
		}

		private bool OnAvatarDrag1(Vector2 delta)
		{
			bool flag = this.m_Dummy[1] != null;
			if (flag)
			{
				this.m_Dummy[1].EngineObject.Rotate(Vector3.up, -delta.x / 2f);
				this.m_DummyAngle[1] = this.m_Dummy[1].EngineObject.LocalEulerAngles;
			}
			return true;
		}

		private bool OnAvatarDrag2(Vector2 delta)
		{
			bool flag = this.m_Dummy[2] != null;
			if (flag)
			{
				this.m_Dummy[2].EngineObject.Rotate(Vector3.up, -delta.x / 2f);
				this.m_DummyAngle[2] = this.m_Dummy[2].EngineObject.LocalEulerAngles;
			}
			return true;
		}

		public void ShowDisplayFrame()
		{
			base.uiBehaviour.m_DisplayFrame.gameObject.SetActive(true);
			base.uiBehaviour.m_RewardFrame.gameObject.SetActive(false);
			base.uiBehaviour.m_BackButton.SetVisible(true);
			base.uiBehaviour.m_OnceButton.SetVisible(true);
			base.uiBehaviour.m_TenButton.SetVisible(true);
			this.RefreshDummy();
		}

		private void RefreshDummy()
		{
			for (int i = 0; i < 3; i++)
			{
				uint[] array = null;
				switch (i)
				{
				case 0:
					array = this._doc.PandoraData.DisplaySlot0;
					break;
				case 1:
					array = this._doc.PandoraData.DisplaySlot1;
					break;
				case 2:
					array = this._doc.PandoraData.DisplaySlot2;
					break;
				}
				bool flag = array == null;
				if (!flag)
				{
					base.uiBehaviour.m_DisplayAvatar[i].transform.localScale = this.m_DummyScale[i];
					uint num = array[0];
					if (num != 0U)
					{
						if (num == 1U)
						{
							uint presentID = this.TransItemToPresentID(array[1]);
							string rideAnim = this.GetRideAnim(array[1]);
							this.m_Dummy[i] = XSingleton<X3DAvatarMgr>.singleton.CreateCommonEntityDummy(this.m_dummPool, presentID, base.uiBehaviour.m_DisplayAvatar[i], this.m_Dummy[i], 1f);
							this.m_Dummy[i].SetAnimation(rideAnim);
							this.m_Dummy[i].EngineObject.LocalEulerAngles = this.m_DummyAngle[i];
						}
					}
					else
					{
						List<uint> list = new List<uint>();
						for (int j = 1; j < array.Length; j++)
						{
							list.Add(array[j]);
						}
						XPlayerAttributes xplayerData = XSingleton<XAttributeMgr>.singleton.XPlayerData;
						bool flag2 = xplayerData != null;
						if (flag2)
						{
							this.outLook.display_fashion.display_fashions.Clear();
							this.outLook.display_fashion.display_fashions.AddRange(list);
							this.m_Dummy[i] = XSingleton<X3DAvatarMgr>.singleton.CreateCommonRoleDummy(this.m_dummPool, xplayerData.RoleID, (uint)XFastEnumIntEqualityComparer<RoleType>.ToInt(xplayerData.Profession), this.outLook, base.uiBehaviour.m_DisplayAvatar[i], this.m_Dummy[i]);
							this.m_Dummy[i].EngineObject.LocalEulerAngles = this.m_DummyAngle[i];
						}
					}
				}
			}
		}

		private uint TransItemToPresentID(uint itemid)
		{
			uint petID = XPetDocument.GetPetID(itemid);
			return XPetDocument.GetPresentID(petID);
		}

		private string GetRideAnim(uint itemid)
		{
			uint petID = XPetDocument.GetPetID(itemid);
			XPetDocument specificDocument = XDocuments.GetSpecificDocument<XPetDocument>(XPetDocument.uuID);
			PetBubble.RowData petBubble = specificDocument.GetPetBubble(XPetActionFile.IDLE, petID);
			bool flag = petBubble == null;
			string result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog(string.Concat(new object[]
				{
					"PetBubble No Find\nitemid:",
					itemid,
					" petid:",
					petID
				}), null, null, null, null, null);
				result = null;
			}
			else
			{
				result = petBubble.ActionFile;
			}
			return result;
		}

		public void PlayOpenFx()
		{
			base.uiBehaviour.m_BackButton.SetVisible(false);
			base.uiBehaviour.m_OnceButton.SetVisible(false);
			base.uiBehaviour.m_TenButton.SetVisible(false);
			this._doc.DestroyFx(this.m_OpenFx);
			this.m_OpenFx = null;
			this.m_OpenFx = this._doc.CreateAndPlayFx("Effects/FX_Particle/UIfx/UI_pdlzx_Clip01", base.uiBehaviour.m_FxPoint);
			XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/UI_PandoraHeart_Ten", true, AudioChannel.Action);
			this._fxTimeToken = XSingleton<XTimerMgr>.singleton.SetTimer((float)XSingleton<XGlobalConfig>.singleton.GetInt("PandoraFxTime") / 10f, new XTimerMgr.ElapsedEventHandler(this.ShowRewardFrame), null);
		}

		public void ShowRewardFrame(object o = null)
		{
			base.uiBehaviour.m_DisplayFrame.gameObject.SetActive(false);
			base.uiBehaviour.m_RewardFrame.gameObject.SetActive(true);
			this.ClearAllFx();
			this._doc.DestroyFx(this.m_OpenFx);
			this.m_OpenFx = null;
			base.uiBehaviour.m_ResultPool.FakeReturnAll();
			for (int i = 0; i < this._doc.ItemCache.Count; i++)
			{
				this.SetupItem(i);
			}
			base.uiBehaviour.m_ResultPool.ActualReturnAll(false);
		}

		private void SetupItem(int index)
		{
			GameObject gameObject = base.uiBehaviour.m_ResultPool.FetchGameObject(false);
			IXUITweenTool ixuitweenTool = gameObject.GetComponent("XUIPlayTween") as IXUITweenTool;
			GameObject gameObject2 = gameObject.transform.Find("ItemTpl").gameObject;
			IXUISprite ixuisprite = gameObject2.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject2, (int)this._doc.ItemCache[index].itemID, (int)this._doc.ItemCache[index].itemCount, false);
			Transform parent = gameObject.transform.Find("Fx");
			ixuisprite.ID = (ulong)this._doc.ItemCache[index].itemID;
			bool isbind = this._doc.ItemCache[index].isbind;
			if (isbind)
			{
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnBindItemClick));
			}
			else
			{
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
			}
			ItemList.RowData itemConf = XBagDocument.GetItemConf((int)this._doc.ItemCache[index].itemID);
			switch (itemConf.ItemQuality)
			{
			case 3:
				this.m_FxList.Add(this._doc.CreateAndPlayFx("Effects/FX_Particle/UIfx/UI_jl_04_orange", parent));
				break;
			case 4:
				this.m_FxList.Add(this._doc.CreateAndPlayFx("Effects/FX_Particle/UIfx/UI_jl_04_purple", parent));
				break;
			case 5:
				this.m_FxList.Add(this._doc.CreateAndPlayFx("Effects/FX_Particle/UIfx/UI_jl_04_red", parent));
				break;
			}
			gameObject.transform.localPosition = this.GetItemPos(index, this._doc.ItemCache.Count, 5, (float)base.uiBehaviour.m_ResultPool.TplWidth, (float)base.uiBehaviour.m_ResultPool.TplHeight, base.uiBehaviour.m_ResultPool.TplPos);
			ixuitweenTool.ResetTween(true);
			ixuitweenTool.PlayTween(true, -1f);
		}

		private Vector3 GetItemPos(int index, int totalCount, int lineCount, float width, float height, Vector3 centerPos)
		{
			float num = centerPos.x - (float)(lineCount - 1) * width / 2f;
			float num2 = centerPos.y + (float)((totalCount + lineCount - 1) / lineCount) * height / 2f;
			bool flag = totalCount / lineCount == index / lineCount;
			if (flag)
			{
				num += (float)(lineCount - totalCount % lineCount) * width / 2f;
			}
			float num3 = num + (float)(index % lineCount) * width;
			float num4 = num2 - (float)(index / lineCount) * height;
			return new Vector3(num3, num4);
		}

		private void ClearAllFx()
		{
			for (int i = 0; i < this.m_FxList.Count; i++)
			{
				this._doc.DestroyFx(this.m_FxList[i]);
			}
			this.m_FxList.Clear();
		}

		private PandoraDocument _doc;

		private XShowGetItemDocument _showItemDoc;

		private ItemListHandler _itemListHandler;

		private XFx m_OpenFx = null;

		private List<XFx> m_FxList = new List<XFx>();

		private XDummy[] m_Dummy = new XDummy[3];

		private Vector3[] m_DummyAngle = new Vector3[3];

		private Vector3[] m_DummyScale = new Vector3[3];

		private const int _avatarSlot = 8;

		private uint _fxTimeToken = 0U;

		private OutLook m_outLook;
	}
}
