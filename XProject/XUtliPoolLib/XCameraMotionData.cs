using System;
using System.ComponentModel;
using System.Xml.Serialization;
using UnityEngine;

namespace XUtliPoolLib
{

	[Serializable]
	public class XCameraMotionData : ICloneable
	{

		public XCameraMotionData()
		{
			this.Follow_Position = true;
		}

		public object Clone()
		{
			return base.MemberwiseClone();
		}

		[SerializeField]
		[DefaultValue(0f)]
		public float At;

		[SerializeField]
		[XmlIgnore]
		public string Motion = null;

		[SerializeField]
		[XmlIgnore]
		public CameraMotionType MotionType = CameraMotionType.CameraBased;

		[SerializeField]
		public string Motion3D = null;

		[SerializeField]
		public CameraMotionType Motion3DType = CameraMotionType.CameraBased;

		[SerializeField]
		public string Motion2_5D = null;

		[SerializeField]
		public CameraMotionType Motion2_5DType = CameraMotionType.CameraBased;

		[SerializeField]
		[DefaultValue(false)]
		public bool LookAt_Target;

		[SerializeField]
		[DefaultValue(true)]
		public bool Follow_Position;

		[SerializeField]
		[DefaultValue(false)]
		public bool AutoSync_At_Begin;

		[SerializeField]
		public CameraMotionSpace Coordinate = CameraMotionSpace.World;
	}
}
