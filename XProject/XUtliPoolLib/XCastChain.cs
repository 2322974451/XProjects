using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{

	[Serializable]
	public class XCastChain
	{

		[SerializeField]
		[DefaultValue(0f)]
		public float At = 0f;

		[SerializeField]
		[DefaultValue(0)]
		public int TemplateID = 0;

		[SerializeField]
		public string Name = null;
	}
}
