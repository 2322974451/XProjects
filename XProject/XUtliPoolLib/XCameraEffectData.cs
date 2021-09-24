using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{

	[Serializable]
	public class XCameraEffectData : XBaseData
	{

		public XCameraEffectData()
		{
			this.ShakeX = true;
			this.ShakeY = true;
			this.ShakeZ = true;
		}

		[SerializeField]
		[DefaultValue(0f)]
		public float Time;

		[SerializeField]
		[DefaultValue(0f)]
		public float FovAmp;

		[SerializeField]
		[DefaultValue(0f)]
		public float Frequency;

		[SerializeField]
		public CameraMotionSpace Coordinate = CameraMotionSpace.World;

		[SerializeField]
		[DefaultValue(true)]
		public bool ShakeX;

		[SerializeField]
		[DefaultValue(true)]
		public bool ShakeY;

		[SerializeField]
		[DefaultValue(true)]
		public bool ShakeZ;

		[SerializeField]
		[DefaultValue(0f)]
		public float AmplitudeX;

		[SerializeField]
		[DefaultValue(0f)]
		public float AmplitudeY;

		[SerializeField]
		[DefaultValue(0f)]
		public float AmplitudeZ;

		[SerializeField]
		[DefaultValue(0f)]
		public float At;

		[SerializeField]
		[DefaultValue(false)]
		public bool Random;

		[SerializeField]
		[DefaultValue(false)]
		public bool Combined;
	}
}
