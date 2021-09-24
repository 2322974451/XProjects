using System;
using UnityEngine;

namespace XMainClient
{

	internal class CollectNpcInfo
	{

		public CollectNpcInfo(uint _npcID, Vector3 _pos, string _name)
		{
			this.id = _npcID;
			this.pos = _pos;
			this.use = false;
			this.name = _name;
		}

		public uint id = 0U;

		public bool use = false;

		public string name;

		public Vector3 pos = Vector3.zero;
	}
}
