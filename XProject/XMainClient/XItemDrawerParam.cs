using System;
using UnityEngine;

namespace XMainClient
{

	internal class XItemDrawerParam
	{

		public void Reset()
		{
			this.Profession = XItemDrawerParam.DefaultProfession;
			this.IconType = 0U;
			this.bShowLevelReq = true;
			this.bShowProfReq = true;
			this.bBinding = false;
			this.MaxItemCount = -1;
			this.NumColor = null;
			this.bHideBinding = false;
			this.bShowMask = false;
			this.MaxShowNum = -1;
		}

		public static uint DefaultProfession = 0U;

		public uint Profession = 0U;

		public uint IconType = 0U;

		public bool bShowLevelReq = true;

		public bool bShowProfReq = true;

		public bool bBinding = false;

		public int MaxItemCount = -1;

		public Color? NumColor = null;

		public bool bHideBinding;

		public bool bShowMask;

		public int MaxShowNum = -1;
	}
}
