using System;

namespace XUtliPoolLib
{

	public interface IXVideo : IXInterface
	{

		void Play(bool loop = false);

		void Stop();

		bool isPlaying { get; }
	}
}
