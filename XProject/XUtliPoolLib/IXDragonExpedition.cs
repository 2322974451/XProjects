using System;
using UnityEngine;

namespace XUtliPoolLib
{

	public interface IXDragonExpedition
	{

		void Drag(float delta);

		void Assign(float delta);

		GameObject Click();

		Transform GetGO(string name);

		void SetLimitPos(float MinPos);

		Camera GetDragonCamera();
	}
}
