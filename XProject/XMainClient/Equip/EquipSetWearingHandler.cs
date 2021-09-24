using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class EquipSetWearingHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "ItemNew/WearingPanel";
			}
		}

		protected override void Init()
		{
			base.Init();
			this.m_SettingPanel = base.transform.FindChild("Panel");
			this.m_Close = (base.transform.FindChild("Panel/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_ClothFashion = (base.transform.FindChild("Panel/Cloth_fishion").GetComponent("XUISprite") as IXUISprite);
			this.m_ClothEquip = (base.transform.FindChild("Panel/Cloth_equip").GetComponent("XUISprite") as IXUISprite);
			this.m_weaponEquip = (base.transform.FindChild("Panel/Weapon_equip").GetComponent("XUISprite") as IXUISprite);
			this.m_WeaponFashion = (base.transform.FindChild("Panel/Weapon_fashion").GetComponent("XUISprite") as IXUISprite);
			this.m_Help = (base.transform.Find("Help").GetComponent("XUIButton") as IXUIButton);
		}

		public override void OnUnload()
		{
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickCloseHandler));
			this.m_ClothFashion.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.ClickClothFashionHandler));
			this.m_ClothEquip.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.ClickClothEquipHandler));
			this.m_WeaponFashion.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.ClickWeaponFashionHandler));
			this.m_weaponEquip.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.ClickWeaponEquipHandler));
			this.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
		}

		public override void UnRegisterEvent()
		{
			this.m_Close.RegisterClickEventHandler(null);
			this.m_ClothFashion.RegisterSpriteClickEventHandler(null);
			this.m_ClothEquip.RegisterSpriteClickEventHandler(null);
			this.m_WeaponFashion.RegisterSpriteClickEventHandler(null);
			this.m_weaponEquip.RegisterSpriteClickEventHandler(null);
		}

		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Item_Equip);
			return true;
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		protected override void OnHide()
		{
			base.OnHide();
			DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.OnPopHandlerSetVisible(false, null);
		}

		public override void RefreshData()
		{
			base.RefreshData();
			this.m_SettingPanel.gameObject.SetActive(true);
		}

		private void SetStateSprite(IXUISprite sprite, bool visible)
		{
			IXUISprite ixuisprite = sprite.gameObject.transform.FindChild("Sprite").GetComponent("XUISprite") as IXUISprite;
			bool flag = ixuisprite == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog(XSingleton<XCommon>.singleton.StringCombine("State XUISprite is NULL", sprite.gameObject.name), null, null, null, null, null);
			}
			else
			{
				ixuisprite.SetAlpha((float)(visible ? 1 : 0));
			}
		}

		private void ClickClothFashionHandler(IXUISprite sprite)
		{
		}

		private void ClickClothEquipHandler(IXUISprite sprite)
		{
		}

		private void ClickWeaponFashionHandler(IXUISprite sprite)
		{
		}

		private void ClickWeaponEquipHandler(IXUISprite sprite)
		{
		}

		private bool ClickCloseHandler(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		private IXUIButton m_Help;

		private IXUIButton m_Close;

		private IXUISprite m_ClothFashion;

		private IXUISprite m_ClothEquip;

		private IXUISprite m_WeaponFashion;

		private IXUISprite m_weaponEquip;

		private Transform m_SettingPanel;
	}
}
