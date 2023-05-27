using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelToggler : MonoBehaviour
{
      bool isOn = false;
      [SerializeField] GameObject InformationPanel;
      [SerializeField] GameObject TaskCanvas;

      public void Start(){
         InformationPanel.SetActive(true);
      }

      public void togglePanel(){
        if(isOn){
            Debug.Log(isOn);
            InformationPanel.SetActive(false);
            TaskCanvas.SetActive(true);
            isOn = false;
        }else{
              Debug.Log(isOn);
            InformationPanel.SetActive(true);
            TaskCanvas.SetActive(false);
            isOn = true;
        }
      }
}
