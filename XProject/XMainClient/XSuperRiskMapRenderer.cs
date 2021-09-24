using System;
using UnityEngine;

namespace XMainClient
{

	internal class XSuperRiskMapRenderer
	{

		public void SetInitInfo(Vector2 _ZeroPos, float stepx, float stepy)
		{
			this.ZeroPos = _ZeroPos;
			this.StepSizeX = stepx;
			this.StepSizeY = stepy;
		}

		public Vector2 CoordToUI(Coordinate coord)
		{
			return this.ZeroPos + new Vector2((float)coord.x * this.StepSizeX, (float)(-(float)coord.y) * this.StepSizeY);
		}

		private Vector2 ZeroPos = Vector2.zero;

		private float StepSizeX = 0f;

		private float StepSizeY = 0f;
	}
}
