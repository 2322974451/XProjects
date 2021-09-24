using System;
using UnityEngine;

namespace XUtliPoolLib
{

	public interface IRenderObject
	{

		int InstanceID { set; }

		bool IsSameObj(int id);

		void SetRenderLayer(int layer);

		void SetShader(int type);

		void ResetShader();

		void SetColor(byte r, byte g, byte b, byte a);

		void SetColor(Color32 c);

		void Clean();

		void Update();
	}
}
