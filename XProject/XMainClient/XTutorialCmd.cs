using System;
using System.Collections.Generic;
using UnityEngine;

namespace XMainClient
{
	// Token: 0x02000DFF RID: 3583
	internal class XTutorialCmd
	{
		// Token: 0x040051D9 RID: 20953
		public int TutorialID;

		// Token: 0x040051DA RID: 20954
		public int step;

		// Token: 0x040051DB RID: 20955
		public string tag;

		// Token: 0x040051DC RID: 20956
		public int mainTutorialBit;

		// Token: 0x040051DD RID: 20957
		public List<XTutorialCmdExecuteCondition> conditions;

		// Token: 0x040051DE RID: 20958
		public List<string> condParams;

		// Token: 0x040051DF RID: 20959
		public XTutorialCmdFinishCondition endcondition;

		// Token: 0x040051E0 RID: 20960
		public List<string> endParam;

		// Token: 0x040051E1 RID: 20961
		public string cmd;

		// Token: 0x040051E2 RID: 20962
		public string param1;

		// Token: 0x040051E3 RID: 20963
		public string param2;

		// Token: 0x040051E4 RID: 20964
		public string param3;

		// Token: 0x040051E5 RID: 20965
		public string param4;

		// Token: 0x040051E6 RID: 20966
		public string param5;

		// Token: 0x040051E7 RID: 20967
		public string param6;

		// Token: 0x040051E8 RID: 20968
		public XCmdState state;

		// Token: 0x040051E9 RID: 20969
		public string text;

		// Token: 0x040051EA RID: 20970
		public Vector3 textPos;

		// Token: 0x040051EB RID: 20971
		public bool pause;

		// Token: 0x040051EC RID: 20972
		public float interalDelay;

		// Token: 0x040051ED RID: 20973
		public string ailinText;

		// Token: 0x040051EE RID: 20974
		public int ailinPos;

		// Token: 0x040051EF RID: 20975
		public string ailinText2;

		// Token: 0x040051F0 RID: 20976
		public string buttomtext;

		// Token: 0x040051F1 RID: 20977
		public string audio;

		// Token: 0x040051F2 RID: 20978
		public string scroll;

		// Token: 0x040051F3 RID: 20979
		public int scrollPos;

		// Token: 0x040051F4 RID: 20980
		public string skipCondition;

		// Token: 0x040051F5 RID: 20981
		public string skipParam1;

		// Token: 0x040051F6 RID: 20982
		public string skipParam2;

		// Token: 0x040051F7 RID: 20983
		public string skipParam3;

		// Token: 0x040051F8 RID: 20984
		public string function;

		// Token: 0x040051F9 RID: 20985
		public string functionparam1;

		// Token: 0x040051FA RID: 20986
		public bool bLastCmdInQueue;

		// Token: 0x040051FB RID: 20987
		public bool isOutError;

		// Token: 0x040051FC RID: 20988
		public bool isCanDestroyOverlay;
	}
}
