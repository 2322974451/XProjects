using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E6E RID: 3694
	internal class XChest
	{
		// Token: 0x0600C5DF RID: 50655 RVA: 0x002BCADC File Offset: 0x002BACDC
		public XChest(GameObject chest, string chestName = null)
		{
			bool flag = chestName != null;
			if (flag)
			{
				this.m_isActivityChest = true;
				this.NOT_OPEN_SPRITE = chestName;
				this.OPENING_SPRITE = chestName + "_1";
				this.OPENED_SPRITE = chestName + "_2";
			}
			else
			{
				this.m_isActivityChest = false;
			}
			this.m_ChestGo = chest;
			this.m_Chest = (chest.GetComponent("XUISprite") as IXUISprite);
			Transform transform = chest.transform.FindChild("Exp");
			bool flag2 = transform != null;
			if (flag2)
			{
				this.m_Exp = (transform.GetComponent("XUILabel") as IXUILabel);
				this.m_ExpTween = XNumberTween.Create(this.m_Exp);
			}
			transform = chest.transform.FindChild("RedPoint");
			bool flag3 = transform != null;
			if (flag3)
			{
				this.m_RedPoint = transform.gameObject;
			}
		}

		// Token: 0x0600C5E0 RID: 50656 RVA: 0x002BCBE4 File Offset: 0x002BADE4
		public void SetExp(uint num)
		{
			this.m_RequiredExp = num;
			bool flag = this.m_ExpTween != null;
			if (flag)
			{
				this.m_ExpTween.SetNumberWithTween((ulong)num, "", false, true);
			}
			this.ResetState();
		}

		// Token: 0x0600C5E1 RID: 50657 RVA: 0x002BCC28 File Offset: 0x002BAE28
		public void Update(uint exp)
		{
			bool flag = !this.m_isActivityChest;
			if (flag)
			{
				this.m_Chest.SetGrey(this.m_RequiredExp <= exp);
			}
			bool flag2 = this.m_RequiredExp <= exp && !this.m_bOpened;
			if (flag2)
			{
				bool flag3 = this.m_ActiveFx == null;
				if (flag3)
				{
					this.m_ActiveFx = XSingleton<XFxMgr>.singleton.CreateFx("Effects/FX_Particle/UIfx/UI_hyd", null, true);
					this.m_ActiveFx.Play(this.m_ChestGo.transform, Vector3.zero, Vector3.one, 1f, true, false);
				}
			}
			else
			{
				bool flag4 = this.m_ActiveFx != null;
				if (flag4)
				{
					XSingleton<XFxMgr>.singleton.DestroyFx(this.m_ActiveFx, true);
					this.m_ActiveFx = null;
				}
			}
			bool flag5 = this.m_RedPoint != null;
			if (flag5)
			{
				this.m_RedPoint.SetActive(this.m_RequiredExp <= exp && !this.m_bOpened);
			}
		}

		// Token: 0x0600C5E2 RID: 50658 RVA: 0x002BCD24 File Offset: 0x002BAF24
		public void ResetState()
		{
			bool flag = this.m_ActiveFx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_ActiveFx, true);
			}
			bool flag2 = this.m_OpenFx != null;
			if (flag2)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_OpenFx, true);
			}
			bool flag3 = this.m_RedPoint != null;
			if (flag3)
			{
				this.m_RedPoint.SetActive(false);
			}
		}

		// Token: 0x0600C5E3 RID: 50659 RVA: 0x002BCD94 File Offset: 0x002BAF94
		private void DestroyOpenFx(object e)
		{
			bool flag = this.m_OpenFx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_OpenFx, true);
			}
		}

		// Token: 0x0600C5E4 RID: 50660 RVA: 0x002BCDC4 File Offset: 0x002BAFC4
		public void Open()
		{
			this.m_Chest.SetSprite(this.OPENING_SPRITE);
			bool flag = this.m_OpenFx == null;
			if (flag)
			{
				this.m_OpenFx = XSingleton<XFxMgr>.singleton.CreateFx("Effects/FX_Particle/UIfx/UI_hyd_01", null, true);
			}
			XSingleton<XTimerMgr>.singleton.SetTimer(1.2f, new XTimerMgr.ElapsedEventHandler(this.DestroyOpenFx), null);
			this.m_OpenFx.Play(this.m_ChestGo.transform, Vector3.zero, Vector3.one, 1f, true, false);
			this.m_bOpened = true;
			this.Update(this.m_RequiredExp);
			bool flag2 = this.m_RedPoint != null;
			if (flag2)
			{
				this.m_RedPoint.SetActive(false);
			}
		}

		// Token: 0x17003491 RID: 13457
		// (get) Token: 0x0600C5E5 RID: 50661 RVA: 0x002BCE80 File Offset: 0x002BB080
		// (set) Token: 0x0600C5E6 RID: 50662 RVA: 0x002BCEA2 File Offset: 0x002BB0A2
		public Vector3 Position
		{
			get
			{
				return this.m_ChestGo.transform.localPosition;
			}
			set
			{
				this.m_ChestGo.transform.localPosition = value;
			}
		}

		// Token: 0x17003492 RID: 13458
		// (set) Token: 0x0600C5E7 RID: 50663 RVA: 0x002BCEB8 File Offset: 0x002BB0B8
		public bool Opened
		{
			set
			{
				this.m_bOpened = value;
				bool bOpened = this.m_bOpened;
				if (bOpened)
				{
					this.m_Chest.SetSprite(this.OPENED_SPRITE);
				}
				else
				{
					this.m_Chest.SetSprite(this.NOT_OPEN_SPRITE);
				}
			}
		}

		// Token: 0x040056C7 RID: 22215
		private GameObject m_ChestGo;

		// Token: 0x040056C8 RID: 22216
		public IXUISprite m_Chest;

		// Token: 0x040056C9 RID: 22217
		private XFx m_OpenFx;

		// Token: 0x040056CA RID: 22218
		private XFx m_ActiveFx;

		// Token: 0x040056CB RID: 22219
		private IXUILabel m_Exp;

		// Token: 0x040056CC RID: 22220
		private XNumberTween m_ExpTween;

		// Token: 0x040056CD RID: 22221
		private GameObject m_RedPoint;

		// Token: 0x040056CE RID: 22222
		public uint m_RequiredExp;

		// Token: 0x040056CF RID: 22223
		private bool m_isActivityChest;

		// Token: 0x040056D0 RID: 22224
		private bool m_bOpened;

		// Token: 0x040056D1 RID: 22225
		private string NOT_OPEN_SPRITE = "bx3";

		// Token: 0x040056D2 RID: 22226
		private string OPENING_SPRITE = "bx3_1";

		// Token: 0x040056D3 RID: 22227
		private string OPENED_SPRITE = "bx3_2";
	}
}
