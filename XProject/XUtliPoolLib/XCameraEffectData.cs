using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x02000212 RID: 530
	[Serializable]
	public class XCameraEffectData : XBaseData
	{
		// Token: 0x06000BFF RID: 3071 RVA: 0x0003EA12 File Offset: 0x0003CC12
		public XCameraEffectData()
		{
			this.ShakeX = true;
			this.ShakeY = true;
			this.ShakeZ = true;
		}

		// Token: 0x0400071C RID: 1820
		[SerializeField]
		[DefaultValue(0f)]
		public float Time;

		// Token: 0x0400071D RID: 1821
		[SerializeField]
		[DefaultValue(0f)]
		public float FovAmp;

		// Token: 0x0400071E RID: 1822
		[SerializeField]
		[DefaultValue(0f)]
		public float Frequency;

		// Token: 0x0400071F RID: 1823
		[SerializeField]
		public CameraMotionSpace Coordinate = CameraMotionSpace.World;

		// Token: 0x04000720 RID: 1824
		[SerializeField]
		[DefaultValue(true)]
		public bool ShakeX;

		// Token: 0x04000721 RID: 1825
		[SerializeField]
		[DefaultValue(true)]
		public bool ShakeY;

		// Token: 0x04000722 RID: 1826
		[SerializeField]
		[DefaultValue(true)]
		public bool ShakeZ;

		// Token: 0x04000723 RID: 1827
		[SerializeField]
		[DefaultValue(0f)]
		public float AmplitudeX;

		// Token: 0x04000724 RID: 1828
		[SerializeField]
		[DefaultValue(0f)]
		public float AmplitudeY;

		// Token: 0x04000725 RID: 1829
		[SerializeField]
		[DefaultValue(0f)]
		public float AmplitudeZ;

		// Token: 0x04000726 RID: 1830
		[SerializeField]
		[DefaultValue(0f)]
		public float At;

		// Token: 0x04000727 RID: 1831
		[SerializeField]
		[DefaultValue(false)]
		public bool Random;

		// Token: 0x04000728 RID: 1832
		[SerializeField]
		[DefaultValue(false)]
		public bool Combined;
	}
}
