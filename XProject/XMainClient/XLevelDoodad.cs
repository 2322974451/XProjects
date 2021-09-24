using System;
using UnityEngine;

namespace XMainClient
{

	internal class XLevelDoodad
	{

		public uint index;

		public int wave;

		public Vector3 pos;

		public XDoodadType type;

		public uint id;

		public uint count;

		public uint token;

		public bool dropped;

		public bool picked;

		public float lastPickTime;

		public uint templateid;

		public ulong roleid;

		public GameObject doodad;

		public GameObject billboard;
	}
}
