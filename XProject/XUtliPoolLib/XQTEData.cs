using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{

	[Serializable]
	public class XQTEData
	{

		[SerializeField]
		public int QTE = 0;

		[SerializeField]
		[DefaultValue(0f)]
		public float At = 0f;

		[SerializeField]
		[DefaultValue(0f)]
		public float End = 0f;
	}
}
