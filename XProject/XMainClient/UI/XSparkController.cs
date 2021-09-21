using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018BF RID: 6335
	internal class XSparkController
	{
		// Token: 0x17003A46 RID: 14918
		// (get) Token: 0x06010847 RID: 67655 RVA: 0x0040D78B File Offset: 0x0040B98B
		// (set) Token: 0x06010848 RID: 67656 RVA: 0x0040D793 File Offset: 0x0040B993
		public Rect Region { get; set; }

		// Token: 0x17003A47 RID: 14919
		// (get) Token: 0x06010849 RID: 67657 RVA: 0x0040D79C File Offset: 0x0040B99C
		// (set) Token: 0x0601084A RID: 67658 RVA: 0x0040D7A4 File Offset: 0x0040B9A4
		public uint Count { get; set; }

		// Token: 0x0601084B RID: 67659 RVA: 0x0040D7AD File Offset: 0x0040B9AD
		public void InitSprite(GameObject parent, GameObject target)
		{
			this.m_Pool.SetupPool(parent, target, 2U, false);
		}

		// Token: 0x0601084C RID: 67660 RVA: 0x0040D7C0 File Offset: 0x0040B9C0
		public void InitScaleRange(float min, float max)
		{
			this._ScaleMax = max;
			this._ScaleMin = min;
		}

		// Token: 0x0601084D RID: 67661 RVA: 0x0040D7D1 File Offset: 0x0040B9D1
		public void InitDelayRange(float min, float max)
		{
			this._DelayMax = max;
			this._DelayMin = min;
		}

		// Token: 0x0601084E RID: 67662 RVA: 0x0040D7E2 File Offset: 0x0040B9E2
		public void InitFrameRateRange(int min, int max)
		{
			this._FrameRateMax = max;
			this._FrameRateMin = min;
		}

		// Token: 0x0601084F RID: 67663 RVA: 0x0040D7F4 File Offset: 0x0040B9F4
		public void Setup()
		{
			this.StopAll();
			this.m_Pool.FakeReturnAll();
			int num = 0;
			while ((long)num < (long)((ulong)this.Count))
			{
				GameObject gameObject = this.m_Pool.FetchGameObject(false);
				IXUISpriteAnimation ixuispriteAnimation = gameObject.GetComponent("XUISpriteAnimation") as IXUISpriteAnimation;
				ixuispriteAnimation.RegisterFinishCallback(new SpriteAnimationFinishCallback(this._OnSparkFinish));
				this._GenerateSpark(gameObject, true);
				num++;
			}
			this.m_Pool.ActualReturnAll(false);
		}

		// Token: 0x06010850 RID: 67664 RVA: 0x0040D878 File Offset: 0x0040BA78
		public void StopAll()
		{
			foreach (uint token in this.m_TimeTokens.Values)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(token);
			}
			this.m_TimeTokens.Clear();
		}

		// Token: 0x06010851 RID: 67665 RVA: 0x0040D8E8 File Offset: 0x0040BAE8
		private void _GenerateSpark(GameObject go, bool bStart)
		{
			float interval = XSingleton<XCommon>.singleton.RandomFloat(this._DelayMin, this._DelayMax);
			int frameRate = XSingleton<XCommon>.singleton.RandomInt(this._FrameRateMin, this._FrameRateMax);
			float num = XSingleton<XCommon>.singleton.RandomFloat(this._ScaleMin, this._ScaleMax);
			Vector3 localPosition;
			localPosition.x = XSingleton<XCommon>.singleton.RandomFloat(this.Region.xMin, this.Region.xMax);
			localPosition.y = XSingleton<XCommon>.singleton.RandomFloat(this.Region.yMin, this.Region.yMax);
			localPosition.z = 0f;
			IXUISpriteAnimation ixuispriteAnimation = go.GetComponent("XUISpriteAnimation") as IXUISpriteAnimation;
			ixuispriteAnimation.SetFrameRate(frameRate);
			go.transform.localScale = Vector3.one * num;
			go.transform.localPosition = localPosition;
			uint value = XSingleton<XTimerMgr>.singleton.SetTimer(interval, new XTimerMgr.ElapsedEventHandler(this._SparkShow), go);
			this.m_TimeTokens.Add(go, value);
			go.SetActive(false);
		}

		// Token: 0x06010852 RID: 67666 RVA: 0x0040DA18 File Offset: 0x0040BC18
		private void _SparkShow(object o)
		{
			GameObject gameObject = o as GameObject;
			IXUISpriteAnimation ixuispriteAnimation = gameObject.GetComponent("XUISpriteAnimation") as IXUISpriteAnimation;
			ixuispriteAnimation.Reset();
			gameObject.SetActive(true);
			this.m_TimeTokens.Remove(gameObject);
		}

		// Token: 0x06010853 RID: 67667 RVA: 0x0040DA5A File Offset: 0x0040BC5A
		private void _OnSparkFinish(IXUISpriteAnimation anim)
		{
			this._GenerateSpark(anim.gameObject, false);
		}

		// Token: 0x04007789 RID: 30601
		private XUIPool m_Pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400778C RID: 30604
		private float _ScaleMin = 1f;

		// Token: 0x0400778D RID: 30605
		private float _ScaleMax = 2f;

		// Token: 0x0400778E RID: 30606
		private float _DelayMin = 1f;

		// Token: 0x0400778F RID: 30607
		private float _DelayMax = 6f;

		// Token: 0x04007790 RID: 30608
		private int _FrameRateMin = 10;

		// Token: 0x04007791 RID: 30609
		private int _FrameRateMax = 20;

		// Token: 0x04007792 RID: 30610
		private Dictionary<GameObject, uint> m_TimeTokens = new Dictionary<GameObject, uint>();
	}
}
