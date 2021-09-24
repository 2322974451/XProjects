using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XChest
	{

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

		private void DestroyOpenFx(object e)
		{
			bool flag = this.m_OpenFx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_OpenFx, true);
			}
		}

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

		private GameObject m_ChestGo;

		public IXUISprite m_Chest;

		private XFx m_OpenFx;

		private XFx m_ActiveFx;

		private IXUILabel m_Exp;

		private XNumberTween m_ExpTween;

		private GameObject m_RedPoint;

		public uint m_RequiredExp;

		private bool m_isActivityChest;

		private bool m_bOpened;

		private string NOT_OPEN_SPRITE = "bx3";

		private string OPENING_SPRITE = "bx3_1";

		private string OPENED_SPRITE = "bx3_2";
	}
}
