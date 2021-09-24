using System;

namespace XUtliPoolLib
{

	public interface IXCurve
	{

		int length { get; }

		float Evaluate(float time);

		float GetValue(int index);

		float GetTime(int index);

		float GetMaxValue();

		float GetLandValue();
	}
}
