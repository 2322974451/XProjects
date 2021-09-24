using System;
using UnityEngine;

namespace XUtliPoolLib
{

	public interface IControlParticle
	{

		void RefreshRenderQueue(bool resetWidget);

		void SetWidget(GameObject go);
	}
}
