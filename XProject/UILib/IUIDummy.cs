using System;

namespace UILib
{

	public interface IUIDummy : IUIWidget, IUIRect
	{

		int RenderQueue { get; }

		RefreshRenderQueueCb RefreshRenderQueue { get; set; }

		void Reset();

		int depth { get; set; }

		float alpha { get; set; }
	}
}
