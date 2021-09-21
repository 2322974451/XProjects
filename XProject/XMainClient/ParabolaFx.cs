using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200090F RID: 2319
	internal class ParabolaFx
	{
		// Token: 0x06008BF3 RID: 35827 RVA: 0x0012D2B0 File Offset: 0x0012B4B0
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

		// Token: 0x06008BF4 RID: 35828 RVA: 0x0012D330 File Offset: 0x0012B530
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

		// Token: 0x06008BF5 RID: 35829 RVA: 0x0012D3BC File Offset: 0x0012B5BC
		public void Destroy()
		{
			XSingleton<XFxMgr>.singleton.DestroyFx(this._fx, true);
		}

		// Token: 0x04002CF7 RID: 11511
		private Vector3 _startPos;

		// Token: 0x04002CF8 RID: 11512
		private Vector3 _endPos;

		// Token: 0x04002CF9 RID: 11513
		private float _speedY;

		// Token: 0x04002CFA RID: 11514
		private float _speedAddY;

		// Token: 0x04002CFB RID: 11515
		private float _duration;

		// Token: 0x04002CFC RID: 11516
		private float _startTime;

		// Token: 0x04002CFD RID: 11517
		private XFx _fx;
	}
}
