using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI.CustomBattle
{

	internal class CustomBattleBountyModeListHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/CustomBattle/BountyModeListFrame";
			}
		}

		protected override void Init()
		{
			base.Init();
			this.timers.Clear();
			this._doc = XDocuments.GetSpecificDocument<XCustomBattleDocument>(XCustomBattleDocument.uuID);
			this._tip = (base.transform.Find("Bg/Tip").GetComponent("XUILabel") as IXUILabel);
			this._tip.SetText(XSingleton<XStringTable>.singleton.GetString("BountyModeGameTip"));
			this._scroll_view = (base.transform.Find("Bg/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this._wrap_content = (base.transform.Find("Bg/Panel/List").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this._wrap_content.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentUpdated));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._doc.SendCustomBattleQueryBountyMode();
		}

		protected override void OnHide()
		{
			this.DestoryAllFx();
			base.OnHide();
		}

		public override void OnUnload()
		{
			this.DestoryAllFx();
			base.OnUnload();
		}

		private void DestoryAllFx()
		{
			foreach (KeyValuePair<Transform, XFx> keyValuePair in this._fx_list)
			{
				this._doc.DestoryFx(keyValuePair.Value);
			}
			this._fx_list.Clear();
		}

		public override void RefreshData()
		{
			base.RefreshData();
			this._wrap_content.SetContentCount(this._doc.BountyList.Count, false);
			this._scroll_view.ResetPosition();
		}

		private void WrapContentUpdated(Transform t, int index)
		{
			bool flag = index < 0 || index >= this._doc.BountyList.Count;
			if (flag)
			{
				t.gameObject.SetActive(false);
			}
			else
			{
				this.SetupBounty(t, index);
			}
		}

		private void SetupBounty(Transform t, int index)
		{
			Transform transform = t.Find("Box");
			Transform transform2 = t.Find("BtnEnter");
			Transform transform3 = t.Find("Course");
			IXUILabel ixuilabel = t.Find("Course/win/Count").GetComponent("XUILabel") as IXUILabel;
			IXUISprite[] array = new IXUISprite[3];
			for (int i = 0; i < 3; i++)
			{
				array[i] = (t.Find(string.Format("Course/fail/Flag{0}/Flag", i)).GetComponent("XUISprite") as IXUISprite);
			}
			Transform transform4 = t.Find("Lock");
			IXUILabel ixuilabel2 = t.Find("Lock/Label").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite = t.GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel3 = t.Find("Game/name").GetComponent("XUILabel") as IXUILabel;
			IXUILabelSymbol ixuilabelSymbol = t.Find("Reward1").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			IXUILabelSymbol ixuilabelSymbol2 = t.Find("Reward2").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			IXUIButton ixuibutton = t.Find("BtnEnter").GetComponent("XUIButton") as IXUIButton;
			IXUILabelSymbol ixuilabelSymbol3 = t.Find("BtnEnter/Label").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			IXUISprite ixuisprite2 = t.Find("Game/Helpicon").GetComponent("XUISprite") as IXUISprite;
			Transform parent = t.Find("Box/Fx");
			IXUISprite ixuisprite3 = t.Find("Icon").GetComponent("XUISprite") as IXUISprite;
			IXUISprite ixuisprite4 = t.Find("Game/NameIcon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.ID = (ulong)index;
			ixuibutton.ID = (ulong)index;
			ixuisprite2.ID = (ulong)this._doc.BountyList[index].gameType;
			ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnHelpClicked));
			ixuilabel3.SetText(this._doc.BountyList[index].gameName);
			SeqListRef<uint> systemBattleReward = this._doc.GetSystemBattleReward((uint)this._doc.BountyList[index].gameID, this._doc.BountyList[index].winMax);
			ixuilabelSymbol.InputText = "";
			ixuilabelSymbol2.InputText = "";
			bool flag = systemBattleReward.Count > 0;
			if (flag)
			{
				ixuilabelSymbol.InputText = XLabelSymbolHelper.FormatSmallIcon((int)systemBattleReward[0, 0]) + " " + systemBattleReward[0, 1].ToString();
			}
			bool flag2 = systemBattleReward.Count > 1;
			if (flag2)
			{
				ixuilabelSymbol2.InputText = XLabelSymbolHelper.FormatSmallIcon((int)systemBattleReward[1, 0]) + " " + systemBattleReward[1, 1].ToString();
			}
			IXUILabel ixuilabel4 = t.Find("Box/CanFetch").GetComponent("XUILabel") as IXUILabel;
			bool flag3 = !this.timers.ContainsKey(t);
			if (flag3)
			{
				IXUILabel label = t.Find("Box/Time").GetComponent("XUILabel") as IXUILabel;
				this.timers.Add(t, new XLeftTimeCounter(label, true));
			}
			bool flag4 = this._fx_list.ContainsKey(t);
			if (flag4)
			{
				this._doc.DestoryFx(this._fx_list[t]);
				this._fx_list[t] = null;
			}
			XLeftTimeCounter xleftTimeCounter = this.timers[t];
			bool flag5 = this._doc.BountyList[index].boxLeftTime > 0U;
			if (flag5)
			{
				xleftTimeCounter.SetLeftTime(this._doc.BountyList[index].boxLeftTime, -1);
				ixuilabel4.gameObject.SetActive(false);
			}
			else
			{
				xleftTimeCounter.SetLeftTime(0f, -1);
				ixuilabel4.gameObject.SetActive(true);
				this._fx_list[t] = XSingleton<XFxMgr>.singleton.CreateUIFx("Effects/FX_Particle/UIfx/UI_BountyModeListFrame_Clip01", parent, this._fx_scale, false);
			}
			switch (this._doc.BountyList[index].status)
			{
			case CustomBattleRoleState.CustomBattle_RoleState_Ready:
				transform.gameObject.SetActive(false);
				transform2.gameObject.SetActive(true);
				transform3.gameObject.SetActive(false);
				transform4.gameObject.SetActive(false);
				ixuisprite.RegisterSpriteClickEventHandler(null);
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnJoinClicked));
				ixuilabelSymbol3.InputText = XLabelSymbolHelper.FormatSmallIcon((int)this._doc.BountyList[index].ticket.itemID) + " " + this._doc.BountyList[index].ticket.itemCount.ToString();
				break;
			case CustomBattleRoleState.CustomBattle_RoleState_Join:
				transform.gameObject.SetActive(false);
				transform2.gameObject.SetActive(false);
				transform3.gameObject.SetActive(true);
				transform4.gameObject.SetActive(false);
				ixuilabel.SetText(this._doc.BountyList[index].winCount.ToString());
				for (int j = 0; j < 3; j++)
				{
					array[j].SetAlpha((float)(((long)j < (long)((ulong)this._doc.BountyList[index].loseCount)) ? 1 : 0));
				}
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnEnterDetailClicked));
				ixuibutton.RegisterClickEventHandler(null);
				break;
			case CustomBattleRoleState.CustomBattle_RoleState_Reward:
				transform.gameObject.SetActive(true);
				transform2.gameObject.SetActive(false);
				transform3.gameObject.SetActive(false);
				transform4.gameObject.SetActive(false);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnEnterDetailClicked));
				ixuibutton.RegisterClickEventHandler(null);
				break;
			case CustomBattleRoleState.Custombattle_RoleState_Taken:
				transform.gameObject.SetActive(true);
				transform2.gameObject.SetActive(false);
				transform3.gameObject.SetActive(false);
				transform4.gameObject.SetActive(false);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnEnterDetailClicked));
				ixuibutton.RegisterClickEventHandler(null);
				break;
			default:
				transform.gameObject.SetActive(false);
				transform2.gameObject.SetActive(false);
				transform3.gameObject.SetActive(false);
				transform4.gameObject.SetActive(false);
				break;
			}
			CustomBattleSystemTable.RowData systemBattleData = this._doc.GetSystemBattleData((uint)this._doc.BountyList[index].gameID);
			bool flag6 = systemBattleData != null;
			if (flag6)
			{
				bool flag7 = systemBattleData.levellimit > XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
				if (flag7)
				{
					transform.gameObject.SetActive(false);
					transform2.gameObject.SetActive(false);
					transform3.gameObject.SetActive(false);
					transform4.gameObject.SetActive(true);
					ixuilabel2.SetText(XStringDefineProxy.GetString("LEVEL_REQUIRE_LEVEL", new object[]
					{
						systemBattleData.levellimit
					}));
					ixuisprite.RegisterSpriteClickEventHandler(null);
					ixuibutton.RegisterClickEventHandler(null);
				}
				ixuisprite3.SetSprite(systemBattleData.IconSpritePath);
				ixuisprite4.SetSprite(systemBattleData.TitleSpriteName);
			}
		}

		private void OnEnterDetailClicked(IXUISprite sp)
		{
			this.ShowDetailByIndex((int)sp.ID);
		}

		public void ShowDetailByIndex(int index)
		{
			bool flag = index >= this._doc.BountyList.Count;
			if (!flag)
			{
				this._doc.CurrentBountyData = this._doc.BountyList[index];
				DlgBase<CustomBattleView, TabDlgBehaviour>.singleton.ShowBountyModeDetailHandler();
			}
		}

		private void OnHelpClicked(IXUISprite sp)
		{
			CustomBattleTypeTable.RowData customBattleTypeData = this._doc.GetCustomBattleTypeData((int)sp.ID);
			string title = (customBattleTypeData != null) ? customBattleTypeData.name : "";
			string @string = XSingleton<XStringTable>.singleton.GetString(string.Format("CustomTypeTip_{0}", sp.ID));
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(title, @string);
		}

		private bool OnJoinClicked(IXUIButton button)
		{
			bool flag = (int)button.ID >= this._doc.BountyList.Count;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("JoinBountyCost", new object[]
				{
					XLabelSymbolHelper.FormatSmallIcon((int)this._doc.BountyList[(int)button.ID].ticket.itemID) + " " + this._doc.BountyList[(int)button.ID].ticket.itemCount.ToString()
				}), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.OnJoinOkClicked));
				this._cache_gameid = this._doc.BountyList[(int)button.ID].gameID;
				result = true;
			}
			return result;
		}

		private bool OnJoinOkClicked(IXUIButton button)
		{
			this._doc.SendCustomBattleJoin(this._cache_gameid, false, "");
			this._cache_gameid = 0UL;
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			return true;
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			foreach (KeyValuePair<Transform, XLeftTimeCounter> keyValuePair in this.timers)
			{
				bool activeInHierarchy = keyValuePair.Key.gameObject.activeInHierarchy;
				if (activeInHierarchy)
				{
					keyValuePair.Value.Update();
				}
			}
		}

		private XCustomBattleDocument _doc = null;

		private IXUILabel _tip;

		private IXUIScrollView _scroll_view;

		private IXUIWrapContent _wrap_content;

		private Dictionary<Transform, XLeftTimeCounter> timers = new Dictionary<Transform, XLeftTimeCounter>();

		private ulong _cache_gameid = 0UL;

		private Dictionary<Transform, XFx> _fx_list = new Dictionary<Transform, XFx>();

		private Vector3 _fx_scale = new Vector3(0.7f, 0.7f);
	}
}
