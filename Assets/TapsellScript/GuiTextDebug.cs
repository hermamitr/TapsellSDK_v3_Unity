﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class GuiTextDebug : MonoBehaviour {
 
    private float windowPosition = -440.0f;
    private int positionCheck = 2;
    private static string windowText = "";
    private Vector2 scrollViewVector = Vector2.zero;
    private GUIStyle debugBoxStyle;
   
    private float leftSide = 0.0f;
    private float debugWidth = 2000.0f;
   
    public bool debugIsOn = false;
   
    public static void debug(string newString)
    {
		//if(newString.Contains("Ad"))
		{
			int logsize = 60;
			if(newString.Length>logsize)
			{
				for (int i=newString.Length/logsize-1;i>=0;i--)
				{
					int start = i * logsize;
					int end = (i + 1) * logsize;
					end = (end > newString.Length) ? newString.Length : end;
					windowText = newString.Substring(start,end-start) + "\n" + windowText;
				}
				UnityEngine.Debug.Log(newString);
			}
			else{
				windowText = newString + "\n" + windowText;
				UnityEngine.Debug.Log(newString);
			}
		}
    }
       
    void Start () {
        debugBoxStyle = new GUIStyle();
        debugBoxStyle.alignment = TextAnchor.UpperLeft;
        leftSide = 120; //Screen.width - debugWidth - 3;
    }
       
   
    void OnGUI () {
       
        if (debugIsOn) {
 
            GUI.depth = 0;
                       
            GUI.BeginGroup (new Rect(windowPosition, 40.0f, 2000f, 2000.0f));
           
                scrollViewVector = GUI.BeginScrollView (new Rect (0, 0.0f, debugWidth, 2000.0f), scrollViewVector, new Rect (0.0f, 0.0f, 400.0f, 2000.0f));
                GUI.Box (new Rect(0, 0.0f, debugWidth - 20.0f, 2000.0f), windowText, debugBoxStyle);
                GUI.EndScrollView();
           
            GUI.EndGroup ();
           
           
   
            if (GUI.Button(new Rect (leftSide, 0.0f,75.0f,40.0f), "Debug")){
                if (positionCheck == 1){
                    windowPosition = -440.0f;
                    positionCheck = 2;
                }
                else {
                    windowPosition = leftSide;
                    positionCheck = 1;
                }
            }
           
            if (GUI.Button(new Rect (leftSide + 80f,0.0f,75.0f,40.0f),"Clear")){
                windowText = "";
            }
        }
    }
 
 
}