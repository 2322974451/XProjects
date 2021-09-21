using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CE9 RID: 3305
	internal class EquipSetWearingHandler : DlgHandlerBase
	{
		// Token: 0x1700328C RID: 12940
		// (get) Token: 0x0600B912 RID: 47378 RVA: 0x002583A0 File Offset: 0x002565A0
		protected override string FileName
		{
			get
			{
				return "ItemNew/WearingPanel";
			}
		}

		// Token: 0x0600B913 RID: 47379 RVA: 0x002583B8 File Offset: 0x002565B8
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

		// Token: 0x0600B914 RID: 47380 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void OnUnload()
		{
		}

		// Token: 0x0600B915 RID: 47381 RVA: 0x002584C4 File Offset: 0x002566C4
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

		// Token: 0x0600B916 RID: 47382 RVA: 0x0025856C File Offset: 0x0025676C
		public override void UnRegisterEvent()
		{
			this.m_Close.RegisterClickEventHandler(null);
			this.m_ClothFashion.RegisterSpriteClickEventHandler(null);
			this.m_ClothEquip.RegisterSpriteClickEventHandler(null);
			this.m_WeaponFashion.RegisterSpriteClickEventHandler(null);
			this.m_weaponEquip.RegisterSpriteClickEventHandler(null);
		}

		// Token: 0x0600B917 RID: 47383 RVA: 0x002585BC File Offset: 0x002567BC
		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Item_Equip);
			return true;
		}

		// Token: 0x0600B918 RID: 47384 RVA: 0x001F8A12 File Offset: 0x001F6C12
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		// Token: 0x0600B919 RID: 47385 RVA: 0x002585DC File Offset: 0x002567DC
		protected override void OnHide()
		{
			base.OnHide();
			DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.OnPopHandlerSetVisible(false, null);
		}

		// Token: 0x0600B91A RID: 47386 RVA: 0x002585F3 File Offset: 0x002567F3
		public override void RefreshData()
		{
			base.RefreshData();
			this.m_SettingPanel.gameObject.SetActive(true);
		}

		// Token: 0x0600B91B RID: 47387 RVA: 0x00258610 File Offset: 0x00256810
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

		// Token: 0x0600B91C RID: 47388 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void ClickClothFashionHandler(IXUISprite sprite)
		{
		}

		// Token: 0x0600B91D RID: 47389 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void ClickClothEquipHandler(IXUISprite sprite)
		{
		}

		// Token: 0x0600B91E RID: 47390 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void ClickWeaponFashionHandler(IXUISprite sprite)
		{
		}

		// Token: 0x0600B91F RID: 47391 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void ClickWeaponEquipHandler(IXUISprite sprite)
		{
		}

		// Token: 0x0600B920 RID: 47392 RVA: 0x00258688 File Offset: 0x00256888
		private bool ClickCloseHandler(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x040049A4 RID: 18852
		private IXUIButton m_Help;

		// Token: 0x040049A5 RID: 18853
		private IXUIButton m_Close;

		// Token: 0x040049A6 RID: 18854
		private IXUISprite m_ClothFashion;

		// Token: 0x040049A7 RID: 18855
		private IXUISprite m_ClothEquip;

		// Token: 0x040049A8 RID: 18856
		private IXUISprite m_WeaponFashion;

		// Token: 0x040049A9 RID: 18857
		private IXUISprite m_weaponEquip;

		// Token: 0x040049AA RID: 18858
		private Transform m_SettingPanel;
	}
}
