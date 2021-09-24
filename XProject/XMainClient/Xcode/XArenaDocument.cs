using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XArenaDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XArenaDocument.uuID;
			}
		}

		public bool RedPoint { get; set; }

		public static void Execute(OnLoadedCallback callback = null)
		{
			XArenaDocument.AsyncLoader.AddTask("Table/SkillCombo", XArenaDocument.SkillComboTable, false);
			XArenaDocument.AsyncLoader.Execute(callback);
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("ArenaDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		public static SkillCombo SkillComboTable = new SkillCombo();
	}
}
