using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{

	[Serializable]
	public class XCombinedData : XBaseData
	{

		[SerializeField]
		public string Name = null;

		[SerializeField]
		[DefaultValue(0f)]
		public float At;

		[SerializeField]
		[DefaultValue(0f)]
		public float End;

		[SerializeField]
		[DefaultValue(false)]
		public bool Override_Presentation;
	}
}
