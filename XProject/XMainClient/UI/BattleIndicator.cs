using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal struct BattleIndicator
	{

		public ulong id;

		public GameObject go;

		public IXUISprite sp;

		public Transform arrow;

		public IXUISprite leader;

		public XGameObject xGameObject;
	}
}
