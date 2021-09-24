using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{

	[Serializable]
	public class XCameraPostEffectData
	{

		[SerializeField]
		[DefaultValue(0f)]
		public float At;

		[SerializeField]
		[DefaultValue(0f)]
		public float End;

		[SerializeField]
		public string Effect = null;

		[SerializeField]
		public string Shader = null;

		[SerializeField]
		[DefaultValue(false)]
		public bool SolidBlack;

		[SerializeField]
		[DefaultValue(0f)]
		public float Solid_At;

		[SerializeField]
		[DefaultValue(0f)]
		public float Solid_End;
	}
}
