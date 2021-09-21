using System;
using System.ComponentModel;
using System.Xml.Serialization;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x0200020B RID: 523
	[Serializable]
	public class XCameraMotionData : ICloneable
	{
		// Token: 0x06000BFA RID: 3066 RVA: 0x0003E928 File Offset: 0x0003CB28
		public XCameraMotionData()
		{
			this.Follow_Position = true;
		}

		// Token: 0x06000BFB RID: 3067 RVA: 0x0003E978 File Offset: 0x0003CB78
		public object Clone()
		{
			return base.MemberwiseClone();
		}

		// Token: 0x040006E7 RID: 1767
		[SerializeField]
		[DefaultValue(0f)]
		public float At;

		// Token: 0x040006E8 RID: 1768
		[SerializeField]
		[XmlIgnore]
		public string Motion = null;

		// Token: 0x040006E9 RID: 1769
		[SerializeField]
		[XmlIgnore]
		public CameraMotionType MotionType = CameraMotionType.CameraBased;

		// Token: 0x040006EA RID: 1770
		[SerializeField]
		public string Motion3D = null;

		// Token: 0x040006EB RID: 1771
		[SerializeField]
		public CameraMotionType Motion3DType = CameraMotionType.CameraBased;

		// Token: 0x040006EC RID: 1772
		[SerializeField]
		public string Motion2_5D = null;

		// Token: 0x040006ED RID: 1773
		[SerializeField]
		public CameraMotionType Motion2_5DType = CameraMotionType.CameraBased;

		// Token: 0x040006EE RID: 1774
		[SerializeField]
		[DefaultValue(false)]
		public bool LookAt_Target;

		// Token: 0x040006EF RID: 1775
		[SerializeField]
		[DefaultValue(true)]
		public bool Follow_Position;

		// Token: 0x040006F0 RID: 1776
		[SerializeField]
		[DefaultValue(false)]
		public bool AutoSync_At_Begin;

		// Token: 0x040006F1 RID: 1777
		[SerializeField]
		public CameraMotionSpace Coordinate = CameraMotionSpace.World;
	}
}
