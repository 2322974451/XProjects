using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017EF RID: 6127
	internal class PandoraView : DlgBase<PandoraView, PandoraBehaviour>
	{
		// Token: 0x170038CC RID: 14540
		// (get) Token: 0x0600FDF0 RID: 65008 RVA: 0x003B99F4 File Offset: 0x003B7BF4
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

		// Token: 0x170038CD RID: 14541
		// (get) Token: 0x0600FDF1 RID: 65009 RVA: 0x003B9A48 File Offset: 0x003B7C48
		public override string fileName
		{
			get
			{
				return "GameSystem/PandoraDlg";
			}
		}

		// Token: 0x170038CE RID: 14542
		// (get) Token: 0x0600FDF2 RID: 65010 RVA: 0x003B9A60 File Offset: 0x003B7C60
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170038CF RID: 14543
		// (get) Token: 0x0600FDF3 RID: 65011 RVA: 0x003B9A74 File Offset: 0x003B7C74
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170038D0 RID: 14544
		// (get) Token: 0x0600FDF4 RID: 65012 RVA: 0x003B9A88 File Offset: 0x003B7C88
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170038D1 RID: 14545
		// (get) Token: 0x0600FDF5 RID: 65013 RVA: 0x003B9A9C File Offset: 0x003B7C9C
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170038D2 RID: 14546
		// (get) Token: 0x0600FDF6 RID: 65014 RVA: 0x003B9AB0 File Offset: 0x003B7CB0
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170038D3 RID: 14547
		// (get) Token: 0x0600FDF7 RID: 65015 RVA: 0x003B9AC4 File Offset: 0x003B7CC4
		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Pandora);
			}
		}

		// Token: 0x0600FDF8 RID: 65016 RVA: 0x003B9ADD File Offset: 0x003B7CDD
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<PandoraDocument>(PandoraDocument.uuID);
			this._showItemDoc = XDocuments.GetSpecificDocument<XShowGetItemDocument>(XShowGetItemDocument.uuID);
		}

		// Token: 0x0600FDF9 RID: 65017 RVA: 0x003B9B08 File Offset: 0x003B7D08
		public override int[] GetTitanBarItems()
		{
			return new int[]
			{
				(int)this._doc.PandoraData.PandoraID,
				(int)this._doc.PandoraData.FireID
			};
		}

		// Token: 0x0600FDFA RID: 65018 RVA: 0x003B9B48 File Offset: 0x003B7D48
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

		// Token: 0x0600FDFB RID: 65019 RVA: 0x003B9DB4 File Offset: 0x003B7FB4
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

		// Token: 0x0600FDFC RID: 65020 RVA: 0x003B9E0E File Offset: 0x003B800E
		public override void StackRefresh()
		{
			base.StackRefresh();
			base.Alloc3DAvatarPool("PandoraView");
			this._showItemDoc.bIgonre = true;
		}

		// Token: 0x0600FDFD RID: 65021 RVA: 0x003B9E31 File Offset: 0x003B8031
		public override void LeaveStackTop()
		{
			base.LeaveStackTop();
			this._showItemDoc.bIgonre = false;
		}

		// Token: 0x0600FDFE RID: 65022 RVA: 0x003B9E48 File Offset: 0x003B8048
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

		// Token: 0x0600FDFF RID: 65023 RVA: 0x003B9EA8 File Offset: 0x003B80A8
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

		// Token: 0x0600FE00 RID: 65024 RVA: 0x003B9FAB File Offset: 0x003B81AB
		private void OnBackClicked(IXUISprite sp)
		{
			this.SetVisible(false, true);
		}

		// Token: 0x0600FE01 RID: 65025 RVA: 0x003B9FB8 File Offset: 0x003B81B8
		private bool OnOnceButtonClicked(IXUIButton button)
		{
			this._doc.SendPandoraLottery(true);
			return true;
		}

		// Token: 0x0600FE02 RID: 65026 RVA: 0x003B9FD8 File Offset: 0x003B81D8
		private bool OnTenButtonClicked(IXUIButton button)
		{
			this._doc.SendPandoraLottery(false);
			return true;
		}

		// Token: 0x0600FE03 RID: 65027 RVA: 0x003B9FF8 File Offset: 0x003B81F8
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

		// Token: 0x0600FE04 RID: 65028 RVA: 0x003BA050 File Offset: 0x003B8250
		private bool OnItemListButtonClicked(IXUIButton button)
		{
			DlgHandlerBase.EnsureCreate<ItemListHandler>(ref this._itemListHandler, base.uiBehaviour.transform, false, null);
			this._itemListHandler.ShowItemList(PandoraDocument.ItemList);
			return true;
		}

		// Token: 0x0600FE05 RID: 65029 RVA: 0x003BA090 File Offset: 0x003B8290
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

		// Token: 0x0600FE06 RID: 65030 RVA: 0x003BA0F8 File Offset: 0x003B82F8
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

		// Token: 0x0600FE07 RID: 65031 RVA: 0x003BA160 File Offset: 0x003B8360
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

		// Token: 0x0600FE08 RID: 65032 RVA: 0x003BA1C8 File Offset: 0x003B83C8
		public void ShowDisplayFrame()
		{
			base.uiBehaviour.m_DisplayFrame.gameObject.SetActive(true);
			base.uiBehaviour.m_RewardFrame.gameObject.SetActive(false);
			base.uiBehaviour.m_BackButton.SetVisible(true);
			base.uiBehaviour.m_OnceButton.SetVisible(true);
			base.uiBehaviour.m_TenButton.SetVisible(true);
			this.RefreshDummy();
		}

		// Token: 0x0600FE09 RID: 65033 RVA: 0x003BA244 File Offset: 0x003B8444
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

		// Token: 0x0600FE0A RID: 65034 RVA: 0x003BA464 File Offset: 0x003B8664
		private uint TransItemToPresentID(uint itemid)
		{
			uint petID = XPetDocument.GetPetID(itemid);
			return XPetDocument.GetPresentID(petID);
		}

		// Token: 0x0600FE0B RID: 65035 RVA: 0x003BA484 File Offset: 0x003B8684
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

		// Token: 0x0600FE0C RID: 65036 RVA: 0x003BA504 File Offset: 0x003B8704
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

		// Token: 0x0600FE0D RID: 65037 RVA: 0x003BA5C8 File Offset: 0x003B87C8
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

		// Token: 0x0600FE0E RID: 65038 RVA: 0x003BA670 File Offset: 0x003B8870
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

		// Token: 0x0600FE0F RID: 65039 RVA: 0x003BA8A0 File Offset: 0x003B8AA0
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

		// Token: 0x0600FE10 RID: 65040 RVA: 0x003BA924 File Offset: 0x003B8B24
		private void ClearAllFx()
		{
			for (int i = 0; i < this.m_FxList.Count; i++)
			{
				this._doc.DestroyFx(this.m_FxList[i]);
			}
			this.m_FxList.Clear();
		}

		// Token: 0x0400701F RID: 28703
		private PandoraDocument _doc;

		// Token: 0x04007020 RID: 28704
		private XShowGetItemDocument _showItemDoc;

		// Token: 0x04007021 RID: 28705
		private ItemListHandler _itemListHandler;

		// Token: 0x04007022 RID: 28706
		private XFx m_OpenFx = null;

		// Token: 0x04007023 RID: 28707
		private List<XFx> m_FxList = new List<XFx>();

		// Token: 0x04007024 RID: 28708
		private XDummy[] m_Dummy = new XDummy[3];

		// Token: 0x04007025 RID: 28709
		private Vector3[] m_DummyAngle = new Vector3[3];

		// Token: 0x04007026 RID: 28710
		private Vector3[] m_DummyScale = new Vector3[3];

		// Token: 0x04007027 RID: 28711
		private const int _avatarSlot = 8;

		// Token: 0x04007028 RID: 28712
		private uint _fxTimeToken = 0U;

		// Token: 0x04007029 RID: 28713
		private OutLook m_outLook;
	}
}
