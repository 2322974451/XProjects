using System;

namespace XMainClient
{

	internal class XSkillExternalBuffArgs : XSkillExternalArgs
	{

		public XSkillExternalBuffArgs()
		{
			this.xBuffDesc.Reset();
			this.xTarget = null;
		}

		public override void Recycle()
		{
			this.xBuffDesc.Reset();
			this.xTarget = null;
			base.Recycle();
			XEventPool<XSkillExternalBuffArgs>.Recycle(this);
		}

		public BuffDesc xBuffDesc = default(BuffDesc);

		public XEntity xTarget;
	}
}
