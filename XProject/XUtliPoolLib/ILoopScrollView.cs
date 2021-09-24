using System;
using System.Collections.Generic;
using UnityEngine;

namespace XUtliPoolLib
{

	public interface ILoopScrollView
	{

		void Init(List<LoopItemData> datas, DelegateHandler onItemInitCallback, Action onDragfinish, int pivot = 0, bool forceRefreshPerTime = false);

		GameObject GetTpl();

		GameObject gameobject { get; }

		bool IsScrollLast();

		void ResetScroll();

		void SetDepth(int delpth);

		GameObject GetFirstItem();

		GameObject GetLastItem();

		void AddItem(LoopItemData data);

		void SetClipSize(Vector2 size);
	}
}
