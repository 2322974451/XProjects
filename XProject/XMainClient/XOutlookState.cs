using System;
using KKSG;

namespace XMainClient
{

	internal class XOutlookState
	{

		public bool bMounted
		{
			get
			{
				return this.type == OutLookStateType.OutLook_RidePet || this.type == OutLookStateType.OutLook_RidePetCopilot;
			}
		}

		public bool bDancing
		{
			get
			{
				return this.type == OutLookStateType.OutLook_Dance;
			}
		}

		public OutLookStateType type;

		public uint param;

		public ulong paramother;
	}
}
