using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class MiniMapElement
	{

		public IXUISprite sp;

		public Transform transform;

		public Vector3 pos;

		public XFx notice;

		public uint heroID = 0U;
	}
}
