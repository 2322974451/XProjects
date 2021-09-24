using System;
using UnityEngine;

namespace XMainClient
{

	internal class XAudioExParam
	{

		public XAudioExParam(XEntity e)
		{
			this._caster = e;
			this._3dPos = Vector3.zero;
		}

		public XAudioExParam(Vector3 pos)
		{
			this._caster = null;
			this._3dPos = pos;
		}

		public XAudioExParam(string param, float v)
		{
			this._caster = null;
			this._3dPos = Vector3.zero;
			this._fmodParam = param;
			this._fmodValue = v;
		}

		public XEntity _caster;

		public Vector3 _3dPos;

		public string _fmodParam;

		public float _fmodValue;
	}
}
