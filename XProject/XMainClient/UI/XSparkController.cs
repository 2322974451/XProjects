using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XSparkController
	{

		public Rect Region { get; set; }

		public uint Count { get; set; }

		public void InitSprite(GameObject parent, GameObject target)
		{
			this.m_Pool.SetupPool(parent, target, 2U, false);
		}

		public void InitScaleRange(float min, float max)
		{
			this._ScaleMax = max;
			this._ScaleMin = min;
		}

		public void InitDelayRange(float min, float max)
		{
			this._DelayMax = max;
			this._DelayMin = min;
		}

		public void InitFrameRateRange(int min, int max)
		{
			this._FrameRateMax = max;
			this._FrameRateMin = min;
		}

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

		public void StopAll()
		{
			foreach (uint token in this.m_TimeTokens.Values)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(token);
			}
			this.m_TimeTokens.Clear();
		}

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

		private void _SparkShow(object o)
		{
			GameObject gameObject = o as GameObject;
			IXUISpriteAnimation ixuispriteAnimation = gameObject.GetComponent("XUISpriteAnimation") as IXUISpriteAnimation;
			ixuispriteAnimation.Reset();
			gameObject.SetActive(true);
			this.m_TimeTokens.Remove(gameObject);
		}

		private void _OnSparkFinish(IXUISpriteAnimation anim)
		{
			this._GenerateSpark(anim.gameObject, false);
		}

		private XUIPool m_Pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private float _ScaleMin = 1f;

		private float _ScaleMax = 2f;

		private float _DelayMin = 1f;

		private float _DelayMax = 6f;

		private int _FrameRateMin = 10;

		private int _FrameRateMax = 20;

		private Dictionary<GameObject, uint> m_TimeTokens = new Dictionary<GameObject, uint>();
	}
}
