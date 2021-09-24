using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class ParabolaFx
	{

		public ParabolaFx(string fxPath, float duration, float speedY, Vector3 startPos, Vector3 endPos)
		{
			this._fx = XSingleton<XFxMgr>.singleton.CreateFx(fxPath, null, true);
			this._fx.Play(startPos, Quaternion.identity, Vector3.one, 1f);
			this._duration = duration;
			this._startTime = Time.time;
			this._startPos = startPos;
			this._endPos = endPos;
			this._speedY = speedY;
			this._speedAddY = -speedY * 2f / duration;
		}

		public bool Update()
		{
			float num = Time.time - this._startTime;
			bool flag = num > this._duration;
			bool result;
			if (flag)
			{
				this.Destroy();
				result = false;
			}
			else
			{
				Vector3 position = Vector3.Lerp(this._startPos, this._endPos, num / this._duration);
				position.y = this._startPos.y + this._speedY * num + this._speedAddY * num * num / 2f;
				this._fx.Position = position;
				result = true;
			}
			return result;
		}

		public void Destroy()
		{
			XSingleton<XFxMgr>.singleton.DestroyFx(this._fx, true);
		}

		private Vector3 _startPos;

		private Vector3 _endPos;

		private float _speedY;

		private float _speedAddY;

		private float _duration;

		private float _startTime;

		private XFx _fx;
	}
}
