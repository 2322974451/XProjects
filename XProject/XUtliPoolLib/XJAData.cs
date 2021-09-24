using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{

	[Serializable]
	public class XJAData : XBaseData
	{

		[SerializeField]
		public string Next_Name = null;

		[SerializeField]
		public string Name = null;

		[SerializeField]
		[DefaultValue(0f)]
		public float At;

		[SerializeField]
		[DefaultValue(0f)]
		public float End;

		[SerializeField]
		[DefaultValue(0f)]
		public float Point;
	}
}
