
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BugType
{
	lvl0,
	lvl1,
	lvl2
}


public class Bug
//: MonoBehaviour
{
	public BugType type { get; private set; }

}
