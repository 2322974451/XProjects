using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	public class XAssociatedCamera : IAssociatedCamera, IXInterface
	{

		public Camera Get()
		{
			return XSingleton<XScene>.singleton.AssociatedCamera;
		}

		public bool Deprecated { get; set; }
	}
}
