using System;
using UnityEngine;

namespace XUtliPoolLib
{

	public interface IXPositionGroup
	{

		void SetGroup(int index);

		Vector3 GetGroup(int index);
	}
}
