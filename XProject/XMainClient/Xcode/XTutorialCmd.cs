using System;
using System.Collections.Generic;
using UnityEngine;

namespace XMainClient
{

	internal class XTutorialCmd
	{

		public int TutorialID;

		public int step;

		public string tag;

		public int mainTutorialBit;

		public List<XTutorialCmdExecuteCondition> conditions;

		public List<string> condParams;

		public XTutorialCmdFinishCondition endcondition;

		public List<string> endParam;

		public string cmd;

		public string param1;

		public string param2;

		public string param3;

		public string param4;

		public string param5;

		public string param6;

		public XCmdState state;

		public string text;

		public Vector3 textPos;

		public bool pause;

		public float interalDelay;

		public string ailinText;

		public int ailinPos;

		public string ailinText2;

		public string buttomtext;

		public string audio;

		public string scroll;

		public int scrollPos;

		public string skipCondition;

		public string skipParam1;

		public string skipParam2;

		public string skipParam3;

		public string function;

		public string functionparam1;

		public bool bLastCmdInQueue;

		public bool isOutError;

		public bool isCanDestroyOverlay;
	}
}
