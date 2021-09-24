using System;
using UnityEngine;

namespace XUtliPoolLib
{

	public class XLocalPRSAsyncData
	{

		public void Reset()
		{
			this.localPos = Vector3.zero;
			this.localRotation = Quaternion.identity;
			this.localScale = Vector3.one;
			this.mask = 0;
			CommonObjectPool<XLocalPRSAsyncData>.Release(this);
		}

		public Vector3 localPos = Vector3.zero;

		public Quaternion localRotation = Quaternion.identity;

		public Vector3 localScale = Vector3.one;

		public short mask = 0;
	}
}
