using System;

namespace XMainClient
{

	internal class XLevelInfo
	{

		public XLevelInfo()
		{
			this.infoName = "";
			this.x = (this.y = (this.z = (this.face = (this.width = (this.height = (this.thickness = 0f))))));
			this.enable = false;
		}

		public string infoName;

		public float x;

		public float y;

		public float z;

		public float face;

		public float width;

		public float height;

		public float thickness;

		public bool enable;
	}
}
