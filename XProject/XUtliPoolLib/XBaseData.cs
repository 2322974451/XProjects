using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{

	[Serializable]
	public class XBaseData
	{

		[SerializeField]
		[DefaultValue(0)]
		public int Index = 0;
	}
}
