using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class TooltipParam : XSingleton<TooltipParam>
	{

		public void Reset()
		{
			this.BodyBag = null;
			this.bEquiped = false;
			this.bBinded = false;
			this.bShowPutInBtn = false;
			this.bShowTakeOutBtn = false;
			this.mainAttributes = null;
			this.compareAttributes = null;
			this.FashionOnBody = null;
		}

		public XBodyBag BodyBag = null;

		public List<uint> FashionOnBody;

		public bool bEquiped = false;

		public bool bBinded = false;

		public bool bShowPutInBtn = false;

		public bool bShowTakeOutBtn = false;

		public XAttributes mainAttributes = null;

		public XAttributes compareAttributes = null;
	}
}
